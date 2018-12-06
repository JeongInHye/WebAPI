using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Modules;
using MySql.Data.MySqlClient;
using System.Collections;

namespace WebAPI.Controllers
{
    [ApiController]
    public class InsertController : ControllerBase
    {
        [Route("api/Insert")]
        [HttpPost]
        public ActionResult<ArrayList> Insert([FromForm] Test test)
        {
            return Query.GetInsert(test);
        }

        [Route("api/Update")]
        [HttpPost]
        public ActionResult<ArrayList> Update([FromForm] Test test)
        {
            return Query.GetUpdate(test);
        }

        [Route("api/Delete")]
        [HttpPost]
        public ActionResult<ArrayList> Delete([FromForm] Test test)
        {
            return Query.GetDelete(test);
        }
    }
}
