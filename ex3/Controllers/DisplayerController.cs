using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using ex3.Models;

namespace WebApplication4.Controllers {
    public class DisplayerController : Controller {
        // GET: Default

        public string Index() {
            return "index";
        }

        public ActionResult Display(string first, int second, int rate = 0) {
            IPAddress address;
            if (IPAddress.TryParse(first, out address)) {
                SimulatorClient.Instance.Connect(first, second);
                return DisplayOnline(first, second, rate);
            }
            else {
                return DisplaySavedMap(first, second);
            }
        }

        ActionResult DisplayOnline(string ip, int port, int rate) {
            ViewBag.rate = rate;
            return View("DisplayOnline");
        }

        ActionResult DisplaySavedMap(string name, int rate) {
            ViewBag.rate = rate;
            return View();
        }

        [HttpPost]
        public string QueryData(string query) {
            //double[] point = GeneratorForTests.Instance.newPoint;
            //return String.Format("{0},{1}", point[0], point[1]);
            float[] data = SimulatorClient.Instance.GetDataFromSimulator(query);

            return ToXml(new FlightSample(data[0], data[1], data[2], data[3]));
            //return ToXml(new Location(data[0], data[1]));
        }

        string ToXml(FlightSample sample) {
            //Initiate XML stuff
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            XmlWriter writer = XmlWriter.Create(sb, settings);

            writer.WriteStartDocument();
            sample.ToXml(writer);
            writer.WriteEndDocument();
            writer.Flush();

            return sb.ToString();
        }
    }
}