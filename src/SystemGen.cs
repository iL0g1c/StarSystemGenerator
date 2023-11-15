using System.Diagnostics;
using BarrycenterGen;
using StarGen;

namespace SystemGen
{
    class _System
    {
        public Barrycenter barrycenter;
        public _System()
        {
            barrycenter = new Barrycenter(new List<Star>());
        }
    }
}