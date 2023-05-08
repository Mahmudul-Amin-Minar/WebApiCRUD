using DomainLayer.Models;
using RepositoryLayer;
using ServiceLayer.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Implementation
{
    public class UserService : IUser
    {
        private readonly AppDbContext _dbContext;
        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Get all users
        public List<User> GetAllRepo()
        {
            return _dbContext.Users.ToList();
        }

        //Get single user
        public User GetSingleRepo(long id)
        {
            //return _dbContext.Users.Find(id);
            return _dbContext.Users.Where(x => x.UserId == id).FirstOrDefault();
        }


        //Add user to users
        public string AddUserRepo(User user)
        {
            try
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }


        //Remove User from user table
        public string RemoveUser(long id)
        {
            try
            {
                var user = _dbContext.Users.Find(id);
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
                return "Successfully Removed";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        public string UpdateUserRepo(User user)
        {
            try
            {
                var userValue = _dbContext.Users.Find(user.UserId);
                if (userValue != null)
                {
                    userValue.UserName = user.UserName;
                    _dbContext.SaveChanges();
                    return "Successfully Updated";
                }
                else
                {
                    return "No record found";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }
    }
}
