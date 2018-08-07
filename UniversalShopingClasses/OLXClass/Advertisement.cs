using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversalShopingClasses.GeneralProductManagement;
using UniversalShopingClasses.UserManagement;

namespace UniversalShopingClasses.OLXClass
{
    public class Advertisement
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(300)]
        public string Title { get; set; }
        [Column(TypeName = "varchar")]
        public string Description { get; set; }
        public float Price { get; set; }
        public DateTime PostedOn { get; set; }
        public User User { get; set; }
        public virtual AdvertisementSubCategory SubCategory { get; set; }
        public virtual AdvertisementType Type { get; set; }
        public virtual ICollection<ProductImages> Images { get; set; }

    }
}
