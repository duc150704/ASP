namespace EF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phim")]
    public partial class Phim
    {
        [Key]
        [Required(ErrorMessage ="{0} không được để trống!")]

        public int ID_Phim { get; set; }

        [Required(ErrorMessage = "Không được để trống!")]
        [MaxLength(200, ErrorMessage = "{0} không quá 200 kí tự!")]
        public string Ten_Phim { get; set; }


        [Required(ErrorMessage = "Không được để trống!")]
        [MaxLength(200, ErrorMessage = "{0} không quá 200 kí tự!")]
        public string Dao_Dien { get; set; }

        [Required(ErrorMessage = "Không được để trống!")]
        [MaxLength(100, ErrorMessage = "{0} không quá 100 kí tự!")]
        public string Anh { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage ="Không được để trống!")]
        public DateTime? Ngay_Khoi_Chieu { get; set; }


        [Required(ErrorMessage ="Không được để trống!")]
        [MaxLength(20, ErrorMessage = "{0} không quá 20 kí tự!")]
        public string ID_LoaiPhim { get; set; }

        public virtual LoaiPhim LoaiPhim { get; set; }
    }
}
