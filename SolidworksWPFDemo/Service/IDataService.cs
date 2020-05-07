using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidworksWPFDemo.Library;

namespace SolidworksWPFDemo.Service
{
    public interface IDataService
    {
        void didLocateElement(ILibrary selectedItem, Helpers.Action action, int coordinatorX, int coordinatorY,
            string textboxHeight);

        void didPrepareEnvironment(string textboxHeight, string textboxWidth, string textboxLenght);

        string didSetCoordinate(int minX, int minY, int maxX, int maxY);

        void didBuildModel();

        void didLoadPcb();
    }
}
