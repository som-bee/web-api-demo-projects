using EmployeeDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeDataAccess;

namespace WebAPIWithSQL
{
    public class EmployeeSecurity
    {
        public static bool Login(string username, string addressId)
        {
            int addId = Int32.Parse(addressId);
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                return entities.Users.Any(user =>
                       user.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                                          && user.AddressId == addId);
            }
        }
    }
}