using System.Diagnostics;
using StarGen;

namespace BarrycenterGen
{
    class Barrycenter
    {
        public void generateBarrycenter(List<Star> BarrycenterStars)
        {
            Star newStar = new Star(false, false);
            List<Star> barrycenterStars = BarrycenterStars;
            if (barrycenterStars.Count == 0)
            {
                newStar.generateStar();
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
                        newStar.generateStar();
                        barrycenterStars.Add(newStar);
                    }
                }
            }
            if (barrycenterStars.Count > 2)
            {
                Star starNodeB = barrycenterStars[0];
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
                Barrycenter barrycenterNode = new Barrycenter();
                barrycenterNode.generateBarrycenter(barrycenterStars);
            }
            else if (barrycenterStars.Count == 2)
            {
                Star starNodeA = barrycenterStars[0];
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
                Star starNodeB = barrycenterStars[0];
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