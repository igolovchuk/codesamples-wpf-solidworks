using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidworksWPFDemo.Library
{
    public class SN74LVC1G08DCK : ILibrary
    {

        public string DisplayName => "SN74LVC1G08DCK";

        public double HeightIncrementor => 0.000605;

        public int LocationXMin => 7;

        public int LocationYMin => 7;

        public int RecomendedX => 7;

        public int RecomendedY => 7;

        public int TModeMin => -40;

        public int TModeMax => 85;
    }
}
