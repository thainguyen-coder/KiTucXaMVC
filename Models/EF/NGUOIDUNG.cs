namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NGUOIDUNG")]
    public partial class NGUOIDUNG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NGUOIDUNG()
        {
            HOADONs = new HashSet<HOADON>();
        }

        [StringLength(20)]
        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Tên đăng nhập ")]
        public string TenDangNhap { get; set; }

        
        [StringLength(20)]
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập thông tin ")]
        public string MatKhau { get; set; }

        [Key]
        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Mã nhân viên ")]
        [StringLength(15)]
        public string MaNV { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Họ tên nhân viên ")]
        [StringLength(50)]
        public string HoTenNV { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Chức vụ ")]
        public int? ChucVu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
    }
}
