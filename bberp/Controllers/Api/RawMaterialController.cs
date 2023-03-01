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
using System.Data;
using bberp.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BBERP.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/RawMaterial")]
    public class RawMaterialController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IConfiguration Configuration;
        public string con = null;
        SqlConnection conn;

        public RawMaterialController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RawMaterial
        [HttpGet]
        public async Task<IActionResult> GetRawMaterial()
        {
            //List<RawMaterial> Items = await _context.RawMaterial.ToListAsync();

            DataTable dtRawMaterial = new DataTable();
            dtRawMaterial = Common.ExecuteDataTableSqlDA(conn, CommandType.StoredProcedure, "IM_GetRawMaterial", null);
            List<RawMaterial> Items = new List<RawMaterial>();
            foreach (DataRow dc in dtRawMaterial.Rows)
            {
                RawMaterial prod = new RawMaterial();
                prod.MaterialId = Convert.ToInt32(dc["MaterialId"]);
                prod.MaterialName = Convert.ToString(dc["MaterialName"]);
                prod.MaterialCode = Convert.ToString(dc["MaterialCode"]);
                prod.Description = Convert.ToString(dc["Description"]);
                prod.GrossWt = Convert.ToDecimal(dc["GrossWt"]);
                prod.BranchId = Convert.ToInt32(dc["BranchId"]);
                

                Items.Add(prod);
              

    }

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