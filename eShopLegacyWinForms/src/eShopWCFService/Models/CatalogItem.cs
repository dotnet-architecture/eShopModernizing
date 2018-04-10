namespace eShopWCFService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class CatalogItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public string Picturefilename { get; set; }
        [DataMember]
        public int CatalogBrandId { get; set; }
        [DataMember]
        public int CatalogTypeId { get; set; }

        [DataMember]
        public CatalogType CatalogType { get; set; }

        [DataMember]
        public CatalogBrand CatalogBrand { get; set; }
    }
}
