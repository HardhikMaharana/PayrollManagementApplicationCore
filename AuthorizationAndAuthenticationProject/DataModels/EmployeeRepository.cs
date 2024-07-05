using AuthorizationAndAuthenticationProject.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace PayrollManagementApplication.DataModels
{
    public class EmployeeRepository
    {
        
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public EmployeeRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {

            _context = context;
            _userManager=userManager;
        }

        public async Task AddDepartment(Department department)
        {
           

            Department model = new Department();
            try
            {
                model.DeptName = department.DeptName;
                model.DeptCode = department.DeptCode;
                model.CreatedOn = DateTime.Now;
                model.CreatedBy = "Admin";
                await _context.AddAsync(model);
                await _context.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                throw ex;
            }
            



           // await _context.Set<Department>().AddAsync(department);
            //await _context.SaveChangesAsync();


        }
        public async Task<List<Department>> GetListOfDepartment()
            {
            return await _context.Departments.ToListAsync();

        }
        public async Task<Department> GetDepartmentById(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task UpdateDepartment(int id, Department model)
        {
            // Employee emp=new Employee();
            var employee = await _context.Departments.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("Department Not Found");
            }
            employee.DeptName = model.DeptName;
            employee.DeptCode = model.DeptCode;
            employee.UpdatedBy = "Admin";
            employee.UpdatedOn = DateTime.Now;
            await _context.SaveChangesAsync();
            // emp.Name= model.Name;


        }

        public async Task DeleteDepartment(int id)
        {
            try
            {
                var department = await _context.Departments.FindAsync(id);
                if (department == null)
                {
                    throw new Exception("Department Not Found");
                }
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Department cant be delete");


            }

        }



    }
}
