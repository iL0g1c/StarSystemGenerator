using System.ComponentModel;
using System.Diagnostics;
using StarGen;

namespace Program
{
    public class StarSystemGenerator
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 50; i++)
            {
                Star star = new Star(isBinary: false);
                star.generateStar();
                Debug.WriteLine(
                    "Basic Type: " + star.BasicStarType + "\n" +
                    "Spectral Class: " + star.SpectralClass + "\n" +
                    "Luminosity: " + star.luminosity + "\n" +
                    "Mass: " + star.mass + "\n" +
                    "Surface Temperature: " + star.surfaceTemperature + "\n" +
                    "Radius: " + star.radius + "\n" +
                    "=======================\n"
                );
            }
        }
    }
}