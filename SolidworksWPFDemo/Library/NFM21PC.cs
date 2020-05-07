using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidworksWPFDemo.Library
{
    public class NFM21PC : ILibrary
    {

        public string DisplayName => "NFM21PC";

        public double HeightIncrementor => 0.000445;

        public int LocationXMin => 7;

        public int LocationYMin => 7;

        public int RecomendedX => 49;

        public int RecomendedY => 23;

        public int TModeMin => -55;

        public int TModeMax => 125;
    }
}
