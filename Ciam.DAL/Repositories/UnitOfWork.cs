using Ciam.DAL.EF;
using Ciam.DAL.Entities;
using Ciam.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Ciam.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectDbContext _context;

        private IRepository<Customer> _customers;

        private IRepository<Product> _products;

        private IRepository<SalesOrder> _salesOrders;

        private IRepository<SalesOrderDetail> _salesOrderDetails;

        private IRepository<SalesStatus> _salesStatuses;

        public UnitOfWork(ProjectDbContext dbContext)
        {
            _context = dbContext;
        }

        public IRepository<Customer> Customers => _customers ?? (_customers = new Repository<Customer>(_context));

        public IRepository<Product> Products => _products ?? (_products = new Repository<Product>(_context));

        public IRepository<SalesOrder> SalesOrders => _salesOrders ?? (_salesOrders = new Repository<SalesOrder>(_context));

        public IRepository<SalesOrderDetail> SalesOrderDetails => _salesOrderDetails ?? (_salesOrderDetails = new Repository<SalesOrderDetail>(_context));

        public IRepository<SalesStatus> SalesStatuses => _salesStatuses ?? (_salesStatuses = new Repository<SalesStatus>(_context));

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        #region Dispose

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Dispose
    }
}
