using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Model;

namespace Users.IBL
{
    public interface IUserRepository : IDisposable
    {
        List<UserModel> GetUsers();
        UserModel GetUserByID(int userId);
        void InsertUser(UserModel user);
        void DeleteUser(int userId);
        string UpdateUser(UserModel user);
       
    }
}
