namespace EF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.InteropServices;

    [Table("LoaiPhim")]
    public partial class LoaiPhim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiPhim()
        {
            Phim = new HashSet<Phim>();
        }

        [Key]
        [StringLength(20, ErrorMessage = "{0} không được vượt quá 20 ký tự!")]
        [DisplayName("Mã loại phim")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public string ID_LoaiPhim { get; set; }

        [StringLength(50, ErrorMessage = "{0} không được vượt quá 50 ký tự!")]
        [DisplayName("Tên loại phim")]
        [Required(ErrorMessage = "{0} không được để trống!")]

        public string TenLoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phim> Phim { get; set; }
    }
}
