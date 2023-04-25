using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace O73Z62_HFT_2022231.Models
{
    public class Renter : Entity
    {
        //primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Renter_ID", TypeName = "int")]
        public override int ID { get; set; }

        //foreign keys
        [ForeignKey(nameof(Car))]
        public int CarID { get; set; }
        //nav prop
        [NotMapped]
        [JsonIgnore]
        public virtual Car Car { get; set; }

        //data fields
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        
        
    }
}
