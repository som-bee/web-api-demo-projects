using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIVersioning.Controllers
{
    public class StudentV2
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class StudentsV2Controller : ApiController
    {
        List<StudentV2> students = new List<StudentV2>()
    {
        new StudentV2() { Id = 1, FirstName = "Tom", LastName = "T"},
        new StudentV2() { Id = 2, FirstName = "Sam", LastName = "S"},
        new StudentV2() { Id = 3, FirstName = "John", LastName = "J"}
    };

        //[Route("api/v2/students")]
        public IEnumerable<StudentV2> Get()
        {
            return students;
        }

        //[Route("api/v2/students/{id}")]
        public StudentV2 Get(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
    }
}
