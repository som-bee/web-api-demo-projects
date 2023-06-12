using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using EmployeeDataAccess;

namespace WebAPIWithSQL.Controllers
{
    public class EmployeesController : ApiController
    {
        // GET api/<controller>
        [BasicAuthentication]
        public HttpResponseMessage Get(string addressId = "all")
        {
            string username = Thread.CurrentPrincipal.Identity.Name;
            
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                addressId= username.ToLower();
                switch (addressId)
                {
                    //case "all":
                    //    return Request.CreateResponse(HttpStatusCode.OK, entities.Employee.ToList());
                    case "1":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Employee.Where(e => e.AddressId == 1).ToList());
                    case "3":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Employee.Where(e => e.AddressId == 3).ToList());
                    case "8":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Employee.Where(e => e.AddressId == 8).ToList());
                    default:
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "address id must be 1/3/8/all");
                }
            }
            
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                var emp = entities.Employee.ToList().FirstOrDefault(e => e.Id==id);
                if (emp != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee Not Found");
                }
            }
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] Employee employee)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    entities.Employee.Add(employee);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                    message.Headers.Location = new Uri(Request.RequestUri + employee.Id.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
           
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody] Employee employee)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    var entity = entities.Employee.ToList().FirstOrDefault(e => e.Id == id);
                    if (entity != null)
                    {
                        entity.FirstName = employee.FirstName;
                        entity.LastName = employee.LastName;
                        entity.Email = employee.Email;
                        entity.AddressId = employee.AddressId;
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id = " + id + " Not Found");
                    }
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
          
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    var emp = entities.Employee.ToList().FirstOrDefault(e => e.Id == id);
                    if (emp != null)
                    {
                        entities.Employee.Remove(emp);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, "Employee Deleted");
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id = " +id +" Not Found");
                    }
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
          
        }
    }
}