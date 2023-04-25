using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace O73Z62_HFT_2022231.Models
{
    public class Company : Entity
    {
        //primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Company_ID", TypeName = "int")]
        public override int ID { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Car> Cars { get; set; }
        //data fields
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public override bool Equals(object o)
        {
            Company y = (o as Company);
            if (y == null)
            {
                return false;
            }
            return (this.Name == y.Name)
            && (this.Email == y.Email)
            && (this.PhoneNumber == y.PhoneNumber);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Email, this.PhoneNumber);
        }

    }
}
