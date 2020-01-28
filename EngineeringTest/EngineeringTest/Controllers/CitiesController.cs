using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EngineeringTest.Models;

namespace EngineeringTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ProvinceCityDBContext _context;

        public CitiesController(ProvinceCityDBContext context)
        {
            _context = context;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<OutputCity> GetCity()
        {
            OutputCity output = new OutputCity();

            var query = new query
            {
                id = ""
            };

            var dtCity = (from c in _context.City
                          join p in _context.Province on c.province_id equals p.province_id
                          select new
                          {
                              c.city_id,
                              p.province_id,
                              p.province,
                              c.type,
                              c.city_name,
                              c.postal_code
                          });

            if (dtCity != null)
            {
                var status = new status
                {
                    code = 200,
                    description = "OK"
                };

                var pc = new ResultCity
                {
                    query = query,
                    status = status,
                    result = dtCity
                };

                output.City = pc;
            }
            else
            {
                var status = new status
                {
                    code = 404,
                    description = "Not Found"
                };

                var resultCity = new ResultCity
                {
                    query = query,
                    status = status,
                    result = dtCity
                };

                output.City = resultCity;
            }

            return output;
        }

        [HttpGet("{cityName}")]
        public async Task<ActionResult<OutputCity>> GetCity(string cityName)
        {
            OutputCity output = new OutputCity();

            var query = new query
            {
                id = ""
            };

            var dtCity = (from c in _context.City
                          join p in _context.Province on c.province_id equals p.province_id
                          where c.city_name == cityName
                          select new
                          {
                              c.city_id,
                              p.province_id,
                              p.province,
                              c.type,
                              c.city_name,
                              c.postal_code
                          });

            if (dtCity != null)
            {
                var status = new status
                {
                    code = 200,
                    description = "OK"
                };

                var pc = new ResultCity
                {
                    query = query,
                    status = status,
                    result = dtCity
                };

                output.City = pc;
            }
            else
            {
                var status = new status
                {
                    code = 404,
                    description = "Not Found"
                };

                var resultCity = new ResultCity
                {
                    query = query,
                    status = status,
                    result = dtCity
                };

                output.City = resultCity;
            }

            return output;
        }

        // GET: api/Cities/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<City>> GetCity(int id)
        //{
        //    var city = await _context.City.FindAsync(id);

        //    if (city == null)
        //    {
        //        return NotFound();
        //    }

        //    return city;
        //}

        // PUT: api/Cities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(int id, City city)
        {
            if (id != city.city_id)
            {
                return BadRequest();
            }

            _context.Entry(city).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
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

        // POST: api/Cities
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(City city)
        {
            _context.City.Add(city);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCity", new { id = city.city_id }, city);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<City>> DeleteCity(int id)
        {
            var city = await _context.City.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            _context.City.Remove(city);
            await _context.SaveChangesAsync();

            return city;
        }

        private bool CityExists(int id)
        {
            return _context.City.Any(e => e.city_id == id);
        }
    }
}
