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
    [Route("api/Product")]
    public class RawMaterialController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RawMaterialController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RawMaterial
        [HttpGet]
        public async Task<IActionResult> GetRawMaterial()
        {
            List<RawMaterial> Items = await _context.RawMaterial.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }



        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<RawMaterial> payload)
        {
            RawMaterial RawMaterial = payload.value;
            _context.RawMaterial.Add(RawMaterial);
            _context.SaveChanges();
            return Ok(RawMaterial);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<RawMaterial> payload)
        {
            RawMaterial RawMaterial = payload.value;
            _context.RawMaterial.Update(RawMaterial);
            _context.SaveChanges();
            return Ok(RawMaterial);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<RawMaterial> payload)
        {
            RawMaterial RawMaterial = _context.RawMaterial
                .Where(x => x.MaterialId == (int)payload.key)
                .FirstOrDefault();
            _context.RawMaterial.Remove(RawMaterial);
            _context.SaveChanges();
            return Ok(RawMaterial);

        }
    }
}