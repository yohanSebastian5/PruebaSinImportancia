using PruebaSinImportancia.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PruebaSinImportancia.Controllers
{
    public class BibliotecaController : Controller
    {
        public static SqlConnection conexion = new SqlConnection( "Data Source=.;Initial Catalog=dbPruebaSena;Integrated Security=True");


        // GET: Biblioteca
        public ActionResult Index()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("List_Libro", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            SqlDataReader tabla = comando.ExecuteReader();
            List<Libro> libros = new List<Libro>();
            while (tabla.Read())
            {
                Libro objE = new Libro();
                objE.id = tabla.GetInt32(0);
                objE.nombre = tabla.GetString(1);
                objE.autor = tabla.GetString(2);
                objE.estado = tabla.GetString(3);
                objE.ubicacionFisica = tabla.GetString(4);
                objE.año = tabla.GetString(5);
                libros.Add(objE);

            }

            conexion.Close();

            return View(libros);
        }

        // GET: Biblioteca/Details/5
        public ActionResult Details(int id)

        {

       
            return View();
        }

        // GET: Biblioteca/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Biblioteca/Create
        [HttpPost]
        public ActionResult Create(Libro objE)
        {

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("Inst_Libro", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombre", objE.nombre);
                comando.Parameters.AddWithValue("@autor", objE.autor);
                comando.Parameters.AddWithValue("@estado", objE.estado);
                comando.Parameters.AddWithValue("@ubicacionfisica", objE.ubicacionFisica);
                comando.Parameters.AddWithValue("@año", objE.año);
                comando.Parameters.AddWithValue("@idGenero", objE.idGenero);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                conexion.Close();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Biblioteca/Edit/5
        public ActionResult Edit(int id)
        {
            conexion.Open();
            string consul = "List_LibroPorId";
            SqlCommand comando = new SqlCommand(consul, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idLibro", id);
            comando.ExecuteNonQuery();
            SqlDataReader tabla = comando.ExecuteReader();
            Libro objE = new Libro();
            while (tabla.Read())
            {

                objE.nombre = tabla.GetString(1);
                objE.autor = tabla.GetString(2);
                objE.estado = tabla.GetString(3);
                objE.ubicacionFisica = tabla.GetString(4);
                objE.año = tabla.GetString(5);

            }
            conexion.Close();
            return View(objE);


        }

        // POST: Biblioteca/Edit/5
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

        // GET: Biblioteca/Delete/5
        public ActionResult Delete(int id)
        {
            conexion.Open();
            string consul = "List_LibroPorId";
            SqlCommand comando = new SqlCommand(consul,conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idLibro",id);
            comando.ExecuteNonQuery();
            SqlDataReader tabla = comando.ExecuteReader();
            Libro objE = new Libro();
            while (tabla.Read())
            {
       
                objE.nombre = tabla.GetString(1);
                objE.autor = tabla.GetString(2);
                objE.estado = tabla.GetString(3);
                objE.ubicacionFisica = tabla.GetString(4);
                objE.año = tabla.GetString(5);

            }
            conexion.Close();
            return View(objE);
        }

        // POST: Biblioteca/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Libro lib)
        {
            try
            {
                conexion.Open();
                string Proc = "Del_Libro";
                SqlCommand comando = new SqlCommand(Proc,conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idProducto",id);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                conexion.Close();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
