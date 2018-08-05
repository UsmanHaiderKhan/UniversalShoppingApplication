using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace UniversalShopingClasses.UserManagement
{
    public class UserHandler
    {
        public User GetUser(string Loginid, string Password)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from v in db.Users.Include(m => m.Gender).Include(m => m.Role) where v.Loginid.Equals(Loginid) && v.Password.Equals(Password) select v).FirstOrDefault();
            }
        }
        public List<User> GetUsers()
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from u in db.Users
                        .Include(m => m.Role)
                        .Include(m => m.Gender)
                        select u).ToList();
            }
        }

        public User GetUser(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from u in db.Users
                        where u.Id == id
                        select u).FirstOrDefault();
            }
        }

        public List<Gender> GetGender()
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.Genders select c).ToList();
            }
        }
        public User GetUserById(int id)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.Users
                        .Include(x => x.Role)
                        .Include(x => x.Gender)
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }
        public User GetUserByEmail(string email)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.Users where c.Email == email select c).FirstOrDefault();
            }
        }

        public List<Contact> GetAllMessages()
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                return (from c in db.Contacts select c).ToList();
            }
        }
    }
}
