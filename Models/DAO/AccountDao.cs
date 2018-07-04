using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class AccountDao
    {
        TrieuTraiTimKara trieutraitim;

        public AccountDao()
        {
            trieutraitim = new TrieuTraiTimKara();
        }
        public IEnumerable<Account> GetAllAccount(int page, int pageSize)
        {
            return trieutraitim.Accounts.Where(x => x.isDelete == 0 && x.role == 2).OrderBy(x => x.id).ToPagedList(page, pageSize);

        }
        public List<string> GetAllAccountName()
        {
            return trieutraitim.Accounts.Where(x => x.isDelete == 0).OrderBy(x => x.name).Select(x => x.name).ToList();

        }

        public Account GetAccountByEmail(string email)
        {
            return trieutraitim.Accounts.Where(x => x.isDelete == 0 && x.email == email).FirstOrDefault();
        }

        public Account GetAccountByID(int id)
        {
            return trieutraitim.Accounts.Where(x => x.isDelete == 0 && x.id == id).FirstOrDefault();
        }

        public bool Update(Account account)
        {
            try
            {
                var current = trieutraitim.Accounts.FirstOrDefault(x => x.id == account.id);
                current.email = account.email;
                current.password = account.password;
                current.name = account.name;
                current.phone = account.phone;

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
                var currentAcc = trieutraitim.Accounts.FirstOrDefault(x => x.id == id);
                if (currentAcc != null)
                {

                    currentAcc.isDelete = 1;
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

        public bool Insert(Account acc)
        {
            acc.createDate = DateTime.Now;
            acc.isDelete = 0;
            acc.role = 2;

            try
            {
                trieutraitim.Accounts.Add(acc);
                trieutraitim.SaveChanges();
                if (acc.id > 0) return true;
            }
            catch (Exception e)
            {
                return false;
            }
            return false;

        }
    }
}
