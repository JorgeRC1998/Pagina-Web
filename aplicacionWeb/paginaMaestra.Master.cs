using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace aplicacionWeb
{
    public partial class paginaMaestra : System.Web.UI.MasterPage
    {
        GestionDatitos objGestion = new GestionDatitos();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //string x = Request.QueryString["serial"];
            //Vehiculito vehiculo = objGestion.consultarVehiculo(x);
            //if (vehiculo != null)
            //{
            //    Label9.Text = vehiculo.placa;
            //    Label10.Text = vehiculo.color;
            //    Label16.Text = vehiculo.marca;
            //    Label11.Text = vehiculo.modelo;
            //    Label12.Text = vehiculo.QR;
            //    Label13.Text = vehiculo.imagen;

            //}
            //else
            //{

            //}
        }

        
       
        protected void Button1_Click1(object sender, EventArgs e)
        {
            //Codigo de prueba para mostrar la descripcion al pulsar el boton, al realizar la integracion con el codigo qr
            //Este codigo se carga al iniciar la pagina, en el metodo load de arriba
            string serial = Request.QueryString["serial"];
            if (serial == null)
            {
                Console.WriteLine("Error");
            }
            else
            {
                Vehiculito vehiculo = objGestion.consultarVehiculo(serial);
                if (vehiculo != null)
                {
                    Label9.Text = vehiculo.placa;
                    Label10.Text = vehiculo.color;
                    Label16.Text = vehiculo.marca;
                    Label11.Text = vehiculo.modelo;
                    Label13.Text = vehiculo.serial;
                }
                else
                {

                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Calificacion objCalificacion = new Calificacion();
            objCalificacion.pregunta1 = Convert.ToInt32(c1.Value);
            objCalificacion.pregunta2 = Convert.ToInt32(c2.Value);
            objCalificacion.pregunta3 = Convert.ToInt32(c3.Value);
            objCalificacion.pregunta4 = Convert.ToInt32(c4.Value);
            objCalificacion.pregunta5 = Convert.ToInt32(c5.Value);
            objCalificacion.serial = Label13.Text;
            if (objCalificacion.serial == "Label")
            {

            }
            else
            {
                objCalificacion = objGestion.insertarCalificacion(objCalificacion);
            }
        }
    }
}