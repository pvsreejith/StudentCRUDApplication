using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentInfo.Context;

namespace StudentInfo.Controllers
{
    public class StudentController : Controller

    {
        // GET: Student

        StudentModel dbObj = new StudentModel();
        public ActionResult Student()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Table_Student model)
        {
            if (ModelState.IsValid)
            {
                Table_Student obj = new Table_Student();
                obj.Name = model.Name;
                obj.Fname = model.Fname;
                obj.Email = model.Email;
                obj.Mobile = model.Mobile;
                obj.Description = model.Description;

                dbObj.Table_Student.Add(obj);
                dbObj.SaveChanges();
            }

            ModelState.Clear();

            return View("Student");

        }

        public ActionResult StudentList()
        {
            var studentList = dbObj.Table_Student.ToList();

            return View(studentList);
        }

        public ActionResult Delete(int id)
        {
            var studentinfo = dbObj.Table_Student.Where(x => x.ID == id).FirstOrDefault();
            dbObj.Table_Student.Remove(studentinfo);
            dbObj.SaveChanges();

            var studentListdel = dbObj.Table_Student.ToList();
            return View("StudentList", studentListdel);
        }


        public ActionResult ViewStudent(Table_Student obj)
        {
            return View(obj);
        }


        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var studentinfo = dbObj.Table_Student.Where(x => x.ID == id).FirstOrDefault();
            return View(studentinfo);
        }

        [HttpPost]
        public ActionResult EditStudent(Table_Student obj)
        {
            dbObj.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            
            dbObj.SaveChanges();
            return View(obj);
        }



    }
}