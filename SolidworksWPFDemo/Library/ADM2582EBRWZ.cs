using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidworksWPFDemo.Library
{
    public class ADM2582EBRWZ : ILibrary
    {

        public string DisplayName => "ADM2582EBRWZ";

        public double HeightIncrementor => 0.00131;

        public int LocationXMin => 12;

        public int LocationYMin => 13;

        public int RecomendedX => 12;

        public int RecomendedY => 19;

        public int TModeMin => -40;

        public int TModeMax => 85;
    }
}
