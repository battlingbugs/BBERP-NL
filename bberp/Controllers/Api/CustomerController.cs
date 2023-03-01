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
    [Route("api/Customer")]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IConfiguration Configuration;
        public string con = null;
        SqlConnection conn;
        public CustomerController(ApplicationDbContext context, IConfiguration _configuration)
        {
            _context = context;
            Configuration = _configuration;
            con = this.Configuration.GetConnectionString("DefaultConnection");
            conn = new SqlConnection(con);
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            DataTable dtcust = new DataTable();
            dtcust = Common.ExecuteDataTableSqlDA(conn, CommandType.StoredProcedure, "IM_GetCust", null);
            List<Customer> Items = new List<Customer>();
            foreach (DataRow dc in dtcust.Rows)
            {
                Customer cust = new Customer();
                cust.CustomerId =Convert.ToInt32(dc["CustomerId"]);
                cust.Address = Convert.ToString(dc["Address"]);
                cust.City = Convert.ToString(dc["City"]);
                cust.ContactPerson = Convert.ToString(dc["ContactPerson"]);
                cust.CustomerName = Convert.ToString(dc["CustomerName"]);
                cust.CustomerTypeId = Convert.ToInt32(dc["CustomerTypeId"]);
                cust.Email = Convert.ToString(dc["Email"]);
                cust.Phone = Convert.ToString(dc["Phone"]);
                cust.State = Convert.ToString(dc["State"]);
                cust.ZipCode = Convert.ToString(dc["ZipCode"]);
                Items.Add(cust);
                
            }

            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<Customer> payload)
        {
            Customer customer = payload.value;
            _context.Customer.Add(customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<Customer> payload)
        {
            Customer customer = payload.value;
            _context.Customer.Update(customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<Customer> payload)
        {
            Customer customer = _context.Customer
                .Where(x => x.CustomerId == (int)payload.key)
                .FirstOrDefault();
            _context.Customer.Remove(customer);
            _context.SaveChanges();
            return Ok(customer);

        }
    }
}