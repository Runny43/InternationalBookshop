using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using InternationalBookshop.Model;
namespace InternationalBookshop.DatabaseHelper
{
    public class Database
    {
        const string database = "InternationalBookShop";
        const string server = "DESKTOP-G0MO3BT";
        SqlConnection connection = new SqlConnection($"Data Source={server};Initial Catalog={database};Integrated Security=True");

        public DataTable GetBooks()
        {
            return Fill("spGetBook");
        }

        public DataTable GetTrolley(String user)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@email", user));
            return Fill2("spGetTrolley", paramList);
        }

        public DataTable GetBooked(String user)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@email", user));
            return Fill2("spGetBooked", paramList);
        }
        public DataTable SearchBook(String book)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@name", book));
            return Fill2("spSearchBook", paramList);
        }
        public void SaveTrolley(Trolley trolley)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@bookid", trolley.bookid));
            paramList.Add(new SqlParameter("@name", trolley.name));
            paramList.Add(new SqlParameter("@email", trolley.email));
            paramList.Add(new SqlParameter("@ISBN", trolley.ISBN));
            paramList.Add(new SqlParameter("@photoPath", trolley.PhotoPath));
            paramList.Add(new SqlParameter("@title", trolley.Title));
            paramList.Add(new SqlParameter("@author", trolley.Author));
            paramList.Add(new SqlParameter("@publicationDate", trolley.PublicationDate));
            paramList.Add(new SqlParameter("@price", trolley.Price));

            Execute("spSaveTrolley", paramList);
        }
        public void SaveBooked(Booked booked)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@bookid", booked.BookId));
            paramList.Add(new SqlParameter("@name", booked.Name));
            paramList.Add(new SqlParameter("@email", booked.Email));
            paramList.Add(new SqlParameter("@country", booked.Country));
            paramList.Add(new SqlParameter("@province", booked.Province));
            paramList.Add(new SqlParameter("@address", booked.Address));
            paramList.Add(new SqlParameter("@postalcode", booked.PostalCode));
            paramList.Add(new SqlParameter("@cardnumber", booked.CardNumber));
            paramList.Add(new SqlParameter("@checkout", booked.Checkout));
            paramList.Add(new SqlParameter("@securitycode", booked.SecurityCode));
            paramList.Add(new SqlParameter("@total", booked.Total));

            Execute("spSaveBooked", paramList);
        }
        public void DeleteTrolley(int Bookid)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@bookid", Bookid));
            

            Execute("spSaveTrolley", paramList);
        }
        public DataTable Fill(string storedProcedure)
        {
            //control de errores
            try
            {
                //usamos la conexion
                using (this.connection)
                {

                    //abra la conexion a la base de datos
                    connection.Open();
                    //creamos un comando de base de datos
                    SqlCommand cmd = connection.CreateCommand();
                    //el comando es de tipo store procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    //le damos el noombre del store procedure
                    cmd.CommandText = storedProcedure;

                    //creamos el objeto que almacena los datos
                    DataTable ds = new DataTable();
                    //el adaptador ejecuta el comando a la base de datos
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    //llena el objeto con los datos que devolvio el adapter
                    adapter.Fill(ds);
                    //retornamos el objeto lleno de datos
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Fill2(string storedProcedure, List<SqlParameter> paramList)
        {
            //control de errores
            try
            {
                //usamos la conexion
                using (this.connection)
                {

                    //abra la conexion a la base de datos
                    connection.Open();
                    //creamos un comando de base de datos
                    SqlCommand cmd = connection.CreateCommand();
                    //el comando es de tipo store procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    //le damos el noombre del store procedure
                    cmd.CommandText = storedProcedure;
                    foreach (SqlParameter param in paramList)
                    {
                        cmd.Parameters.Add(param);
                    }

                    cmd.ExecuteNonQuery();
                    //creamos el objeto que almacena los datos
                    DataTable ds = new DataTable();
                    //el adaptador ejecuta el comando a la base de datos
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    //llena el objeto con los datos que devolvio el adapter
                    adapter.Fill(ds);
                    //retornamos el objeto lleno de datos
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Execute(string storedProcedure, List<SqlParameter> paramList)
        {
            //control de errores
            try
            {
                //usamos la conexion
                using (this.connection)
                {
                    //abra la conexion a la base de datos
                    connection.Open();
                    //creamos un comando de base de datos
                    SqlCommand cmd = connection.CreateCommand();
                    //el comando es de tipo store procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    //le damos el noombre del store procedure
                    cmd.CommandText = storedProcedure;

                    foreach (SqlParameter param in paramList)
                    {
                        cmd.Parameters.Add(param);
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}