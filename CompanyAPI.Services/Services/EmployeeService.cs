using EmployeeManagement.Core.Entities;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Services.Interfaces;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _unitOfWork.Employees.GetAllAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _unitOfWork.Employees.GetByIdAsync(id);
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _unitOfWork.Employees.AddAsync(employee);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _unitOfWork.Employees.Update(employee);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if (employee != null)
            {
                _unitOfWork.Employees.Delete(employee);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}
