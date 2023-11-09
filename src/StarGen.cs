using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace StarGen
{
    public class Star
    {
        public enum BasicType
        {
            A,
            F,
            G,
            K,
            WhiteDwarf,
            M,
            BrownDwarf,
            Subgiant,
            Giant,
            Special
        }
        public BasicType BasicStarType;
        public int SizeCode;
        public int SpectralClass;

        public Star(bool isBinary, string? rawBasicStarType = null, int? sizeCode = null, int? spectralClass = null)
        {
            if (isBinary)
            {
                if (rawBasicStarType == null || sizeCode == null || spectralClass == null)
                {
                    throw new ArgumentException("Star is a binary but some parameters are not provided.");
                }
                BasicStarType = (BasicType)Enum.Parse(typeof(BasicType), rawBasicStarType);
                SizeCode =  sizeCode ?? default(int);
                SpectralClass = spectralClass ?? default(int);
            }
        }

        public void generateStar()
        {
            // Get Star type
            RandomRoll.GetRandomRoll dice = new RandomRoll.GetRandomRoll();
            int starTypeRoll = dice.getRandomRoll(1, 100);
            int specificationRoll;

            switch (starTypeRoll)
            {
                case 1:
                    specificationRoll = dice.getRandomRoll(1, 10);
                    if (specificationRoll >= 7)
                    {
                        BasicStarType = BasicType.Subgiant;
                        SizeCode = 4;
                    }
                    else
                    {
                        BasicStarType = BasicType.A;
                        SizeCode = 5;
                    }
                    break;
                case >= 2 and <= 4:
                    specificationRoll = dice.getRandomRoll(1, 10);
                    if (specificationRoll >= 9)
                    {
                        BasicStarType = BasicType.Subgiant;
                        SizeCode = 4;
                    }
                    else
                    {
                        BasicStarType = BasicType.F;
                        SizeCode = 5;
                    }
                    break;
                case >= 5 and <= 12:
                    specificationRoll = dice.getRandomRoll(1, 10);
                    if (specificationRoll == 10)
                    {
                        BasicStarType = BasicType.Subgiant;
                        SizeCode = 4;
                    }
                    else
                    {
                        BasicStarType = BasicType.G;
                        SizeCode = 5;
                    }
                    break;
                case >= 13 and <= 26:
                    BasicStarType = BasicType.K;
                    break;
                case >= 27 and <= 36:
                    BasicStarType = BasicType.WhiteDwarf;
                    break;
                case >= 37 and <= 85:
                    BasicStarType = BasicType.M;
                    break;
                case >= 86 and <= 98:
                    BasicStarType = BasicType.BrownDwarf;
                    break;
                case 99:
                    specificationRoll = dice.getRandomRoll(1, 10);
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
                    break;
                case 100:
                    BasicStarType = BasicType.Special;
                    break;
            }

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

        private void getStarData()
        {

        }
    }
}