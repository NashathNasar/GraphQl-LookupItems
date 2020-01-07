using FirstGrphql.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstGrphql
{
    public interface ILookupItemRepository
    {

        Task<List<Customer>> GetCustomersAsync();
        Task<List<ChargingType>> GetChargingTypesAsync();

        Task<List<Division>> GetDivisionsAsync();
        Task<List<InvoicedBy>> GetInvoicedBysAsync();
        Task<List<PaymentTerm>> GetPaymentTermsAsync();

        Task<List<ProductGroup>> GetProductGroupsAsync();

        Task<List<ProductUnit>> GetProductUnitsAsync();
        Task<List<Origin>> GetOriginsAsync();

        Task<List<OrderApprover>> GetOrderApproversAsync();

        Task<List<ProductCategory>> GetProductCategoriesAsync(int ProductGroupId=0);
        Task<List<Product>> GetProductsAsync(int CategoryId = 0);
        Task<List<ReceiptsMovementType>> GetReceiptsMovementTypesAsync();
        Task<List<DeliveryMovementsType>> GetDeliveryMovementTypesAsync();
        Task<List<DeliveryType>> GetDeliveryTypesAsync(int MovementTypeId=0);
        Task<List<ReceiptsType>> GetReceiptsTypesAsync(int MovementTypeId = 0);
        Task<List<Project>> GetProjectsAsync(int CustomerId=0);

        Task<List<InvoicesType>> GetInvoicesTypesAsync();
    }

    public class CustomerRepository : ILookupItemRepository
    {
        private readonly AbsContext _context;

        public CustomerRepository(AbsContext context)
        {
            _context = context;
        }

        public Task<List<ChargingType>> GetChargingTypesAsync()
        {
            return _context.ChargingTypes.ToListAsync();
        }

        public Task<List<Customer>> GetCustomersAsync()
        {
            return _context.Customers.ToListAsync();
        }

        public Task<List<Division>> GetDivisionsAsync()
        {
            return _context.Divisions.ToListAsync();
        }

        public Task<List<InvoicedBy>> GetInvoicedBysAsync()
        {
            return _context.InvoicedBy.ToListAsync();
        }

        public Task<List<PaymentTerm>> GetPaymentTermsAsync()
        {
            return _context.PaymentTerms.ToListAsync();
        }

        public Task<List<ProductGroup>> GetProductGroupsAsync()
        {
            return _context.ProductGroups.ToListAsync();
        }

        public Task<List<Origin>> GetOriginsAsync()
        {
            return _context.Origins.ToListAsync();
        }

        public Task<List<ProductUnit>> GetProductUnitsAsync()
        {
            return _context.ProductUnits.ToListAsync();
        }

        public Task<List<DeliveryMovementsType>> GetDeliveryMovementTypesAsync()
        {
            return _context.DeliveryMovementTypes.ToListAsync();
        }

        public Task<List<Project>> GetProjectsAsync(int customerId=0)
        {
            if (customerId > 0)
            {
                return _context.Projects
                    .Where(x => x.CustomerId == customerId)
                    .ToListAsync();
            }
            return _context.Projects.ToListAsync();
        }

        public Task<List<DeliveryType>> GetDeliveryTypesAsync(int movementtypeId = 0)
        {
            if (movementtypeId > 0)
            {
                return _context.DeliveryTypes
                    .Where(x => x.MovementTypeId== movementtypeId)
                    .ToListAsync();
            }
            return _context.DeliveryTypes.ToListAsync();
        }

        public Task<List<InvoicesType>> GetInvoicesTypesAsync()
        {
            return _context.InvoiceTypes.ToListAsync();
        }

        public Task<List<OrderApprover>> GetOrderApproversAsync()
        {
            return _context.OrderApprovers.ToListAsync();
        }

        public Task<List<ProductCategory>> GetProductCategoriesAsync(int productgroupId = 0)
        {
            if (productgroupId > 0)
            {
                return _context.ProductCategories
                    .Where(x => x.ProductGroupId == productgroupId)
                    .ToListAsync();
            }
            return _context.ProductCategories.ToListAsync();
        }

        public Task<List<Product>> GetProductsAsync(int categoryId = 0)
        {
            if (categoryId > 0)
            {
                return _context.Products
                    .Where(x => x.CategoryId == categoryId)
                    .ToListAsync();
            }
            return _context.Products.ToListAsync();
        }

        public Task<List<ReceiptsMovementType>> GetReceiptsMovementTypesAsync()
        {
            return _context.ReceiptMovementTypes.ToListAsync();
        }

        public Task<List<ReceiptsType>> GetReceiptsTypesAsync(int movementtypeId = 0)
        {
            if (movementtypeId > 0)
            {
                return _context.ReceiptTypes
                    .Where(x => x.MovementTypeId == movementtypeId)
                    .ToListAsync();
            }
            return _context.ReceiptTypes.ToListAsync();
        }
    }



}
