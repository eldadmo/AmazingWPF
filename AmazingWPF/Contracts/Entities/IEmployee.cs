using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AmazingWPF.Contracts.Entities
{
    public interface IEmployee
    {
        string Name { get; set; } 
        string LastName { get; set; }
        long Id { get; set; }
        long Salary { get; set; }
        DateTime Birthday { get; set; }
        bool CanRelocate { get; set; }
        Uri BitmapUri { get; set; }
    }
}