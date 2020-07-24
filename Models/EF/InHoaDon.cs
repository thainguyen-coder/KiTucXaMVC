namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    
    public partial class InHoaDon
    {
        
        public string MaHD { get; set; }

        
        public string MaNV { get; set; }

        
        public string MaPhong { get; set; }

       
        public DateTime NgayGhi { get; set; }
        public double tongTien { get; set; }

    }
}
