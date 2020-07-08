using System;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using AmazingWPF.Contracts.Entities;
using AmazingWPF.Contracts.Services;
using AmazingWPF.Models;

namespace AmazingWPF.Services
{
    public class EmployeeService : IEmployeeService
    {
        public async Task<IEmployee> GetEmployee()
        {
            await Task.Delay(2500);
            IEmployee employee = new Employee()
            {
                Name = "James",
                LastName = "Bond",
                Birthday = new DateTime(1920, 11, 11),
                CanRelocate = true,
                Id = 007,
                Salary = 10000000,
                BitmapUri = new Uri("pack://application:,,,/Resources/Bond.jpg", UriKind.RelativeOrAbsolute),
            };
            return employee;
        }
    }
}