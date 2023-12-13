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
        public List<Staff> GetStaffListByID(int id)
        {
            var StaffID = _Context.Staff
              .Where(p => p.Id == id)
              .ToList();
            return StaffID;
        }
        public void UpdateStaff([FromBody] Staff staff)
        {
            try
            {
                var existingStaff = _Context.Staff.FirstOrDefault(s => s.Id == staff.Id);
                if (existingStaff == null)
                {
                    throw new Exception();
                }
                existingStaff.FullName = staff.FullName;
                existingStaff.ShortName = staff.ShortName;
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
                if (existingStaff == null)
                {
                    throw new Exception();
                }
                _Context.Remove(existingStaff);
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có vấn đề xảy ra khi xóa!");
            }
        }
    }
}
