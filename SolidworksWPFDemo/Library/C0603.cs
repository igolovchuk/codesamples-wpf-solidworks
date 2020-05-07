using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidworksWPFDemo.Library
{
    public class C0603 : ILibrary
    {
        public string DisplayName => "C0603";

        public double HeightIncrementor => 0.00042;

        public int LocationXMin => 7;

        public int LocationYMin => 7;

        public int RecomendedX => 49;

        public int RecomendedY => 12;

        public int TModeMin => -55;

        public int TModeMax => 125;
    }
}
