using API2.Models;
using API2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API2.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        public List<Staff> GetStaffList(string? term)
        {
            return _staffRepository.GetStaffList(term);
        }
        public void AddStaff([FromBody] Staff staff)
        {
            _staffRepository.AddStaff(staff);
        }
        public Staff GetStaffListByID(int id)
        {
            return _staffRepository.GetStaffListByID(id);
        }
        public void UpdateStaff([FromBody] Staff staff, int id)
        {
             _staffRepository.UpdateStaff(staff, id);
        }
        public void DeleteStaff(int id)
        {
            _staffRepository.DeleteStaff(id);
        }
    }
}
