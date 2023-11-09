using System.ComponentModel;
using System.Diagnostics;
using StarGen;

namespace Program
{
    public class StarSystemGenerator
    {
        static void Main(string[] args)
        {
            Star star = new Star(isBinary: false);
            star.generateStar();
        }
    }
}