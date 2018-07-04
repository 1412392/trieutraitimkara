using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class SingerDao
    {
        TrieuTraiTimKara trieutraitim;

        public SingerDao()
        {
            trieutraitim = new TrieuTraiTimKara();
        }
        public IEnumerable<Singer> GetAllSinger(int page, int pageSize)
        {
            return trieutraitim.Singers.Where(x => x.isDelete == 0).OrderBy(x => x.id).ToPagedList(page, pageSize);

        }
        public List<string> GetAllSingerName()
        {
            return trieutraitim.Singers.Where(x => x.isDelete == 0).OrderBy(x => x.name).Select(x => x.name).ToList();

        }

        public Singer GetSingerByID(int id)
        {
            return trieutraitim.Singers.Where(x => x.isDelete == 0 && x.id == id).FirstOrDefault();
        }



        public bool Update(Singer singer)
        {
            try
            {
                var current = trieutraitim.Singers.FirstOrDefault(x => x.id == singer.id);
                current.imageurl = singer.imageurl;
                current.keyword = singer.keyword;
                current.metadescription = singer.metadescription;
                current.name = singer.name;
                current.seotitle = singer.seotitle;
                current.description = singer.description;
                current.views = singer.views;

                trieutraitim.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var currentCate = trieutraitim.Singers.FirstOrDefault(x => x.id == id);
                if (currentCate != null)
                {

                    currentCate.isDelete = 1;
                    trieutraitim.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Insert(Singer cate)
        {
            cate.createDate = DateTime.Now;
            cate.isDelete = 0;

            try
            {
                trieutraitim.Singers.Add(cate);
                trieutraitim.SaveChanges();
                if (cate.id > 0) return true;
            }
            catch (Exception e)
            {
                return false;
            }
            return false;

        }

        public IEnumerable<Singer> GetAllSingerByKeyword(string q, int page, int size )
        {
            page = page + 1;
            return trieutraitim.Singers.Where(x => x.isDelete == 0 && x.name.Contains(q))
                .OrderBy(x => x.id).ToPagedList(page, size);
        }
    }
}
