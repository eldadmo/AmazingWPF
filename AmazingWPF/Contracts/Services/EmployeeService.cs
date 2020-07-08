using System.Threading.Tasks;
using AmazingWPF.Contracts.Entities;

namespace AmazingWPF.Contracts.Services
{
    public interface IEmployeeService
    {
        Task<IEmployee> GetEmployee();
    }
}