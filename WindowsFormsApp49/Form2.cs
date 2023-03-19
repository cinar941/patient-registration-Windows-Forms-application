using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//sql kutuphanemız

namespace WindowsFormsApp49
{
    public partial class Form2 : Form
    {
        //connectıon cumle sql verı tabanındakı adresımmız verılerın oldugu yer
        SqlConnection dfg = new SqlConnection("Data Source=DESKTOP-RLCKHNM\\SQLEXPRESS;Initial Catalog=sbo;Integrated Security=True;Pooling=False");
        public Form2()
        {
            InitializeComponent();
        }  
        private void Form2_Load(object sender, EventArgs e)          
        {
            dateTimePicker1.ShowUpDown = true;//bu ozellıık ıle yan tarfındakı oklar ıle gun gun ilerı geri yapabılıyoruz
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            radioButton1.CheckedChanged += RadioButton1_CheckedChanged;
            radioButton2.CheckedChanged += RadioButton2_CheckedChanged;
            progressBar1.Click += ProgressBar1_Click;
            button1.VisibleChanged += Button1_VisibleChanged;//button un vısıblle changed ozellıgını ayarladık
            //controls tooltıp ıle textbox masked text box ve buton uzerıne balonuck cıkarak bılldırı vermesınnı sagladık
            Controls_Tooltip("GEÇERLİ BİR ŞİFRE GİRİNİZ", "LÜTFEN BOŞLUK BIRAKMAYINIZ",textBox3);
            Controls_Tooltip("İSİM SOYİSİM BÖLÜMÜDÜR", "İSİM SOY İSİM ARASI BİR BOŞLUK BIRAKINIZ", textBox1);
            Controls_Tooltip("TELEFON NUMARASI BÖLÜMÜDÜR", "GEÇERLİ BİR TELEFON NUMARASI GİRİNİZ", maskedTextBox1);
            Controls_Tooltip("", "BOŞ BÖLÜM BIRAKMAYINIZ", button1);
            Controls_Tooltip("LÜTFEN BOŞLUK BIRAKMAYINIZ", "",maskedTextBox2);
            // TextMaskFormat özelliğini ayarlama
            maskedTextBox2.TextMaskFormat = MaskFormat.IncludeLiterals;
        }
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //date tıme pıcker dan sectıgım tarıhı masked textbox2 ye yazdık
            maskedTextBox2.Text = dateTimePicker1.Value.ToString();
        }
        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {//radıo butona tıklayınca kendı rengını kırmızı yanındakı butonu beyaz yapııyor
            radioButton2.BackColor = Color.Red;
            radioButton1.BackColor = Color.White;
            radioButton2.Text = "cinsiyet erkek seçildi";
        }
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {//radıo butona tıklayınca kendı rengını kırmızı yanındakı butonu beyaz yapııyor
            radioButton1.BackColor = Color.Red;
            radioButton2.BackColor = Color.White;
            radioButton2.Text = "cinsiyet kadın seçildi";

        }
        private void ProgressBar1_Click(object sender, EventArgs e)
        {//progres bara tıklandıg zaman form 1 e donuyor
            Form1 fg = new Form1();
            fg.Show();
        }
        private void Button1_VisibleChanged(object sender, EventArgs e)
        {
            //butonun visible degısınce butonun arka plan rengı degısıyor
            button1.BackColor = Color.AliceBlue;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == ""||textBox2.Text==""||textBox3.Text==""||maskedTextBox2.Text==""||maskedTextBox1.Text=="")
            {//if içinde belirtilen yerler boş ise bosluk bırakmayı mesajı geldı
                MessageBox.Show("BOŞLUK BIRAKMAYINIZ");
            }else
            {
                progressBar1.Visible = true;//progrss barı gorunur yaptık
                try
                {
                    if (dfg.State == ConnectionState.Closed)
                    {//text boxlar ve masked text boxlardan aldıklarımzı pparametrelere atadık ve bu parametreler 
                        //ile add yaptık yanı ekledık yenı kullanıcı kaydı yapmış olduk
                        dfg.Open();
                        string kayit = "insert into gir(ISIMSOYISIM,kullanıcadı,şifre,TARİH,TELEFONNUMARASI,CİNSİYET) values (@tcno,@isim,@bolum,@trh,@tlf,@CNS)";
                        SqlCommand komut = new SqlCommand(kayit, dfg);
                        komut.Parameters.AddWithValue("@tcno", textBox1.Text);
                        komut.Parameters.AddWithValue("@isim", textBox2.Text);
                        komut.Parameters.AddWithValue("@bolum", textBox3.Text);
                        komut.Parameters.AddWithValue("@trh", maskedTextBox2.Text);
                        komut.Parameters.AddWithValue("@tlf", maskedTextBox1.Text);
                        if(radioButton1.Checked==true)
                        {
                            komut.Parameters.AddWithValue("@CNS", radioButton1.Text);

                        }else if(radioButton2.Checked==true)
                        {
                            komut.Parameters.AddWithValue("@CNS", radioButton2.Text);
                        }
                        komut.ExecuteNonQuery();
                        dfg.Close();
                        //progrss bar mın max degerlerı belırledık ve value deerını maxa esıtlemek ıcın donguye soktuk
                        //bu sekılde progrs bar doldu ve en son dongu kırıdı ve progress bar gızlendı
                        int i;
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = 200;
                        for (i = 0; i <= 199; i++)
                        {
                            progressBar1.Value = i;
                        }
            MessageBox.Show(" Kayıt İşlemi Gerçekleşti.GİRİŞ ekranına gıtmek ıçın barın uzerıne tıklayınız");//message box uyarı verdı
                    }
                
                    }
                catch (Exception hata)
                {
                    MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                }
                
            }
        }
        private void maskedTextBox1_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {//type valıdatıtg completed ozellıgını ayarladık
           
            if (!e.IsValidInput)
            {//tooltıp tıtle uarı verır gecersız tarıh
                toolTip1.ToolTipTitle = "Geçersiz tarih";
                toolTip1.Show("Verdiğiniz veriler, aa / gg / yyyy biçiminde geçerli bir tarih olmalıdır.", maskedTextBox2, 0, -20, 5000);
            }
            else
            {
                DateTime userDate = (DateTime)e.ReturnValue;
                if (userDate < DateTime.Now)
                {//secılen tarıh eger sımdıkı tarıhten eskı ıse tooltıp uyarı verır 
                    toolTip1.ToolTipTitle = "Geçersiz tarih";
                    toolTip1.Show("Verdiğiniz veriler, aa / gg / yyyy biçiminde geçerli bir tarih olmalıdır.", maskedTextBox2, 0, -20, 5000);
                    e.Cancel = true;
                }
            }
        }     
        ToolTip Controls_Tooltip(string baslik, string aciklama, Control cntrl)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.Active = true; // Görünsün mü?
            toolTip.ToolTipTitle = baslik; // Çıkacak Mesajın Başlığı
            toolTip.ToolTipIcon = ToolTipIcon.Info; // Çıkacak Mesajda yer alacak ıkon
            toolTip.UseFading = true; // Silinerek kaybolma ve yavaşça görünme
            toolTip.UseAnimation = true; // Animasyonlu açılış
            toolTip.IsBalloon = true; // Baloncuk şekli mi dikdörtgen mi?
            toolTip.ShowAlways = true; // her zaman göster
            toolTip.AutoPopDelay = 3000; // Mesajın açık kalma süresi
            toolTip.ReshowDelay = 3000; // Mause çekildikten kaç ms sonra kaybolsun
            toolTip.InitialDelay = 100; // Mesajın açılma süresi
            toolTip.BackColor = Color.Red; // arka plan rengi
            toolTip.ForeColor = Color.White; // yazı rengi
            toolTip.SetToolTip(cntrl, aciklama); // Hangi kontrolde görünsün
            return toolTip;
        }
        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {//masked textbox 2 nın maskesını ayarladık
            maskedTextBox2.Mask = "00/00/0000";
        }
    }
}
