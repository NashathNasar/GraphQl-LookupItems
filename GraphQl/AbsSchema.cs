
using FirstGrphql.Data;
using GraphQL.Types;
using GraphQL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstGrphql.GraphQl
{
    public class AbsSchema : Schema
    {
        public AbsSchema(IServiceProvider services) : base(services)
        {
            Query = services.GetRequiredService<AbsQuery>();
        }
    }

    public class AbsQuery : ObjectGraphType
    {
       public AbsQuery(ILookupItemRepository repository)
        {
            Field<ListGraphType<CustomerType>>("customers", resolve: context => repository.GetCustomersAsync());
            Field<ListGraphType<ChargingTypeType>>("chargingtypes", resolve: context => repository.GetChargingTypesAsync());
            Field<ListGraphType<DivisionType>>("division", resolve: context => repository.GetDivisionsAsync());
            Field<ListGraphType<InvoicedByType>>("invoicedby", resolve: context => repository.GetInvoicedBysAsync());
            Field<ListGraphType<PaymentTermType>>("paymentterms", resolve: context => repository.GetPaymentTermsAsync());
            Field<ListGraphType<ProductGroupType>>("productgroups", resolve: context => repository.GetProductGroupsAsync());
            Field<ListGraphType<OriginType>>("origins", resolve: context => repository.GetOriginsAsync());


        }
    }
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field(x => x.CustomerId);
            Field(x => x.CustomerName);
        }
    }
    
    public class ChargingTypeType: ObjectGraphType<ChargingType>
    {
        public ChargingTypeType()
        {


            Field(x => x.ChargingTypeId);
            Field(x => x.ChargingTypeName);
        }
    }


    public class DivisionType : ObjectGraphType<Division>
    {
        public DivisionType()
        {

            Field(x => x.DivisionId);
            Field(x => x.DivisionName);

        }
    }

    public class InvoicedByType : ObjectGraphType<InvoicedBy>
    {
        public InvoicedByType()
        {
            Field(x => x.InvoicedById);
            Field(x => x.InvoicedByName);
        }
    }
    public class PaymentTermType : ObjectGraphType<PaymentTerm>
    {
        public PaymentTermType()
        {
            Field(x => x.PaymentTermId);
            Field(x => x.PaymentTermName);
        }
    }
    public  class ProductGroupType: ObjectGraphType<ProductGroup>
    {
        public ProductGroupType()
        {
            Field(x => x.ProductGroupId);
            Field(x => x.ProductGroupName);
        }


    }
    public class OriginType : ObjectGraphType<Origin>
    {
        public OriginType()
        {
            Field(x => x.OriginId);
            Field(x => x.OriginName);
        }
    }



    public interface ILookupItem
    {
        int Id { get; set; }
        string Name { get; set; }
    }


    public class LookupItemType<T>:ObjectGraphType<T> where T : ILookupItem
    {
        public LookupItemType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
        }
    }

}
