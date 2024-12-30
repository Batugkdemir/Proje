using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Proje;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    public partial class Form1 : Form
    {
        Ogrenci? ogr; //? iþareti null dönebileceklerin altýný yeþil çizer
        Dersler? drs; //! iþareti boþ gelsede önemseme mantýðýyla çalýþýr
        Sinif? snf; //o => o lambda iþaretidir o nesnesi için her bir o.blabla deðerini eþleþip eþleþmediðini kontrol
        public Form1()
        {
            InitializeComponent();
            ogrcomboboxsinifsecguncelle();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Öðrenci cruid iþleminde tablolarýn null olup olmadýðýný kontrol eder varsa alanlarý doldurun diye msgbox atar.
                if (TxtAd.Text == string.Empty || TxtSoyad.Text == string.Empty || TxtNumara.Text == string.Empty || SinifcomboBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Tüm Alanlar Doldurmak Zorunludur");
                    return;
                }
                //database baðlantýmýzý açýyoruz
                using (var ctx = new DBContext())
                {
                    //combobaxdaki seçilen sýnýfý databaseyle eþleþtiriyoruz 
                    var snf = ctx.tblSiniflar.FirstOrDefault(s => s.SinifAd == SinifcomboBox.SelectedItem.ToString());
                    //eþleþtirdiðimiz comboboxdaki sýnýfýn null olup olmadýðýný kontrol ediyoruz
                    if (snf != null)
                    {
                        //burada kontenjanda yer olup olmadýðýný sorguluyoruz
                        if (snf.Kontenjan != 0 && snf.Kontenjan > 0)
                        {
                            //eðer kontenjanda yer varsa kaydetme iþlemi baþladýðý için kontenjaný düþürüyor
                            snf.Kontenjan--;
                            ctx.SaveChanges();
                            using (var context = new DBContext())
                            {
                                // Numaranýn unique sorgusunu yapýyoruz ayný numara var mý diye
                                bool numaraVarMi = context.Ogrenciler.Any(o => o.Numara == TxtNumara.Text.Trim());
                                if (numaraVarMi)
                                {
                                    MessageBox.Show("Bu numara zaten mevcut.");
                                    return;
                                }

                            }
                            try
                            {
                                //burada öðrenci kaydetme iþlemini yapýyoruz
                                using (var context = new DBContext())
                                {
                                    var ogr = new Ogrenci
                                    {
                                        Ad = TxtAd.Text,
                                        Soyad = TxtSoyad.Text,
                                        Numara = TxtNumara.Text,
                                        SinifId = snf.SinifId,
                                    };
                                    //ogrenciler tablosuna ekleyip kaydediyoruz
                                    context.Ogrenciler.Add(ogr);
                                    context.SaveChanges();
                                    MessageBox.Show("Öðrenci baþarýyla kaydedildi.");
                                }
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show("Öðrenci Kaydedilemedi Hata!" + "/n" + ex);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Kontenjan Doludur!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sýnýf Seçimi Boþ Býrakýlamaz.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Bir hata Oluþtu" + ex.Message);
            }
        }


        private void DerssecimBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new DBContext())
                {
                    //firstordefault ilk elemaný döndürüyor txtnumarada girili olan yeni forma öðrencinin numarasýný ve ýd parametrelerini gönderir
                    var ogr = ctx.Ogrenciler.FirstOrDefault(o => o.Numara == TxtNumara.Text.Trim());
                    if (ogr != null)
                    {
                        this.ogr = ogr;
                        DersSecim form2 = new DersSecim(ogr.Numara,ogr.OgrenciId);
                        form2.Show();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Bir hata" + ex.Message);
            }
        }



        private void btnbul_Click(object sender, EventArgs e)
        {
            using (var ctx = new DBContext())
            {
                // Numara üstünden öðrenci buluyor
                var ogr = ctx.Ogrenciler.FirstOrDefault(o => o.Numara == TxtNumara.Text.Trim());
                if (ogr != null)
                {
                    this.ogr = ogr;
                    TxtAd.Text = ogr.Ad;
                    TxtSoyad.Text = ogr.Soyad;
                    TxtNumara.Text = ogr.Numara;
                    //Öðrencinin comboboxdaki sýnýfýnýda getiriyor
                    var snf = ctx.tblSiniflar.FirstOrDefault(s => s.SinifAd == SinifcomboBox.SelectedItem.ToString());
                    if (snf != null)
                    {
                        SinifcomboBox.SelectedItem = snf.SinifAd;
                    }
                }
                else
                {
                    MessageBox.Show("Öðrenci Bulunamadý!");
                }
            }
        }

        private void btnguncel_Click(object sender, EventArgs e)
        {
            using (var ctx = new DBContext())
            {
                if (ogr != null)
                {
                    ogr.Numara = TxtNumara.Text.Trim();
                    ogr.Ad = TxtAd.Text.Trim();
                    ogr.Soyad = TxtSoyad.Text.Trim();
                    //Comboboxda seçili olan sýnýfýn kontenjanýný bulup güncelleme için yer olup olmadýðýný kontrol ediyorum
                    var snf = ctx.tblSiniflar.FirstOrDefault(s => s.SinifAd == SinifcomboBox.SelectedItem.ToString());
                    if (snf != null && snf.Kontenjan != 0 && snf.Kontenjan > 0 )
                    {
                        ogr.SinifId = snf.SinifId;
                        snf.Kontenjan--;
                    }
                    ctx.Entry(ogr).State = EntityState.Modified;
                    MessageBox.Show(ctx.SaveChanges() > 0 ? "Güncelleme Baþarýlý" : "Güncelleme Baþarýsýz");
                }
                else
                {
                    MessageBox.Show("Önce Öðrenci Bulunmalýdýr.");
                }
            }
        }



        private void dersbulBtn_Click(object sender, EventArgs e)
        {
            using (var ctx = new DBContext())
            {
                //derskod üzerinden dersin adýný çaðýrýyorum güncelleme yapabilmek için
                var drs = ctx.tblDersler.FirstOrDefault(d => d.DersKod == derskoduTxt.Text.Trim());
                if (drs != null)
                {
                    this.drs = drs;
                    dersadTxt.Text = drs.DersAd;
                }
                else
                {
                    MessageBox.Show("Ders Bulunamadý!");
                }

            }
        }

        private void derskaydetBtn_Click(object sender, EventArgs e)
        {
            //derskaydetmek için textlerin null olup olmadýðýný kontrol ediyorum
            if (dersadTxt.Text == string.Empty || derskoduTxt.Text == string.Empty)
            {
                MessageBox.Show("Tüm Alanlarý Doldurmasý Zorunludur");
                return;
            }

            try
            {
                using (var context = new DBContext())
                {
                    //ders kodunu unique olduðu için ders kodunun daha önce olup olmadýðýný kontrol ediyorum.
                    bool derskodvarmi = context.tblDersler.Any(d => d.DersKod == derskoduTxt.Text.Trim());
                    if (derskodvarmi)
                    {
                        MessageBox.Show("Bu ders kodu zaten mevcut.");
                        return;
                    }
                }
                using (var context = new DBContext())
                {
                    //ayný þekilde ders adýnýnda ayný olmamasý için kontrol ediyorum
                    bool dersadvarmi = context.tblDersler.Any(d => d.DersAd == dersadTxt.Text.Trim());
                    if (dersadvarmi)
                    {
                        MessageBox.Show("Bu ders adý zaten mevcut.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata ile karþýlaþýldý:\n" + ex.Message);
            }

            try
            {
                //ders ekliyorum tbldersler tablosuna
                using (var context = new DBContext())
                {
                    var drs = new Dersler
                    {
                        DersAd = dersadTxt.Text,
                        DersKod = derskoduTxt.Text
                    };

                    context.tblDersler.Add(drs);
                    context.SaveChanges();
                    MessageBox.Show("Ders baþarýyla kaydedildi.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Bir hata ile karþýlaþýldý." + "/n" + ex);
            }
        }

        private void dersguncelleBtn_Click(object sender, EventArgs e)
        {
            using (var ctx = new DBContext())
            {

                if (drs != null)
                {
                    drs.DersAd = dersadTxt.Text.Trim();
                    drs.DersKod = derskoduTxt.Text.Trim();
                    //Entity state savechanges çaðýrýldýðýnda drs ile iliþkili tüm deðiþiklikleri update sorgusu olarak yansýtýr
                    ctx.Entry(drs).State = EntityState.Modified;
                    try
                    {
                        using (var context = new DBContext())
                        {
                            //Güncelleme yapýlýrken derse adýnýn unique olduðu için daha önce o ders adýnda bir kayýt var mý kontrolünü yapýyorum
                            bool dersadvarmi = context.tblDersler.Any(d => d.DersAd == dersadTxt.Text.Trim());
                            if (dersadvarmi)
                            {
                                MessageBox.Show("Bu ders adý zaten mevcut.");
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata ile karþýlaþýldý:\n" + ex.Message);
                    }
                    MessageBox.Show(ctx.SaveChanges() > 0 ? "Güncelleme Baþarýlý" : "Güncelleme Baþarýsýz");
                }

                else
                {
                    MessageBox.Show("Önce Ders Bulunmalýdýr.");
                }


            }
        }

        private void sinifkaydetBtn_Click(object sender, EventArgs e)
        {
            //sýnýf textlerinin null olmamasý için 
            if (sinifadTxt.Text == string.Empty || sinifkontenjanTxt.Text == string.Empty)
            {
                MessageBox.Show("Tüm Alanlarý Doldurmasý Zorunludur");
                return;
            }

            try
            {
                using (var context = new DBContext())
                {
                    //sýnýf adý unique olduðu baþka o adda kayýt var mý kontrol ediyorum
                    bool sinifadvarmi = context.tblSiniflar.Any(d => d.SinifAd == sinifadTxt.Text.Trim());
                    if (sinifadvarmi)
                    {
                        MessageBox.Show("Bu sýnýf adý zaten mevcut.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata ile karþýlaþýldý!:\n" + ex.Message);
            }

            try
            {
                //Sýnýf verisini databaseye kaydediyorum
                using (var context = new DBContext())
                {
                    var snf = new Sinif
                    {
                        SinifAd = sinifadTxt.Text,
                        //kontenjan databasede int olduðu için texteki stringi int e çeviriyorum
                        Kontenjan = Int32.Parse(sinifkontenjanTxt.Text),
                    };
                    context.tblSiniflar.Add(snf);
                    context.SaveChanges();
                    MessageBox.Show("Sýnýf baþarýyla kaydedildi.");
                    ogrcomboboxsinifsecguncelle();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Bir Hatayla Karþýlaþýldý." + "/n" + ex);
            }
        }

        private void sinifbulBtn_Click(object sender, EventArgs e)
        {
            using (var ctx = new DBContext())
            {
                //sinifad kullanarak buluyorum kontenjan deðerini texte yazýyorum
                var snf = ctx.tblSiniflar.FirstOrDefault(s => s.SinifAd == sinifadTxt.Text.Trim());
                if (snf != null)
                {
                    this.snf = snf;
                    sinifkontenjanTxt.Text = snf.Kontenjan.ToString();
                }
                else
                {
                    MessageBox.Show("Sýnýf Bulunamadý!");
                }

            }
        }

        private void sinifguncelleBtn_Click(object sender, EventArgs e)
        {
            using (var ctx = new DBContext())
            {
                if (snf != null)
                {
                    snf.Kontenjan = Int32.Parse(sinifkontenjanTxt.Text.Trim());
                    ctx.Entry(snf).State = EntityState.Modified;
                    MessageBox.Show(ctx.SaveChanges() > 0 ? "Güncelleme Baþarýlý" : "Güncelleme Baþarýsýz");
                }

                else
                {
                    MessageBox.Show("Önce Sýnýf Bulunmalýdýr.");
                }


            }
        }

        private void ogrcomboboxsinifsecguncelle()
        {
            //comboboxýn verisini getirebilmek için constrakta çaðýrýyorum ve yeni sýnýf eklendiðinde bilgileri görmek için sýnýfkaydet dede çaðýrýyorum
            using (var ctx = new DBContext())
            {
                var siniflist = ctx.tblSiniflar.Select(s => s.SinifAd).ToList();

                if (siniflist != null && siniflist.Any())
                {
                    SinifcomboBox.DataSource = siniflist;
                }
                else
                {
                    MessageBox.Show("Hiç Sýnýf Bulunamadý");
                }
            }
        }
    }
}
