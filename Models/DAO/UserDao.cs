using Models.EF;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class UserDao
    {
        TrieuTraiTimKara db;
        public UserDao()
        {
            db = new TrieuTraiTimKara();

        }
        public long Insert(Account entity)
        {
            db.Accounts.Add(entity);
            db.SaveChanges();
            return entity.id;


        }
        public int Login(string email, string password)
        {
            var user = db.Accounts.FirstOrDefault(x => x.email == email);

            if (user == null)
            {
                return -1;//không tồn tại
            }
            else
            {
                if (user.isDelete == 1)
                {
                    return 0;//tài khoản bị khóa
                }
                else if (db.Accounts.FirstOrDefault(x => x.email == email && x.password == password && x.role == 1) != null)
                {
                    return 1;//đúng
                }
                else
                {
                    return 2;//mật khẩu sai
                }

            }
        }
        public Account findByUsername(string email)
        {
            var a = db.Accounts.FirstOrDefault(x => x.email == email);
            return a;

        }

    }
}
