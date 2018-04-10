namespace eShopWCFService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [Table("CatalogItemsStock")]
    [DataContract]
    public partial class CatalogItemsStock
    {
        [Column(TypeName = "date")]
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public int CatalogItemId { get; set; }
        [DataMember]
        public int AvailableStock { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember]
        public int StockId { get; set; }
    }
}
