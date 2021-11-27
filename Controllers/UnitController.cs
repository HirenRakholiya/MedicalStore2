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

    public class UnitController : Controller
    {
        string connectionString = @"Data Source=.;Initial Catalog=PharmaWholeSale;Integrated Security=True";
        // GET: Unit
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Select * from Unit";
                SqlDataAdapter adp = new SqlDataAdapter(query, con);
                adp.Fill(dt);
            }
            return View(dt);
        }

        // GET: Unit/Create
        public ActionResult Create()
        {
            return View(new UnitModel());
        }

        // POST: Unit/Create
        [HttpPost]
        public ActionResult Create(UnitModel unitModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Insert into Unit Values(@UnitName)";
                SqlCommand cmd = new SqlCommand(query, con);
                // cmd.Parameters.AddWithValue("@Id", manufactureModel.Id);
                cmd.Parameters.AddWithValue("@UnitName", unitModel.UnitName);

                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
            //try
            //{
            //    // TODO: Add insert logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Unit/Edit/5
        public ActionResult Edit(int id)
        {
            UnitModel unitModel = new UnitModel();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Select * from   Unit where  UnitId=@UnitId";
                SqlDataAdapter adp = new SqlDataAdapter(query, con);
                adp.SelectCommand.Parameters.AddWithValue("@UnitId", id);
                adp.Fill(dt);
            }
            if (dt.Rows.Count == 1)
            {
                unitModel.UnitId = Convert.ToInt32(dt.Rows[0][0].ToString());
                unitModel.UnitName = dt.Rows[0][1].ToString();

                return View(unitModel);

            }
            else
                return RedirectToAction("Index");
        }

        // POST: Unit/Edit/5
        [HttpPost]
        public ActionResult Edit(UnitModel unitModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Update Unit set UnitName=@UnitName where UnitId=@UnitId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UnitId", unitModel.UnitId);
                cmd.Parameters.AddWithValue("@UnitName", unitModel.UnitName);

                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
            //try
            //{
            //    // TODO: Add update logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Unit/Delete/5
        public ActionResult Delete(int id)
        {
            UnitModel unitModel = new UnitModel();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Select * from Unit where UnitId=@UnitId";
                SqlDataAdapter adp = new SqlDataAdapter(query, con);
                adp.SelectCommand.Parameters.AddWithValue("@UnitId", id);
                adp.Fill(dt);
            }
            if (dt.Rows.Count == 1)
            {
                unitModel.UnitId = Convert.ToInt32(dt.Rows[0][0].ToString());
                unitModel.UnitName = dt.Rows[0][1].ToString();

                return View(unitModel);

            }
            else
                return RedirectToAction("Index");
        }

        // POST: Unit/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Delete From Unit  where UnitId=@UnitId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UnitId", id);

                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
            //try
            //{
            //    // TODO: Add delete logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}
