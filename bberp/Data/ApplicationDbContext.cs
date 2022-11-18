using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BBERP.Models;

namespace BBERP.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<BBERP.Models.ApplicationUser> ApplicationUser { get; set; }

        public DbSet<BBERP.Models.Bill> Bill { get; set; }

        public DbSet<BBERP.Models.BillType> BillType { get; set; }

        public DbSet<BBERP.Models.Branch> Branch { get; set; }

        public DbSet<BBERP.Models.CashBank> CashBank { get; set; }
        

        public DbSet<BBERP.Models.Currency> Currency { get; set; }

        public DbSet<BBERP.Models.Customer> Customer { get; set; }

        public DbSet<BBERP.Models.CustomerType> CustomerType { get; set; }

        public DbSet<BBERP.Models.GoodsReceivedNote> GoodsReceivedNote { get; set; }

        public DbSet<BBERP.Models.Invoice> Invoice { get; set; }

        public DbSet<BBERP.Models.InvoiceType> InvoiceType { get; set; }

        public DbSet<BBERP.Models.NumberSequence> NumberSequence { get; set; }

        public DbSet<BBERP.Models.PaymentReceive> PaymentReceive { get; set; }

        public DbSet<BBERP.Models.PaymentType> PaymentType { get; set; }

        public DbSet<BBERP.Models.PaymentVoucher> PaymentVoucher { get; set; }

        public DbSet<BBERP.Models.Product> Product { get; set; }

        public DbSet<BBERP.Models.RawMaterial> RawMaterial { get; set; }

        public DbSet<BBERP.Models.ProductType> ProductType { get; set; }

        public DbSet<BBERP.Models.PurchaseOrder> PurchaseOrder { get; set; }

        public DbSet<BBERP.Models.PurchaseOrderLine> PurchaseOrderLine { get; set; }

        public DbSet<BBERP.Models.PurchaseType> PurchaseType { get; set; }

        public DbSet<BBERP.Models.SalesOrder> SalesOrder { get; set; }

        public DbSet<BBERP.Models.SalesOrderLine> SalesOrderLine { get; set; }

        public DbSet<BBERP.Models.SalesType> SalesType { get; set; }

        public DbSet<BBERP.Models.Shipment> Shipment { get; set; }

        public DbSet<BBERP.Models.ShipmentType> ShipmentType { get; set; }

        public DbSet<BBERP.Models.UnitOfMeasure> UnitOfMeasure { get; set; }

        public DbSet<BBERP.Models.Vendor> Vendor { get; set; }

        public DbSet<BBERP.Models.VendorType> VendorType { get; set; }

        public DbSet<BBERP.Models.Warehouse> Warehouse { get; set; }

        public DbSet<BBERP.Models.UserProfile> UserProfile { get; set; }

        public DbSet<BBERP.Models.CountryMaster> CountryMaster { get; set; }
    }
}
