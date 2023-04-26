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
    public class MVVMRenters : ObservableRecipient
    {
        public RestCollection<Renter> Renters { get; set; }

        private Renter selectedRenter;

        public Renter SelectedRenter
        {
            get { return selectedRenter; }
            set
            {
                SetProperty(ref selectedRenter, value);
                (DeleteRenterCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateRenterCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public ICommand CreateRenterCommand { get; set; }
        public ICommand DeleteRenterCommand { get; set; }
        public ICommand UpdateRenterCommand { get; set; }

        public MVVMRenters()
        {
            if (!IsInDesignMode)
            {
                Renters = new RestCollection<Renter>("http://localhost:11938/", "renter");

               

                CreateRenterCommand = new RelayCommand(() =>
                {
                    Renters.Add(new Renter()
                    {
                        Name = "",
                    });
                });

                UpdateRenterCommand = new RelayCommand(() =>
                {
                    Renters.Update(selectedRenter);
                });

                DeleteRenterCommand = new RelayCommand(() =>
                {
                    Renters.Delete(selectedRenter.ID);
                },
                () =>
                {
                    return selectedRenter != null;
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
