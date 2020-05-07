using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidworksWPFDemo.Library
{
    public class S558_599_U7_F : ILibrary
    {

        public string DisplayName => "S558-599-U7-F";

        public double HeightIncrementor => 0.002935;

        public int LocationXMin => 11;

        public int LocationYMin => 12;

        public int RecomendedX => 101;

        public int RecomendedY => 58;

        public int TModeMin => -20;

        public int TModeMax => 110;
    }
}
