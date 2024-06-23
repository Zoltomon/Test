using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Test5.Classes;
using Test5.Models;

namespace Test5.Controllers
{
    public class AutorizationController
    {
        public PersonalData Autorization(string login, string password)
        {
            if(login == "" && password == "") 
            {
                throw new Exception("Введите данные");
            }
            var conn = ConnectDBClass.connection.PersonalData.FirstOrDefault(x => x.Users.Login == login && x.Users.Password == password);
            if(conn == null)
            {
                throw new Exception("Неправильно введены данные");
            }
            return conn;
        }
    }
}
