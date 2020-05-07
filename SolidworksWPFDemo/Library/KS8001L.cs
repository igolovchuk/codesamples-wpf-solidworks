using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidworksWPFDemo.Library
{
    public class KS8001L : ILibrary
    {

        public string DisplayName => "KS8001L";

        public double HeightIncrementor => 0.00076;

        public int LocationXMin => 11;

        public int LocationYMin => 11;

        public int RecomendedX => 84;

        public int RecomendedY => 46;

        public int TModeMin => 0;

        public int TModeMax => 70;
    }
}
