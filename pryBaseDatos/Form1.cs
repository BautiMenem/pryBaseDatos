using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace pryBaseDatos
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        OleDbConnection conn = null;
        OleDbCommand cmd = null;
        OleDbDataReader LectorBD = null;
        private void btnConectar_Click(object sender, EventArgs e)
        {
            
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=biblio.accdb; ");
            conn.Open();

            MessageBox.Show("Conectado a base de datos!!!");
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.TableDirect;
            cmd.CommandText = "TITULO";

            //MessageBox.Show("Conexion" + " " + cmd.CommandText, "Mesnsaje de conexion");

            LectorBD = cmd.ExecuteReader();

            while (LectorBD.Read())
            {
                dtvDatos.Rows.Add(LectorBD[0]);
                dtvDatos.Rows[].Add(LectorBD[1]);
                dtvDatos.Rows[].Add(LectorBD[2]);
            }
        }
    }
}
