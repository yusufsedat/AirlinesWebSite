using Microsoft.AspNetCore.Mvc;
using WebProgramlama_Odev.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebProgramlama_Odev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminApiController : ControllerBase
    {
        AirlineContext c = new AirlineContext();

        // GET: api/<AdminApiController>
        [HttpGet]
        public List<AdminModel> Get()
        {
            var adm = c.Admins.ToList();
            // normalde json formatına cevirip gondermem lazım  [ApiController] bunu otomatik yapıyor
            return adm;

        }

        // GET api/<AdminApi>/5
        [HttpGet("{id}")]
        public ActionResult<AdminModel> Get(int? id)
        {

            if (id is null)
            {
                return NotFound();
            }
            var y = c.Admins.FirstOrDefault(z => z.IdAdmin == id);
            if (y == null)
            {
                return NotFound();
            }
            return y;
        }


        // POST api/<AdminApi>
        [HttpPost]
        public IActionResult Post([FromBody] AdminModel adm)
        {
            c.Admins.Add(adm);
            c.SaveChanges();
            return Ok(adm);
        }

        // PUT api/<AdminApi>/5
        [HttpPut("{id}")]
        public IActionResult Put(int? id, [FromBody] AdminModel adm)
        {

            if (id is null)
            {
                return NotFound();
            }

            var y1 = c.Admins.FirstOrDefault(x => x.IdAdmin == id);

            if (y1 is null)
            {
                return NotFound();

            }
            else
            {   
                y1.Name = adm.Name;
                y1.email = adm.email;
                y1.Password = adm.Password;
                c.Update(y1);
                c.SaveChanges();
                return Ok();

            }

        }

        // DELETE api/<AdminApi>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var a = c.Admins.FirstOrDefault(s => s.IdAdmin == id);

            if (a is null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(a);
                c.SaveChanges();
                return Ok();
            }
        }
    }
}
