using O73Z62_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static O73Z62_HFT_2022231.Logic.Services.CompanyLogic;

namespace O73Z62_HFT_2022231.Logic.Interfaces
{
    public interface ICompanyLogic
    {
        void Create(Company company);
        void Delete(int id);
        IEnumerable<Company> ReadAll();
        Company Read(int id);
        void Update(Company company);
        IEnumerable<Supercar> SupercarCompany();
    }
}
