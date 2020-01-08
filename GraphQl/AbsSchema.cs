
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
            Field<ListGraphType<OrderApproverType>>("orderapprover", resolve: context => repository.GetOrderApproversAsync());
            Field<ListGraphType<ProductUnitType>>("productunits", resolve: context => repository.GetProductUnitsAsync());
            Field<ListGraphType<ReceiptMovementType>>("receiptmovementtypes", resolve: context => repository.GetReceiptsMovementTypesAsync());
            Field<ListGraphType<ReceivedDivisionType>>("receiveddivisions", resolve: context => repository.GetReceivedDivisonsAsync());
            Field<ListGraphType<DeliveryMovementType>>("deliverymovementtypes", resolve: context => repository.GetDeliveryMovementTypesAsync());
            Field<ListGraphType<ProductCategoryType>>("productcategories", resolve: context => repository.GetProductCategoriesAsync());
            Field<ListGraphType<ProductCategoryType>>("productcategoriesbygroup",
                 arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "ProductGroupId" }),
                resolve: context =>
                {
                    var productgroupId = context.GetArgument<int>("ProductGroupId");
                    return repository.GetProductCategoriesAsync(productgroupId);
                });

            Field<ListGraphType<ProductType>>("products", resolve: context => repository.GetProductsAsync());
            Field<ListGraphType<ProductType>>("productbycategories",
                 arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "CategoryId" }),
                resolve: context =>
                {
                    var categoryId = context.GetArgument<int>("CategoryId");
                    return repository.GetProductsAsync(categoryId);
                });

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
            Field<ListGraphType<SubOrderType>>("suborders",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "SalesOrderID" }),
                resolve: context =>
                {
                    var salesorderId = context.GetArgument<int>("SalesOrdrId");
                    return repository.GetSubOrdersAsync(salesorderId);

                });
            Field<ListGraphType<SalesOrderType>>("salesordertypes",
              arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "CustomerId" }),
              resolve: context =>
              {
                  var customerId = context.GetArgument<int>("CustomerId");
                  return repository.GetSalesOrdersAsync(customerId);
              });
            Field<ListGraphType<ReceiptType>>("receipttypes",
           arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "MovementTypeId" }),
           resolve: context =>
           {

               var movementtypeId = context.GetArgument<int>("MovementTypeId");

               return repository.GetReceiptsTypesAsync(movementtypeId);


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

        public class ProductCategoryType: ObjectGraphType<ProductCategory>
        {
            public ProductCategoryType()
            {
                base.Field(x => x.CategoryId);
                base.Field(x => x.CategoryName);
                base.Field(x => x.ProductGroupId);

            }
        }

        public class ProductType: ObjectGraphType<Product>
        {

            public ProductType()
            {
                base.Field(x => x.ProductId);
                base.Field(x => x.ProductName);
                base.Field(x => x.CategoryId);
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

        public class ReceiptMovementType: ObjectGraphType<ReceiptsMovementType>
        {
            public ReceiptMovementType()
            {
                base.Field(x => x.MovementTypeId);
                base.Field(x => x.MovementType);
            }
        }
        public class OrderApproverType: ObjectGraphType<OrderApprover>
        {
            public OrderApproverType()
            {
                base.Field(x => x.ApprovedById);
                base.Field(x => x.ApprovedBy);
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

        public class ReceiptType :ObjectGraphType<ReceiptsType>
        {

            public ReceiptType()
            {

                base.Field(x => x.ReceiptTypeId);
                base.Field(x => x.ReceiptTypeName);
                base.Field(x => x.MovementTypeId);

            }
        }


        public class ReceivedDivisionType: ObjectGraphType<ReceivedDivison>
        {


            public ReceivedDivisionType()
            {

                base.Field(x => x.ReceivedById);
                base.Field(x => x.ReceivedBy);
            }






        }
        public class SalesOrderType : ObjectGraphType<SalesOrder>
        {
            public SalesOrderType()
            {

                base.Field(x => x.SalesOrderId);
                base.Field(x => x.OurOrderRef);
                base.Field(x => x.CustomerId);






            }


        }
        public class SubOrderType: ObjectGraphType<SubOrder>
        {
            public SubOrderType()
            {
                base.Field(x => x.SubOrderId);
                base.Field(x => x.Reference);
                base.Field(x => x.SalesOrderId);

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