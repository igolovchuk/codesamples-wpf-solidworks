using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidworksWPFDemo.Library
{
    public class MT47H64M16HR : ILibrary
    {

        public string DisplayName => "MT47H64M16HR";

        public double HeightIncrementor => 0.00055;

        public int LocationXMin => 8;

        public int LocationYMin => 12;

        public int RecomendedX => 8;

        public int RecomendedY => 12;

        public int TModeMin => -55;

        public int TModeMax => 150;
    }
}
