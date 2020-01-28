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
    public class ProvincesController : ControllerBase
    {
        private readonly ProvinceCityDBContext _context;

        public ProvincesController(ProvinceCityDBContext context)
        {
            _context = context;
        }

        // GET: api/Provinces
        [HttpGet]
        public async Task<OutputProvince> GetProvince()
        {
            OutputProvince output = new OutputProvince();

            var query = new query
            {
                id = ""
            };

            //return await _context.Province.ToListAsync();
            var dtProvince = _context.Province.ToList();

            if (dtProvince != null)
            {
                var status = new status
                {
                    code = 200,
                    description = "OK"
                };

                var resultProvince = new ResultProvince
                {
                    query = query,
                    status = status,
                    result = dtProvince
                };

                output.Province = resultProvince;
            }
            else
            {
                var status = new status
                {
                    code = 404,
                    description = "Not Found"
                };

                var resultProvince = new ResultProvince
                {
                    query = query,
                    status = status,
                    result = dtProvince
                };

                output.Province = resultProvince;
            }

            return output;
        }

        [HttpGet("{provinceName}")]
        public async Task<ActionResult<OutputProvince>> GetProvince(string provinceName)
        {
            OutputProvince output = new OutputProvince();

            var query = new query
            {
                key = provinceName
            };

            var dtProvince = _context.Province.Where(p => p.province == provinceName).FirstOrDefault();

            if(dtProvince != null)
            {
                var status = new status
                {
                    code = 200,
                    description = "OK"
                };

                var resultProvince = new ResultProvince
                {
                    query = query,
                    status = status,
                    result = dtProvince
                };

                output.Province = resultProvince;
            }
            else
            {
                var status = new status
                {
                    code = 404,
                    description = "Not Found"
                };

                var resultProvince = new ResultProvince
                {
                    query = query,
                    status = status,
                    result = dtProvince
                };

                output.Province = resultProvince;
            }

            return output;
        }

        // GET: api/Provinces/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Province>> GetProvince(int id)
        //{
        //    var province = await _context.Province.FindAsync(id);

        //    if (province == null)
        //    {
        //        return NotFound();
        //    }

        //    return province;
        //}

        // PUT: api/Provinces/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvince(int id, Province province)
        {
            if (id != province.province_id)
            {
                return BadRequest();
            }

            _context.Entry(province).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvinceExists(id))
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

        // POST: api/Provinces
        [HttpPost]
        public async Task<ActionResult<Province>> PostProvince(Province province)
        {
            _context.Province.Add(province);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProvince", new { id = province.province_id }, province);
        }

        // DELETE: api/Provinces/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Province>> DeleteProvince(int id)
        {
            var province = await _context.Province.FindAsync(id);
            if (province == null)
            {
                return NotFound();
            }

            _context.Province.Remove(province);
            await _context.SaveChangesAsync();

            return province;
        }

        private bool ProvinceExists(int id)
        {
            return _context.Province.Any(e => e.province_id == id);
        }
    }
}
