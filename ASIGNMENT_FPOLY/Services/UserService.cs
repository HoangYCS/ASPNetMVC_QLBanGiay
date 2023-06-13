using ASIGNMENT_FPOLY.IServices;
using ASIGNMENT_FPOLY.Models;
using Microsoft.EntityFrameworkCore;

namespace ASIGNMENT_FPOLY.Services
{
    public class UserService : IUserService
    {

        DBShopping context;
        public UserService()
        {
            context = new DBShopping();
        }
        public bool CreateUser(User p)
        {
            try
            {
                context.Users.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteUser(Guid id)
        {
            try
            {
                var Users = context.Users.Find(id);
                context.Users.Remove(Users);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            return context.Users.Include("Role").Where(x=>x.Role.Status==1).ToList();
        }

        public User GetOneUser(string userName, string Pass)
        {
            return GetAllUsers().Find(x => x.UserName == userName && x.PassWord == Pass);
        }

        public User GetUserById(Guid id)
        {
            return context.Users.FirstOrDefault(p => p.IdUser == id);
        }

        public User GetUserByName(string name)
        {
            return context.Users.FirstOrDefault(p => p.UserName == name);
        }

        public bool UpdateUser(User obj)
        {
            try
            {
                var User = context.Users.Find(obj.IdUser);
                User.PassWord = obj.PassWord;
                context.Users.Update(User);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
