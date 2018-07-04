using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class MediaDao
    {
        TrieuTraiTimKara trieutraitim;

        public MediaDao()
        {
            trieutraitim = new TrieuTraiTimKara();
        }
        public IEnumerable<Media> GetAllMedia(int page, int pageSize)
        {
            return trieutraitim.Media.Where(x => x.isDelete == 0).OrderBy(x => x.createDate).ToPagedList(page, pageSize);

        }
        public IEnumerable<Media> GetMediaByCate(int CateID, int page, int pageSize)
        {
            return trieutraitim.Media.Where(x => x.isDelete == 0 && x.categoryid == CateID).ToPagedList(page, pageSize);

        }
        public Media GetMediaByID(int id)
        {
            return trieutraitim.Media.Where(x => x.isDelete == 0 && x.id == id).FirstOrDefault();

        }
    }
}
