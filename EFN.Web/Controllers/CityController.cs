using EFN.Database;
using EFN.Database.Entity;
using EFN.Services.City;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EFN.Web.Controllers
{
    public class CityController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: City
        public async Task<ActionResult> Index()
        {
            ICityService CityService = new CityService(db);
            var cityList = await CityService.GetList();

            return View("City", "_Layout", cityList);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ICityService CityService = new CityService(db);
            var cityDet = await CityService.GetItem(id);

            return View(cityDet);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(City city)
        {
            try
            {
                ICityService CityService = new CityService(db);
                await CityService.Insert(city);
                return RedirectToAction("Index");
            }
            catch
            {

                throw;
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            ICityService CityService = new CityService(db);
            var cityEdit = await CityService.GetItem(id);
            return View(cityEdit);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(City city)
        {
            try
            {
                ICityService CityService = new CityService(db);
                await CityService.Update(city);
                return RedirectToAction("Index");
            }
            catch
            {
                throw;
            }
        }

        public async Task<ActionResult> Delete(int? id)
        {
            ICityService CityService = new CityService(db);
            var cityDelete = await CityService.GetItem(id);
            return View(cityDelete);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                ICityService CityService = new CityService(db);
                await CityService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {

                throw;
            }
        }
    }
}