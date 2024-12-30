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
        Ogrenci? ogr; //? i�areti null d�nebileceklerin alt�n� ye�il �izer
        Dersler? drs; //! i�areti bo� gelsede �nemseme mant���yla �al���r
        Sinif? snf; //o => o lambda i�aretidir o nesnesi i�in her bir o.blabla de�erini e�le�ip e�le�medi�ini kontrol
        public Form1()
        {
            InitializeComponent();
            ogrcomboboxsinifsecguncelle();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //��renci cruid i�leminde tablolar�n null olup olmad���n� kontrol eder varsa alanlar� doldurun diye msgbox atar.
                if (TxtAd.Text == string.Empty || TxtSoyad.Text == string.Empty || TxtNumara.Text == string.Empty || SinifcomboBox.SelectedIndex == -1)
                {
                    MessageBox.Show("T�m Alanlar Doldurmak Zorunludur");
                    return;
                }
                //database ba�lant�m�z� a��yoruz
                using (var ctx = new DBContext())
                {
                    //combobaxdaki se�ilen s�n�f� databaseyle e�le�tiriyoruz 
                    var snf = ctx.tblSiniflar.FirstOrDefault(s => s.SinifAd == SinifcomboBox.SelectedItem.ToString());
                    //e�le�tirdi�imiz comboboxdaki s�n�f�n null olup olmad���n� kontrol ediyoruz
                    if (snf != null)
                    {
                        //burada kontenjanda yer olup olmad���n� sorguluyoruz
                        if (snf.Kontenjan != 0 && snf.Kontenjan > 0)
                        {
                            //e�er kontenjanda yer varsa kaydetme i�lemi ba�lad��� i�in kontenjan� d���r�yor
                            snf.Kontenjan--;
                            ctx.SaveChanges();
                            using (var context = new DBContext())
                            {
                                // Numaran�n unique sorgusunu yap�yoruz ayn� numara var m� diye
                                bool numaraVarMi = context.Ogrenciler.Any(o => o.Numara == TxtNumara.Text.Trim());
                                if (numaraVarMi)
                                {
                                    MessageBox.Show("Bu numara zaten mevcut.");
                                    return;
                                }

                            }
                            try
                            {
                                //burada ��renci kaydetme i�lemini yap�yoruz
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
                                    MessageBox.Show("��renci ba�ar�yla kaydedildi.");
                                }
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show("��renci Kaydedilemedi Hata!" + "/n" + ex);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Kontenjan Doludur!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("S�n�f Se�imi Bo� B�rak�lamaz.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Bir hata Olu�tu" + ex.Message);
            }
        }


        private void DerssecimBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new DBContext())
                {
                    //firstordefault ilk eleman� d�nd�r�yor txtnumarada girili olan yeni forma ��rencinin numaras�n� ve �d parametrelerini g�nderir
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
                // Numara �st�nden ��renci buluyor
                var ogr = ctx.Ogrenciler.FirstOrDefault(o => o.Numara == TxtNumara.Text.Trim());
                if (ogr != null)
                {
                    this.ogr = ogr;
                    TxtAd.Text = ogr.Ad;
                    TxtSoyad.Text = ogr.Soyad;
                    TxtNumara.Text = ogr.Numara;
                    //��rencinin comboboxdaki s�n�f�n�da getiriyor
                    var snf = ctx.tblSiniflar.FirstOrDefault(s => s.SinifAd == SinifcomboBox.SelectedItem.ToString());
                    if (snf != null)
                    {
                        SinifcomboBox.SelectedItem = snf.SinifAd;
                    }
                }
                else
                {
                    MessageBox.Show("��renci Bulunamad�!");
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
                    //Comboboxda se�ili olan s�n�f�n kontenjan�n� bulup g�ncelleme i�in yer olup olmad���n� kontrol ediyorum
                    var snf = ctx.tblSiniflar.FirstOrDefault(s => s.SinifAd == SinifcomboBox.SelectedItem.ToString());
                    if (snf != null && snf.Kontenjan != 0 && snf.Kontenjan > 0 )
                    {
                        ogr.SinifId = snf.SinifId;
                        snf.Kontenjan--;
                    }
                    ctx.Entry(ogr).State = EntityState.Modified;
                    MessageBox.Show(ctx.SaveChanges() > 0 ? "G�ncelleme Ba�ar�l�" : "G�ncelleme Ba�ar�s�z");
                }
                else
                {
                    MessageBox.Show("�nce ��renci Bulunmal�d�r.");
                }
            }
        }



        private void dersbulBtn_Click(object sender, EventArgs e)
        {
            using (var ctx = new DBContext())
            {
                //derskod �zerinden dersin ad�n� �a��r�yorum g�ncelleme yapabilmek i�in
                var drs = ctx.tblDersler.FirstOrDefault(d => d.DersKod == derskoduTxt.Text.Trim());
                if (drs != null)
                {
                    this.drs = drs;
                    dersadTxt.Text = drs.DersAd;
                }
                else
                {
                    MessageBox.Show("Ders Bulunamad�!");
                }

            }
        }

        private void derskaydetBtn_Click(object sender, EventArgs e)
        {
            //derskaydetmek i�in textlerin null olup olmad���n� kontrol ediyorum
            if (dersadTxt.Text == string.Empty || derskoduTxt.Text == string.Empty)
            {
                MessageBox.Show("T�m Alanlar� Doldurmas� Zorunludur");
                return;
            }

            try
            {
                using (var context = new DBContext())
                {
                    //ders kodunu unique oldu�u i�in ders kodunun daha �nce olup olmad���n� kontrol ediyorum.
                    bool derskodvarmi = context.tblDersler.Any(d => d.DersKod == derskoduTxt.Text.Trim());
                    if (derskodvarmi)
                    {
                        MessageBox.Show("Bu ders kodu zaten mevcut.");
                        return;
                    }
                }
                using (var context = new DBContext())
                {
                    //ayn� �ekilde ders ad�n�nda ayn� olmamas� i�in kontrol ediyorum
                    bool dersadvarmi = context.tblDersler.Any(d => d.DersAd == dersadTxt.Text.Trim());
                    if (dersadvarmi)
                    {
                        MessageBox.Show("Bu ders ad� zaten mevcut.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata ile kar��la��ld�:\n" + ex.Message);
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
                    MessageBox.Show("Ders ba�ar�yla kaydedildi.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Bir hata ile kar��la��ld�." + "/n" + ex);
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
                    //Entity state savechanges �a��r�ld���nda drs ile ili�kili t�m de�i�iklikleri update sorgusu olarak yans�t�r
                    ctx.Entry(drs).State = EntityState.Modified;
                    try
                    {
                        using (var context = new DBContext())
                        {
                            //G�ncelleme yap�l�rken derse ad�n�n unique oldu�u i�in daha �nce o ders ad�nda bir kay�t var m� kontrol�n� yap�yorum
                            bool dersadvarmi = context.tblDersler.Any(d => d.DersAd == dersadTxt.Text.Trim());
                            if (dersadvarmi)
                            {
                                MessageBox.Show("Bu ders ad� zaten mevcut.");
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata ile kar��la��ld�:\n" + ex.Message);
                    }
                    MessageBox.Show(ctx.SaveChanges() > 0 ? "G�ncelleme Ba�ar�l�" : "G�ncelleme Ba�ar�s�z");
                }

                else
                {
                    MessageBox.Show("�nce Ders Bulunmal�d�r.");
                }


            }
        }

        private void sinifkaydetBtn_Click(object sender, EventArgs e)
        {
            //s�n�f textlerinin null olmamas� i�in 
            if (sinifadTxt.Text == string.Empty || sinifkontenjanTxt.Text == string.Empty)
            {
                MessageBox.Show("T�m Alanlar� Doldurmas� Zorunludur");
                return;
            }

            try
            {
                using (var context = new DBContext())
                {
                    //s�n�f ad� unique oldu�u ba�ka o adda kay�t var m� kontrol ediyorum
                    bool sinifadvarmi = context.tblSiniflar.Any(d => d.SinifAd == sinifadTxt.Text.Trim());
                    if (sinifadvarmi)
                    {
                        MessageBox.Show("Bu s�n�f ad� zaten mevcut.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata ile kar��la��ld�!:\n" + ex.Message);
            }

            try
            {
                //S�n�f verisini databaseye kaydediyorum
                using (var context = new DBContext())
                {
                    var snf = new Sinif
                    {
                        SinifAd = sinifadTxt.Text,
                        //kontenjan databasede int oldu�u i�in texteki stringi int e �eviriyorum
                        Kontenjan = Int32.Parse(sinifkontenjanTxt.Text),
                    };
                    context.tblSiniflar.Add(snf);
                    context.SaveChanges();
                    MessageBox.Show("S�n�f ba�ar�yla kaydedildi.");
                    ogrcomboboxsinifsecguncelle();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Bir Hatayla Kar��la��ld�." + "/n" + ex);
            }
        }

        private void sinifbulBtn_Click(object sender, EventArgs e)
        {
            using (var ctx = new DBContext())
            {
                //sinifad kullanarak buluyorum kontenjan de�erini texte yaz�yorum
                var snf = ctx.tblSiniflar.FirstOrDefault(s => s.SinifAd == sinifadTxt.Text.Trim());
                if (snf != null)
                {
                    this.snf = snf;
                    sinifkontenjanTxt.Text = snf.Kontenjan.ToString();
                }
                else
                {
                    MessageBox.Show("S�n�f Bulunamad�!");
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
                    MessageBox.Show(ctx.SaveChanges() > 0 ? "G�ncelleme Ba�ar�l�" : "G�ncelleme Ba�ar�s�z");
                }

                else
                {
                    MessageBox.Show("�nce S�n�f Bulunmal�d�r.");
                }


            }
        }

        private void ogrcomboboxsinifsecguncelle()
        {
            //combobox�n verisini getirebilmek i�in constrakta �a��r�yorum ve yeni s�n�f eklendi�inde bilgileri g�rmek i�in s�n�fkaydet dede �a��r�yorum
            using (var ctx = new DBContext())
            {
                var siniflist = ctx.tblSiniflar.Select(s => s.SinifAd).ToList();

                if (siniflist != null && siniflist.Any())
                {
                    SinifcomboBox.DataSource = siniflist;
                }
                else
                {
                    MessageBox.Show("Hi� S�n�f Bulunamad�");
                }
            }
        }
    }
}
