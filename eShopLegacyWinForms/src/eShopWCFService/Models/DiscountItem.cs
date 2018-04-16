using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace eShopWCFService.Models
{
    [DataContract]
    public class DiscountItem
    {
        public DiscountItem()
        {
        }

        [DataMember]
        public double Size { get; set; }

        [Column(TypeName = "date")]
        [DataMember]
        public DateTime Start { get; set; }

        [Column(TypeName = "date")]
        [DataMember]
        public DateTime End { get; set; }

        [Key]
        [DataMember]
        public int Id { get; set; }
    }
}