using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Veri_Tabanli_Parti_Secim_İstatistikleri
{
    public partial class FrmOyGirisi : Form
    {
        public FrmOyGirisi()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=DbSecimProjesi;Integrated Security=True");

        private void btngiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLILCE (ILCE, APARTI,BPARTI,CPARTI,DPARTI,EPARTI) values (@P1, @P2, @P3, @P4, @P5, @P6 )", baglanti);
            komut.Parameters.AddWithValue("@P1", txtilcead.Text);
            komut.Parameters.AddWithValue("@P2", txta.Text);
            komut.Parameters.AddWithValue("@P3", txtb.Text);
            komut.Parameters.AddWithValue("@P4", txtc.Text);
            komut.Parameters.AddWithValue("@P5", txtd.Text);
            komut.Parameters.AddWithValue("@P6", txte.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Oy Girişi Gerçekleşti!");
        }

        private void btngrafik_Click(object sender, EventArgs e)
        {
            Grafikler grf = new Grafikler();
            grf.Show();
        }
    }
}
