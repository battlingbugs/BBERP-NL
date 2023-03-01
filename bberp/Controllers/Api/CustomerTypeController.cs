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
using Microsoft.Extensions.Configuration;
using System.Data;
using bberp.Data;
using System.Data.SqlClient;

namespace BBERP.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/CustomerType")]
    public class CustomerTypeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IConfiguration Configuration;
        public string con = null;
        SqlConnection conn;
        public CustomerTypeController(ApplicationDbContext context, IConfiguration _configuration)
        {
            _context = context;
            Configuration = _configuration;
            con = this.Configuration.GetConnectionString("DefaultConnection");
            conn = new SqlConnection(con);
        }

        // GET: api/CustomerType
        [HttpGet]
        public async Task<IActionResult> GetCustomerType()
        {
            DataTable dtcusttype = new DataTable();
            
            dtcusttype = Common.ExecuteDataTableSqlDA(conn, CommandType.StoredProcedure, "IM_GetCustType", null);
            List<CustomerType> Items = Common.BindList<CustomerType>(dtcusttype);
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }



        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<CustomerType> payload)
        {
            CustomerType customerType = payload.value;
            _context.CustomerType.Add(customerType);
            _context.SaveChanges();
            return Ok(customerType);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<CustomerType> payload)
        {
            CustomerType customerType = payload.value;
            _context.CustomerType.Update(customerType);
            _context.SaveChanges();
            return Ok(customerType);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<CustomerType> payload)
        {
            CustomerType customerType = _context.CustomerType
                .Where(x => x.CustomerTypeId == (int)payload.key)
                .FirstOrDefault();
            _context.CustomerType.Remove(customerType);
            _context.SaveChanges();
            return Ok(customerType);

        }
    }
}