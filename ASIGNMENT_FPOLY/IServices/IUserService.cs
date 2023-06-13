using ASIGNMENT_FPOLY.Models;

namespace ASIGNMENT_FPOLY.IServices
{
    public interface IUserService
    {

        public bool CreateUser(User obj);
        public bool UpdateUser(User obj);
        public bool DeleteUser(Guid id);
        public List<User> GetAllUsers();
        public User GetUserById(Guid id);
        public User GetUserByName(string name);
        public User GetOneUser(string userName, string Pass);
    }
}
