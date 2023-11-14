using IntegracionCRM.ApiRest;
using System;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

namespace IntegracionCRM
{
    public class Program
    {
        static DBApi dBApi = new DBApi();
 
        static contactoMautic cont = new contactoMautic();
   
                    
        
        static void Main(string[] args)
        {
            try
            {
                          EnviarContactoMautic();
                        //    BorrarContactoMautic();


            }

            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }

        

        private static void EnviarContactoMautic() 
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=facturacion.bebelandia.com.ec;Initial Catalog=InventarioSQL;User ID=inventario;Password=inventa3iobm11$;"))

                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("dbo.spContactosMautic", con);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    var dt = new DataTable();
                    var da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                   // StringBuilder jsonf = new StringBuilder();
                    for (int i = 0; i < dt.Rows.Count; i++)

                    {
                        string landing = dt.Rows[i]["landing_origen"].ToString();
                        string crm = dt.Rows[i]["tipo_crm"].ToString();
                        string cedula = dt.Rows[i]["cedula"].ToString();
                        string tipo_facebook = dt.Rows[i]["tipo_facebook"].ToString();
                        string tipo_web = dt.Rows[i]["tipo_web"].ToString();
                        string tipo_cliente = dt.Rows[i]["tipo_cliente"].ToString();
                        string ultima_compra = dt.Rows[i]["ultima_compra"].ToString();
                        string fecha_nacimiento = dt.Rows[i]["fecha_nacimiento"].ToString();
                        string categoria_socia = dt.Rows[i]["categoria_socia"].ToString();
                        string local = dt.Rows[i]["local"].ToString();
                        string semana = dt.Rows[i]["semana"].ToString();
                        string nombre = dt.Rows[i]["nombre"].ToString();
                        string apellido = dt.Rows[i]["apellido"].ToString();
                        string email = dt.Rows[i]["email"].ToString();
                        string mobile = dt.Rows[i]["mobile"].ToString();
                        string phone = dt.Rows[i]["phone"].ToString();
                        string direccion = dt.Rows[i]["direccion"].ToString();
                        string ciudad = dt.Rows[i]["ciudad"].ToString();
                        string provincia = dt.Rows[i]["provincia"].ToString();
                        string fecha_ultima_activacion = dt.Rows[i]["fecha_ultima_activacion"].ToString();


                        dynamic val = cont.contacto();
                        string json = val;

                        json = json.Replace("landing2", landing);
                        json = json.Replace("crm2", crm);
                        json = json.Replace("cedula2", cedula);
                        json = json.Replace("afiliadafb2", tipo_facebook);
                        json = json.Replace("afiliadaweb2", tipo_web);
                        json = json.Replace("tipocliente2", tipo_cliente);
                        json = json.Replace("categoriasocia2", categoria_socia);
                        json = json.Replace("ultimacompra2", ultima_compra);
                        json = json.Replace("fpp2", fecha_nacimiento);
                        json = json.Replace("tienda2", local);
                        json = json.Replace("semana2", semana);
                        json = json.Replace("firstname2", nombre);
                        json = json.Replace("lastname2", apellido);
                        json = json.Replace("email2", email);
                        json = json.Replace("mobile2", mobile);
                        json = json.Replace("phone2", phone);
                        json = json.Replace("address12", direccion);
                        json = json.Replace("city2", ciudad);
                        json = json.Replace("provincia2", provincia);
                        json = json.Replace("last_active2", fecha_ultima_activacion);


                        dynamic respuesta = dBApi.PostInsert("http://mx1.newsbebemundo.ec/api/contacts/new", json);
                        string res = respuesta.ToString();
                        Console.WriteLine("Respuesta WS:" + res);
                        Console.WriteLine("Contacto CI: " + cedula + " Insertado " + res+" # "+i);



                    }

                }
            }
            catch (SqlException ex)
            {
                string error = ex.ToString();
            
                Console.WriteLine(ex);

            }
        }



        private static void BorrarContactoMautic()
        {
            try
            {
               


                    for (int i = 517000; i < 900000; i++)

                    {

                        

                        dynamic respuesta = dBApi.delete($"http://mx1.newsbebemundo.ec/api/contacts/{i}/delete");
                        string res = respuesta.ToString();
                        Console.WriteLine("Contacto ID: " + i  + " Borrado " + res);



                    }

                
            }
            catch (SqlException ex)
            {
                string error = ex.ToString();

                Console.WriteLine(ex);

            }
        }









    }
}
