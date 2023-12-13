using API2.Models;
using Microsoft.AspNetCore.Mvc;

namespace API2.Repositories
{
    public interface IStaffRepository
    {
        List<Staff> GetStaffList(string? term);
        void AddStaff([FromBody] Staff staff);
        List<Staff> GetStaffListByID(int id);
        void UpdateStaff([FromBody] Staff staff);
        void DeleteStaff(int id);
    }
}
