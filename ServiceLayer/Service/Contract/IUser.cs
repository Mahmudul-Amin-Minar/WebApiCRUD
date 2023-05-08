using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Contract
{
    public interface IUser
    {
        //GetAll Records
        List<User> GetAllRepo();

        //GetSingle Record
        User GetSingleRepo(long id);

        //Add Record
        string AddUserRepo(User user);

        //Update Record
        string UpdateUserRepo(User user);

        //Delete Record
        string RemoveUser(long id);
    }
}
