using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidworksWPFDemo.Library
{
    public class TRS3221ECPWR : ILibrary
    {

        public string DisplayName => "TRS3221ECPWR";

        public double HeightIncrementor => 0.000665;

        public int LocationXMin => 12;

        public int LocationYMin => 9;

        public int RecomendedX => 12;

        public int RecomendedY => 9;

        public int TModeMin => -40;

        public int TModeMax => 85;
    }
}
