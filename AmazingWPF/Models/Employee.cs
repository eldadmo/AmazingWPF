using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using AmazingWPF.Contracts.Entities;
using Caliburn.Micro;

namespace AmazingWPF.Models
{
    public class Employee : PropertyChangedBase ,IEmployee
    {
        private string m_name;
        private string m_lastName;
        private long m_id;
        private long m_salary;
        private DateTime m_birthday;
        private bool m_canRelocate;
        private Uri m_bitmapUri;

        public string Name
        {
            get => m_name;
            set
            {
                if (value == m_name) return;
                m_name = value;
                NotifyOfPropertyChange();
            }
        }

        public string LastName
        {
            get => m_lastName;
            set
            {
                if (value == m_lastName) return;
                m_lastName = value;
                NotifyOfPropertyChange();
            }
        }

        public long Id
        {
            get => m_id;
            set
            {
                if (value == m_id) return;
                m_id = value;
                NotifyOfPropertyChange();
            }
        }

        public long Salary
        {
            get => m_salary;
            set
            {
                if (value == m_salary) return;
                m_salary = value;
                NotifyOfPropertyChange();
            }
        }

        public DateTime Birthday
        {
            get => m_birthday;
            set
            {
                if (value.Equals(m_birthday)) return;
                m_birthday = value;
                NotifyOfPropertyChange();
            }
        }

        public bool CanRelocate
        {
            get => m_canRelocate;
            set
            {
                if (value == m_canRelocate) return;
                m_canRelocate = value;
                NotifyOfPropertyChange();
            }
        }

        public Uri BitmapUri
        {
            get => m_bitmapUri;
            set
            {
                if (Equals(value, m_bitmapUri)) return;
                m_bitmapUri = value;
                NotifyOfPropertyChange();
            }
        }
    }
}