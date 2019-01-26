using Ciam.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace Ciam.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Customer> Customers { get; }

        IRepository<Product> Products { get; }

        IRepository<SalesOrder> SalesOrders { get; }

        IRepository<SalesOrderDetail> SalesOrderDetails { get; }

        IRepository<SalesStatus> SalesStatuses { get; }

        Task<int> SaveChangesAsync();
    }
}
