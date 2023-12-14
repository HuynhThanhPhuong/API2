using API2.Models;
using Microsoft.AspNetCore.Mvc;

namespace API2.Services
{
    public interface IStaffService
    {
        List<Staff> GetStaffList(string? term);
        void AddStaff([FromBody] Staff satff);
        Staff GetStaffListByID(int id);
        void UpdateStaff([FromBody] Staff satff, int id);
        void DeleteStaff(int id);
    }
}
