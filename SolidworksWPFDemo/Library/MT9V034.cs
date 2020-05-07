using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidworksWPFDemo.Library
{
    public class MT9V034 : ILibrary
    {

        public string DisplayName => "MT9V034";

        public double HeightIncrementor => 0.00111;

        public int LocationXMin => 12;

        public int LocationYMin => 12;

        public int RecomendedX => 60;

        public int RecomendedY => 44;

        public int TModeMin => -30;

        public int TModeMax => 70;
    }
}
