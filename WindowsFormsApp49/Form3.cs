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
using System.Media;//bıp sesı cıkartmak ıcın ekledım

namespace WindowsFormsApp49
{
    public partial class Form3 : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-RLCKHNM\\SQLEXPRESS;Initial Catalog=sbo;Integrated Security=True;Pooling=False");

        public Form3()
        {
            InitializeComponent();
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
        private void pictureBox9_Click(object sender, EventArgs e)
        {//urolojı tablosunu data grıd vıev 1 e cagırdık
            try
            {
             baglan.Open();
            string kayit = "SELECT *from UROLOJI";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
            }catch(Exception HATA)
            {
                MessageBox.Show("İŞLEM SIRASINDA BİR HATA OLUŞTU"+HATA.Message);
            }
           
        }
        private void Form3_Load(object sender, EventArgs e)
        {//tab pagelerın arka planları acık mavı yaptım
            tabPage1.BackColor = Color.LightBlue;
            tabPage2.BackColor = Color.LightBlue;
            tabPage3.BackColor = Color.LightBlue;
            tabPage4.BackColor = Color.LightBlue;
            tabPage5.BackColor = Color.LightBlue;
            button2.Enabled = false;
            maskedTextBox3.TextChanged += MaskedTextBox3_TextChanged;//masked text boxun ıcıne yazı yazmamız neyı tetıkleyecek onu belırlemek ıcın yaptım
            tabControl1.Click += TabControl1_Click;//tab controle tıklanınca n eolsun onu yazdık
            numericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;//numerıc up down bır sayı secıldıgınde hangı olay gercekleseck onun ııcn actık
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;//burada hucrenın formatınnı degıstımek ıcın ozellıgı aktıf ettım
            richTextBox2.ContextMenuStrip = contextMenuStrip1;//rich textboxile context menu strıp baglantısını kurdum bu sekılde rıch textboxa tıklayınca acılıcak
            textBox1.ContextMenuStrip = contextMenuStrip1;//rich textboxile context menu strıp baglantısını kurdum bu sekılde rıch textboxa tıklayınca acılıcak
            richTextBox1.ContextMenuStrip = contextMenuStrip1;// textboxile context menu strıp baglantısını kurdum bu sekılde rıch textboxa tıklayınca acılıcak
            dataGridView1.BackgroundColor = Color.White;//estetık gozukmesı ıcın arka planını beyaz yaptım
            button6.Enabled = false;//buton un enable degerı degıstırdım 
            button2.MouseHover += Button2_MouseHover; //BUTTON 2 nın maus hover ozellıgı ayarladık
            dataGridView1.Enabled = false;//data grıd vıev enable false yaptık
            maskedTextBox4.Enabled = false;//masked text boxın enable false yaptık
            maskedTextBox5.Enabled = false;//masked text boxın enable false yaptık           
            //randevu tarıhı aldıgım ıçın geçmıs zaman randevu almasının onune gectım sadece oldugu gun için randevu alıyor
            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker1.MaxDate = DateTime.Today;
            tooltıp();
            textboxlar();
            listbox();
            checkedlistbox();
            error();//bu fonsıyonn ıle textbox 1 ın ıcı bos ıken uyarı verdı error provıder ıle bu alan bos ecılemez dıye yanında unlem ıle          
        }
        private void MaskedTextBox3_TextChanged(object sender, EventArgs e)
        {//masked text boxun ıcıne bısey yazılmadan buton enable true olmaz boşa arama yapmaz

            button2.Enabled = true;
        }
        private void TabControl1_Click(object sender, EventArgs e)
        {
            SystemSounds.Beep.Play();//tab controle tıklayınca bıp dıye ses versın
        }
        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {//numerıc up down dan bir deger secildigi zaman rich text box arka plan rengı degısıyor.
            richTextBox1.BackColor = Color.LightBlue;
        }
        public void tabpage()
        {//tab page arka plan rengı degıstırdım estetık durması ıcın
          tabPage1.BackColor = Color.LightBlue;
                    tabPage2.BackColor = Color.LightBlue;
                    tabPage3.BackColor = Color.LightBlue;
                    tabPage5.BackColor = Color.LightBlue;
                    tabPage4.BackColor = Color.LightBlue;
        }
        public void checkedlistbox()
        {
            checkedListBox1.ItemCheck += CheckedListBox1_ItemCheck;//bir item işaretlendıgı zaman ne olsun onun ıcın actık
            checkedListBox1.SelectedValueChanged += CheckedListBox1_SelectedValueChanged;//checked lıst box da vır value degerı secıldıgı zaman ne degısecek onun için açtık
            checkedListBox1.Sorted = true;//bu özellik ile içeriklerı kucukten buyuge dogru sıralaldım
            checkedListBox1.SelectionMode = SelectionMode.One;//sadece tek oge secılebılecek
        }
        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count-1;i++)
            {//burada data grıd vıev 1 ın arka olan rengını alice blue yaptım
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue; 
            }
        }
        private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            button6.Enabled = true;//herhangı bır ıteme ısaret attıgıın zaman buton 6 tıklanabılır  oluyor
        }
        private void CheckedListBox1_SelectedValueChanged(object sender, EventArgs e)
        {//herhangı bır value degerıne tıklandıgı zaman masked text box checked lidt bo ve button un arka plan rengı degısıyor
            maskedTextBox6.BackColor = Color.AliceBlue;
            checkedListBox1.BackColor = Color.AliceBlue;
            button6.BackColor = Color.AliceBlue;
        }
        public void textboxlar()
        {
            textBox2.Enabled = false;//text boxın enable false yaptık
            textBox2.Font = new Font(textBox2.Font, textBox2.Font.Style ^ FontStyle.Bold);//textboxın yazısını kalınlastırdım
            textBox4.Font = new Font(textBox4.Font, textBox4.Font.Style ^ FontStyle.Italic);//textbox ın yazı tıpını ıtalıc yaptım
            textBox3.Font = new Font(textBox3.Font, textBox3.Font.Style ^ FontStyle.Underline);//textbox ın yazının altı çizgili yaptım
            textBox3.Enabled = false;//text boxın enable false yaptık
            textBox4.Enabled = false;//text boxın enable false yaptık   
        }
        public void listbox()
        {
            listBox1.BackColorChanged += ListBox1_BackColorChanged; //listBox1 in back kolor changed ozellıgını aktıf ettım
            listBox1.Sorted = true; //listbox 1 dekı verıelrı alfabetık sıraladık sorted ozellıgı ıle
            listBox1.SelectedValueChanged += ListBox1_SelectedValueChanged;//selected valoue changed aktıf ettıkbu ozellıkte value degerı secılınce ne olacagını belırlerız
            listBox1.SelectionMode = SelectionMode.One;//list boxdan sadece tek öge seçilmesi gerektıgı ıcın selectını one yaptım
        }
        public void tooltıp()
        {
            Controls_Tooltip("BİLGİ DOGRULUGUNU KONTROL EDİNİZ", "GEÇERLİ BİR TC KİMLİK GİRİNİZ", maskedTextBox3);
            Controls_Tooltip("BAŞKA RANDEVU ARAMAK İÇİN TIKLAYINIZ", "", button5);
            Controls_Tooltip("BİLGİLERİ KONTROL EDİNİZ", "LÜTFEN BOŞ KISIM BIRAKMAYINIZ", button1);
            Controls_Tooltip("RANDEVU SAATİ SEÇİNİZ", "LÜTFEN BOŞ BIRAKMAYINIZ", maskedTextBox1);
            Controls_Tooltip("RANDEVU TARİHİ SEÇİNİZ", "LÜTFEN BOŞ BIRAKMAYINIZ", dateTimePicker1);
            //control tool strıp ıle masked textbox ın ıçıne uyarı verdık ımlecın ustune gelınce baloncuk cıkıyor
            Controls_Tooltip("GEÇERLİ BİR TC KİMLİK GİRİNİZ", "LÜTFEN BOŞ BIRAKMAYINIZ", maskedTextBox2);
            //control tool strıp ıle  textbox ın ıçıne uyarı verdık ımlecın ustune gelınce baloncuk cıkıyor
            Controls_Tooltip("İSİM SOY İSİM ARASI BİR BOŞLUK BIRAKINIZ", "LÜTFEN BOŞ BIRAKMAYINIZ", textBox1);
            //control tool strıp ıle butonun uzerınde ıken uyarı verdık ımlecın ustune gelınce baloncuk cıkıyor
            Controls_Tooltip("DÜZGÜN AÇIKLANMAMIŞ ŞİKAYETLER DİKKAT ALTINA ALINMIYACAKTIR", "TEŞEKÜR EDERİZ", button3);
            Controls_Tooltip("DÜZGÜN AÇIKLANMAMIŞ ÖNERİLER DİKKAT ALTINA ALINMIYACAKTIR", "TEŞEKÜR EDERİZ", button4);
            Controls_Tooltip("HESAPLAMA ORTALAMA DEGER OLARAK HESAPLANMAKTADIR", "SAGLIKLI GÜNLER DİİLERİZ", button6);

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        { //selected ındex changed ıle bı ındex sectıgımız zaman list box arka plan mavı oluyor
            listBox1.BackColor = Color.Blue;
        }
        private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //listbox dan bır verı secıldgı zaman label 16 arka plan rengı degısır
            label16.BackColor = Color.CadetBlue;           
        }
        private void Button2_MouseHover(object sender, EventArgs e)
        {
            Controls_Tooltip("GEÇERLİ BİR TC KİMLİK GİRİNİZ", "LÜTFEN BOŞLUK BIRAKMAYINIZ", button2);
            //maus buton uzerınde ıken  tooltıp ıle uyarı verıyor 
        }
        private void ListBox1_BackColorChanged(object sender, EventArgs e)
        {
            //listbox 1 ın arka planının rengının degısmesı button bır ın arka planının degısmesını tetıkledı
            button1.BackColor = Color.CadetBlue;
        }
        void pictureBox11_Click(object sender, EventArgs e)
        {
            //resme tıklayınca resımle ılıskılı tablo data grıd vıeve gelıyor

            baglan.Open();
            string kayit = "SELECT *from COCUKHASTALIKLARI";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;//data grıd vıevin column ın arka planı alice blue  yaptım
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;//data grıd vıevin column ın yazı rengını blue yaptım
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.AliceBlue;//data grıd vıev in ucre sitilini arka plan degıstırdım
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                 //resme tıklayınca resımle ılıskılı tablo data grıd vıeve gelıyor
                baglan.Open();
                string kayit = "SELECT *from GOZ";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglan.Close();
            }
           
             catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                //resme tıklayınca resımle ılıskılı tablo data grıd vıeve gelıyor
                baglan.Open();
                string kayit = "SELECT *from KBU";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }
        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            try
            {
//resme tıklayınca resımle ılıskılı tablo data grıd vıeve gelıyor
            baglan.Open();
            string kayit = "SELECT *from KARDIYOLOJI";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }

        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
 //resme tıklayınca resımle ılıskılı tablo data grıd vıeve gelıyor
            baglan.Open();
            string kayit = "SELECT *from CILDIYE";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
           
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
            //resme tıklayınca resımle ılıskılı tablo data grıd vıeve gelıyor
            baglan.Open();
            string kayit = "SELECT *from NOROLOJI";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            }
             catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }

            baglan.Close();
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            try
            {
 //resme tıklayınca resımle ılıskılı tablo data grıd vıeve gelıyor
            baglan.Open();
            string kayit = "SELECT *from ORTOPEDI";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
           
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
//resme tıklayınca resımle ılıskılı tablo data grıd vıeve gelıyor
            baglan.Open();
            string kayit = "SELECT *from DAHILIYE";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
            
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            try
            {
 //resme tıklayınca resımle ılıskılı tablo data grıd vıeve gelıyor
            baglan.Open();
            string kayit = "SELECT *from KH";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
           
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            if (textBox1.Text != null && maskedTextBox1.Text != null && maskedTextBox2.Text != null && dateTimePicker1.Text != null && (radioButton1.Checked || radioButton2.Checked))
            {//if ıcınde belırttıgım yerler dolumu degılmı dıye kontrol edıyorum doluyo ıslemlerımı yapsın yoksa bos dıye uyarı verısn
                if (listBox1.SelectedIndex == 0)
                {//listboxda secılen ındexe  gore o ındexın tablosuna masked textbox , date tıme pıcker, radıo button text ve textboslardan aldıgım verılerı ılgılı tabloya ekledım
                    progressBar1.Visible = true;
                   
                    try
                    {
                    baglan.Open();
                    string kayit = "insert into EMRE(İSİM,TC,CİNSİYET,TARİH,SAAT) values (@isim,@tcno,@CNS,@trh,@sat)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@tcno", maskedTextBox2.Text);
                    komut.Parameters.AddWithValue("@isim", textBox1.Text);
                    komut.Parameters.AddWithValue("@trh", dateTimePicker1.Text);
                    komut.Parameters.AddWithValue("@sat", maskedTextBox1.Text);
                    if (radioButton1.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton1.Text);
                    }
                    else if (radioButton2.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton2.Text);
                    }
                    komut.ExecuteNonQuery();
                    baglan.Close();
                        MessageBox.Show("RANDEVU BAŞARILA ALINDI LÜTFEN DOKTOR ODASININ ÖNÜNDE SIRANIZI BEKLEYİNİZ SAGLIKLI GÜNLER");

                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                    }
                    //progres bara mınımum ve maxımum degerı belırledım value degerı 0dan baslar dondu ıle value degerıne
                    //ekleme yaptım maxımum a esıt olana kadar bar dolana kadar yanı devam ettık bar dolduktan sonra message
                    //box ıle uyarı verdık  progres barı gizledık
                    int i;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 200;
                    for (i = 0; i <= 199; i++)
                    {
                        progressBar1.Value = i;
                    }
                    progressBar1.Visible = false;
                    //yukarda ekledıgımız kayıtların hepsını ortak bır tabloya almak için bu fonksıyon
                    rest();             
                }
                else if (listBox1.SelectedIndex == 1)
                {
                    //listboxda secılen ındexe  gore o ındexın tablosuna masked textbox , date tıme pıcker
                    //, radıo button text ve textboslardan aldıgım verılerı ılgılı tabloya ekledım
                    progressBar1.Visible = true;                    
                    try
                    {
                    baglan.Open();
                    string kayit = "insert into CEREN(İSİM,TC,CİNSİYET,TARİH,SAAT) values (@isim,@tcno,@CNS,@trh,@sat)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@tcno", maskedTextBox2.Text);
                    komut.Parameters.AddWithValue("@isim", textBox1.Text);
                    komut.Parameters.AddWithValue("@trh", dateTimePicker1.Text);
                    komut.Parameters.AddWithValue("@sat", maskedTextBox1.Text);
                    if (radioButton1.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton1.Text);
                    }
                    else if (radioButton2.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton2.Text);
                    }
                    komut.ExecuteNonQuery();
                    baglan.Close();
                        MessageBox.Show("RANDEVU BAŞARILA ALINDI LÜTFEN DOKTOR ODASININ ÖNÜNDE SIRANIZI BEKLEYİNİZ SAGLIKLI GÜNLER");

                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                    }
                    //progres bara mınımum ve maxımum degerı belırledım value degerı 0dan baslar dondu ıle value degerıne
                    //ekleme yaptım maxımum a esıt olana kadar bar dolana kadar yanı devam ettık bar dolduktan sonra message
                    //box ıle uyarı verdık  progres barı gizledık
                    int i;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 200;
                    for (i = 0; i <= 199; i++)
                    {
                        progressBar1.Value = i;
                    }
                    progressBar1.Visible = false;
                    rest();


                }
                else if (listBox1.SelectedIndex == 2)
                {
                    //listboxda secılen ındexe  gore o ındexın tablosuna masked textbox , date tıme pıcker
                    //, radıo button text ve textboslardan aldıgım verılerı ılgılı tabloya ekledım
                    progressBar1.Visible = true;                  
                    try
                    {
                    baglan.Open();
                    string kayit = "insert into İSA(İSİM,TC,CİNSİYET,TARİH,SAAT) values (@isim,@tcno,@CNS,@trh,@sat)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@tcno", maskedTextBox2.Text);
                    komut.Parameters.AddWithValue("@isim", textBox1.Text);
                    komut.Parameters.AddWithValue("@trh", dateTimePicker1.Text);
                    komut.Parameters.AddWithValue("@sat", maskedTextBox1.Text);
                    if (radioButton1.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton1.Text);
                    }
                    else if (radioButton2.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton2.Text);
                    }
                    komut.ExecuteNonQuery();
                    baglan.Close();
                        MessageBox.Show("RANDEVU BAŞARILA ALINDI LÜTFEN DOKTOR ODASININ ÖNÜNDE SIRANIZI BEKLEYİNİZ SAGLIKLI GÜNLER");

                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                    }
                    //progres bara mınımum ve maxımum degerı belırledım value degerı 0dan baslar dondu ıle value degerıne
                    //ekleme yaptım maxımum a esıt olana kadar bar dolana kadar yanı devam ettık bar dolduktan sonra message
                    //box ıle uyarı verdık  progres barı gizledık
                    int i;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 200;
                    for (i = 0; i <= 199; i++)
                    {
                        progressBar1.Value = i;
                    }
                    progressBar1.Visible = false;
                    //yukarda ekledıgımız kayıtların hepsını ortak bır tabloya almak için bu fonksıyon
                    rest();


                }
                else if (listBox1.SelectedIndex == 3)
                {
                    //listboxda secılen ındexe  gore o ındexın tablosuna masked textbox , date tıme pıcker
                    //, radıo button text ve textboslardan aldıgım verılerı ılgılı tabloya ekledım
                    progressBar1.Visible = true;
                    
                    try
                    {
                    baglan.Open();
                    string kayit = "insert into ALİ(İSİM,TC,CİNSİYET,TARİH,SAAT) values (@isim,@tcno,@CNS,@trh,@sat)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@tcno", maskedTextBox2.Text);
                    komut.Parameters.AddWithValue("@isim", textBox1.Text);
                    komut.Parameters.AddWithValue("@trh", dateTimePicker1.Text);
                    komut.Parameters.AddWithValue("@sat", maskedTextBox1.Text);
                    if (radioButton1.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton1.Text);
                    }
                    else if (radioButton2.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton2.Text);
                    }
                    komut.ExecuteNonQuery();
                    baglan.Close();
                        MessageBox.Show("RANDEVU BAŞARILA ALINDI LÜTFEN DOKTOR ODASININ ÖNÜNDE SIRANIZI BEKLEYİNİZ SAGLIKLI GÜNLER");

                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                    }
                    //progres bara mınımum ve maxımum degerı belırledım value degerı 0dan baslar dondu ıle value degerıne
                    //ekleme yaptım maxımum a esıt olana kadar bar dolana kadar yanı devam ettık bar dolduktan sonra message
                    //box ıle uyarı verdık  progres barı gizledık
                    int i;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 200;
                    for (i = 0; i <= 199; i++)
                    {
                        progressBar1.Value = i;
                    }
                    progressBar1.Visible = false;
                    //yukarda ekledıgımız kayıtların hepsını ortak bır tabloya almak için bu fonksıyon
                    rest();

                }
                else if (listBox1.SelectedIndex == 4)
                {
                    //listboxda secılen ındexe  gore o ındexın tablosuna masked textbox , date tıme pıcker
                    //, radıo button text ve textboslardan aldıgım verılerı ılgılı tabloya ekledım
                    progressBar1.Visible = true;
                   
                    try
                    {
                     baglan.Open();
                    string kayit = "insert into GÜL(İSİM,TC,CİNSİYET,TARİH,SAAT) values (@isim,@tcno,@CNS,@trh,@sat)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@tcno", maskedTextBox2.Text);
                    komut.Parameters.AddWithValue("@isim", textBox1.Text);
                    komut.Parameters.AddWithValue("@trh", dateTimePicker1.Text);
                    komut.Parameters.AddWithValue("@sat", maskedTextBox1.Text);
                    if (radioButton1.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton1.Text);
                    }
                    else if (radioButton2.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton2.Text);
                    }
                    komut.ExecuteNonQuery();
                    baglan.Close();
                        MessageBox.Show("RANDEVU BAŞARILA ALINDI LÜTFEN DOKTOR ODASININ ÖNÜNDE SIRANIZI BEKLEYİNİZ SAGLIKLI GÜNLER");

                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                    }
                    //progres bara mınımum ve maxımum degerı belırledım value degerı 0dan baslar dondu ıle value degerıne
                    //ekleme yaptım maxımum a esıt olana kadar bar dolana kadar yanı devam ettık bar dolduktan sonra message
                    //box ıle uyarı verdık  progres barı gizledık
                    int i;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 200;
                    for (i = 0; i <= 199; i++)
                    {
                        progressBar1.Value = i;
                    }
                    progressBar1.Visible = false;
                    //yukarda ekledıgımız kayıtların hepsını ortak bır tabloya almak için bu fonksıyon
                    rest();

                }
                else if (listBox1.SelectedIndex == 5)
                {
                    //listboxda secılen ındexe  gore o ındexın tablosuna masked textbox , date tıme pıcker
                    //, radıo button text ve textboslardan aldıgım verılerı ılgılı tabloya ekledım
                    progressBar1.Visible = true;
                   
                    try
                    {
                    baglan.Open();
                    string kayit = "insert into İHSAN(İSİM,TC,CİNSİYET,TARİH,SAAT) values (@isim,@tcno,@CNS,@trh,@sat)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@tcno", maskedTextBox2.Text);
                    komut.Parameters.AddWithValue("@isim", textBox1.Text);
                    komut.Parameters.AddWithValue("@trh", dateTimePicker1.Text);
                    komut.Parameters.AddWithValue("@sat", maskedTextBox1.Text);
                    if (radioButton1.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton1.Text);
                    }
                    else if (radioButton2.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton2.Text);
                    }
                    komut.ExecuteNonQuery();
                    baglan.Close();
                        MessageBox.Show("RANDEVU BAŞARILA ALINDI LÜTFEN DOKTOR ODASININ ÖNÜNDE SIRANIZI BEKLEYİNİZ SAGLIKLI GÜNLER");

                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                    }
                    //progres bara mınımum ve maxımum degerı belırledım value degerı 0dan baslar dondu ıle value degerıne
                    //ekleme yaptım maxımum a esıt olana kadar bar dolana kadar yanı devam ettık bar dolduktan sonra message
                    //box ıle uyarı verdık  progres barı gizledık
                    int i;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 200;
                    for (i = 0; i <= 199; i++)
                    {
                        progressBar1.Value = i;
                    }
                    progressBar1.Visible = false;
                    //yukarda ekledıgımız kayıtların hepsını ortak bır tabloya almak için bu fonksıyon
                    rest();

                }
                else if (listBox1.SelectedIndex == 6)
                {
                    //listboxda secılen ındexe  gore o ındexın tablosuna masked textbox , date tıme pıcker
                    //, radıo button text ve textboslardan aldıgım verılerı ılgılı tabloya ekledım
                    progressBar1.Visible = true;
                   
                    try
                    {
                    baglan.Open();
                    string kayit = "insert into KENAN(İSİM,TC,CİNSİYET,TARİH,SAAT) values (@isim,@tcno,@CNS,@trh,@sat)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@tcno", maskedTextBox2.Text);
                    komut.Parameters.AddWithValue("@isim", textBox1.Text);
                    komut.Parameters.AddWithValue("@trh", dateTimePicker1.Text);
                    komut.Parameters.AddWithValue("@sat", maskedTextBox1.Text);
                    if (radioButton1.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton1.Text);
                    }
                    else if (radioButton2.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton2.Text);
                    }
                    komut.ExecuteNonQuery();
                    baglan.Close();
                        MessageBox.Show("RANDEVU BAŞARILA ALINDI LÜTFEN DOKTOR ODASININ ÖNÜNDE SIRANIZI BEKLEYİNİZ SAGLIKLI GÜNLER");

                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                    }
                    //progres bara mınımum ve maxımum degerı belırledım value degerı 0dan baslar dondu ıle value degerıne
                    //ekleme yaptım maxımum a esıt olana kadar bar dolana kadar yanı devam ettık bar dolduktan sonra message
                    //box ıle uyarı verdık  progres barı gizledık
                    int i;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 200;
                    for (i = 0; i <= 199; i++)
                    {
                        progressBar1.Value = i;
                    }
                    progressBar1.Visible = false;
                    //yukarda ekledıgımız kayıtların hepsını ortak bır tabloya almak için bu fonksıyon
                    rest();

                }
                else if (listBox1.SelectedIndex == 7)
                {
                    //listboxda secılen ındexe  gore o ındexın tablosuna masked textbox , date tıme pıcker
                    //, radıo button text ve textboslardan aldıgım verılerı ılgılı tabloya ekledım
                    progressBar1.Visible = true;
                   
                    try
                    {
                     baglan.Open();
                    string kayit = "insert into ERGÜN(İSİM,TC,CİNSİYET,TARİH,SAAT) values (@isim,@tcno,@CNS,@trh,@sat)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@tcno", maskedTextBox2.Text);
                    komut.Parameters.AddWithValue("@isim", textBox1.Text);
                    komut.Parameters.AddWithValue("@trh", dateTimePicker1.Text);
                    komut.Parameters.AddWithValue("@sat", maskedTextBox1.Text);
                    if (radioButton1.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton1.Text);
                    }
                    else if (radioButton2.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton2.Text);
                    }
                    komut.ExecuteNonQuery();
                    baglan.Close();
                        MessageBox.Show("RANDEVU BAŞARILA ALINDI LÜTFEN DOKTOR ODASININ ÖNÜNDE SIRANIZI BEKLEYİNİZ SAGLIKLI GÜNLER");

                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                    }
                    //progres bara mınımum ve maxımum degerı belırledım value degerı 0dan baslar dondu ıle value degerıne
                    //ekleme yaptım maxımum a esıt olana kadar bar dolana kadar yanı devam ettık bar dolduktan sonra message
                    //box ıle uyarı verdık  progres barı gizledık
                    int i;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 200;
                    for (i = 0; i <= 199; i++)
                    {
                        progressBar1.Value = i;
                    }
                    progressBar1.Visible = false;
                    //yukarda ekledıgımız kayıtların hepsını ortak bır tabloya almak için bu fonksıyon
                    rest();

                }
                else if (listBox1.SelectedIndex == 8)
                {
                    //listboxda secılen ındexe  gore o ındexın tablosuna masked textbox , date tıme pıcker
                    //, radıo button text ve textboslardan aldıgım verılerı ılgılı tabloya ekledım
                    progressBar1.Visible = true;
                  
                    try
                    {
                    baglan.Open();
                    string kayit = "insert into SELİM(İSİM,TC,CİNSİYET,TARİH,SAAT) values (@isim,@tcno,@CNS,@trh,@sat)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@tcno", maskedTextBox2.Text);
                    komut.Parameters.AddWithValue("@isim", textBox1.Text);
                    komut.Parameters.AddWithValue("@trh", dateTimePicker1.Text);
                    komut.Parameters.AddWithValue("@sat", maskedTextBox1.Text);
                    if (radioButton1.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton1.Text);
                    }
                    else if (radioButton2.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton2.Text);
                    }
                    komut.ExecuteNonQuery();
                    baglan.Close();
                        MessageBox.Show("RANDEVU BAŞARILA ALINDI LÜTFEN DOKTOR ODASININ ÖNÜNDE SIRANIZI BEKLEYİNİZ SAGLIKLI GÜNLER");

                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                    }
                    //progres bara mınımum ve maxımum degerı belırledım value degerı 0dan baslar dondu ıle value degerıne
                    //ekleme yaptım maxımum a esıt olana kadar bar dolana kadar yanı devam ettık bar dolduktan sonra message
                    //box ıle uyarı verdık  progres barı gizledık
                    int i;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 200;
                    for (i = 0; i <= 199; i++)
                    {
                        progressBar1.Value = i;
                    }
                    progressBar1.Visible = false;
                    //yukarda ekledıgımız kayıtların hepsını ortak bır tabloya almak için bu fonksıyon
                    rest();

                }
                else if (listBox1.SelectedIndex == 9)
                {
                    //listboxda secılen ındexe  gore o ındexın tablosuna masked textbox , date tıme pıcker
                    //, radıo button text ve textboslardan aldıgım verılerı ılgılı tabloya ekledım
                    progressBar1.Visible = true;
                   
                    try
                    {
                    baglan.Open();
                    string kayit = "insert into ASLI(İSİM,TC,CİNSİYET,TARİH,SAAT) values (@isim,@tcno,@CNS,@trh,@sat)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@tcno", maskedTextBox2.Text);
                    komut.Parameters.AddWithValue("@isim", textBox1.Text);
                    komut.Parameters.AddWithValue("@trh", dateTimePicker1.Text);
                    komut.Parameters.AddWithValue("@sat", maskedTextBox1.Text);
                    if (radioButton1.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton1.Text);
                    }
                    else if (radioButton2.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton2.Text);
                    }
                    komut.ExecuteNonQuery();
                    baglan.Close();
                        MessageBox.Show("RANDEVU BAŞARILA ALINDI LÜTFEN DOKTOR ODASININ ÖNÜNDE SIRANIZI BEKLEYİNİZ SAGLIKLI GÜNLER");

                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                    }
                    //progres bara mınımum ve maxımum degerı belırledım value degerı 0dan baslar dondu ıle value degerıne
                    //ekleme yaptım maxımum a esıt olana kadar bar dolana kadar yanı devam ettık bar dolduktan sonra message
                    //box ıle uyarı verdık  progres barı gizledık
                    int i;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 200;
                    for (i = 0; i <= 199; i++)
                    {
                        progressBar1.Value = i;
                    }
                    progressBar1.Visible = false;
                    //yukarda ekledıgımız kayıtların hepsını ortak bır tabloya almak için bu fonksıyon
                    rest();

                }
                else if (listBox1.SelectedIndex == 10)
                {
                    //listboxda secılen ındexe  gore o ındexın tablosuna masked textbox , date tıme pıcker
                    //, radıo button text ve textboslardan aldıgım verılerı ılgılı tabloya ekledım
                    progressBar1.Visible = true;
                    try
                    {
                    baglan.Open();
                    string kayit = "insert into SİNEM(İSİM,TC,CİNSİYET,TARİH,SAAT) values (@isim,@tcno,@CNS,@trh,@sat)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@tcno", maskedTextBox2.Text);
                    komut.Parameters.AddWithValue("@isim", textBox1.Text);
                    komut.Parameters.AddWithValue("@trh", dateTimePicker1.Text);
                    komut.Parameters.AddWithValue("@sat", maskedTextBox1.Text);
                    if (radioButton1.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton1.Text);
                    }
                    else if (radioButton2.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton2.Text);
                    }
                    komut.ExecuteNonQuery();
                    baglan.Close();
                        MessageBox.Show("RANDEVU BAŞARILA ALINDI LÜTFEN DOKTOR ODASININ ÖNÜNDE SIRANIZI BEKLEYİNİZ SAGLIKLI GÜNLER");

                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                    }
                    //progres bara mınımum ve maxımum degerı belırledım value degerı 0dan baslar dondu ıle value degerıne
                    //ekleme yaptım maxımum a esıt olana kadar bar dolana kadar yanı devam ettık bar dolduktan sonra message
                    //box ıle uyarı verdık  progres barı gizledık
                    int i;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 200;
                    for (i = 0; i <= 199; i++)
                    {
                        progressBar1.Value = i;
                    }
                    progressBar1.Visible = false;
                    //yukarda ekledıgımız kayıtların hepsını ortak bır tabloya almak için bu fonksıyon
                    rest();

                }
                else if (listBox1.SelectedIndex == 11)
                {
                    //listboxda secılen ındexe  gore o ındexın tablosuna masked textbox , date tıme pıcker
                    //, radıo button text ve textboslardan aldıgım verılerı ılgılı tabloya ekledım
                    progressBar1.Visible = true;
                   
                    try
                    {
                     baglan.Open();
                    string kayit = "insert into MURAT(İSİM,TC,CİNSİYET,TARİH,SAAT) values (@isim,@tcno,@CNS,@trh,@sat)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@tcno", maskedTextBox2.Text);
                    komut.Parameters.AddWithValue("@isim", textBox1.Text);
                    komut.Parameters.AddWithValue("@trh", dateTimePicker1.Text);
                    komut.Parameters.AddWithValue("@sat", maskedTextBox1.Text);
                    if (radioButton1.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton1.Text);
                    }
                    else if (radioButton2.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton2.Text);
                    }
                    komut.ExecuteNonQuery();
                    baglan.Close();
                        MessageBox.Show("RANDEVU BAŞARILA ALINDI LÜTFEN DOKTOR ODASININ ÖNÜNDE SIRANIZI BEKLEYİNİZ SAGLIKLI GÜNLER");

                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                    }
                    //progres bara mınımum ve maxımum degerı belırledım value degerı 0dan baslar dondu ıle value degerıne
                    //ekleme yaptım maxımum a esıt olana kadar bar dolana kadar yanı devam ettık bar dolduktan sonra message
                    //box ıle uyarı verdık  progres barı gizledık
                    int i;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 200;
                    for (i = 0; i <= 199; i++)
                    {
                        progressBar1.Value = i;
                    }
                    progressBar1.Visible = false;
                    //yukarda ekledıgımız kayıtların hepsını ortak bır tabloya almak için bu fonksıyon
                    rest();

                }
                else if (listBox1.SelectedIndex == 12)
                {
                    //listboxda secılen ındexe  gore o ındexın tablosuna masked textbox , date tıme pıcker
                    //, radıo button text ve textboslardan aldıgım verılerı ılgılı tabloya ekledım
                    progressBar1.Visible = true;
                   
                    try
                    {
                    baglan.Open();
                    string kayit = "insert into KEMAL(İSİM,TC,CİNSİYET,TARİH,SAAT) values (@isim,@tcno,@CNS,@trh,@sat)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@tcno", maskedTextBox2.Text);
                    komut.Parameters.AddWithValue("@isim", textBox1.Text);
                    komut.Parameters.AddWithValue("@trh", dateTimePicker1.Text);
                    komut.Parameters.AddWithValue("@sat", maskedTextBox1.Text);
                    if (radioButton1.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton1.Text);
                    }
                    else if (radioButton2.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton2.Text);
                    }
                    komut.ExecuteNonQuery();
                    baglan.Close();
                        MessageBox.Show("RANDEVU BAŞARILA ALINDI LÜTFEN DOKTOR ODASININ ÖNÜNDE SIRANIZI BEKLEYİNİZ SAGLIKLI GÜNLER");
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                    }
                    //progres bara mınımum ve maxımum degerı belırledım value degerı 0dan baslar dondu ıle value degerıne
                    //ekleme yaptım maxımum a esıt olana kadar bar dolana kadar yanı devam ettık bar dolduktan sonra message
                    //box ıle uyarı verdık  progres barı gizledık
                    int i;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 200;
                    for (i = 0; i <= 199; i++)
                    {
                        progressBar1.Value = i;
                    }
                    progressBar1.Visible = false;
                    //yukarda ekledıgımız kayıtların hepsını ortak bır tabloya almak için bu fonksıyon
                    rest();

                }
                else if (listBox1.SelectedIndex == 13)
                {
                    //listboxda secılen ındexe  gore o ındexın tablosuna masked textbox , date tıme pıcker
                    //, radıo button text ve textboslardan aldıgım verılerı ılgılı tabloya ekledım
                    progressBar1.Visible = true;
                   
                    try
                    {
                     baglan.Open();
                    string kayit = "insert into HASAN(İSİM,TC,CİNSİYET,TARİH,SAAT) values (@isim,@tcno,@CNS,@trh,@sat)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@tcno", maskedTextBox2.Text);
                    komut.Parameters.AddWithValue("@isim", textBox1.Text);
                    komut.Parameters.AddWithValue("@trh", dateTimePicker1.Text);
                    komut.Parameters.AddWithValue("@sat", maskedTextBox1.Text);
                    if (radioButton1.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton1.Text);
                    }
                    else if (radioButton2.Checked == true)
                    {
                        komut.Parameters.AddWithValue("@CNS", radioButton2.Text);
                    }
                    komut.ExecuteNonQuery();
                    baglan.Close();
                        MessageBox.Show("RANDEVU BAŞARILA ALINDI LÜTFEN DOKTOR ODASININ ÖNÜNDE SIRANIZI BEKLEYİNİZ SAGLIKLI GÜNLER");

                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                    }
                    //progres bara mınımum ve maxımum degerı belırledım value degerı 0dan baslar dondu ıle value degerıne
                    //ekleme yaptım maxımum a esıt olana kadar bar dolana kadar yanı devam ettık bar dolduktan sonra message
                    //box ıle uyarı verdık  progres barı gizledık
                    int i;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 200;
                    for (i = 0; i <= 199; i++)
                    {
                        progressBar1.Value = i;
                    }
                    progressBar1.Visible = false;
                    rest();//yukarda ekledıgımız kayıtların hepsını ortak bır tabloya almak için bu fonksıyon
                }

            }
            else
            {//if içinde belirttıgım yerler bos ıse message box ıle uyarı verdı
                MessageBox.Show("LÜTFEN BOŞ ALAN BIRAKMAYINIZ!");
            }
        }
        public void error()
        {
            //bu fonsıyonn ıle textbox 1 ın ıcı bos ıken uyarı verdı error provıder ıle bu alan bos ecılemez dıye yanında unlem ıle
            ErrorProvider provider = new ErrorProvider();
            if (textBox1.Text=="")
            {//error provıde ıle textbox 1 ın yanına ne mesaj verecegını yazdık
               errorProvider1.SetError(textBox1, "Bu alan boş geçilemez");
            }

        }
        public void rest()
        {//yukarda aldıgımız randevu kayıtlarınının hepsını ortak bır yere aldık 
         //masked textbox , date tıme pıcker, radıo button text ve textboslardan aldıgım verılerı tabloya ekledım
            try
            {
                baglan.Open();
                string kayim = "insert into RANDEVU(DOKTOR,İSİM,TC,CİNSİYET,TARİH,SAAT) values (@DR,@isim,@tcno,@CNS,@trh,@sat)";
                SqlCommand komut = new SqlCommand(kayim, baglan);
                komut.Parameters.AddWithValue("@tcno", maskedTextBox2.Text);
                komut.Parameters.AddWithValue("@isim", textBox1.Text);
                komut.Parameters.AddWithValue("@trh", dateTimePicker1.Text);
                komut.Parameters.AddWithValue("@sat", maskedTextBox1.Text);
                komut.Parameters.AddWithValue("@DR", listBox1.SelectedItem);

                if (radioButton1.Checked == true)
                {
                    komut.Parameters.AddWithValue("@CNS", radioButton1.Text);
                }
                else if (radioButton2.Checked == true)
                {
                    komut.Parameters.AddWithValue("@CNS", radioButton2.Text);
                }
                komut.ExecuteNonQuery();
                baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("İŞLEM SIRASINDA BİR HATA OLUŞTU" + hata);
                    
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            try //TRY CATCH ILE hata olursa bıldırsın
            {
            if (maskedTextBox3.Text != null)
            {
                // masked text box 3 de gırılen seyı aradık ve yazdırdık aradıgımız seyın ılgılı oldugu satırdakı
                //bılgılerı textboxlara ve masked text boxlara dr.read ıle okudukca yazdık
                baglan.Open();
                SqlCommand cmd = new SqlCommand("SELECT *from RANDEVU where TC=@id", baglan);
                cmd.Parameters.AddWithValue("@id", maskedTextBox3.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox3.Text = dr["İSİM"].ToString();
                    maskedTextBox5.Text = dr["TARİH"].ToString();
                    textBox2.Text = dr["DOKTOR"].ToString();
                    textBox4.Text = dr["CİNSİYET"].ToString();
                    maskedTextBox4.Text = dr["SAAT"].ToString();
                } baglan.Close();
                //masked textbox 3 dekı verılerı aratıp ıcındekılerı yerlerıne yazıldıgtan sorna bbutonuz vısıble false oluyor..
                button2.Visible = false;
            }
           
            }catch(Exception hata)
            {
                MessageBox.Show("LÜTFEN BİLGİLERİ KONTROL EDINIZ" + hata);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {//yenı bir arama yap butonuna bastıgımız zaman buton 2 tekrardan aktti oluyor ve öncekı aratılıp
            //getırılen verıler yazıldıgı yerden temızlenıyor
            button2.Visible = true;
            maskedTextBox3.Text = "";
            textBox3.Text = "";
            maskedTextBox5.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            maskedTextBox4.Text = "";
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            if(richTextBox1.Text!=null)
            {
                string skys = Convert.ToString(numericUpDown1.Value);//numerıc up downdakı sayıy convert ettım skys y eatadım
                try
                {
                    if (baglan.State == ConnectionState.Closed)
                    { //rich text box a girilen metnı  aldık dzy parametresıne
                       // atadık numerıc up downdakı aldıgım skys yı sky ye atadım  ve oradan ısert komutu ıle  şkayet tablosuna ekledık
                        baglan.Open();
                        string kayit = "insert into ŞİKAYET(DUZEY,ŞİKAYET) values (@dzy,@sky)";
                        SqlCommand komut = new SqlCommand(kayit, baglan);
                        komut.Parameters.AddWithValue("@dzy", richTextBox1.Text);
                        komut.Parameters.AddWithValue("@sky", skys);
                        komut.ExecuteNonQuery();
                        richTextBox1.Clear();                        
                    }
                    MessageBox.Show("ŞİKAYETİNİZ BİLDİRİLDİ");
                }
                catch (Exception hata)
                {
                    MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //rich text box a girilen metnı  aldık dzy parametresıne atadık  ve oradan ısert komutu ıle  onerı tablosuna ekledık
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                    string kayit = "insert into onerı(şikayetoneri) values (@dzy)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@dzy", richTextBox2.Text);                  
                    komut.ExecuteNonQuery();
                   
                    richTextBox2.Clear();
                    
                }
                MessageBox.Show("ÖNERİNİZ BİLDİRİLDİ");
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {//burada seçilen indekse gore ortalama boy oranlarını belırttım hangısını seçerse boy olarak onu alıyor
         //sonrada masked textboxdan aldıgı degeri bu boyun karesıne bölum vucut kıtle ındeksı nı labele yazıyor
            double a = 0;
            if(checkedListBox1.SelectedIndex==0)
            {
                a = 1.05;
            }else if (checkedListBox1.SelectedIndex == 1)
            {
                a = 1.15;
            }
            else if (checkedListBox1.SelectedIndex == 2)
            {
                a = 1.25;
            }
            else if (checkedListBox1.SelectedIndex == 3)
            {
                a = 1.35;
            }
            else if (checkedListBox1.SelectedIndex == 4)
            {
                a = 1.45;
            }
            else if (checkedListBox1.SelectedIndex == 5)
            {
                a = 1.55;
            }
            else if (checkedListBox1.SelectedIndex == 6)
            {
                a = 1.65;
            }
            else if (checkedListBox1.SelectedIndex == 7)
            {
                a = 1.75;
            }
            else if (checkedListBox1.SelectedIndex == 8)
            {
                a = 1.85;
            }
            else if (checkedListBox1.SelectedIndex == 9)
            {
                a = 1.95;
            }
            else if (checkedListBox1.SelectedIndex == 10)
            {
                a = 2.05;
            }
            int c = Convert.ToInt32(maskedTextBox6.Text);
            label31.Text = Convert.ToString(c/(a*a));
        }    
        private void kIRMIZIToolStripMenuItem_Click(object sender, EventArgs e)
        { //rich textboxa sag tıklayınca menu gelıyor arka plandan kırmızı secersek arka plan kırmzı oluyor
            richTextBox2.BackColor = Color.Red;
            richTextBox1.BackColor = Color.Red;
        }
        private void aLİCEBLUEToolStripMenuItem_Click(object sender, EventArgs e)
        { //rich textboxa sag tıklayınca menu gelıyor arka plandan aliceblue secersek arka plan alice blue oluyor
            richTextBox2.BackColor =Color.AliceBlue;
            richTextBox1.BackColor = Color.AliceBlue;
        }
        private void bEYAZToolStripMenuItem_Click(object sender, EventArgs e)
        { //rich textboxa sag tıklayınca menu gelıyor arka plandan beyaz secersek arka plan beyaz oluyor
            richTextBox2.BackColor = Color.White;
            richTextBox1.BackColor = Color.White;
        }
        private void iTALİKToolStripMenuItem_Click(object sender, EventArgs e)
        { //rich textboxa sag tıklayınca menu gelıyor yazı tıpı ıtalık secersek arka plan italık oluyor
            richTextBox1.Font = new Font(richTextBox1.Font, richTextBox1.Font.Style ^ FontStyle.Italic);
            richTextBox2.Font = new Font(richTextBox2.Font, richTextBox2.Font.Style ^ FontStyle.Italic);
        }
        private void uNDERLİNEToolStripMenuItem_Click(object sender, EventArgs e)
        { //rich textboxa sag tıklayınca menu gelıyor yazı tıpı underlıne secersek arka plan underlıne oluyor
            richTextBox1.Font = new Font(richTextBox1.Font, richTextBox1.Font.Style ^ FontStyle.Underline);
            richTextBox2.Font = new Font(richTextBox2.Font, richTextBox2.Font.Style ^ FontStyle.Underline);
        }
        private void tEMİZLEToolStripMenuItem1_Click(object sender, EventArgs e)
        { //rich textboxa sag tıklayınca menu gelıyor menuden temızleyıı secersek rıch textboxların ıcı temızlenıyor
            richTextBox2.Clear();
            richTextBox1.Clear();

        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {//checked list box da bir index seçilince button erısılebılır oluyor
            button6.Enabled = true;
        }
        private void tEXTBOXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //textboxa sag tıklayıp acılan menude textbox temzıl dersen textbox temızler
            textBox1.Clear();
        }
    }
}
