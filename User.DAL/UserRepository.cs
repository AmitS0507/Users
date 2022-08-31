using System;
using System.Collections.Generic;
using System.Linq;
using Users.IBL;
using Users.Model;

namespace Users.BL
{
    public class UserRepository: IUserRepository, IDisposable
    {

        List<UserModel> users = new List<UserModel>

       {
            new UserModel { Id = 1, FirstName = "Rich", LastName = "Grey", EmailAddress = "rich.grey@test.com", NotesField = "Architect", CreationTime = DateTime.Now.ToShortDateString()},
            new UserModel { Id = 2, FirstName = "Ian", LastName = "Warnett", EmailAddress = "ian.warnett@test.com", NotesField = "Product Owner", CreationTime = DateTime.Now.ToShortDateString()},
            new UserModel { Id = 3, FirstName = "Adam", LastName = "Whitlock", EmailAddress = "adam.whitlock@test.com", NotesField = "Business Analyst", CreationTime = DateTime.Now.ToShortDateString()},
       };
        public UserRepository()
        {
           
        }

        public List<UserModel> GetUsers()
        {
            return users;
        }

        public UserModel GetUserByID(int id)
        {
            return users.FirstOrDefault((p) => p.Id == id);
           
        }

        public void InsertUser(UserModel user)
        {
            if (user != null)
            {
                users.Add(user);
            }
        }

        public void DeleteUser(int userID)
        {
            UserModel user = users.Find((p)=> p.Id == userID);
            if (user != null)
            {
                users.Remove(user);
            }
        }

        public string UpdateUser( UserModel user)
        {
            var existingUser = users.Where(s => s.Id == user.Id)
                                                    .FirstOrDefault<UserModel>();

            if (existingUser ==null)
            {
                return "Not Found";

            }

            else
            {
                var userIndiex = users.FindIndex((p) => p.Id == user.Id);

                users[userIndiex] = user;

                return "Updated Successfully";
            }

            


            
                
            
        }

        public void Dispose()
        {
          //  Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
