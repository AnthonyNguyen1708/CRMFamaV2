using CRMFamaV2.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRMFamaV2.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ApplicationDbContext _context;

        protected readonly IConfiguration _configuration;

        public BaseController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
    }
}