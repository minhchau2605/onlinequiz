using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLTK.DeatView;
using PagedList;

namespace DataLTK
{
    public class ThiSinhData
    {
        private TracNghiemEntities tn;
        public ThiSinhData()
        {
            tn = new TracNghiemEntities();
        }
        public List<ThiSinhView> ListThiSinhNoPaging()
        {
            var res = from a in tn.ThiSinhs
                      join b in tn.Lops
                      on a.MaLop equals b.MaLop
                      select new ThiSinhView()
                      {
                          MaThiSinh = a.MaThiSinh,
                          HoTen = a.HoTen,
                          GioiTinh = a.GioiTinh,
                          NgaySinh = a.NgaySinh,
                          DiaChi = a.DiaChi,
                          MaLop = b.MaLop,
                          TenLop = b.TenLop,
                          Khoi = b.Khoi
                      };
            return res.ToList();
        }
        public IEnumerable<ThiSinhView> ListThiSinh(string searchString, int page, int pageSize)
        {
            var res = from a in tn.ThiSinhs
                      join b in tn.Lops
                      on a.MaLop equals b.MaLop
                      select new ThiSinhView()
                      {
                          MaThiSinh = a.MaThiSinh,
                          HoTen = a.HoTen,
                          GioiTinh = a.GioiTinh,
                          NgaySinh = a.NgaySinh,
                          DiaChi = a.DiaChi,
                          MaLop = b.MaLop,
                          TenLop = b.TenLop,
                          Khoi = b.Khoi
                      };
            IQueryable<ThiSinhView> model = res;
            //Search by TenLop
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x=>x.TenLop.Contains(searchString));
            }
            return model.OrderByDescending(x => x.MaThiSinh).ToPagedList(page, pageSize);
        }
		public int Insert(ThiSinh entity)
		{
			tn.ThiSinhs.Add(entity);
			tn.SaveChanges();
			return entity.MaThiSinh;
		}
		public bool Update(ThiSinh entity)
		{
			var ts = tn.ThiSinhs.Find(entity.MaThiSinh);
			ts.HoTen = entity.HoTen;
			ts.GioiTinh = entity.GioiTinh;
			ts.NgaySinh = entity.NgaySinh;
            ts.DanToc = entity.DanToc;
			ts.DiaChi = entity.DiaChi;
            ts.MaLop = entity.MaLop;
            ts.NienKhoa = entity.NienKhoa;
			ts.Image = entity.Image;
			ts.Password = entity.Password;
			tn.SaveChanges();
			return true;
		}
		public bool Delete(int id)
		{
			var ts = tn.ThiSinhs.Find(id);
            var kq = (tn.KetQuas.Where(x => x.MaThiSinh == id));
            foreach (var item in kq)
            {                
                tn.KetQuas.Remove(item);
            }
            tn.ThiSinhs.Remove(ts);
			tn.SaveChanges();
			return true;
		}
		public List<ThiSinh> ListThiSinhID(int id)
		{
			var tan = tn.ThiSinhs.Where(x => x.MaThiSinh == id);
			return tan.ToList();
		}
	}
}
