using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidworksWPFDemo.Library
{
    public class C0402 : ILibrary
    {
        public string DisplayName => "C0402";

        public double HeightIncrementor => 0.00027;

        public int LocationXMin => 7;

        public int LocationYMin => 7;

        public int RecomendedX => 19;

        public int RecomendedY => 28;

        public int TModeMin => -55;

        public int TModeMax => 125;
    }
}
