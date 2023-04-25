using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using O73Z62_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace O73Z62_GUI_2022232.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Car> Cars { get; set; }

        private Car selectedCar;

        public Car SelectedCar
        {
            get { return selectedCar; }
            set 
            {
                SetProperty(ref selectedCar, value);
                (DeleteCarCommand as RelayCommand).NotifyCanExecuteChanged();
                //updatenélis meg kell hívni a relayCommandot
            }
        }


        public ICommand CreateCarCommand { get; set; }
        public ICommand DeleteCarCommand { get; set; }
        public ICommand UpdateCarCommand { get; set; }

        public MainWindowViewModel()
        {
            Cars = new RestCollection<Car>("http://localhost:11938/", "car");
            CreateCarCommand = new RelayCommand(() =>
            {
                Cars.Add(new Car()
                {
                    ID = 100,
                    CompanyID = 3,
                    Brand = "Ferrari",
                    Name = "Purosangue",
                    Engine = "V12",
                    Power = 670,
                    MonthlyPrice = 15000,
                    CylinderCapacity = 6500
                });
            });
            DeleteCarCommand = new RelayCommand(() =>
            {
                Cars.Delete(selectedCar.ID);
            },
            () =>
            {
                return selectedCar != null;
            });
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
    }
}
