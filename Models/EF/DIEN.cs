namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DIEN")]
    public partial class DIEN
    {
        [Key]
        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Mã điện")]
        [StringLength(15)]
        public string MaDien { set; get; }
        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Mã phòng")]
        [StringLength(15)]
        public string MaPhong { set; get; }
        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Ngày ghi")]
        public DateTime NgayGhi { set; get; }
        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Chỉ số đầu")]
        public int CSD { set; get; }
        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Chỉ số cuối")]
        public int CSC { set; get; }
        [Required(ErrorMessage = "Vui lòng nhập thông tin")]
        [Display(Name = "Đơn giá")]
        public double DonGia { set; get; }
        public double ThanhTienD
        {
            get
            {
                return (CSC - CSD) * DonGia;
            }
        }
        public virtual PHONG PHONG { get; set; }
    }
}
