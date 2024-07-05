using AuthorizationAndAuthenticationProject.DataModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace PayrollManagementApplication.DataModels
{
    public class EmployeeRepository
    {
        
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {

            _context = context;
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


    }
    }
