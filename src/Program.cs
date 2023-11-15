using System.ComponentModel;
using System.Diagnostics;
using BarrycenterGen;
using StarGen;
using RandomRoll;
using System.Collections;

namespace Program
{
    public class StarSystemGenerator
    {
        static void Main(string[] args)
        {
            RandomRoll.GetRandomRoll dice = new RandomRoll.GetRandomRoll();
            for (int i = 0; i < 50; i++)
            {
            Barrycenter newBarrycenter = new Barrycenter();
            Debug.WriteLine($"Star System {i+1}\n");
            newBarrycenter.generateBarrycenter(new List<Star>());
            //Debug.WriteLine(dice.getRandomRoll(1,10));

            }
        }
    }
}