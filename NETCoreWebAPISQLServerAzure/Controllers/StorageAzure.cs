using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NETCoreWebAPISQLServerAzure.Controllers
{
    public class StorageAzure
    {
        public List<perros> ListadePerros;
        public bool Almacenar(string Nombre, string Sexo, int year_adopcion, string esterilizacion, string direccion)
        {
            var connect = new SqlConnection
                ("Server=" +
                "Initial Catalog=App_Perror;" +
                "Persist Security Info=False;" +
                "User ID=;" +
                "Password=;" +
                "MultipleActiveResultSets=False;" +
                "Encrypt=True;" +
                "TrustServerCertificate=False;" +
                "Connection Timeout=30;");
            var query = new SqlCommand
                ("INSERT INTO Datos (Nombre, Sexo, year_adopcion, esterilizacion, direccion) VALUES " +
                "('" + Nombre + "','" + Sexo + "','" + year_adopcion + "', '" + esterilizacion + "','" + direccion + "')", connect);

            try
                {
                    connect.Open();
                    query.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
            catch (SqlException ex)
            {
                    connect.Close();
                    return false;
                    
            }
        }

        public List<perros> Consulta(int ID)
        {
            var dt = new DataTable();
            var connect = new SqlConnection
                ("Server=tcp:perros.database.windows.net,1433;" +
                "Initial Catalog=App_Perror;" +
                "Persist Security Info=False;" +
                "User ID=erikroot;" +
                "Password=6TeQ&KeraN16;" +
                "MultipleActiveResultSets=False;" +
                "Encrypt=True;" +
                "TrustServerCertificate=False;" +
                "Connection Timeout=30;");
            var cmd = new SqlCommand
                ("SELECT * From Datos WHERE ID ='" + ID + "'", connect);
            connect.Open();
            var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            ListadePerros = new List<perros>();
            perros perro = new perros();
            perro.ID = int.Parse((dt.Rows[0]["ID"]).ToString());
            perro.Nombre = (dt.Rows[0]["Nombre"]).ToString();
            perro.Sexo = (dt.Rows[0]["Sexo"]).ToString();
            perro.year_adopcion = int.Parse((dt.Rows[0]["year_adopcion"]).ToString());
            perro.esterilizacion = (dt.Rows[0]["esterilizacion"]).ToString();
            perro.direccion = (dt.Rows[0]["direccion"]).ToString();
            ListadePerros.Add(perro);

            return ListadePerros;
        }
    }
}
