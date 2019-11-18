//using LibraryMvcApp.Services;
using LibraryMvcApp.Models;
using LibraryMvcApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace LibraryMvcApp.Controllers
{
    public class MultimediaController : Controller
    {
        private readonly IMultimediaServices _service;

        public MultimediaController(IMultimediaServices service)
        {
            _service = service;
        }

        public JsonResult Index()
        {
            return Json(_service.GetAllMultimedia(),JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public JsonResult Create([FromBody]string obje)
        {
           // dynamic deserializedData = JsonConvert.DeserializeObject<dynamic>(obje);
            return Json(null);
        }

        //[HttpPost]
        //public JsonResult Create(JsonResult obje)
        //{
        //   // dynamic deserializedData = JsonConvert.DeserializeObject<dynamic>(obje);
        //    return Json(null);
        //}

        // GET: Multimedia/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Multimedia/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Multimedia/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Multimedia/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
