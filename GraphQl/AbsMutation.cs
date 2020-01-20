using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;
using System.Xml;
using FirstGrphql.Data;
using System.Threading.Tasks;

//using  FirstGrphql.GraphQl.AbsQuery;
using GraphQL;

namespace FirstGrphql.GraphQl
{
    public class AbsMutation : ObjectGraphType
    {


        public AbsMutation (ILookupItemRepository lookupItemRepository)
        {


            FieldAsync<AbsQuery.ProductType>(
               "createProduct",
               arguments: new QueryArguments(
                   new QueryArgument<NonNullGraphType<ProductReviewInputType>> { Name = "product" }),
               resolve: async context =>
               {
                   var product = context.GetArgument<Product>("product");
                   return await context.TryAsyncResolve(
                  async c => await lookupItemRepository.AddNewInput(product));

               });
            FieldAsync<AbsQuery.ProductType>(
             "updateProduct",
             arguments: new QueryArguments(
                 new QueryArgument<NonNullGraphType<ProductReviewInputType>> { Name = "product" },
                  new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "productId" }),
             resolve: async context =>
             {
                 var product = context.GetArgument<Product>("product");
                 var productId = context.GetArgument<int>("productId");
                 var dbProduct = lookupItemRepository.GetById(productId);
                 if(dbProduct==null)
                 {
                     context.Errors.Add(new ExecutionError("Couldn't find owner in db."));
                     return null;
                 }

                 return await context.TryAsyncResolve(
                async c => await lookupItemRepository.UpdateInput(dbProduct , product ));

             });
            FieldAsync<StringGraphType>(
                 "deleteProduct",
                 arguments: new QueryArguments(
                     new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "productId" }),
                 resolve: async context =>
                 {
                     var productId = context.GetArgument<int>("productId");
                     var product = lookupItemRepository.GetById(productId);
                     if (product == null)
                     {
                         context.Errors.Add(new ExecutionError("Couldn't find Product in db."));
                         return null;
                     }
                     await context.TryAsyncResolve(
                    async c=> await lookupItemRepository.DeleteNewInput(product));
                     return $"The product with the id: {productId} has been successfully deleted from db.";

                     // return await context.TryAsyncResolve(
                     //async c => await lookupItemRepository.DeleteNewInput(product));
                     // return $"The owner with the id: {productId} has been successfully deleted from db.";
                 });





        }







    }
}
