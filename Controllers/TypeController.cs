using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using MedicalStore.Models;

namespace MedicalStore.Controllers
{
    public class TypeController : Controller
    {
        string connectionString = @"Data Source=.;Initial Catalog=PharmaWholeSale;Integrated Security=True";
        // GET: Type
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Select * from Type";
                SqlDataAdapter adp = new SqlDataAdapter(query, con);
                adp.Fill(dt);
            }
            return View(dt);
        }

        // GET: Type/Details/5
       

        // GET: Type/Create
        public ActionResult Create()
        {
            return View(new TypeModel());
        }

        // POST: Type/Create
        [HttpPost]
        public ActionResult Create(TypeModel typeModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Insert into Type Values(@TypeName)";
                SqlCommand cmd = new SqlCommand(query, con);
                // cmd.Parameters.AddWithValue("@Id", manufactureModel.Id);
                cmd.Parameters.AddWithValue("@TypeName", typeModel.TypeName);

                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Type/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Type/Edit/5
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

        // GET: Type/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Type/Delete/5
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
