using mvc_webapp_dropdown_populated_by_dropdown.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_webapp_dropdown_populated_by_dropdown.Controllers
{
    public class HomeController : Controller
    {
        private List<StateModel> listOfStateModels;
        private List<CityModel> listOfCityModels;

        public HomeController()
        {
            listOfStateModels = new List<StateModel>();
            listOfCityModels = new List<CityModel>();

            listOfStateModels.Add(new StateModel() { StateId = 1, StateName = "West Yorkshire" });
            listOfStateModels.Add(new StateModel() { StateId = 2, StateName = "East Yorkshire" });
            listOfStateModels.Add(new StateModel() { StateId = 3, StateName = "Lincolnshire" });
            listOfStateModels.Add(new StateModel() { StateId = 4, StateName = "East Midlands" });
            listOfStateModels.Add(new StateModel() { StateId = 5, StateName = "Nottinghamshire" });
            listOfStateModels.Add(new StateModel() { StateId = 6, StateName = "Hertfordshire" });

            listOfCityModels.Add(new CityModel() { CityId = 1, StateId = 1, CityName = "Bradford" });
            listOfCityModels.Add(new CityModel() { CityId = 2, StateId = 1, CityName = "Leeds" });
            listOfCityModels.Add(new CityModel() { CityId = 3, StateId = 2, CityName = "Bridlington" });
            listOfCityModels.Add(new CityModel() { CityId = 4, StateId = 2, CityName = "Kingston upon Hull" });
            listOfCityModels.Add(new CityModel() { CityId = 5, StateId = 3, CityName = "Lincoln" });
            listOfCityModels.Add(new CityModel() { CityId = 6, StateId = 3, CityName = "Grantham" });
            listOfCityModels.Add(new CityModel() { CityId = 7, StateId = 4, CityName = "Nottingham" });
            listOfCityModels.Add(new CityModel() { CityId = 8, StateId = 4, CityName = "Leicester" });
            listOfCityModels.Add(new CityModel() { CityId = 9, StateId = 5, CityName = "Nottingham" });
            listOfCityModels.Add(new CityModel() { CityId = 10, StateId = 5, CityName = "Worksop" });
            listOfCityModels.Add(new CityModel() { CityId = 11, StateId = 6, CityName = "St Albans" });
            listOfCityModels.Add(new CityModel() { CityId = 12, StateId = 6, CityName = "Hatfield" });

        }

        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<SelectListItem> listOfSelectListItems =
                (
                        from obj in listOfStateModels
                        select new SelectListItem()
                        {
                            Text = obj.StateName,
                            Value = obj.StateId.ToString()
                        }
                ).ToList();

            return View(listOfSelectListItems);
        }

        public PartialViewResult GetCity(int StateId)
        {
            IEnumerable<SelectListItem> listOfSelectListItems = (
                    from obj in listOfCityModels
                    where obj.StateId == StateId
                    select new SelectListItem()
                    {
                        Value = obj.CityId.ToString(),
                        Text = obj.CityName
                    }
                 ).ToList();

            return PartialView("CityPartial", listOfSelectListItems);
        }
    }
}