
using AuthorizationAndAuthenticationProject.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace PayrollManagementApplication.DataModels
{
    public class DesignationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public DesignationRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {

            _context = context;
            _userManager = userManager;
        }
        public async Task AddDesignation(Designation designation)
        {
            Designation model = new Designation();
            try
            {
                model.DesignationName = designation.DesignationName;
                model.DesignationCode = designation.DesignationCode;
                model.CreatedOn = DateTime.Now;
                model.CreatedBy = "Admin";
                await _context.AddAsync(model);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Designation>> GetListOfDesignation()
        {
            return await _context.Designations.ToListAsync();
        }
        public async Task<Designation> GetDesignationById(int id)
        {
            return await _context.Designations.FindAsync(id);
        }
        public async Task UpdateDesignation(int id, Designation model)
        {
            var employee = await _context.Designations.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("Designation Not Found");
            }
            employee.DesignationName = model.DesignationName;
            employee.DesignationCode = model.DesignationCode;
            employee.UpdatedBy = "Admin";
            employee.UpdatedOn = DateTime.Now;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteDesignation(int id)
        {
            try
            {
                var designation = await _context.Designations.FindAsync(id);
                if (designation == null)
                {
                    throw new Exception("Designation Not Found");
                }
                _context.Designations.Remove(designation);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Designation cant be delete");
            }
        }
    }
}
