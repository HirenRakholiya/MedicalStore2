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
                TypeModel typeModel = new TypeModel();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Select * from   Type where  TypeId=@TypeId";
                SqlDataAdapter adp = new SqlDataAdapter(query, con);
                adp.SelectCommand.Parameters.AddWithValue("@TypeId", id);
                adp.Fill(dt);
            }
            if (dt.Rows.Count == 1)
            {
                typeModel.Typeid = Convert.ToInt32(dt.Rows[0][0].ToString());
                typeModel.TypeName = dt.Rows[0][1].ToString();

                return View(typeModel);

            }
            else
                return RedirectToAction("Index");
        }

        // POST: Type/Edit/5
        [HttpPost]
        public ActionResult Edit(TypeModel typeModel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Update Type set TypeName=@TypeName where TypeId=@TypeId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TypeId", typeModel.Typeid);
                cmd.Parameters.AddWithValue("@TypeName", typeModel.TypeName);

                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Type/Delete/5
        public ActionResult Delete(int id)
        {
            TypeModel typeModel = new TypeModel();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Select * from Type where TypeId=@TypeId";
                SqlDataAdapter adp = new SqlDataAdapter(query, con);
                adp.SelectCommand.Parameters.AddWithValue("@TypeId", id);
                adp.Fill(dt);
            }
            if (dt.Rows.Count == 1)
            {
                typeModel.Typeid = Convert.ToInt32(dt.Rows[0][0].ToString());
                typeModel.TypeName = dt.Rows[0][1].ToString();

                return View(typeModel);

            }
            else
                return RedirectToAction("Index");
        }

        // POST: Type/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Delete From Type  where TypeId=@TypeId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TypeId", id);

                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}
