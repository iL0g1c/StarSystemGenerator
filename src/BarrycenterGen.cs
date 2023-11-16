using System.Diagnostics;
using StarGen;

namespace BarrycenterGen
{
    class Barrycenter
    {

        public Star? starNodeA {get; private set;}
        public Star starNodeB {get; private set;}
        public Barrycenter? barrycenterNode {get; private set;}
        public Barrycenter(List<Star> barrycenterStars)
        {
            Star newStar = new Star(false, false);   
            if (barrycenterStars.Count == 0)
            {
                barrycenterStars.Add(newStar);
            }
            if (barrycenterStars.Last().nextIsBinary)
            {
                while (true)
                {
                    if (!newStar.nextIsBinary)
                    {
                        break;
                    }
                    else
                    {
                        newStar = new Star(
                            isBinary: newStar.nextIsBinary,
                            isSame: newStar.nextIsSame,
                            basicStarType: newStar.BasicStarType,
                            sizeCode: newStar.SizeCode,
                            spectralClass: newStar.SpectralClass
                        );
                        barrycenterStars.Add(newStar);
                    }
                }
            }
            if (barrycenterStars.Count > 2)
            {
                starNodeB = barrycenterStars[0];
                Debug.WriteLine(
                    "Basic Type: " + barrycenterStars[0].BasicStarType + "\n" +
                    "Spectral Class: " + barrycenterStars[0].SpectralClass + "\n" +
                    "Luminosity: " + barrycenterStars[0].luminosity + "\n" +
                    "Mass: " + barrycenterStars[0].mass + "\n" +
                    "Surface Temperature: " + barrycenterStars[0].surfaceTemperature + "\n" +
                    "Radius: " + barrycenterStars[0].radius + "\n" +
                    "=======================\n"
                );
                barrycenterStars.RemoveAt(0);
                barrycenterNode = new Barrycenter(barrycenterStars);
                //barrycenterNode.generateBarrycenter(barrycenterStars);
            }
            else if (barrycenterStars.Count == 2)
            {
                starNodeB = barrycenterStars[0];
                Debug.WriteLine(
                    "Basic Type: " + barrycenterStars[0].BasicStarType + "\n" +
                    "Spectral Class: " + barrycenterStars[0].SpectralClass + "\n" +
                    "Luminosity: " + barrycenterStars[0].luminosity + "\n" +
                    "Mass: " + barrycenterStars[0].mass + "\n" +
                    "Surface Temperature: " + barrycenterStars[0].surfaceTemperature + "\n" +
                    "Radius: " + barrycenterStars[0].radius + "\n" +
                    "=======================\n"
                );
                barrycenterStars.RemoveAt(0);
                starNodeA = barrycenterStars[0];
                Debug.WriteLine(
                    "Basic Type: " + barrycenterStars[0].BasicStarType + "\n" +
                    "Spectral Class: " + barrycenterStars[0].SpectralClass + "\n" +
                    "Luminosity: " + barrycenterStars[0].luminosity + "\n" +
                    "Mass: " + barrycenterStars[0].mass + "\n" +
                    "Surface Temperature: " + barrycenterStars[0].surfaceTemperature + "\n" +
                    "Radius: " + barrycenterStars[0].radius + "\n" +
                    "=======================\n"
                );
                barrycenterStars.RemoveAt(0);
            } else
            {
                starNodeB = barrycenterStars[0];
                Debug.WriteLine(
                    "Basic Type: " + barrycenterStars[0].BasicStarType + "\n" +
                    "Spectral Class: " + barrycenterStars[0].SpectralClass + "\n" +
                    "Luminosity: " + barrycenterStars[0].luminosity + "\n" +
                    "Mass: " + barrycenterStars[0].mass + "\n" +
                    "Surface Temperature: " + barrycenterStars[0].surfaceTemperature + "\n" +
                    "Radius: " + barrycenterStars[0].radius + "\n" +
                    "=======================\n"
                );
            }
        }
    }
}