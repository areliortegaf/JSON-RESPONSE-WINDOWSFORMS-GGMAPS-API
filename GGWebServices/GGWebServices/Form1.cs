using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text;

namespace GGWebServices
{//contenido auntogenerado
    public partial class Form1 : Form //tipo forma
    {

        //FIELDS

       // String KEY = "AIza............";


        public Form1()
        {
            InitializeComponent(); //el constructor 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void coneccionHTTP(String dir, String api)
        {
           
            //System.net
            WebRequest request = WebRequest.Create("https://maps.googleapis.com/maps/api/geocode/json?address=" + dir + "&key=" + api);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Display the status.
            Console.WriteLine(response.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            textBox3.Text = responseFromServer;
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            String API_KEY = textBox1.Text;

            //saca la direccion del textBox
            String direccion = textBox2.Text;
            //cambia los espacios por "+" para ser leidos correctamente
            direccion = direccion.Replace(" ", "+");

            if (API_KEY == null || API_KEY == "" || direccion == null || direccion == "")
            {
                string message = "¡Favor de llenar los campos!";
                string caption = "Error detectado";
                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                DialogResult result;

                // Muestra el mensaje en dialog box
                result = MessageBox.Show(message, caption, buttons);

            }
            else
            {
                //manda llamar la coneccion htttp
                coneccionHTTP(direccion, API_KEY);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
