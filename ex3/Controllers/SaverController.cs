using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ex3.Models;

namespace ex3.Controllers {
    public class SaverController : Controller {

        public ActionResult Save(string ip, int port, int rate, int time, string name) {
            ViewBag.rate = rate;
            Session["rate"] = rate;
            Session["iterations"] = rate * time;
            ViewBag.fileName = name;
            return View("SaveOnline");
        }
        // Saving the data sample in the file
        public void SaveDataSample(string data, string fileName, bool toCreateFile) {
            InfoModel.Instance.SaveSample(data, fileName, toCreateFile);
        }
    }
}