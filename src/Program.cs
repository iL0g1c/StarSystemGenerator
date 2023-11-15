using System.ComponentModel;
using System.Diagnostics;
using System.Collections;

using DataTools;
using StarGen;
using SystemGen;

namespace Program
{
    public class StarSystemGenerator
    {
        static void Main(string[] args)
        {
            List<_System> systems = new List<_System>();
            for (int i = 0; i < 50; i++)
            {
                Debug.WriteLine("Star System " + i);
                _System system = new _System();
                systems.Add(system);
            }
            Debug.WriteLine(systems[0].barrycenter.starNodeB.SizeCode);
            Loader loader = new Loader();
            loader.saveSystemJson(systems);
        }
    }
}