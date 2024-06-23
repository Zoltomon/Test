using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Test4.Models;
using Test4.Views;

namespace Test4.Classes
{
    public class AutorizationController
    {
        public PersonalData Autorization(string login, string password)
        {
            if(login == "" && password == "")
            {
                throw new Exception("Введите данные");
            }
            var conn = ConnectDBClass.connect.PersonalData.FirstOrDefault(p => p.Users.Login == login && p.Users.Password == password);
            if(conn == null)
            {
                throw new Exception("Неправильно введены данные");
            }
            return conn;
        }
    }
}
