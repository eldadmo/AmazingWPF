using AmazingWPF.Contracts.Services;
using AmazingWPF.Models;
using AmazingWPF.Screens;
using Caliburn.Micro;

namespace AmazingWPF.ViewModels
{
    public class MainViewModel : Screen , IMainViewModel
    {
        private readonly IEmployeeService m_employeeService;
        private Employee m_employee;
        private bool m_isBusy;

        public MainViewModel(IEmployeeService employeeService)
        {
            m_employeeService = employeeService;
        }

        public bool IsBusy
        {
            get => m_isBusy;
            set
            {
                if (value == m_isBusy) return;
                m_isBusy = value;
                NotifyOfPropertyChange();
            }
        }

        public Employee Employee
        {
            get => m_employee;
            set
            {
                if (Equals(value, m_employee)) return;
                m_employee = value;
                NotifyOfPropertyChange();
            }
        }

        public async void Get()
        {
            Employee = null;
            IsBusy = true;
            Employee = (Employee) await m_employeeService.GetEmployee();
            IsBusy = false;
        }
    }
}