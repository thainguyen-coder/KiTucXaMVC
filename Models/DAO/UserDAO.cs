using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.DAO
{
    public class UserDAO
    {
        private DBKTX db;

        public UserDAO()
        {
            db = new DBKTX();
        }
        public int login(string user, string pass)
        {
            var result = db.NGUOIDUNGs.SingleOrDefault(x => x.TenDangNhap.Contains(user) && x.MatKhau.Contains(pass));
            if (result == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
       
        public String Insert(NGUOIDUNG entityNguoiDung)
        {
            db.NGUOIDUNGs.Add(entityNguoiDung);
            db.SaveChanges();
            return entityNguoiDung.TenDangNhap;
        }
        public NGUOIDUNG Find(string tenDN)
        {
            return db.NGUOIDUNGs.Find(tenDN);

        }
       
        public List<NGUOIDUNG> ListAll()
        {
            return db.NGUOIDUNGs.ToList();
        }
        public List<NGUOIDUNG> ListWhereAll(string searchString)
        {
            if(!string.IsNullOrEmpty(searchString))
            return db.NGUOIDUNGs.Where(x => x.MaNV.Contains(searchString)).ToList();
            return db.NGUOIDUNGs.ToList();

        }
    }


  
}
