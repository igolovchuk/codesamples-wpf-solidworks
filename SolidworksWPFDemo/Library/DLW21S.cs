using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidworksWPFDemo.Library
{
    public class DLW21S : ILibrary
    {
        public string DisplayName => "DLW21S";

        public double HeightIncrementor => 0.0007;

        public int LocationXMin => 7;

        public int LocationYMin => 7;

        public int RecomendedX => 12;

        public int RecomendedY => 28;

        public int TModeMin => -40;

        public int TModeMax => 85;
    }
}
