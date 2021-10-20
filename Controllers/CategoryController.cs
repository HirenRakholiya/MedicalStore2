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
    public class CategoryController : Controller
    {
        string connectionString = @"Data Source=.;Initial Catalog=PharmaWholeSale;Integrated Security=True";
        // GET: Category
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Select * from Category";
                SqlDataAdapter adp = new SqlDataAdapter(query, con);
                adp.Fill(dt);
            }
            return View(dt);
           
        }

        // GET: Category/Details/5
       

        // GET: Category/Create
        public ActionResult Create()
        {
            return View(new CategoryModel());
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryModel categoryModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Insert into Category Values(@CategoryName)";
                SqlCommand cmd = new SqlCommand(query, con);
                // cmd.Parameters.AddWithValue("@Id", manufactureModel.Id);
                cmd.Parameters.AddWithValue("@CategoryName", categoryModel.CategoryName);
              
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
           
            CategoryModel categoryModel = new CategoryModel();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Select * from Category where CategoryId=@CategoryId";
                SqlDataAdapter adp = new SqlDataAdapter(query, con);
                adp.SelectCommand.Parameters.AddWithValue("@CategoryId", id);
                adp.Fill(dt);
            }
            if (dt.Rows.Count == 1)
            {
                categoryModel.CategoryId = Convert.ToInt32(dt.Rows[0][0].ToString());
                categoryModel.CategoryName = dt.Rows[0][1].ToString();
            
                return View(categoryModel);

            }
            else
                return RedirectToAction("Index");
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(CategoryModel categoryModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Update Category set CategoryName=@CategoryName where CategoryId=@CategoryId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CategoryId", categoryModel.CategoryId);
                cmd.Parameters.AddWithValue("@CategoryName",categoryModel.CategoryName);
                
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
           
            CategoryModel categoryModel = new CategoryModel();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Select * from Category where CategoryId=@CategoryId";
                SqlDataAdapter adp = new SqlDataAdapter(query, con);
                adp.SelectCommand.Parameters.AddWithValue("@CategoryId", id);
                adp.Fill(dt);
            }
            if (dt.Rows.Count == 1)
            {
                categoryModel.CategoryId = Convert.ToInt32(dt.Rows[0][0].ToString());
                categoryModel.CategoryName = dt.Rows[0][1].ToString();
             
                return View(categoryModel);

            }
            else
                return RedirectToAction("Index");
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Delete From Category  where CategoryId=@CategoryId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CategoryId", id);

                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}
