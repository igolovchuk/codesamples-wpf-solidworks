using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidworksWPFDemo.Library
{
    public class R0402 : ILibrary
    {

        public string DisplayName => "R0402";

        public double HeightIncrementor => 0.0002;

        public int LocationXMin => 7;

        public int LocationYMin => 7;

        public int RecomendedX => 24;

        public int RecomendedY => 31;

        public int TModeMin => -55;

        public int TModeMax => 155;
    }
}
