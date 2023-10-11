using CRMFamaV2.Models;
using CRMFamaV2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRMFamaV2.Controllers
{
    public class PartnerController : BaseController
    {
        public PartnerController(ApplicationDbContext context, IConfiguration configuration) : base(context, configuration)
        {
        }

        // SHOW PARTNER LIST
        public IActionResult Index()
        {
            var objPartner = _context.PartnerList.ToList();
            return View(objPartner);
        }

        //CREATE PARTNER
        public IActionResult CreatePartner()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePartner(PartnerModel obj)
        {
            if (ModelState.IsValid)
            {
                _context.PartnerList.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //EDIT PARTNER
        public IActionResult EditPartner(int id)
        {
            if ( id == 0)
            {
                return NotFound();
            }
            var partnerFromDb = _context.PartnerList.Find(id);

            if (partnerFromDb == null)
            {
                return NotFound();
            }

            return View(partnerFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPartner(PartnerModel obj)
        {
            if (ModelState.IsValid)
            {
                obj.UpdateDateTime = DateTime.Now;
                _context.PartnerList.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var partnerFromDb = _context.PartnerList.Find(id);

            if (partnerFromDb == null)
            {
                return NotFound();
            }

            _context.PartnerList.Remove(partnerFromDb);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

