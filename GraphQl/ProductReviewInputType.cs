using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstGrphql.GraphQl
{
    public class ProductReviewInputType : InputObjectGraphType 
    {

        public ProductReviewInputType ()
        {

            Name = "reviewInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            //Field<NonNullGraphType<StringGraphType>>("formname");
            Field<IdGraphType>("id");
            Field<NonNullGraphType<IntGraphType>>("productId");




        }






    }
}
