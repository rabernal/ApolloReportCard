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

namespace ApolloReportCard.Controllers
{
    public class HomeController : Controller
    {
        private ApolloDB db = new ApolloDB();

        // GET: Home
        public async Task<ActionResult> Index()
        {
            return View(await db.Criteria.ToListAsync());
        }

        // GET: Home/About
        public ActionResult About()
        {
            
            return View(db.Criteria.ToList());
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
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,QuarterOneGrade,QuarterOneComments,QuarterTwoGrade,QuarterTwoComments,QuarterThreeGrade,QuarterThreeComments,QuarterFourGrade,QuarterFourComments")] CriteriaModel criteriaModel)
        {
            if (ModelState.IsValid)
            {
                db.Criteria.Add(criteriaModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(criteriaModel);
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
