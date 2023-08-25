using BikeFactory2.Models;
using BikeFactory2.Data;
using BikeFactory2.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeFactory2.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeController : ControllerBase
    {
        private readonly BikeFactoryContext _context;

        public BikeController(BikeFactoryContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Bikes>> GetList(EBikeCriteria criteria)
        {
            var value = (int)criteria;

            if (criteria == EBikeCriteria.All)
                return _context.Bikes.ToList();
            //else if (criteria == EBikeCriteria.Front)
            //    return _context.Bikes.Where(x => x.SuspensionType == 1).ToList();
            //else if (criteria == EBikeCriteria.Rear)
            //    return _context.Bikes.Where(x => x.SuspensionType == 2).ToList();
            else return _context.Bikes.Where(x => x.SuspensionType == value).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Bikes?> SearchById(int id)
        {
            var result = _context.Bikes.Find(id);
            return result;
        }
        [HttpPut]
        public IActionResult Update(Bikes bike)
        {
            _context.Update(bike);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult Insert(Bikes bike)
        {

            _context.Bikes.Add(bike);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var bike = new Bikes() { Id = id };
            _context.Bikes.Remove(bike);
            _context.SaveChanges();
            return Ok();
        }
    }
}
