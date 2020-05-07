using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidworksWPFDemo.Library
{
    public class ASVMP : ILibrary
    {

        public string DisplayName => "ASVMP";

        public double HeightIncrementor => 0.000435;

        public int LocationXMin => 9;

        public int LocationYMin => 10;

        public int RecomendedX => 68;

        public int RecomendedY => 60;

        public int TModeMin => -40;

        public int TModeMax => 85;
    }
}
