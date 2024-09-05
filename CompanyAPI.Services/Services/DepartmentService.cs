using EmployeeManagement.Core.Entities;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Services.Interfaces;

namespace EmployeeManagement.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _unitOfWork.Departments.GetAllAsync();
        }

        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await _unitOfWork.Departments.GetByIdAsync(id);
        }

        public async Task AddDepartmentAsync(Department department)
        {
            await _unitOfWork.Departments.AddAsync(department);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            _unitOfWork.Departments.Update(department);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id);
            if (department != null)
            {
                _unitOfWork.Departments.Delete(department);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}
