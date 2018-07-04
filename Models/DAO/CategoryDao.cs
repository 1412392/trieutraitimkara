using Models.EF;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Threading.Tasks;
using Model.CustomClass;
using PagedList;

namespace Models.DAO
{

    public class CategoryDao
    {
        TrieuTraiTimKara trieutraitim;

        public CategoryDao()
        {
            trieutraitim = new TrieuTraiTimKara();
        }
        public IEnumerable<Category> GetAllCategory(int page, int pageSize)
        {
            return trieutraitim.Categories.Where(x => x.isDelete == 0).OrderBy(x => x.id).ToPagedList(page, pageSize);

        }
        public List<string> GetAllCategoryName()
        {
            return trieutraitim.Categories.Where(x => x.isDelete == 0).OrderBy(x => x.name).Select(x => x.name).ToList();

        }

        public Category GetCategoryByID(int id)
        {
            return trieutraitim.Categories.Where(x => x.isDelete == 0 && x.id == id).FirstOrDefault();
        }

        public dynamic GetAllCategoryAndNumberProduct()
        {
            dynamic list = (
                from a in trieutraitim.Categories
                join b in trieutraitim.Media on a.id equals b.id into listleftjoin
                from c in listleftjoin.DefaultIfEmpty()
                group c by new { a.id, a.name, a.seotitle } into d

                select new
                {
                    ProducerID = d.Key.id,
                    NumberProduct = d.Count(x => x.name != null),
                    ProducerName = d.Key.name,
                    ProducerMetaTitle = d.Key.seotitle
                }

                ).AsEnumerable().Select(k => k.ToExpando());

            return list;

        }

        public bool Update(Category cate)
        {
            try
            {
                var current = trieutraitim.Categories.FirstOrDefault(x => x.id == cate.id);
                current.imageurl = cate.imageurl;
                current.keyword = cate.keyword;
                current.metadescription = cate.metadescription;
                current.name = cate.name;
                current.seotitle = cate.seotitle;

                current.views = cate.views;

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
                var currentCate = trieutraitim.Categories.FirstOrDefault(x => x.id == id);
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

        public bool Insert(Category cate)
        {
            cate.createDate = DateTime.Now;
            cate.isDelete = 0;

            try
            {
                trieutraitim.Categories.Add(cate);
                trieutraitim.SaveChanges();
                if (cate.id > 0) return true;
            }
            catch (Exception e)
            {
                return false;
            }
            return false;

        }
    }

}
