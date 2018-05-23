using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLTK
{
	public class MonThiData
	{
		TracNghiemEntities tn = null;
		public MonThiData()
		{
			tn = new TracNghiemEntities();
		}
		public List<MonThi> ListMonThi()
		{
			var res = tn.MonThis.ToList();
			return res;
		}
		public int Insert(MonThi entity)
		{
			tn.MonThis.Add(entity);
			tn.SaveChanges();
			return entity.MaMon;
		}
		public bool Update(MonThi entity)
		{
			var mt = tn.MonThis.Find(entity.MaMon);
			mt.TenMon = entity.TenMon;
			tn.SaveChanges();
			return true;

		}
		public bool Delete(int id)
		{
			var mt = tn.MonThis.Find(id);
            var quiz = (tn.Quizs.Where(x => x.MaMon == id));
            var dt = (tn.DeThis.Where(x => x.MaDe == id));
            foreach (var item in quiz)
            {
                tn.Quizs.Remove(item);
            }
            foreach (var item in dt)
            {
                var ch_db = (tn.ch_db.Where(x => x.MaDe == item.MaDe));
                foreach(var item_chdb in ch_db)
                {
                    tn.ch_db.Remove(item_chdb);
                }
                tn.DeThis.Remove(item);
            }
            tn.MonThis.Remove(mt);
			tn.SaveChanges();
			return true;
		}
	}
}
