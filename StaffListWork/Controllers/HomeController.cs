using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.StaffListWork.Entity;
using DAL.StaffListWork.Interface;
using StaffListWork.Models;
using AutoMapper;

namespace StaffListWork.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Employee> db;
        public HomeController()
        {
            db = new DAL.StaffListWork.Repository.StaffRepository();
        }
        public ActionResult Index()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmpoloyeeViewModel>());
            var staffAll = Mapper.Map<IEnumerable<Employee>, List<EmpoloyeeViewModel>>(db.GetAll());

            foreach (EmpoloyeeViewModel em in staffAll)
            {
                if (em.IdHead != null)
                {
                    var nameHeader = db.Get(em.IdHead);
                    if(nameHeader!=null)
                    em.NameHeader = nameHeader.FirstName + " " + nameHeader.LastName;
                }
            }
            return View(staffAll);
        }


    public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(EmpoloyeeViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                Mapper.Initialize(cfg => cfg.CreateMap<EmpoloyeeViewModel, Employee>());
                var staff = Mapper.Map<EmpoloyeeViewModel, Employee>(model);
                
                db.Create(staff);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmpoloyeeViewModel>());
            EmpoloyeeViewModel emp = Mapper.Map<Employee, EmpoloyeeViewModel>(db.Get(id.Value));
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(EmpoloyeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<EmpoloyeeViewModel, Employee>());
                var emp = Mapper.Map < EmpoloyeeViewModel, Employee> (model);
                db.Update(emp);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmpoloyeeViewModel>());
            EmpoloyeeViewModel emp = Mapper.Map<Employee, EmpoloyeeViewModel>(db.Get(id.Value));
            return View(emp);
        }
        [HttpPost]
        public ActionResult Delete(EmpoloyeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<EmpoloyeeViewModel, Employee>());
                var emp = Mapper.Map<EmpoloyeeViewModel, Employee>(model);
                db.Delete(emp.Id);
                return RedirectToAction("Index");
            }
            return View(model);
        }
   
    }
}