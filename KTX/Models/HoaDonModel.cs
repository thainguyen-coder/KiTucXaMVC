using DocumentFormat.OpenXml.Office2010.ExcelAc;
using KTX.ViewModels;
using Models.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KTX.Models
{
    public class HoaDonModel
    {
        private DBKTX context;

        public HoaDonModel()
        {
            context = new DBKTX();
        }

        [Required(ErrorMessage = "Nhập mã hóa đơn")]
        [Display(Name = "Mã hóa đơn")]
        public string MaHD
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Nhập mã nhân viên")]
        [Display(Name = "Mã nhân viên")]
        public string MaNV
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Nhập mã phòng")]
        [Display(Name = "Mã phòng")]
        public string MaPhong
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Nhập mã ngày ghi")]
        [Display(Name = "Ngày ghi")]
        public DateTime NgayGhi
        {
            get;
            set;
        }
        public double tongTien { get; set; }
        public virtual DIEN DIEN { get; set; }
        public virtual NUOC NUOC { get; set; }

        // models

        //public double tongTien1()
        //{
        //    QLDsModel qld = new QLDsModel();
        //    QLNsModel qln = new QLNsModel();
        //    HoaDonModel donModel = new HoaDonModel();
        //    double tongTien = 0;

        //    if (qld.MaPhong == donModel.MaPhong && qln.MaPhong == donModel.MaPhong)
        //    {

        //        tongTien = ((qld.CSC - qld.CSD) * qld.DonGia) + ((qln.CSC - qln.CSD) * qln.DonGia);
        //        return tongTien;
        //    }
        //    return 0;

        //}

        public List<HOADON> listAll()
        {
            return context.HOADONs.ToList();
        }


        //public List<HOADON> ListWhereAll(string searchString)
        //{
        //    if (!string.IsNullOrEmpty(searchString))
        //        return context.HOADONs.Where(x => x.MaHD.Contains(searchString)).ToList();

        //    return context.HOADONs.ToList();

        //}
        //tim hoa đơn
        public List<HoaDonViewModel> FindHD(string searchString)
        {

            var query = from i in context.HOADONs
                        join c in context.PHONGs on i.MaPhong equals c.MaPhong
                        join d in context.DIENs on c.MaPhong equals d.MaPhong
                        join e in context.NUOCs on d.MaPhong equals e.MaPhong
                        where (i.MaHD.Contains(searchString))
                        select new
                        {
                            hd = i.MaHD,
                            nv = i.MaNV,
                            mp = i.MaPhong,
                            nghi = i.NgayGhi,
                            chiSoMoiD = d.CSC,
                            chiSoCuD = d.CSD,
                            dogiaD = d.DonGia,
                            chiSoMoiN = e.CSC,
                            chiSoCuN = e.CSD,
                            donGiaN = e.DonGia,
                        };
            List<HoaDonViewModel> hd = new List<HoaDonViewModel>();

            foreach (var item in query)
            {

                HoaDonViewModel hd1 = new HoaDonViewModel();
                hd1.MaHD = item.hd;
                hd1.MaNV = item.nv;
                hd1.MaPhong = item.mp;
                hd1.NgayGhi = item.nghi;
                var tongTien = (item.chiSoMoiD - item.chiSoCuD) * item.dogiaD + (item.chiSoMoiN - item.chiSoCuN) * item.donGiaN;
                hd1.TongTien = tongTien;
                hd.Add(hd1);

            }
            //check;
            return hd;


        }
        //in hóa đơn
        public List<HoaDonViewModel> inHoaDons()
        {
            var query = from i in context.HOADONs
                        join c in context.PHONGs on i.MaPhong equals c.MaPhong
                        join d in context.DIENs on c.MaPhong equals d.MaPhong
                        join e in context.NUOCs on d.MaPhong equals e.MaPhong
                        select new
                        {
                            hd = i.MaHD,
                            nv = i.MaNV,
                            mp = i.MaPhong,
                            nghi = i.NgayGhi,
                            chiSoMoiD = d.CSC,
                            chiSoCuD = d.CSD,
                            dogiaD = d.DonGia,
                            chiSoMoiN = e.CSC,
                            chiSoCuN = e.CSD,
                            donGiaN = e.DonGia,
                        };
            List<HoaDonViewModel> hd = new List<HoaDonViewModel>();

            foreach (var item in query)
            {

                HoaDonViewModel hd1 = new HoaDonViewModel();
                hd1.MaHD = item.hd;
                hd1.MaNV = item.nv;
                hd1.MaPhong = item.mp;
                hd1.NgayGhi = item.nghi;
                var tongTien = (item.chiSoMoiD - item.chiSoCuD) * item.dogiaD + (item.chiSoMoiN - item.chiSoCuN) * item.donGiaN;
                hd1.TongTien = tongTien;
                hd.Add(hd1);

            }
            return hd;
        }

        public List<XuatHoaDon> listAllHD()
        {
            var query = from i in context.HOADONs
                        join c in context.PHONGs on i.MaPhong equals c.MaPhong
                        join d in context.DIENs on c.MaPhong equals d.MaPhong
                        join e in context.NUOCs on d.MaPhong equals e.MaPhong
                        select new
                        {
                            hd = i.MaHD,
                            nv = i.MaNV,
                            mp = i.MaPhong,
                            nghi = i.NgayGhi,
                            chiSoMoiD = d.CSC,
                            chiSoCuD = d.CSD,
                            dogiaD = d.DonGia,
                            chiSoMoiN = e.CSC,
                            chiSoCuN = e.CSD,
                            donGiaN = e.DonGia,
                        };

            List<XuatHoaDon> hd = new List<XuatHoaDon>();

            foreach (var item in query)
            {
                XuatHoaDon xuatHoaDon = new XuatHoaDon()
                {
                    MaHD = item.hd,
                    MaNV = item.nv,
                    MaPhong = item.mp,
                    NgayGhi = item.nghi,
                    CSC = item.chiSoMoiD,
                    CSD = item.chiSoCuD,
                    DonGia = item.dogiaD,
                    CSCN = item.chiSoMoiN,
                    CSDN = item.chiSoCuN,
                    DonGiaN = item.donGiaN

                };

                hd.Add(xuatHoaDon);
            }

            return hd;
        }


        //public List<HOADON> ketNoi(String search)
        //{

        //    var query = from i in context.HOADONs
        //                join c in context.PHONGs on i.MaPhong equals c.MaPhong
        //                join d in context.DIENs on c.MaPhong equals d.MaPhong
        //                join e in context.NUOCs on d.MaPhong equals e.MaPhong
        //                select new
        //                {
        //                    hd = i.MaHD,
        //                    nv = i.MaNV,
        //                    mp = i.MaPhong,
        //                    nghi = i.NgayGhi,
        //                    chiSoMoiD = d.CSC,
        //                    chiSoCuD = d.CSD,
        //                    dogiaD = d.DonGia,
        //                    chiSoMoiN = e.CSC,
        //                    chiSoCuN = e.CSD,
        //                    donGiaN = e.DonGia,
        //                };
        //    List<HOADON> hd = new List<HOADON>();

        //    foreach (var item in query)
        //    {

        //        HOADON hd1 = new HOADON();
        //        hd1.MaHD = item.hd;
        //        hd1.MaNV = item.nv;
        //        hd1.MaPhong = item.mp;
        //        hd1.NgayGhi = item.nghi;
        //        var tongTien = (item.chiSoMoiD - item.chiSoCuD) * item.dogiaD + (item.chiSoMoiN - item.chiSoCuN) * item.donGiaN;
        //        //hd1.tongTien = tongTien;
        //        hd.Add(hd1);

        //    }
        //    //check;
        //    return hd;


        //}

        public String Insert(HOADON enity)
        {
            context.HOADONs.Add(enity);
            context.SaveChanges();


            return enity.MaHD;
        }
        public HOADON Find(string maHD)
        {
            return context.HOADONs.Find(maHD);

        }

        public HOADON GetByMaHD(string maHD)
        {
            return context.HOADONs.SingleOrDefault(x => x.MaHD == maHD);
        }

        public bool Update(HOADON maHD)
        {
            try
            {
                var hd = context.HOADONs.Select(x => x).Where(x => x.MaHD == maHD.MaHD).FirstOrDefault();
                hd.MaHD = maHD.MaHD;
                hd.MaNV = maHD.MaNV;
                hd.MaPhong = maHD.MaPhong;
                hd.NgayGhi = maHD.NgayGhi;
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public void Delete(string maHD)
        {
            try
            {
                var hd = context.HOADONs.FirstOrDefault(x => x.MaHD.Contains(maHD));
                context.HOADONs.Remove(hd);
                context.SaveChanges();

            }
            catch (Exception e)
            {

            }
        }
    }
}