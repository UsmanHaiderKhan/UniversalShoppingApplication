using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversalShopingClasses.OLXClass
{
    public class AdvertisementSubCategory : IListable
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }
        [Required]
        public virtual AdvertismentCateory AdvertismentCateory { get; set; }
    }
}
