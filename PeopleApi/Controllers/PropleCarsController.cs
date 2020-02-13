using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleApi.Model;

namespace PeopleApi.Controllers
{
    [Route("api/people/{personId:int}/cars")]
    [ApiController]
    public class PropleCarsController : ControllerBase
    {
        private readonly DataContext _context;

        public PropleCarsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PropleCars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCarList(int personId)
        {
            var person = await _context.PersonList.FindAsync(personId);
            if (person == null)
            {
                return NotFound();
            }
            return await _context.CarList.Where(x => x.OwnderId == personId).ToListAsync();
        }

        // GET: api/PropleCars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _context.CarList.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/PropleCars/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PropleCars
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(int personId, Car car)
        {
            var person = await _context.PersonList.FindAsync(personId);
            if (personId == null)
            {
                return NotFound();
            }
            car.OwnderId = personId;
            _context.CarList.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCar", new {personId, id = car.Id }, car);
        }

        // DELETE: api/PropleCars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> DeleteCar(int id)
        {
            var car = await _context.CarList.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.CarList.Remove(car);
            await _context.SaveChangesAsync();

            return car;
        }

        private bool CarExists(int id)
        {
            return _context.CarList.Any(e => e.Id == id);
        }
    }
}
