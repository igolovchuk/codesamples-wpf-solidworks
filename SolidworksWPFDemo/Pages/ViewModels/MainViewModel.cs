using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using FirstFloor.ModernUI.Windows.Controls;
using SolidworksWPFDemo.Helpers;
using SolidworksWPFDemo.Library;
using SolidworksWPFDemo.Service;
using SolidWorks.Interop.sldworks;

namespace SolidworksWPFDemo.Pages.ViewModels
{
    /// <summary>
    /// A simple view model for configuring theme, font and accent colors.
    /// </summary>
    public class MainViewModel : NotifyPropertyChanged
    {
        #region Fields

        private readonly IDataService _dataService;
        private string _selectedImage;
        private List<Tuple<string, int>> _elementHistoryList; 
        private ObservableCollection<ILibrary> _itemSource;
        private ILibrary _selectedItem;
        private string _textboxInfo;
        private int _coordinatorXMin;
        private int _coordinatorYMin;
        private int _coordinatorXMax;
        private int _coordinatorYMax;
        private int _coordinatorX;
        private int _coordinatorY;
        private int _tmodeMin;
        private int _tmodeMax;
        private int _tWork;

        #endregion

        #region Constructors

        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _elementHistoryList = new List<Tuple<string, int>>();
            AppearanceManager.Current.PropertyChanged += OnAppearanceManagerPropertyChanged;
            SelectedImage = $"{Properties.Settings.Default.ModelFolder}plata.jpg";
            var workplacesList = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces().Contains(typeof(ILibrary)))
       .Select(t => Activator.CreateInstance(t) as ILibrary).ToList();
            ItemsSource = new ObservableCollection<ILibrary>(workplacesList);

            AddElementCommand = new RelayCommand(ExecuteAddElementCommand);
            MoveElementCommand = new RelayCommand(ExecuteMoveElementCommand);
        }

        #endregion

        #region Properties

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

        public ObservableCollection<ILibrary> ItemsSource
        {
            get { return _itemSource; }
            set
            {
                if (_itemSource != value)
                {
                    _itemSource = value;
                    OnPropertyChanged("ItemsSource");
                }
            }
        }

        public ILibrary SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    SelectedImage = $"{Properties.Settings.Default.ModelFolder}{_selectedItem.DisplayName}.jpg";
                    CoordinatorXMin = _selectedItem.LocationXMin;
                    CoordinatorXMax = Convert.ToInt32(LoadViewModel.Instanse.TextBoxLength) - CoordinatorXMin;
                    CoordinatorYMin = _selectedItem.LocationXMin;
                    CoordinatorYMax = Convert.ToInt32(LoadViewModel.Instanse.TextBoxWidth) - CoordinatorYMin;
                    CoordinatorX = _selectedItem.RecomendedX;
                    CoordinatorY = _selectedItem.RecomendedY;
                    TextBoxInfo = _dataService.didSetCoordinate(CoordinatorXMin, CoordinatorYMin, CoordinatorXMax, CoordinatorYMax);
                    TModeMin = _selectedItem.TModeMin;
                    TModeMax = _selectedItem.TModeMax;
                    OnPropertyChanged("SelectedItem");
                }
            }
        }

        public int CoordinatorX
        {
            get { return _coordinatorX; }
            set
            {
                if (_coordinatorX != value)
                {
                    _coordinatorX = value;
                    OnPropertyChanged("CoordinatorX");
                }
            }
        }

        public int CoordinatorY
        {
            get { return _coordinatorY; }
            set
            {
                if (_coordinatorY != value)
                {
                    _coordinatorY = value;
                    OnPropertyChanged("CoordinatorY");
                }
            }
        }

        public int CoordinatorXMin
        {
            get { return _coordinatorXMin; }
            set
            {
                if (_coordinatorXMin != value)
                {
                    _coordinatorXMin = value;
                    OnPropertyChanged("CoordinatorXMin");
                }
            }
        }

        public int CoordinatorYMin
        {
            get { return _coordinatorYMin; }
            set
            {
                if (_coordinatorYMin != value)
                {
                    _coordinatorYMin = value;
                    OnPropertyChanged("CoordinatorYMin");
                }
            }
        }

        public int CoordinatorXMax
        {
            get { return _coordinatorXMax; }
            set
            {
                if (_coordinatorXMax != value)
                {
                    _coordinatorXMax = value;
                    OnPropertyChanged("CoordinatorXMax");
                }
            }
        }

        public int CoordinatorYMax
        {
            get { return _coordinatorYMax; }
            set
            {
                if (_coordinatorYMax != value)
                {
                    _coordinatorYMax = value;
                    OnPropertyChanged("CoordinatorYMax");
                }
            }
        }

        public int TModeMin
        {
            get { return _tmodeMin; }
            set
            {
                if (_tmodeMin != value)
                {
                    _tmodeMin = value;
                    OnPropertyChanged("TModeMin");
                }
            }
        }

        public int TModeMax
        {
            get { return _tmodeMax; }
            set
            {
                if (_tmodeMax != value)
                {
                    _tmodeMax = value;
                    OnPropertyChanged("TModeMax");
                }
            }
        }

        public int TWork
        {
            get { return _tWork; }
            set
            {
                if (_tWork != value)
                {
                    _tWork = value;
                    OnPropertyChanged("TWork");
                }
            }
        }

        public string TextBoxInfo
        {
            get { return _textboxInfo; }
            set
            {
                if (_textboxInfo != value)
                {
                    _textboxInfo = value;
                    OnPropertyChanged("TextBoxInfo");
                }
            }
        }

        #endregion

        #region Commands

        public ICommand AddElementCommand { get; private set; }

        public ICommand MoveElementCommand { get; private set; }

        #endregion

        #region Methods

        private void ExecuteMoveElementCommand(object obj)
        {
           _dataService.didLocateElement(SelectedItem, Helpers.Action.Move, CoordinatorX, CoordinatorY, LoadViewModel.Instanse.TextBoxHeight);    
        }

        private void ExecuteAddElementCommand(object obj)
        {
            _elementHistoryList.Add(new Tuple<string, int>(SelectedItem.DisplayName, TWork));

            if (_elementHistoryList.Sum(el => el.Item2) <= TModeMax)
            {
              _dataService.didLocateElement(SelectedItem, Helpers.Action.Add, CoordinatorX, CoordinatorY, LoadViewModel.Instanse.TextBoxHeight);
            }
            else
            {
                ModernDialog.ShowMessage($"Temperature Limit Hit! Element {_elementHistoryList.FirstOrDefault(el => el.Item2 == TWork)?.Item1} need to move.", "Warning!", MessageBoxButton.OK);
            }
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
