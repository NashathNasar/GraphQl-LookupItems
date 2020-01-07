using FirstGrphql.GraphQl;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FirstGrphql.Data
{
    public class AbsContext :DbContext
    {


        public AbsContext(DbContextOptions<AbsContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers{ get; set; }
        public DbSet<ChargingType> ChargingTypes { get; set; }

        public DbSet<Division> Divisions { get; set; }

        public DbSet<InvoicedBy> InvoicedBy { get; set; }
        public DbSet<PaymentTerm> PaymentTerms { get; set; }

        public DbSet<ProductGroup> ProductGroups { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductUnit> ProductUnits { get; set; }
        public DbSet<Origin> Origins { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<DeliveryMovementsType> DeliveryMovementTypes { get; set; }


        public DbSet<ReceiptsMovementType> ReceiptMovementTypes { get; set; }
        public DbSet<DeliveryType> DeliveryTypes { get; set; }

        public DbSet<ReceiptsType> ReceiptTypes { get; set; }

        public DbSet<InvoicesType> InvoiceTypes { get; set; }


        public DbSet<OrderApprover> OrderApprovers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeliveryMovementsType>(entity =>
            {
                entity.HasKey(x => x.MovementTypeId);
            });

            modelBuilder.Entity<ReceiptsMovementType>(entity =>
            {
                entity.HasKey(x => x.MovementTypeId);
            });
            modelBuilder.Entity<InvoicesType>(entity =>

            {
                entity.HasKey(x => x.InvoiceTypeId);

            });
            modelBuilder.Entity<ReceiptsType>(entity =>
            {
                entity.HasKey(x => x.ReceiptTypeId);
            });
            modelBuilder.Entity<OrderApprover>(entity =>
            {
                entity.HasKey(x => x.ApprovedById);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {

                entity.HasKey(x => x.CategoryId);            
            
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(x => x.ProjectId);
            });

            modelBuilder.Entity<ProductUnit>(entity=> 
            {
                entity.HasKey(x => x.UnitId);
            });
        }
    }


    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

    }


    public class Project
    {
        public int ProjectId { get; set; }

        public int CustomerId { get; set; }

        public string ProjectName { get; set; }

    }
    public class ChargingType
    {



        public int ChargingTypeId { get; set; }

        public string ChargingTypeName { get; set; }




    }

    public class Division
    {

        public int DivisionId { get; set; }

        public string DivisionName { get; set; }



    }
    public class InvoicedBy
    {


        public int InvoicedById { get; set; }

        public string InvoicedByName { get; set; }


    }


    public class PaymentTerm
    {

        public int PaymentTermId { get; set; }


        public string PaymentTermName { get; set; }



    }

    public class ProductGroup
    {


        public int ProductGroupId { get; set; }
        public string ProductGroupName { get; set; }


    }

    public class ProductCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }


        public int ProductGroupId { get; set; }

    }

    public class Product
    {
      public int ProductId { get; set; }
      public string ProductName { get; set; }
      public int CategoryId { get; set; }

    }

    public class DeliveryMovementsType
    {


        public int MovementTypeId { get; set; }

        public string MovementType { get; set; }

    }


    public class ReceiptsMovementType
    {
        public int MovementTypeId { get; set; }

        public string MovementType { get; set; }
    }

    public class ReceiptsType
    {

        public int ReceiptTypeId { get; set; }
        public string ReceiptTypeName { get; set; }
        public int MovementTypeId { get; set; }
    }

    public class DeliveryType
    {
        public int DeliveryTypeId { get; set; }

        public string DeliveryTypeName { get; set; }

        public int MovementTypeId { get; set; }


    }

    public class ProductUnit
    {
        public int UnitId { get; set; }
        public string Unit { get; set; }
    }
    public class Origin
    {

        public int OriginId { get; set; }

        public string OriginName { get; set; }

        public string OriginCode { get; set; }
    }

    public class InvoicesType
    {


        public int InvoiceTypeId { get; set; }
        public string InvoiceType { get; set; }
    }

    public class OrderApprover
    {
        public int ApprovedById { get; set; }
        public string ApprovedBy { get; set; }

    }

}
