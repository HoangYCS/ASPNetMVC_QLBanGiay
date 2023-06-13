using ASIGNMENT_FPOLY.IServices;
using ASIGNMENT_FPOLY.Models;

namespace ASIGNMENT_FPOLY.Services
{
    public class RoleService : IRoleService
    {

        DBShopping context;
        public RoleService()
        {
            context = new DBShopping();
        }
        public bool CreateRole(Role p)
        {
            try
            {
                context.Roles.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteRole(Guid id)
        {
            try
            {
                var Roles = context.Roles.Find(id);
                context.Roles.Remove(Roles);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Role> GetAllRoles()
        {
            return context.Roles.ToList();
        }
        public Role GetRoleById(Guid id)
        {
            return context.Roles.FirstOrDefault(p => p.Id == id);
        }
        public List<Role> GetRolesByName(string name)
        {
            return context.Roles.Where(p => p.Description.Contains(name)).ToList();
        }
        public bool UpdateRole(Role obj)
        {
            try
            {
                var Role = context.Roles.Find(obj.Id);
                context.Roles.Update(Role);
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
