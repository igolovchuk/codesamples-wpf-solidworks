using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidworksWPFDemo.Library
{
    public class TMS360DM368 : ILibrary
    {

        public string DisplayName => "TMS360DM368";

        public double HeightIncrementor => 0.000635;

        public int LocationXMin => 13;

        public int LocationYMin => 13;

        public int RecomendedX => 13;

        public int RecomendedY => 13;

        public int TModeMin => 0;

        public int TModeMax => 70;
    }
}
