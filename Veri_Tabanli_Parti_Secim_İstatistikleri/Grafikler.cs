﻿using System;
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
    public partial class Grafikler : Form
    {
        public Grafikler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=DbSecimProjesi;Integrated Security=True");


        private void Grafikler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select ILCE from TBLILCE", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select SUM(APARTI), SUM(BPARTI), SUM(CPARTI), SUM(DPARTI), SUM(EPARTI) FROM TBLILCE", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A PARTİ", dr2[0]);
                chart1.Series["Partiler"].Points.AddXY("B PARTİ", dr2[1]);
                chart1.Series["Partiler"].Points.AddXY("C PARTİ", dr2[1]);
                chart1.Series["Partiler"].Points.AddXY("D PARTİ", dr2[1]);
                chart1.Series["Partiler"].Points.AddXY("E PARTİ", dr2[1]);
            }
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLILCE where ILCE=@P1", baglanti);
            komut.Parameters.AddWithValue("@P1", comboBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                progressBar1.Value = int.Parse(dr[2].ToString());
                progressBar2.Value = int.Parse(dr[3].ToString());
                progressBar3.Value = int.Parse(dr[4].ToString());
                progressBar4.Value = int.Parse(dr[5].ToString());
                progressBar5.Value = int.Parse(dr[6].ToString());

                lbla.Text = dr[2].ToString();
                lblb.Text = dr[3].ToString();
                lblc.Text = dr[4].ToString();
                lbld.Text = dr[5].ToString();
                lble.Text = dr[6].ToString();
            }
            baglanti.Close();
        }
    }
}
