using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidworksWPFDemo.Library
{
    public interface ILibrary
    {
         string DisplayName { get; }

         double HeightIncrementor { get; }

         int LocationXMin { get; }

         int LocationYMin { get; }

         int RecomendedX { get; }

         int RecomendedY { get; }

         int TModeMin { get; }

         int TModeMax { get; }
    }
}
