using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Vietjet.com.Models
{
    public class bay
    {
        public int Id { get; set; }
        [Display(Name ="Mã chuyến bay")]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Ngày khởi hành")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Hãng hàng không")]
        public string Genre { get; set; }
        [Column(TypeName = "decimal(18, 2)")]

        [Display(Name = "Giá vé")]
        public decimal Price { get; set; }
        [Display(Name ="hạng vé")]
        public string Rating { get; set; }

    }
}
