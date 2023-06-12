using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeServiceWebAPI.Controllers
{
    [Authorize]
    public class EmployeesController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using(EmployeeDBforAPIEntities entities = new EmployeeDBforAPIEntities())
            {
                return entities.Employees.ToList();
            }
        }
    }
}
