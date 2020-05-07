using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidworksWPFDemo.Library
{
    public class LMZ12003TZ : ILibrary
    {

        public string DisplayName => "LMZ12003TZ";

        public double HeightIncrementor => 0.002335;

        public int LocationXMin => 13;

        public int LocationYMin => 11;

        public int RecomendedX => 36;

        public int RecomendedY => 34;

        public int TModeMin => -40;

        public int TModeMax => 125;
    }
}
