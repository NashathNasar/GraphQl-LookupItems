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

        public DbSet<Origin> Origins { get; set; }
    }


    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

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

    public class Origin
    {

        public int OriginId { get; set; }

        public string OriginName { get; set; }

        public string OriginCode { get; set; }
    }

}
