using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerAtteck
{
    public  class Missile
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public int Mass { get; set; }
        public Dictionary<string, double> Origin { get; set; }
        public Dictionary<string, double> Angle { get; set; }
        public double Time { get; set; }
        public Missile(string name, int speed, int mass, Dictionary<string, double> origin, Dictionary<string, double> angle, double time)
        {
            Name = name;
            Speed = speed;
            Mass = mass;
            Origin = origin;
            Angle = angle;
            Time = time;
        }
    }
    
    
}
