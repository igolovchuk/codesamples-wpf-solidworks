using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidworksWPFDemo.Helpers;
using SolidworksWPFDemo.Library;
using SolidworksWPFDemo.Pages.ViewModels;
using SolidWorks.Interop.sldworks;
using Action = SolidworksWPFDemo.Helpers.Action;

namespace SolidworksWPFDemo.Service
{
    public class DataService : IDataService
    {
        IModelDoc2 _swModel;
        PartDoc _swPart;

        int _longstatus = 0;
        int _longwarnings = 0;
        double _oldX;
        double _oldY;

        public AssemblyDoc SwAssy { get; set; }

        public SldWorks SwApp { get; set; }

        public double Height { get; set; }

        public double Width { get; set; }

        public double Length { get; set; }

        public void didLocateElement(ILibrary selectedItem, Helpers.Action action, int coordinatorX, int coordinatorY, string textboxHeight)
        {
            double height = Convert.ToDouble(textboxHeight) / 1000;
            double coX = Convert.ToDouble(coordinatorX) / 1000;
            double coY = (-1) * Convert.ToDouble(coordinatorY) / 1000;
   
            if (action == Action.Move)
             {
               _swModel.Extension.SelectByID2("", "FACE", _oldX, height + selectedItem.HeightIncrementor, _oldY, false, 0, null, 0);
               _swModel.EditDelete();
             }
             SwApp.OpenDoc6(@"C:\Certificate\ASVMP.SLDPRT", 1, 0, "", _longstatus, _longwarnings);
             SwAssy.AddComponent(@"C:\Certificate\ASVMP.SLDPRT", coX, height + selectedItem.HeightIncrementor, coY);
              
            _oldX = coX;
            _oldY = coY;

        }

        public void didPrepareEnvironment(string textboxHeight, string textboxWidth, string textboxLenght)
        {
            Process[] processes = Process.GetProcessesByName("SLDWORKS");

            foreach (Process process in processes)
            {
                process.CloseMainWindow();
                process.Kill();
            }

            Guid myGuid1 = new Guid("B4875E89-91F6-4124-BB63-2539727E98FA");
            object processSw = Activator.CreateInstance(Type.GetTypeFromCLSID(myGuid1));

            SwApp = (SldWorks)processSw;
            SwApp.Visible = true;

            Width = Convert.ToDouble(textboxWidth) / 1000;
            Length = Convert.ToDouble(textboxLenght) / 1000;
            Height = Convert.ToDouble(textboxHeight) / 1000;
        }

        public void didBuildModel()
        {
             SwApp.NewPart();
            _swModel = SwApp.IActiveDoc2; 
            _swPart = (PartDoc)(_swModel);

            _swModel.Extension.SelectByID2("Top", "PLANE", 0, 0, 0, false, 0, null, 0);
            _swModel.SketchManager.InsertSketch(true);
            _swModel.ClearSelection2(true);
            
            _swModel.SketchManager.CreateCornerRectangle(0, 0, 0, Length, Width, 0);
            _swModel.ClearSelection2(true);

            _swModel.SketchManager.InsertSketch(true);

            _swModel.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, Height, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);

            _swModel.Extension.SelectByID2("", "FACE", Length / 2, Height, - Width / 2, false, 0, null, 0);
            _swModel.ShowNamedView2("*Top", 5);

            _swModel.ViewZoomTo2(-1.40224455089843E-02, 7.79877043000974E-02, 0, 0.090572328390715, -1.30337019942975E-02, 0);

            _swModel.SketchManager.CreateCircle(0.004, Width - 0.004, 0, 0.004, Width - 0.004 + 0.00135, 0);
            _swModel.ClearSelection2(true);

            _swModel.SketchManager.CreateCircle(0.004, 0.004, 0, 0.004, 0.00535, 0);
            _swModel.ClearSelection2(true);

            _swModel.SketchManager.CreateCircle(Length - 0.004, Width - 0.004, 0, Length - 0.004, Width - 0.004 + 0.00135, 0);
            _swModel.ClearSelection2(true);

            _swModel.SketchManager.CreateCircle(Length - 0.004, 0.004, 0, Length - 0.004, 0.00535, 0);
            _swModel.ClearSelection2(true);

            _swModel.ShowNamedView2("*Isometry", 7);

            _swModel.Extension.SelectByID2("Arc1@", "EXTSKETCHSEGMENT", 5.96034675525732E-03, 6.63356185593879E-02, 0, false, 0, null, 0);
            _swModel.FeatureManager.FeatureCut3(true, false, false, 1, 0, 0.005, 0.005, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            _swModel.ViewZoomTo2(-1.30039690871637E-02, 3.75387366394858E-02, 1.58777579102132E-02, 0.142076690355558, -0.052121832944159, 1.58777579102138E-02);
            _swModel.ShowNamedView2("*Left", 3);
            _swModel.ViewZoomTo2(-0.083498837770881115, 0.014433467968860341, -0.060000000000000081, 0.0096740082936823124, -0.016165167848730275, -0.059999999999999866);
            _swModel.Extension.SelectByID2("", "EDGE", 0, Height / 2, 0, true, 0, null, 0);
            _swModel.Extension.SelectByID2("", "EDGE", 0, Height / 2, - Width, true, 0, null, 0);
            _swModel.ShowNamedView2("*Righr", 4);
            _swModel.ViewZoomTo2(-0.013345844591793166, 0.018717276983323025, 0.059999999999999894, 0.080438974189122076, -0.017083126923257995, 0.060000000000000143);
            _swModel.Extension.SelectByID2("", "EDGE", Length, Height / 2, 0, true, 0, null, 0);
            _swModel.Extension.SelectByID2("", "EDGE", Length, Height / 2, - Width, true, 0, null, 0);
            _swModel.ShowNamedView2("*Isometry", 7);
            _swModel.FeatureManager.InsertFeatureChamfer(4, 1, 0.0027, 0.78539816339745, 0, 0, 0, 0);


            _swModel.Extension.SelectByID2("Body-Feature1", "BODYFEATURE", 0, 0, 0, false, 0, null, 0);
            _swModel.Extension.SelectByID2("Unknown", "BROWSERITEM", 0, 0, 0, false, 0, null, 0);
            _swModel.ClearSelection2(true);
            _swPart.SetMaterialPropertyName2("По умолчанию", @"C:/ProgramData/SolidWorks/SolidWorks 2012/Sustainability/Sustainability Extras.sldmat", "Плата системы питания");
            _swModel.ClearSelection2(true);

            _swModel.SaveAs3(@"C:\Certificate\plata.SLDPRT", 0, 2);
        }

        public void didLoadPcb()
        {
            _swModel = SwApp.NewDocument(@"C:\ProgramData\SolidWorks\SolidWorks 2012\templates\gost-assy.asmdot", 0, 0, 0);
            SwApp.ActivateDoc2("Assembly1", false, _longstatus);
            _swModel = SwApp.ActiveDoc;

            SwAssy = (AssemblyDoc)_swModel;
            SwApp.OpenDoc6(@"C:\Certificate\plata.SLDPRT", 1, 0, "", _longstatus, _longwarnings);
            SwAssy.AddComponent(@"C:\Certificate\plata.SLDPRT", Length / 2, Height / 2, -Width / 2);
        }
    }
}
