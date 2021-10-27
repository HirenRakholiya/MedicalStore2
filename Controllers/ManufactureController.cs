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
    public class ManufactureController : Controller
    {
        string connectionString = @"Data Source=.;Initial Catalog=PharmaWholeSale;Integrated Security=True";
        // GET: Manufacture
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Select * from Manufacture";
                SqlDataAdapter adp = new SqlDataAdapter(query, con);
                adp.Fill(dt);
            }
            return View(dt);
        }

        // GET: Manufacture/Details/5
       

        // GET: Manufacture/Create
        public ActionResult Create()
        {
            return View(new ManufactureModel());
        }

        // POST: Manufacture/Create
        [HttpPost]
        public ActionResult Create(ManufactureModel manufactureModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Insert into Manufacture Values(@ManufactureName,@ManufactureEmail,@ManufactureMobile,@ManufactureAddress,@ManufactureZipcode,@ManufactureCountry)";
                SqlCommand cmd = new SqlCommand(query, con);
                // cmd.Parameters.AddWithValue("@Id", manufactureModel.Id);
                cmd.Parameters.AddWithValue("@ManufactureName", manufactureModel.ManufactureName); 
                cmd.Parameters.AddWithValue("@ManufactureEmail", manufactureModel.ManufactureEmail);
                cmd.Parameters.AddWithValue("@ManufactureMobile", manufactureModel.ManufactureMobile);
                cmd.Parameters.AddWithValue("@ManufactureAddress", manufactureModel.ManufactureAddress);
                cmd.Parameters.AddWithValue("@ManufactureZipcode", manufactureModel.ManufactureZipcode);
                cmd.Parameters.AddWithValue("@ManufactureCountry", manufactureModel.ManufactureCountry);
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Manufacture/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Manufacture/Edit/5
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

        // GET: Manufacture/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Manufacture/Delete/5
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
