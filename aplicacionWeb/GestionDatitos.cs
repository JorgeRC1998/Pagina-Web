using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;


namespace aplicacionWeb
{
    public class GestionDatitos
    {

        public Vehiculito consultarVehiculo(string serial)
        {

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = "lincecars123.database.windows.net",
                UserID = "admin123",
                Password = "Velezmesa96/",
                InitialCatalog = "linceCars"
            };

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {

                connection.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = connection;
                comando.CommandText = "exec [dbo].[usp_ConsultaVeh] " + '"' + serial + '"';
                SqlDataReader registro = comando.ExecuteReader();

                if (registro.Read())
                {
                    Vehiculito vehiculo = new Vehiculito();
                    vehiculo.serial = registro.GetString(0);
                    vehiculo.placa = registro.GetString(1);
                    vehiculo.color = registro.GetString(2);
                    vehiculo.marca = registro.GetString(3);
                    vehiculo.modelo = registro.GetString(4);
                    vehiculo.QR = registro.GetString(5);
                    vehiculo.imagen = registro.GetString(6);
                    vehiculo.nitEmp = registro.GetInt64(7);
                    return vehiculo;
                }
                else
                {
                    registro.Close();
                    return null;
                }
            }
        }

        public Calificacion insertarCalificacion(Calificacion calificacion)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = "lincecars123.database.windows.net",
                UserID = "admin123",
                Password = "Velezmesa96/",
                InitialCatalog = "linceCars"
            };

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {

                connection.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = connection;
                comando.CommandText = "exec sp_CalificarVehiculo " + calificacion.pregunta1 + "," + calificacion.pregunta2 + "," + calificacion.pregunta3 + "," +calificacion.pregunta4 +"," +calificacion.pregunta5 + "," +'"' + calificacion.serial+ '"';
                comando.ExecuteNonQuery();               
            }

            return calificacion;
        }
    }
}