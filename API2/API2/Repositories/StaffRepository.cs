using API2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace API2.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly Api2Context _Context;
        public StaffRepository(Api2Context context)
        {
            _Context = context;
        }
        public List<Staff> GetStaffList(string? term)
        {
            if (string.IsNullOrEmpty(term))
            {
                return _Context.Staff.ToList();
            }
            var filteredStaff = _Context.Staff
              .Where(p => p.FullName.ToLower().Contains(term.ToLower()))
              .ToList();

            return filteredStaff;
        }
        public void AddStaff ([FromBody] Staff staff)
        {
            try
            {
                _Context.Staff.Add(staff);
                _Context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("Có vấn đề xảy ra khi lưu!");
            }
        }
        public Staff GetStaffListByID(int id)
        {
            var StaffID = _Context.Staff
              .FirstOrDefault(p => p.Id == id);
            return StaffID;
        }
        public void UpdateStaff([FromBody] Staff staff, int id)
        {
            try
            {
                var existingStaff = _Context.Staff.FirstOrDefault(s => s.Id == id);
                if (existingStaff != null)
                {
                    existingStaff.FullName = staff.FullName;
                    existingStaff.ShortName = staff.ShortName;
                }
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có vấn đề xảy ra khi lưu!");
            }
        }
        public void DeleteStaff(int id)
        {
            try
            {
                var existingStaff = _Context.Staff.FirstOrDefault(s => s.Id == id);
                if (existingStaff != null)
                {
                    _Context.Remove(existingStaff);
                }
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có vấn đề xảy ra khi xóa!");
            }
        }
    }
}
