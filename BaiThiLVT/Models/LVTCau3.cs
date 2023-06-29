using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace BaiThiLVT.Models
{
    [Table("LVTCau3")]
    public class LVTCau3
    {
        [Key]
        public string IDNhanVien{ get; set;}
        public string TenNhanVien{ get; set;}
        public string DiaChi{ get; set;}

    }
}