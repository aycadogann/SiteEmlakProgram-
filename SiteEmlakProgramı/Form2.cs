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

namespace SiteEmlakProgramı
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Siteler;Integrated Security=True");

        private void KayitGoruntule()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from SiteBilgi", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while(oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["Site"].ToString());
                ekle.SubItems.Add(oku["SatKira"].ToString());
                ekle.SubItems.Add(oku["Oda"].ToString());
                ekle.SubItems.Add(oku["Metrekare"].ToString());
                ekle.SubItems.Add(oku["Fiyat"].ToString());
                ekle.SubItems.Add(oku["Blok"].ToString());
                ekle.SubItems.Add(oku["No"].ToString());
                ekle.SubItems.Add(oku["AdSoyad"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Notlar"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void cmb_Site_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Site.Text=="Zambak Sitesi")
            {
                btn_Zambak.BackColor = Color.Yellow;
                btn_Gul.BackColor = Color.White;
                btn_Menekse.BackColor= Color.White;
                btn_Papatya.BackColor= Color.White;
            }

            if (cmb_Site.Text == "Papatya Sitesi")
            {
                btn_Papatya.BackColor = Color.Yellow;
                btn_Gul.BackColor = Color.White;
                btn_Menekse.BackColor = Color.White;
                btn_Zambak.BackColor = Color.White;
            }

            if (cmb_Site.Text == "Gül Sitesi")
            {
                btn_Gul.BackColor = Color.Yellow;
                btn_Zambak.BackColor = Color.White;
                btn_Menekse.BackColor = Color.White;
                btn_Papatya.BackColor = Color.White;
            }

            if (cmb_Site.Text == "Menekşe Sitesi")
            {
                btn_Menekse.BackColor = Color.Yellow;
                btn_Gul.BackColor = Color.White;
                btn_Zambak.BackColor = Color.White;
                btn_Papatya.BackColor = Color.White;
            }
        }

        private void Temizle()
        {
            txt_Id.Clear();
            cmb_Site.Text = "";
            cmb_SatKira.Text = "";
            cmb_OdaSayisi.Text = "";
            txt_Metrakare.Clear();
            txt_Fiyat.Clear();
            cmb_Blok.Text = "";
            txt_No.Clear();
            txt_AdSoyad.Clear();
            txt_Telefon.Clear();
            txt_Notlar.Clear();
        }
        private void btn_Goruntule_Click(object sender, EventArgs e)
        {
            KayitGoruntule();
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into SiteBilgi (id,Site,SatKira,Oda,Metrekare,Fiyat,Blok,No,AdSoyad,Telefon,Notlar) " +
                "values ('"+txt_Id.Text.ToString()+ "' , '" +cmb_Site.Text.ToString()+ "' , '" +cmb_SatKira.Text.ToString() + "' , " +
                "'" + cmb_OdaSayisi.Text.ToString()+ "' , '" +txt_Metrakare.Text.ToString()+ "' , " +
                "'" +txt_Fiyat.Text.ToString() + "' , '" +cmb_Blok.Text.ToString()+ "' , '" + txt_No.Text.ToString() + "', " +
                "'" +txt_AdSoyad.Text.ToString()+ "' , '" +txt_Telefon.Text.ToString()+ "' , '" +txt_Notlar.Text.ToString()+"')  ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Temizle();
            KayitGoruntule();
        }

        int id = 0;
        private void btn_Sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from SiteBilgi where id=(" + id + ")", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            KayitGoruntule();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            txt_Id.Text = listView1.SelectedItems[0].SubItems[0].Text;
            cmb_Site.Text= listView1.SelectedItems[0].SubItems[1].Text;
            cmb_SatKira.Text= listView1.SelectedItems[0].SubItems[2].Text;
            cmb_OdaSayisi.Text= listView1.SelectedItems[0].SubItems[3].Text;
            txt_Metrakare.Text= listView1.SelectedItems[0].SubItems[4].Text;
            txt_Fiyat.Text= listView1.SelectedItems[0].SubItems[5].Text;
            cmb_Blok.Text= listView1.SelectedItems[0].SubItems[6].Text;
            txt_No.Text= listView1.SelectedItems[0].SubItems[7].Text;
            txt_AdSoyad.Text= listView1.SelectedItems[0].SubItems[8].Text;
            txt_Telefon.Text= listView1.SelectedItems[0].SubItems[9].Text;
            txt_Notlar.Text=listView1.SelectedItems[0].SubItems[10].Text;


        }

        private void btn_Duzelt_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update SiteBilgi set id= '" + txt_Id.Text.ToString() + "' , Site= '" + cmb_Site.Text.ToString() + "' , SatKira= '" + cmb_SatKira.Text.ToString() + "' , " +
                "Oda='" + cmb_OdaSayisi.Text.ToString() + "' , Metrekare ='" + txt_Metrakare.Text.ToString() + "' , " +
                "Fiyat='" + txt_Fiyat.Text.ToString() + "' , Blok='" + cmb_Blok.Text.ToString() + "' , No= '" + txt_No.Text.ToString() + "', " +
                "AdSoyad='" + txt_AdSoyad.Text.ToString() + "' , Telefon='" + txt_Telefon.Text.ToString() + "' , Notlar='" + txt_Notlar.Text.ToString() + "'  where id=("+id+") ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Temizle();
            KayitGoruntule();
        }
    }
}
