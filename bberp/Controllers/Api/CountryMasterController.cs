using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BBERP.Data;
using BBERP.Models;
using BBERP.Models.SyncfusionViewModels;
using Microsoft.AspNetCore.Authorization;

namespace BBERP.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/CountryMaster")]
    public class CountryMasterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountryMasterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CountryMaster
        [HttpGet]
        public async Task<IActionResult> GetCountryMaster()
        {
            List<CountryMaster> Items = await _context.CountryMaster.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<CountryMaster> Countrymaster)
        {
            CountryMaster countrymaster = Countrymaster.value;
            _context.CountryMaster.Add(countrymaster);
            _context.SaveChanges();
            return Ok(countrymaster);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<CountryMaster> Countrymaster)
        {
            CountryMaster countrymaster = Countrymaster.value;
            _context.CountryMaster.Update(countrymaster);
            _context.SaveChanges();
            return Ok(countrymaster);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<CountryMaster> Countrymaster)
        {
            CountryMaster countrymaster = _context.CountryMaster
                .Where(x => x.Id == (int)Countrymaster.key)
                .FirstOrDefault();
            _context.CountryMaster.Remove(countrymaster);
            _context.SaveChanges();
            return Ok(countrymaster);

        }
    }
}