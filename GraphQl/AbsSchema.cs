
using FirstGrphql.Data;
using GraphQL.Language.AST;
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
            Field<ListGraphType<InvoiceType>>("invoicetype", resolve: context => repository.GetInvoicesTypesAsync());
            Field<ListGraphType<PaymentTermType>>("paymentterms", resolve: context => repository.GetPaymentTermsAsync());
            Field<ListGraphType<ProductGroupType>>("productgroups", resolve: context => repository.GetProductGroupsAsync());
            Field<ListGraphType<OriginType>>("origins", resolve: context => repository.GetOriginsAsync());
            Field<ListGraphType<ProductUnitType>>("productunits", resolve: context => repository.GetProductUnitsAsync());
            Field<ListGraphType<DeliveryMovementType>>("deliverymovementtypes", resolve: context => repository.GetDeliveryMovementTypesAsync());
            Field<ListGraphType<ProjectType>>("projects", resolve: context => repository.GetProjectsAsync());
            Field<ListGraphType<ProjectType>>("projectsbycustomer",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "CustomerId" }),
                resolve: context =>
                {
                    var customerId = context.GetArgument<int>("CustomerId");
                    return repository.GetProjectsAsync(customerId);
                });

            Field<ListGraphType<DeliveryTypeType>>("deliverytypes",
            arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "MovementTypeId" }),
            resolve: context =>
            {

                var movementtypeId = context.GetArgument<int>("MovementTypeId");

                return repository.GetDeliveryTypesAsync(movementtypeId);


            });



        }
        public class CustomerType : ObjectGraphType<Customer>
        {
            public CustomerType()
            {
                base.Field(x => x.CustomerId);
                base.Field(x => x.CustomerName);
            }
        }

        public class ProjectType : ObjectGraphType<Project>
        {
            public ProjectType()
            {

                base.Field(x => x.ProjectId);
                base.Field(x => x.ProjectName);
                base.Field(x => x.CustomerId);

            }
        }

        public class ChargingTypeType : ObjectGraphType<ChargingType>
        {
            public ChargingTypeType()
            {


                base.Field(x => x.ChargingTypeId);
                base.Field(x => x.ChargingTypeName);
            }
        }


        public class DivisionType : ObjectGraphType<Division>
        {
            public DivisionType()
            {

                base.Field(x => x.DivisionId);
                base.Field(x => x.DivisionName);

            }
        }

        public class InvoicedByType : ObjectGraphType<InvoicedBy>
        {
            public InvoicedByType()
            {
                base.Field(x => x.InvoicedById);
                base.Field(x => x.InvoicedByName);
            }
        }

        public class InvoiceType: ObjectGraphType<InvoicesType>
        {
            public InvoiceType()
            {
                base.Field(x => x.InvoiceTypeId);
                base.Field(x => x.InvoiceType);

            }



        }

        public class PaymentTermType : ObjectGraphType<PaymentTerm>
        {
            public PaymentTermType()
            {
                base.Field(x => x.PaymentTermId);
                base.Field(x => x.PaymentTermName);
            }
        }
        public class ProductGroupType : ObjectGraphType<ProductGroup>
        {
            public ProductGroupType()
            {
                base.Field(x => x.ProductGroupId);
                base.Field(x => x.ProductGroupName);
            }


        }
        public class OriginType : ObjectGraphType<Origin>
        {
            public OriginType()
            {
                base.Field(x => x.OriginId);
                base.Field(x => x.OriginName);
            }
        }

        public class ProductUnitType : ObjectGraphType<ProductUnit>
        {
            public ProductUnitType()
            {
                base.Field(x => x.UnitId);
                base.Field(x => x.Unit)
    ;
            }
        }

        public class DeliveryMovementType : ObjectGraphType<DeliveryMovementsType>
        {

            public DeliveryMovementType()
            {
                base.Field(x => x.MovementTypeId);
                base.Field(x => x.MovementType);

            }



        }

        public class DeliveryTypeType : ObjectGraphType<DeliveryType>
        {

            public DeliveryTypeType()
            {
                base.Field(x => x.DeliveryTypeId);
                base.Field(x => x.DeliveryTypeName);
                base.Field(x => x.MovementTypeId);
            }




        }
        public interface ILookupItem
        {
            int Id { get; set; }
            string Name { get; set; }
        }


        public class LookupItemType<T> : ObjectGraphType<T> where T : ILookupItem
        {
            public LookupItemType()
            {
                base.Field(x => x.Id);
                base.Field(x => x.Name);
            }
        }

        public class ByteArrayGraphType : ScalarGraphType
        {
            public ByteArrayGraphType()
            {
                Name = "ByteArray";
                Description = "Byte Array For RowVersion";
            }

            public override object ParseLiteral(IValue value)
            {
                if (value is StringValue v)
                {
                    return ParseValue(value);
                }
                return null;
            }

            public override object ParseValue(object value)
            {
                return Convert.ToBase64String(value as byte[]);
            }

            public override object Serialize(object value)
            {
                return ParseValue(value);
            }
        }

    }
}