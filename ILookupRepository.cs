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

        Task<List<DeliveryMovementsType>> GetDeliveryMovementTypesAsync();
        Task<List<DeliveryType>> GetDeliveryTypesAsync(int MovementTypeId=0);

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
    }



}
