using LibraryMvc.Models;
using LibraryMvc.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Web.Mvc;

namespace LibraryMvc.Controllers
{
    public class MultimediaController : Controller
    {
        private readonly IMultimediaServices _service;

        public MultimediaController(IMultimediaServices service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        public JsonResult Index()
        {
            return Json(_service.GetAllMultimedia(), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpPost]
        public JsonResult Details(int id, string className)
        {
            var multimedia = _service.GetObject(id,className);
            return Json(multimedia, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public JsonResult Create(string newMultimedia)
        {
            JObject deserializedData = JsonConvert.DeserializeObject<JObject>(newMultimedia);
            
            switch (deserializedData.Property("SelectedClass").Value.ToString())
            {
                case "Audio book":
                    _service.AddObject(JsonConvert.DeserializeObject<AudioBook>(newMultimedia));
                    break;
                case "Game":
                    _service.AddObject(JsonConvert.DeserializeObject<Game>(newMultimedia));
                    break;
                case "Music record":
                    _service.AddObject(JsonConvert.DeserializeObject<MusicRecord>(newMultimedia));
                    break;
                case "Book":
                    _service.AddObject(JsonConvert.DeserializeObject<Book>(newMultimedia));
                    break;
                case "Magazine":
                    _service.AddObject(JsonConvert.DeserializeObject<Magazine>(newMultimedia));
                    break;
                default:
                    break;
            }

            return Json(null);
        }
        
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public JsonResult UploadFile()
        {
            string fileName = MultimediaServices.NextPossibleFilename();
            bool flag = false;
          //  SignInManager
            if (Request.Files != null && Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                try
                {
                    file.SaveAs(Path.Combine(Server.MapPath("~/Images"), fileName));
                    flag = true;
                }
                catch (Exception)
                {
                    flag = false;
                }
            }

            return new JsonResult { Data = new {FileName = fileName, Status = flag } };
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public JsonResult Edit( string updatedMultimedia)
        {
            JObject deserializedData = JsonConvert.DeserializeObject<JObject>(updatedMultimedia);

            switch (deserializedData.Property("ClassName").Value.ToString())
            {
                case "AudioBook":
                    _service.EditObject(JsonConvert.DeserializeObject<AudioBook>(updatedMultimedia));
                    break;
                case "Game":
                    _service.EditObject(JsonConvert.DeserializeObject<Game>(updatedMultimedia));
                    break;
                case "MusicRecord":
                    _service.EditObject(JsonConvert.DeserializeObject<MusicRecord>(updatedMultimedia));
                    break;
                case "Book":
                    _service.EditObject(JsonConvert.DeserializeObject<Book>(updatedMultimedia));
                    break;
                case "Magazine":
                    _service.EditObject(JsonConvert.DeserializeObject<Magazine>(updatedMultimedia));
                    break;
                default:
                    break;
            }
            return Json(null);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public JsonResult Delete( int id, string className)
        {
            _service.DeleteObject(id, className);
            return Json(null);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public JsonResult DeleteCoverPhoto( int id, string className)
        {
            _service.DeleteCoverPhoto(id, className);
            return Json(null);
        }
    }
}
