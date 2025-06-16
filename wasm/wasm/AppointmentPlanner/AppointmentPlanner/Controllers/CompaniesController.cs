using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppointmentPlanner.Data;

namespace AppointmentPlanner.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompaniesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CompaniesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetCompanies()
        {
            var companies = await _context.Companies
                .Select(c => new { c.CompanyId, c.Name })
                .ToListAsync();
            return Ok(companies);
        }

        // GET: api/companies/{companyId}/sites
        [HttpGet("{companyId}/sites")]
        public async Task<ActionResult<IEnumerable<object>>> GetSitesForCompany(int companyId)
        {
            var sites = await _context.CompanySites
                .Where(cs => cs.CompanyId == companyId)
                .Select(cs => new { cs.Site.SiteId, cs.Site.Name })
                .Distinct()
                .ToListAsync();
            return Ok(sites);
        }
    }
}