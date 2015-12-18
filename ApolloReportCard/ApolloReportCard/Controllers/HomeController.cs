using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApolloReportCard.EntetyDBContext;
using ApolloReportCard.Models;
using System.Data.Entity.Migrations;

namespace ApolloReportCard.Controllers
{
    public class HomeController : Controller
    {
        private ApolloDB db = new ApolloDB();
        public HomeController()
        {

            ViewData["Q1"] = "12/2/15";
            ViewData["Q2"] = "3/1/16";
            ViewData["Q3"] = "6/1/16";
            ViewData["Q4"] = "9/1/16";
        }

        // GET: Home
        public async Task<ActionResult> Index()
        {
            //var models = db.Criteria
            //.Where(x => x.UserId == User.Identity.Name);
            //return View(await models.ToListAsync());
            List<CriteriaModel> tempcontainer = new List<CriteriaModel>();
            tempcontainer = await db.Criteria.ToListAsync();
            return View(tempcontainer.Where(x => x.UserId == User.Identity.Name).ToList());
        }

        //public async Task<ActionResult> Index2()
        //{
        //    List<CriteriaModel> tempcontainer = new List<CriteriaModel>();
        //    tempcontainer = await db.Criteria.ToListAsync();
        //    return View(tempcontainer.Where(x => x.UserId == User.Identity.Name).ToList());
        //}

        [HttpPost]
        public ActionResult Index(List<CriteriaModel> myCriteria)
        {
            if (ModelState.IsValid)
            {
                using (ApolloDB dc = new ApolloDB())
                {
                    foreach (var i in myCriteria)
                    {
                        var c = dc.Criteria.Where(a => a.Id.Equals(i.Id)).FirstOrDefault();
                        if (c != null)
                        {
                            c.Name = i.Name;
                            c.QuarterOneGrade = i.QuarterOneGrade;
                            c.QuarterOneComments = i.QuarterOneComments;
                            c.QuarterTwoGrade = i.QuarterTwoGrade;
                            c.QuarterTwoComments = i.QuarterTwoComments;
                            c.QuarterThreeGrade = i.QuarterThreeGrade;
                            c.QuarterThreeComments = i.QuarterThreeComments;
                            c.QuarterFourGrade = i.QuarterFourGrade;
                            c.QuarterFourComments = i.QuarterFourComments;
                        }
                    }
                    dc.SaveChanges();
                }
                ViewBag.Message = "Successfully Updated.";
                return View(myCriteria);
            }// end model state if
            else
            {
                ViewBag.Message = "Failed ! Please try again.";
                return View(myCriteria);
            }// end of else


        }

        //[HttpPost]
        //public ActionResult Index2(List<CriteriaModel> myCriteria)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (ApolloDB dc = new ApolloDB())
        //        {
        //            foreach (var i in myCriteria)
        //            {
        //                var c = dc.Criteria.Where(a => a.Id.Equals(i.Id)).FirstOrDefault();
        //                if (c != null)
        //                {
        //                    c.Name = i.Name;
        //                    c.QuarterOneGrade = i.QuarterOneGrade;
        //                    c.QuarterOneComments = i.QuarterOneComments;
        //                    c.QuarterTwoGrade = i.QuarterTwoGrade;
        //                    c.QuarterTwoComments = i.QuarterTwoComments;
        //                    c.QuarterThreeGrade = i.QuarterThreeGrade;
        //                    c.QuarterThreeComments = i.QuarterThreeComments;
        //                    c.QuarterFourGrade = i.QuarterFourGrade;
        //                    c.QuarterFourComments = i.QuarterFourComments;
        //                }
        //            }
        //            dc.SaveChanges();
        //        }
        //        ViewBag.Message = "Successfully Updated.";
        //        return View(myCriteria);
        //    }// end model state if
        //    else
        //    {
        //        ViewBag.Message = "Failed ! Please try again.";
        //        return View(myCriteria);
        //    }// end of else
        //}// end of index2 method



        // GET: Home/About
        public ActionResult About()
        {
            return View();

            //return View(db.Criteria.ToList());
        }

        // GET: Home/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CriteriaModel criteriaModel = await db.Criteria.FindAsync(id);
            if (criteriaModel == null)
            {
                return HttpNotFound();
            }
            return View(criteriaModel);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,QuarterOneGrade,QuarterOneComments,QuarterTwoGrade,QuarterTwoComments,QuarterThreeGrade,QuarterThreeComments,QuarterFourGrade,QuarterFourComments")] CriteriaModel criteriaModel, List<CriteriaModel> myCriteria)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    criteriaModel.UserId = User.Identity.Name;
                    db.Criteria.AddOrUpdate(criteriaModel);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                //db.Criteria.Add(criteriaModel);

            }
            ViewBag.Message = "New data was not updated, please login.";
            //return View(criteriaModel);
            return RedirectToAction("Index");
        }

        // GET: Home/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CriteriaModel criteriaModel = await db.Criteria.FindAsync(id);
            if (criteriaModel == null)
            {
                return HttpNotFound();
            }
            return View(criteriaModel);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,QuarterOneGrade,QuarterOneComments,QuarterTwoGrade,QuarterTwoComments,QuarterThreeGrade,QuarterThreeComments,QuarterFourGrade,QuarterFourComments")] CriteriaModel criteriaModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(criteriaModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(criteriaModel);
        }

        // GET: Home/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CriteriaModel criteriaModel = await db.Criteria.FindAsync(id);
            if (criteriaModel == null)
            {
                return HttpNotFound();
            }
            return View(criteriaModel);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CriteriaModel criteriaModel = await db.Criteria.FindAsync(id);
            db.Criteria.Remove(criteriaModel);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
