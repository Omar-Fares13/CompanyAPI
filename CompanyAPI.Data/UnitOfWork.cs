using EmployeeManagement.Core.Entities;
using EmployeeManagement.Core.Interfaces;

namespace EmployeeManagement.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Departments = new Repository<Department>(_context);
            Employees = new Repository<Employee>(_context);
        }

        public IRepository<Department> Departments { get; private set; }
        public IRepository<Employee> Employees { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
