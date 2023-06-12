﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIDemo.Controllers
{
    public class ValuesController : ApiController
    {
        static List<string> list = new List<string>() { "value0","value1"};
        // GET api/values
        public IEnumerable<string> Get()
        {
            return list;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return list[id];
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
            list.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
            list[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            list.RemoveAt(id);
        }
    }
}
