using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidworksWPFDemo.Library
{
    public class DLW5BS : ILibrary
    {
        public string DisplayName => "DLW5BS";

        public double HeightIncrementor => 0.00275;

        public int LocationXMin => 8;

        public int LocationYMin => 8;

        public int RecomendedX => 35;

        public int RecomendedY => 43;

        public int TModeMin => -25;

        public int TModeMax => 85;
    }
}
