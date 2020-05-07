using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using SolidworksWPFDemo.Helpers;
using SolidworksWPFDemo.Library;
using SolidworksWPFDemo.Service;
using SolidWorks.Interop.sldworks;

namespace SolidworksWPFDemo.Pages.ViewModels
{
    /// <summary>
    /// A simple view model for configuring theme, font and accent colors.
    /// </summary>
    public class LoadViewModel : NotifyPropertyChanged
    {
        #region Fields

        private readonly IDataService _dataService;
        private string _selectedImage;
        private string _textboxHeight;
        private string _textboxLength;
        private string _textboxWidth;
        private static LoadViewModel _instanse;

        #endregion

        #region Constructors

        public LoadViewModel(IDataService dataService)
        {
            _dataService = dataService;
            AppearanceManager.Current.PropertyChanged += OnAppearanceManagerPropertyChanged;
            SelectedImage = $"{Properties.Settings.Default.ModelFolder}plata.jpg";
            TextBoxHeight = "2,4";
            TextBoxWidth = "120";
            TextBoxLength = "70";
            
            AddToAssemblyCommand = new RelayCommand(ExecuteAddToAssemblyCommand);
            BuildCommand = new RelayCommand(ExecuteBuildCommand);
        }

        #endregion

        #region Properties

        public static LoadViewModel Instanse => _instanse ?? (_instanse = new LoadViewModel(new DataService()));

        public string TextBoxHeight
        {
            get { return _textboxHeight; }
            set
            {
                if (_textboxHeight != value)
                {
                    _textboxHeight = value;
                    OnPropertyChanged("TextBoxHeight");
                }
            }
        }

        public string TextBoxLength
        {
            get { return _textboxLength; }
            set
            {
                if (_textboxLength != value)
                {
                    _textboxLength = value;
                    OnPropertyChanged("TextBoxLength");
                }
            }
        }

        public string TextBoxWidth
        {
            get { return _textboxWidth; }
            set
            {
                if (_textboxWidth != value)
                {
                    _textboxWidth = value;
                    OnPropertyChanged("TextBoxWidth");
                }
            }
        }

        public string SelectedImage
        {
            get { return _selectedImage; }
            set
            {
                if (_selectedImage != value)
                {
                    _selectedImage = value;
                    OnPropertyChanged("SelectedImage");
                }
            }
        }

        #endregion

        #region Commands

        public ICommand AddToAssemblyCommand { get; private set; }

        public ICommand BuildCommand { get; private set; }

        #endregion

        #region Methods

        private void ExecuteBuildCommand(object obj)
        {
            _dataService.didPrepareEnvironment(TextBoxHeight, TextBoxWidth, TextBoxLength);
            _dataService.didBuildModel();
        }

        private void ExecuteAddToAssemblyCommand(object obj)
        {
            _dataService.didPrepareEnvironment(TextBoxHeight, TextBoxWidth, TextBoxLength);
            _dataService.didLoadPcb();
        }

        private void OnAppearanceManagerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ThemeSource" || e.PropertyName == "AccentColor")
            {

            }
        }
        #endregion



    }
}
