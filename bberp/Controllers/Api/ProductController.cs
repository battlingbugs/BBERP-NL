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
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IConfiguration Configuration;
        public string con = null;
        SqlConnection conn;
        public ProductController(ApplicationDbContext context, IConfiguration _configuration)
        {
            _context = context;
            Configuration = _configuration;
            con = this.Configuration.GetConnectionString("DefaultConnection");
            conn = new SqlConnection(con);
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            //List<Product> Items = await _context.Product.ToListAsync();
            DataTable dtcust = new DataTable();
            dtcust = Common.ExecuteDataTableSqlDA(conn, CommandType.StoredProcedure, "IM_GetProd", null);
            List<Product> Items = new List<Product>();
            foreach (DataRow dc in dtcust.Rows)
            {
                Product prod = new Product();
                prod.ProductId = Convert.ToInt32(dc["ProductId"]);
                prod.BranchId = Convert.ToInt32(dc["BranchId"]);
                prod.CurrencyId = Convert.ToInt32(dc["CurrencyId"]);
                prod.Description = Convert.ToString(dc["Description"]);
                prod.ProductCode = Convert.ToString(dc["ProductCode"]);
                prod.ProductImageUrl = Convert.ToString(dc["ProductImageUrl"]);
                prod.ProductName = Convert.ToString(dc["ProductName"]);
                prod.GrossWt = Convert.ToDecimal(dc["GrossWt"]);
                
                Items.Add(prod);
                

    }
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }



        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<Product> payload)
        {
            //IM_SaveProd
            Product product = payload.value;
            SqlParameter[] parms = new SqlParameter[7];
        
            parms[0] = new SqlParameter("@BranchId", product.BranchId);
            parms[1] = new SqlParameter("@CurrencyId", product.CurrencyId);
            parms[2] = new SqlParameter("@Description", product.Description);
            parms[3] = new SqlParameter("@ProductCode", product.ProductCode);
            parms[4] = new SqlParameter("@ProductImageUrl", product.ProductImageUrl);
            parms[5] = new SqlParameter("@ProductName", product.ProductName);
            parms[6] = new SqlParameter("@GrossWt", product.GrossWt);
            Common.ExecuteNonQuery(conn, CommandType.StoredProcedure, "IM_SaveProd", parms);
            //Product product = payload.value;
            //_context.Product.Add(product);
            //_context.SaveChanges();
            return Ok(product);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<Product> payload)
        {
            //Product product = payload.value;
            //_context.Product.Update(product);
            //_context.SaveChanges();
            Product product = payload.value;
            SqlParameter[] parms = new SqlParameter[8];
            parms[0] = new SqlParameter("@ProductId", product.ProductId);
            parms[1] = new SqlParameter("@BranchId", product.BranchId);
            parms[2] = new SqlParameter("@CurrencyId", product.CurrencyId);
            parms[3] = new SqlParameter("@Description", product.Description);
            parms[4] = new SqlParameter("@ProductCode", product.ProductCode);
            parms[5] = new SqlParameter("@ProductImageUrl", product.ProductImageUrl);
            parms[6] = new SqlParameter("@ProductName", product.ProductName);
            parms[7] = new SqlParameter("@GrossWt", product.GrossWt);
            Common.ExecuteNonQuery(conn, CommandType.StoredProcedure, "IM_UpdateProd", parms);
            return Ok(product);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<Product> payload)
        {
            //Product product = new Product();
            //product.ProductId = (Int32)payload.key;
                //_context.Product
            //    .Where(x => x.ProductId == (int)payload.key)
            //    .FirstOrDefault();
            //_context.Product.Remove(product);
            //_context.SaveChanges();
            //Product product = payload.key;
            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter("@ProductId", Convert.ToInt32(payload.key));
            
            Common.ExecuteNonQuery(conn, CommandType.StoredProcedure, "IM_DeleteProd", parms);
            return Ok();

        }
    }
}