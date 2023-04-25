using O73Z62_HFT_2022231.Logic.Interfaces;
using O73Z62_HFT_2022231.Models;
using O73Z62_HFT_2022231.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O73Z62_HFT_2022231.Logic.Services
{
    public class CompanyLogic : ICompanyLogic
    {
        ICompanyRepository companyRepo;

        public CompanyLogic(ICompanyRepository companyRepo)
        {
            this.companyRepo = companyRepo;
        }

        public void Create(Company company)
        {
            if (company.Name == null || company.PhoneNumber == null || company.Email == null
                || company.Name == "" || company.PhoneNumber == "" || company.Email == "")
            {
                throw new ArgumentNullException("You have to enter all the information");
            }
            else
            {
                companyRepo.Create(company);
            }
        }

        public void Delete(int id)
        {
            companyRepo.Delete(id);
        }

        public Company Read(int id)
        {
            Company company = companyRepo.Read(id);
            if (company == null)
            {
                throw new ArgumentException($"Company with id({id}) does not exists.");
            }
            return company;
        }

        public IEnumerable<Company> ReadAll()
        {
            return companyRepo.ReadAll();
        }

        public void Update(Company company)
        {
            companyRepo.Update(company);
        }
        //company with the most powerful cars(highest horsepower)
        public IEnumerable<Supercar> SupercarCompany()
        {
            var q = from x in companyRepo.ReadAll()
                        select new Supercar()
                        {
                            CompanyName = x.Name.ToString(),
                            SumPower = x.Cars.Sum(t => t.Power)
                        };
            IEnumerable<Supercar> eredmeny = q.OrderByDescending(t => t.SumPower).Take(1);
            return eredmeny;
        }

        public class Supercar
        {
            public string CompanyName { get; set; }
            public int SumPower { get; set; }

            public override bool Equals(object o)
            {
                Supercar y = (o as Supercar);
                if (y == null)
                {
                    return false;
                }
                return (this.CompanyName == y.CompanyName)
                && (this.SumPower == y.SumPower);  
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.CompanyName, this.SumPower);
            }
        }
    }
}
