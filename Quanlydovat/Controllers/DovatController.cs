using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quanlydovat.Models;
using Quanlydovat.DAL;
namespace Quanlydovat.Controllers
{
    public class DovatController : Controller
    {
        // GET: Dovat
        DALDo DAL = new DALDo();
        public ActionResult Index(string search)
        {
            List<Do> dos = new List<Do>();
            dos = DAL.getAll(string.Empty);
            if (!string.IsNullOrEmpty(search))
            {
                dos = dos.Where(x => x.Ten.Contains(search)).ToList();
            }
            return View(dos);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Do dovat)
        {
            DAL.Create(dovat);
            return RedirectToAction("Index");

        }

        public ActionResult Edit( string id)
        {
            List<Do> dovat = new List<Do>();
            dovat= DAL.getAll(id);
            return View(dovat.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(Do dovat)
        {
            DAL.Create(dovat);
            return RedirectToAction("Index");

        }
        //xoaaaa
        public ActionResult Delete(string id)
        {
            List<Do> dovat = new List<Do>();
            dovat = DAL.getAll(id);
            return View(dovat.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(Do dovat)
        {
            DAL.Delete(dovat);
            return RedirectToAction("Index");

        }
    }
}