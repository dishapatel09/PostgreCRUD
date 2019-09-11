using PostgreCRUD.Web.Context;
using PostgreCRUD.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace PostgreCRUD.Web.Repository
{
    public class UserRepository : IRepository<User>
    {

        UsersContext _context;

        public UserRepository(UsersContext usersContext)
        {
            _context = usersContext;
        }

        public void Add(User user)
        {
            if (user != null)
            {
                _context.Add(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<User> FindAll()
        {
            List<User> users = _context.Users.ToList();
            return (users);
        }

        public User FindByID(int id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public void Remove(int id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.Remove(user);
                _context.SaveChanges();
            }
        }

        public void Update(User user)
        {           
           
                _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.Update(user);
                _context.SaveChanges();
            
        }
    }
}
