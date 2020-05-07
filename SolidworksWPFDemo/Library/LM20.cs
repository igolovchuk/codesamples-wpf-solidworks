using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidworksWPFDemo.Library
{
    public class LM20 : ILibrary
    {

        public string DisplayName => "LM20";

        public double HeightIncrementor => 0.000555;

        public int LocationXMin => 8;

        public int LocationYMin => 7;

        public int RecomendedX => 62;

        public int RecomendedY => 26;

        public int TModeMin => -55;

        public int TModeMax => 130;
    }
}
