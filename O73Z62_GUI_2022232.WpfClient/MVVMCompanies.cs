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
    public class MVVMCompanies : ObservableRecipient
    {
        public RestCollection<Company> Companies { get; set; }

        private Company selectedCompany;

        public Company SelectedCompany
        {
            get { return selectedCompany; }
            set
            {
                SetProperty(ref selectedCompany, value);
                (DeleteCompanyCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateCompanyCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand CreateCompanyCommand { get; set; }
        public ICommand DeleteCompanyCommand { get; set; }
        public ICommand UpdateCompanyCommand { get; set; }


        public MVVMCompanies()
        {
            if (!IsInDesignMode)
            {
                Companies = new RestCollection<Company>("http://localhost:11938/", "company");

                CreateCompanyCommand = new RelayCommand(() =>
                {
                    Companies.Add(new Company()
                    {
                        Name = "",
                    });
                });

                UpdateCompanyCommand = new RelayCommand(() =>
                {
                    Companies.Update(selectedCompany);
                });

                DeleteCompanyCommand = new RelayCommand(() =>
                {
                    Companies.Delete(selectedCompany.ID);
                },
                () =>
                {
                    return selectedCompany != null;
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
