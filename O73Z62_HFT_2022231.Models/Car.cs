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
    public class Car : Entity
    {
        //primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Car_ID", TypeName = "int")]
        public override int ID { get; set; }

        //foreign key
        [ForeignKey(nameof(Company))]
        public int CompanyID { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Company Company { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Renter Renter { get; set; }

        //data fields
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Engine { get; set; }
        public int CylinderCapacity { get; set; }
        public int Power { get; set; }
        public int MonthlyPrice { get; set; }
    }
}
