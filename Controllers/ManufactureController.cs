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
            ManufactureModel manufactureModel = new ManufactureModel();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Select * from Manufacture where ManufactureId=@ManufactureId";
                SqlDataAdapter adp = new SqlDataAdapter(query, con);
                adp.SelectCommand.Parameters.AddWithValue("@ManufactureId", id);
                adp.Fill(dt);
            }
            if (dt.Rows.Count == 1)
            {
                manufactureModel.ManufactureId = Convert.ToInt32(dt.Rows[0][0].ToString());
                manufactureModel.ManufactureName = dt.Rows[0][1].ToString();
                manufactureModel.ManufactureEmail = dt.Rows[0][2].ToString();
                manufactureModel.ManufactureMobile = dt.Rows[0][3].ToString();
                manufactureModel.ManufactureAddress = dt.Rows[0][4].ToString();
                manufactureModel.ManufactureZipcode = Convert.ToInt32(dt.Rows[0][5].ToString());
                manufactureModel.ManufactureCountry = dt.Rows[0][6].ToString();



                return View(manufactureModel);

            }
            else
                return RedirectToAction("Index");
        }

        // POST: Manufacture/Edit/5
        [HttpPost]
        public ActionResult Edit(ManufactureModel manufactureModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Update Manufacture set ManufactureName=@ManufactureName, ManufactureEmail=@ManufactureEmail, ManufactureMobile=@ManufactureMobile, ManufactureAddress=@ManufactureAddress , ManufactureZipcode=@ManufactureZipcode, ManufactureCountry=@ManufactureCountry where ManufactureId=@ManufactureId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ManufactureId", manufactureModel.ManufactureId);
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

        // GET: Manufacture/Delete/5
        public ActionResult Delete(int id)
        {
            ManufactureModel manufactureModel = new ManufactureModel();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Select * from Manufacture where ManufactureId=@ManufactureId";
                SqlDataAdapter adp = new SqlDataAdapter(query, con);
                adp.SelectCommand.Parameters.AddWithValue("@ManufactureId", id);
                adp.Fill(dt);
            }
            if (dt.Rows.Count == 1)
            {
                manufactureModel.ManufactureId = Convert.ToInt32(dt.Rows[0][0].ToString());
                manufactureModel.ManufactureName = dt.Rows[0][1].ToString();
                manufactureModel.ManufactureEmail = dt.Rows[0][2].ToString();
                manufactureModel.ManufactureMobile = dt.Rows[0][3].ToString();
                manufactureModel.ManufactureAddress = dt.Rows[0][4].ToString();
                manufactureModel.ManufactureZipcode = Convert.ToInt32(dt.Rows[0][5].ToString());
                manufactureModel.ManufactureCountry = dt.Rows[0][6].ToString();



                return View(manufactureModel);

            }
            else
                return RedirectToAction("Index");
        }

        // POST: Manufacture/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Delete From Manufacture  where ManufactureId=@ManufactureId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ManufactureId", id);

                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}
