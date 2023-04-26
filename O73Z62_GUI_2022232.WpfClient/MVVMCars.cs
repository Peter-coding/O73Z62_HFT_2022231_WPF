using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using O73Z62_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace O73Z62_GUI_2022232.WpfClient
{
    public class MVVMCars : ObservableRecipient
    {
        public RestCollection<Car> Cars { get; set; }

        private Car selectedCar;

        public int CompanyID { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Engine { get; set; }
        public int CylinderCapacity { get; set; }
        public int Power { get; set; }
        public int MonthlyPrice { get; set; }

        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                SetProperty(ref selectedCar, value);
                (DeleteCarCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateCarCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand CreateCarCommand { get; set; }
        public ICommand DeleteCarCommand { get; set; }
        public ICommand UpdateCarCommand { get; set; }

        public MVVMCars()
        {
            if (!IsInDesignMode)
            {
                Cars = new RestCollection<Car>("http://localhost:11938/", "car");

                CreateCarCommand = new RelayCommand(() =>
                {
                    Cars.Add(new Car()
                    {
                        CompanyID = CompanyID,
                        Brand = Brand,
                        Name = Name,
                        Engine = Engine,
                        Power = Power,
                        MonthlyPrice = MonthlyPrice,
                        CylinderCapacity = CylinderCapacity
                    });
                });

                UpdateCarCommand = new RelayCommand(() =>
                {
                    Cars.Update(selectedCar);
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
