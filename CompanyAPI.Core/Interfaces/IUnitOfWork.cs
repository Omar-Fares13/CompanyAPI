using EmployeeManagement.Core.Entities;

namespace EmployeeManagement.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Department> Departments { get; }
        IRepository<Employee> Employees { get; }
        Task<int> CompleteAsync();
    }
}
