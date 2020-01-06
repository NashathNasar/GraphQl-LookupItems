﻿using FirstGrphql.Data;
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
    }



}