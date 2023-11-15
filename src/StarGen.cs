using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Markup;
using CsvHelper;
using DataTools;

namespace StarGen
{
    public class Star
    {
        public enum BasicType
        {
            B,
            A,
            F,
            G,
            K,
            WhiteDwarf,
            M,
            BrownDwarf,
            Special
        }
        public BasicType BasicStarType {get; set;}
        public int SizeCode {get; set;}
        public int SpectralClass {get; set;}
        public float luminosity {get; set;}
        public float mass {get; set;}
        public float surfaceTemperature {get; set;}
        public float radius {get; set;}
        public bool isBinary;
        private bool isSame;
        public bool nextIsBinary;
        public bool nextIsSame;
        public Star(bool isBinary, bool isSame, BasicType? basicStarType = null, int? sizeCode = null, int? spectralClass = null)
        {
            if (isBinary && isSame)
            {
                BasicStarType = basicStarType ?? default(BasicType);
                SizeCode =  sizeCode ?? default(int);
                SpectralClass = spectralClass ?? default(int);
            }
            else if (isBinary && !isSame)
            {
                basicStarType = basicStarType ?? default(BasicType);
            }
        }

        public void generateStar()
        {
            RandomRoll.GetRandomRoll dice = new RandomRoll.GetRandomRoll();
            // Get Star type
            if (!isSame)
            {
                int starTypeRoll = dice.getRandomRoll(1, 100);
                int specificationRoll;

                switch (starTypeRoll)
                {
                    case 1:
                        specificationRoll = dice.getRandomRoll(1, 10);
                        if (specificationRoll >= 7)
                        {
                            SizeCode = 4;
                        }
                        else
                        {
                            SizeCode = 5;
                        }

                        if (isBinary && !isSame)
                        {
                            BasicStarType = BasicType.A;
                        }
                        else
                        {
                            BasicStarType = BasicType.A;
                        }
                        break;
                    case >= 2 and <= 4:
                        specificationRoll = dice.getRandomRoll(1, 10);
    
                        if (specificationRoll >= 9)
                        {
                            SizeCode = 4;
                        }
                        else
                        {
                            SizeCode = 5;
                        }

                        if (isBinary && !isSame)
                        {
                            if (BasicStarType == BasicType.A)
                            {
                                BasicStarType = BasicType.BrownDwarf;
                                SizeCode = 0;
                            }
                            else
                            {
                                BasicStarType = BasicType.F;
                            }
                        }
                        else
                        {
                            BasicStarType = BasicType.F;
                        }
                        break;
                    case >= 5 and <= 12:
                        specificationRoll = dice.getRandomRoll(1, 10);
                        if (specificationRoll == 10)
                        {
                            SizeCode = 4;
                        }
                        else
                        {
                            SizeCode = 5;
                        }

                        if (isBinary && !isSame)
                        {
                            if (new[] {BasicType.A, BasicType.F}.Contains(BasicStarType))
                            {
                                BasicStarType = BasicType.BrownDwarf;
                                SizeCode = 0;
                            }
                            else
                            {
                                BasicStarType = BasicType.G;
                            }
                        }
                        else
                        {
                        BasicStarType = BasicType.G;
                        }
                        break;
                    case >= 13 and <= 26:
                        if (isBinary && !isSame)
                        {
                            if (new[] {BasicType.A, BasicType.F, BasicType.G}.Contains(BasicStarType))
                            {
                                BasicStarType = BasicType.BrownDwarf;
                                SizeCode = 0;
                            }
                            else
                            {
                                BasicStarType = BasicType.K;
                            }
                        }
                        else
                        {
                        BasicStarType = BasicType.K;
                        }
                        SizeCode = 5;
                        break;
                    case >= 27 and <= 36:
                        BasicStarType = BasicType.WhiteDwarf;
                        SizeCode = 7;
                        break;
                    case >= 37 and <= 85:
                        if (isBinary && !isSame)
                        {
                            if (new[] {
                                BasicType.A,
                                BasicType.F,
                                BasicType.G,
                                BasicType.K
                            }.Contains(BasicStarType))
                            {
                                BasicStarType = BasicType.BrownDwarf;
                                SizeCode = 0;
                            }
                            else
                            {
                                BasicStarType = BasicType.M;
                            }
                        }
                        else
                        {
                            BasicStarType = BasicType.M;
                        }
                        SizeCode = 5;
                        break;
                    case >= 86 and <= 98:
                        BasicStarType = BasicType.BrownDwarf;
                        SizeCode = 0;
                        break;
                    case 99:
                        specificationRoll = dice.getRandomRoll(1, 10);
                        if (isBinary && !isSame)
                        {
                            BasicStarType = BasicType.BrownDwarf;
                            SizeCode = 0;
                        }
                        else
                        {
                            SizeCode = 3;
                            switch (specificationRoll)
                            {
                                case 1:
                                    BasicStarType = BasicType.F;
                                    break;

                                case 2:
                                    BasicStarType = BasicType.G;
                                    break;
                                
                                case >= 3 and <= 7:
                                    BasicStarType = BasicType.K;
                                    break;
                                
                                case >= 8:
                                    BasicStarType = BasicType.K;
                                    SizeCode = 4;
                                    break;

                            }
                        }
                        break;
                    case 100:
                        BasicStarType = BasicType.Special;
                        break;
                }
            }
            if (isBinary && isSame)
            {
                int spectralClassResult = dice.getRandomRoll(1,9);
                if (spectralClassResult < SpectralClass)
                {
                    spectralClassResult = SpectralClass;
                }
            }
            else
            {
                // Get Star Spectral Class
                if (BasicStarType == BasicType.K && SizeCode == 4)
                {
                    SpectralClass = 0;
                }
                else
                {
                    int spectralClassResult = dice.getRandomRoll(1,9);
                    SpectralClass = spectralClassResult - 1;
                }
            }

            int binaryCheckRoll = dice.getRandomRoll(1,10);
            if (binaryCheckRoll >= 7)
            {
                int binaryRoll = dice.getRandomRoll(1,10);
                if (binaryRoll == 1 || binaryRoll == 2)
                {
                    nextIsBinary = true;
                    nextIsSame = true;
                }
                else if (binaryRoll >= 3)
                {
                    nextIsBinary = true;
                    nextIsSame = false;
                }
            }

            // Apply Star Stat modifiers
            float[] starData = getStarNumberData();
            if (BasicStarType == BasicType.BrownDwarf || BasicStarType == BasicType.WhiteDwarf)
            {
                mass = starData[1];
                surfaceTemperature = starData[2];
                radius = starData[3];
                luminosity = calculateDwarfLuminosity();
            } else if (SizeCode == 3 || SizeCode == 4)
            {
                float[] starModifiers = getStarStatModifierData();
                luminosity = starData[0] * starModifiers[0];
                mass = starData[1] * starModifiers[1];
                surfaceTemperature = starData[2] * starModifiers[2];
                radius = calculateGiantRadius();
            }
            else
            {
                luminosity = starData[0];
                mass = starData[1];
                surfaceTemperature = starData[2];
                radius = starData[3];
            }
        }

        private float calculateDwarfLuminosity()
        {
            float a = (float)Math.Pow(radius, 2);
            float b = (float)Math.Pow(surfaceTemperature, 4);
            float c = (float)Math.Pow(5800,4);
            return a * b / c;
        }

        private float calculateGiantRadius()
        {
            float a = 5800 / surfaceTemperature;
            float b = (float)Math.Pow(luminosity, 0.5f);
            return b * (float)Math.Pow(a, 2);
        }

        private float[] getStarStatModifierData()
        {
            int row = 0;

            RandomRoll.GetRandomRoll dice = new RandomRoll.GetRandomRoll();
            Loader starStatModifiers = new Loader();
            string[,] starStatModifiersData = starStatModifiers.loadCsvTable("starStatModifers.csv");
            float[] parsedStarStatData = new float[4];

            switch (SizeCode)
            {
                case 3:
                    row = 0;

                    int starModifierIndex = dice.getRandomRoll(1,10);
                    string starModifierData = starStatModifiersData[row,starModifierIndex];

                    string[] values = starModifierData.Split("/");
                    parsedStarStatData[1] = Convert.ToSingle(values[0]);
                    parsedStarStatData[0] = Convert.ToSingle(values[1]);
                    parsedStarStatData[2] = Convert.ToSingle(1.0f);
                    parsedStarStatData[3] = Convert.ToSingle(calculateGiantRadius());
                    break;
                case 4:
                    row = 1;

                    int starMassRadiusIndex = dice.getRandomRoll(1, 10);
                    string massRadiusData = starStatModifiersData[row,starMassRadiusIndex];

                    values = massRadiusData.Split("/");
                    parsedStarStatData[1] = Convert.ToSingle(values[0]);
                    parsedStarStatData[0] = Convert.ToSingle(values[1]);
                    parsedStarStatData[2] = Convert.ToSingle(1.0f);
                    parsedStarStatData[3] = Convert.ToSingle(calculateGiantRadius());
                    break;
            }
            return parsedStarStatData;
        }
        private float[] getStarNumberData()
        {
            int row = 0;
            switch (BasicStarType)
            {
                case BasicType.B:
                    switch (SizeCode)
                    {
                        case 5:
                            row = 0;
                            break;
                        default:
                            throw new ArgumentException("Type is B but sizecode is not 5.");
                    }
                    break;
                case BasicType.A:
                    switch (SizeCode)
                    {
                        case 5:
                            row = 1;
                            break;
                        case 4:
                            row = 6;
                            break;
                        case 3:
                            row = 10;
                            break;

                    }
                    break;
                case BasicType.F:
                    switch (SizeCode)
                    {
                        case 5:
                            row = 2;
                            break;
                        case 4:
                            row = 7;
                            break;
                        case 3:
                            row = 11;
                            break;
                    }
                    break;
                case BasicType.G:
                    switch (SizeCode)
                    {
                        case 5:
                            row = 3;
                            break;
                        case 4:
                            row = 8;
                            break;
                        case 3:
                            row = 12;
                            break;
                    }
                    break;
                case BasicType.K:
                    switch (SizeCode)
                    {
                        case 5:
                            row = 4;
                            break;
                        case 4:
                            row = 9;
                            break;
                        case 3:
                            row = 13;
                            break;
                    }
                    break;
                case BasicType.M:
                    switch (SizeCode)
                    {
                        case 5:
                            row = 5;
                            break;
                        case 3:
                            row = 14;
                            break;
                        default:
                            throw new ArgumentException("Type is M but sizecode is not 5 or 3.");
                    }
                    break;
                case BasicType.BrownDwarf:
                    row = 15;
                    break;
                case BasicType.WhiteDwarf:
                    row = 16;
                    break;
            }
            Loader starNumberTypes = new Loader();
            string[,] starNumberTypeData = starNumberTypes.loadCsvTable("starNumberType.csv");
            string starDataPoint = starNumberTypeData[row,SpectralClass];
            
            string[] values = starDataPoint.Split("/");

            float[] starDataParsed = new float[4];
            if (values[0] == "")
            {
                starDataParsed[0] = 0.0f;
            }
            else
            {
                starDataParsed[0] = Convert.ToSingle(values[0]); 
            }
            starDataParsed[1] = Convert.ToSingle(values[1]);
            starDataParsed[2] = Convert.ToSingle(values[2]);
            starDataParsed[3] = Convert.ToSingle(values[3]);
            return starDataParsed;
        }
    }
}