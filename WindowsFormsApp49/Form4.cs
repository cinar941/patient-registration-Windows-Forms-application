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
    public partial class Form4 : Form
    {//sqlconnectıon ıle baglantı adresımı yazdım lazım oldugu yerde cagırıyorum tekrar yazmak zorunda kalmım
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-RLCKHNM\\SQLEXPRESS;Initial Catalog=sbo;Integrated Security=True;Pooling=False");
        public Form4()
        {
            InitializeComponent();
        }
        ToolTip Controls_Tooltip(string uyarı, string aciklama, Control cntrl)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.Active = true; // Görünsün mü?
            toolTip.ToolTipTitle = uyarı; // Çıkacak Mesajın Başlığı
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
        private void button2_Click_1(object sender, EventArgs e)
        {
            guncelle();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            kayitbul();
        }
        public void kayitbul()
        {//textbox1 de gırılen seyı aradık ve yazdırdık
           
            try
            {
            if (textBox3.Text != null)
            {
               baglan.Open();
                SqlCommand cmd = new SqlCommand("SELECT *from admin where kullanıcadı=@id", baglan);
                cmd.Parameters.AddWithValue("@id", textBox3.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox1.Text = dr["kullanıcadı"].ToString();
                    textBox2.Text = dr["şifre"].ToString();
                }
                baglan.Close();
            }
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {//admin isimli yonetıcı bılgılerıne yenı yonetıcı ekledık parameters add vıth valu ıle
            try
            {
                if (baglan.State == ConnectionState.Closed)
                    baglan.Open();
                string kayit = "insert into admin(kullanıcadı,şifre) values (@tcno,@isim)";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                komut.Parameters.AddWithValue("@tcno", textBox1.Text);
                komut.Parameters.AddWithValue("@isim", textBox2.Text);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Müşteri Kayıt İşlemi Gerçekleşti.");
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }
        public void guncelle()
        {
          
            try
            {
  //burada film tarih tablosunu dta grıd e yazdık
            baglan.Open();
            string kayit = "SELECT *from admin";
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
        private void button5_Click(object sender, EventArgs e)
        {
            //textbox4 de gırılen seyı aradık ve yazdırdık
            kayitbul1();
        }
        public void kayitbul1()
        {//textbox4 de gırılen seyı aradık ve yazdırdık
            
            try
            {
if (textBox4.Text != null)
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("SELECT *from gir where kullanıcadı=@id", baglan);
                cmd.Parameters.AddWithValue("@id", textBox4.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox6.Text = dr["kullanıcadı"].ToString();
                    textBox5.Text = dr["şifre"].ToString();
                    textBox7.Text = dr["TARİH"].ToString();
                    textBox8.Text = dr["TELEFONNUMARASI"].ToString();
                    textBox9.Text = dr["CİNSİYET"].ToString();
                }
                baglan.Close();
            }
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
           
            try
            {
 //burada gir tablosunu dta grıd e yazdık
            baglan.Open();
            string kayit = "SELECT *from gir";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }
        public void gir()
        {
           
            try
            {
 //burada gir tablosunu dta grıd e yazdık
            baglan.Open();
            string kayit = "SELECT *from gir";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //kullanıcı girişi için burada yenı kullanıcı ekleme yaptım
            try
            {
                if (baglan.State == ConnectionState.Closed)
                    baglan.Open();
                string kayit = "insert into gir(kullanıcadı,şifre,TARİH,TELEFONNUMARASI,CİNSİYET,ISIMSOYISIM) values (@KA,@SFR,@TRH,@TLF,@CNS,@IO)";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                komut.Parameters.AddWithValue("@KA", textBox6.Text);
                komut.Parameters.AddWithValue("@SFR", textBox5.Text);
                komut.Parameters.AddWithValue("@TRH", textBox7.Text);
                komut.Parameters.AddWithValue("@TLF", textBox8.Text);
                komut.Parameters.AddWithValue("@CNS", textBox9.Text);
                komut.Parameters.AddWithValue("@IO", textBox12.Text);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Kullanıc Kayıt İşlemi Gerçekleşti.");
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }      
        private void button8_Click(object sender, EventArgs e)
        {
           
            try
            {
 //burada oneri tablosunu dta grıd e yazdık
            baglan.Open();
            string kayit = "SELECT *from onerı";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            textBox6.Multiline = true;//textbox 6 nınn multı lıne aktı ettım
            button5.Enabled = false;//buton un enable false yaptım
            textBox4.TextChanged += TextBox4_TextChanged;//textbox ın text changed ozellıgını aktıf ettım     
            lıstvıev();
            datagrıdvıev();
            guncelle();
            pro();
            oneri();
            şikayet();
            gir();
            combobox();
            tooltıp();//button 5 ve 15 e tooltıp balon ıle uyarı verdım yenlıs yapmamaları ıcın
        }
        public void tooltıp()
        {
            //button 5 ve 15 e tooltıp balon ıle uyarı verdım yenlıs yapmamaları ıcın
            Controls_Tooltip("KULLANICI ARA SİL BÖLÜMÜ KONTROL EDİNİZ", "", button5);
            Controls_Tooltip("SİLİNECEK RANDEVUNUN DOGRULUGUNDAN EMİN OLUNUZ", "", button15);
            Controls_Tooltip("DOKTOR SEÇTİGİNİZDEN EMİN OLUNUZ", "", button14);
        }
        private void ListView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {//list vievde herhangı   bır ıteme tıklayınca sıl butonunun yanı buton 17 arka plan  kırmızı oluyor
            button17.BackColor = Color.Red;
        }
        public void combobox()
        {
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;//selected index changed aktıf ettık bır ındex secıldıgınde ne iş yapılıcak onu belırlıycem
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;//combo box 1 indrop down items ıle sıtılını dropdown lıst yazdım ve combo box un ıcıne bısey yazılmasını onledım
            comboBox1.Sorted = true;//combo box 1ın verılerıını alfabetık sıraladık
            comboBox2.FlatStyle = FlatStyle.Popup;//flat style ı popup yapınca ılk basta keanlıklar gozukmuyor ama tıklayınca gelıyor silik halde
            comboBox1.FlatStyle = FlatStyle.Flat;//flat style ıle combo box ın kenalıkları tok edıldı kenarınakı oka basınca ıcerıkelr gozukuyor       
        }
        public void lıstvıev()
        {
            listView1.SelectedIndexChanged += ListView1_SelectedIndexChanged;
            listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;//list viev sortıng özellegı ile list vıevdekı ogelerı alfabetik sıraladım
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;// başlık sıtılını tıklanamaz yaptım
            listView1.MultiSelect = false;//listvievden çoklu seçim yapılmasını engelledım tek tek seçecek ornegın tek tek sılecek coklu degıl
            listView1.ItemChecked += ListView1_ItemChecked;//list viev ıtem checked ozellgı actım bu ozellık bır ıtem scıldıgı zaman ne olacagını secmemızı saglar
            listView1.CheckBoxes = true; //list vievin checked ozelllıgını aktıf ettım     
            listView1.BackColor = System.Drawing.Color.AliceBlue; //list vievin arka plan rengını degısırdım
            listView1.ForeColor = System.Drawing.Color.Black;
            listView1.BorderStyle = BorderStyle.FixedSingle; //list view in  kenarlık sıtılını fıxedsıngle yaptım
            listView1.FullRowSelect = true;  //ListView' verinin üzerine tıklandığı anda satırın tümünü seçer.
            listView1.GridLines = true; //ListView'e ızgaralı görünüm kazandırır.
            listView1.View = View.Details; //list vıev detalıst yanı detaylı bır tablo olmasını ssectık
            listView1.Columns.Add("ŞİKAYET ÖNERİ", 200);  // list viev Sütun başlığı ekle
            listView1.Columns.Add("AYRINTI", 1000); // list viev Sütun başlığı ekle
        }
        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //herhangı bır ındexın secılmesı buttton 17 uzerınde yazıyı secıldı sıl yapıyor
            button17.Text = "SEÇİLDİ SİL";
        }
        public void datagrıdvıev()
        {
            dataGridView6.BackgroundColor = Color.White;//estetık gozukmesı ıcın arka planını beyaz yaptım
            dataGridView4.BackgroundColor = Color.White;//estetık gozukmesı ıcın arka planını beyaz yaptım
            dataGridView1.BackgroundColor = Color.White;//estetık gozukmesı ıcın arka planını beyaz yaptım
            dataGridView2.BackgroundColor = Color.White;//estetık gozukmesı ıcın arka planını beyaz yaptım
            dataGridView3.BackgroundColor = Color.White;//estetık gozukmesı ıcın arka planını beyaz yaptım
            dataGridView5.BackgroundColor = Color.White;//estetık gozukmesı ıcın arka planını beyaz yaptım
            this.dataGridView3.GridColor = Color.BlueViolet;//gridin  color blue vıolet yaptım
            this.dataGridView3.BorderStyle = BorderStyle.Fixed3D;  //data grıd vıew ın kenalıgını degıstırdık
            dataGridView3.BackgroundColor = Color.Black;   //butona basınca  border sstyle degısıyor
            dataGridView3.GridColor = SystemColors.ActiveBorder; //data grıd vıev arka plan siyah oluyor
            //tabloda bırden fazla satır secılebılır
            this.listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            this.dataGridView5.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView5.MultiSelect = true;
            this.dataGridView6.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView6.MultiSelect = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = true;
            //hiçbir tabloda birden faazla satır seçilemiyor
            this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.MultiSelect = false;
            this.dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView4.MultiSelect = false;
            this.dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.MultiSelect = false;
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {//comboboxdan bır ındex secıldıgı zaman arka plan rengı degısıyor
            comboBox1.BackColor = Color.AliceBlue;
        }
        private void TextBox4_TextChanged(object sender, EventArgs e)
        {//textbox ın ıçı dolu oldugunda enable true oluyor
            //textbox ın ıcınde yazılan seyı aramak ıcın kullanıyorum bbu butonu
            button5.Enabled = true;
        }     
        public void pro()
        {
            //textbox 3 içi boş iken  error provıder yanında unlem olarak uyarır
            if (textBox3.Text=="")
            {ErrorProvider provider = new ErrorProvider();
                errorProvider1.SetError(textBox3, "Bu alan boş geçilemez"); 
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
           
            try
            {
 //textbox 4 den aldıgımzı degerı strıng atadık  o strıgn atama ıle sql tablomuzda arama yaptık delete komutu ıle ılgılı satırı  sıldık
            string numara = Convert.ToString(textBox4.Text);
            string sql = "DELETE FROM gir WHERE kullanıcadı=@numara";
            SqlCommand komut = new SqlCommand(sql, baglan);
            komut.Parameters.AddWithValue("@numara", numara);
            baglan.Open();
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("silme işlemi başarılı");
            //gır tablosunu sıldıkten sonra guncellemek ıcın tekrrar cagırdık
            baglan.Open();
            string kayit = "SELECT *from gir";
            SqlCommand komuta = new SqlCommand(kayit, baglan);
            SqlDataAdapter da = new SqlDataAdapter(komuta);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }  
        private void button8_Click_1(object sender, EventArgs e)
        {//onerı tablomuzu data grıd wıeve yazdık
            baglan.Open();
            string kayit = "SELECT *from onerı";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            baglan.Close();
        }
        public void oneri()
        {
            //onerı tablomuzu data grıd wıeve yazdık
            baglan.Open();
            string kayit = "SELECT *from onerı";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            baglan.Close();
        }
        private void button7_Click_1(object sender, EventArgs e)
        {//selected rows ıle satırı sectık ve  kayıtsıl fonsıyonuna gonderdık oradakı delete komutu ıle sıldık
           
            try
            {
             foreach (DataGridViewRow drow in dataGridView3.SelectedRows)  
            {
                string numara = Convert.ToString(drow.Cells[0].Value);
                KayıtSil(numara);
                MessageBox.Show("KAYIT SİLME BAŞARILI");
                baglan.Open();
                string kayit = "SELECT *from onerı";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView3.DataSource = dt;
                baglan.Close();
            }
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }
        void KayıtSil(string numara)
        { //delete komutu ile numara parametrısıne atanan degıskenın satırını sıldık
           
            try
            {
            baglan.Open();
            string sql = "DELETE FROM onerı WHERE şikayetoneri=@numara";
            SqlCommand komut = new SqlCommand(sql, baglan);
            komut.Parameters.AddWithValue("@numara", numara);
            komut.ExecuteNonQuery();
            baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {//butona tıklandıgı  zaman mesela bolum dahılıye dahılıye bolumune yenı doktor geldı doktor ekleme yapıyoruz
            //parameters addvıthvalou ıle gelen parametreler eklenıyor
            if (comboBox1.SelectedIndex == 0)
            {

                try
                {//butona tıklandıgı  zaman mesela bolum CILDIYE bolumune yenı doktor geldı doktor ekleme yapıyoruz
                 //parameters addvıthvalou ıle gelen parametreler eklenıyor
                    if (baglan.State == ConnectionState.Closed)
                        baglan.Open();
                    string bolum = Convert.ToString(comboBox1.SelectedItem);
                    string kayit = "insert into CILDIYE(BOLUMU,ADI,ODANUMARASI,KAT) values (@BO,@ADI,@ON,@KAT)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@BO", bolum);
                    komut.Parameters.AddWithValue("@ADI", textBox10.Text);
                    komut.Parameters.AddWithValue("@ON", textBox11.Text);
                    komut.Parameters.AddWithValue("@KAT", textBox13.Text);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("Doktor Kayıt İşlemi Gerçekleşti.");
                }
                catch (Exception hata)
                {
                    MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                try
                {//butona tıklandıgı  zaman mesela bolum COCUK HASTALIKLARI bolumune yenı doktor geldı doktor ekleme yapıyoruz
                 //parameters addvıthvalou ıle gelen parametreler eklenıyor
                    if (baglan.State == ConnectionState.Closed)
                        baglan.Open();
                    string kayit = "insert into COCUKHASTALIKLARI(BOLUMU,ADI,ODANUMARASI,KAT) values (@BO,@ADI,@ON,@KAT)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@BO", comboBox1.Text);
                    komut.Parameters.AddWithValue("@ADI", textBox10.Text);
                    komut.Parameters.AddWithValue("@ON", textBox11.Text);
                    komut.Parameters.AddWithValue("@KAT", textBox13.Text);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("Doktor Kayıt İşlemi Gerçekleşti.");
                }
                catch (Exception hata)
                {
                    MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                try
                {//butona tıklandıgı  zaman mesela bolum noroşojı dahılıye bolumune yenı doktor geldı doktor ekleme yapıyoruz
                 //parameters addvıthvalou ıle gelen parametreler eklenıyor
                    if (baglan.State == ConnectionState.Closed)
                        baglan.Open();
                   string kayit = "insert into DAHILIYE(BOLUMU,ADI,ODANUMARASI,KAT) values (@BO,@ADI,@ON,@KAT)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@BO", comboBox1.Text);
                    komut.Parameters.AddWithValue("@ADI", textBox10.Text);
                    komut.Parameters.AddWithValue("@ON", textBox11.Text);
                    komut.Parameters.AddWithValue("@KAT", textBox13.Text);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("Doktor Kayıt İşlemi Gerçekleşti.");
                }
                catch (Exception hata)
                {
                    MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                }
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                try
                {//butona tıklandıgı  zaman mesela bolum GOZ bolumune yenı doktor geldı doktor ekleme yapıyoruz
                 //parameters addvıthvalou ıle gelen parametreler eklenıyor
                    if (baglan.State == ConnectionState.Closed)
                        baglan.Open();
                    string kayit = "insert into GOZ(BOLUMU,ADI,ODANUMARASI,KAT) values (@BO,@ADI,@ON,@KAT)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@BO", comboBox1.Text);
                    komut.Parameters.AddWithValue("@ADI", textBox10.Text);
                    komut.Parameters.AddWithValue("@ON", textBox11.Text);
                    komut.Parameters.AddWithValue("@KAT", textBox13.Text);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("Doktor Kayıt İşlemi Gerçekleşti.");
                }
                catch (Exception hata)
                {
                    MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                }
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                try
                {//butona tıklandıgı  zaman mesela bolum KADIN HASTALIKLARI bolumune yenı doktor geldı doktor ekleme yapıyoruz
                 //parameters addvıthvalou ıle gelen parametreler eklenıyor
                    if (baglan.State == ConnectionState.Closed)
                        baglan.Open();
                    string kayit = "insert into KH(BOLUMU,ADI,ODANUMARASI,KAT) values (@BO,@ADI,@ON,@KAT)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@BO", comboBox1.Text);
                    komut.Parameters.AddWithValue("@ADI", textBox10.Text);
                    komut.Parameters.AddWithValue("@ON", textBox11.Text);
                    komut.Parameters.AddWithValue("@KAT", textBox13.Text);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("Doktor Kayıt İşlemi Gerçekleşti.");
                }
                catch (Exception hata)
                {
                    MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                }
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                try
                {//butona tıklandıgı  zaman mesela bolum KARDIYOLOJI KARDIYOLOJI bolumune yenı doktor geldı doktor ekleme yapıyoruz
                 //parameters addvıthvalou ıle gelen parametreler eklenıyor
                    if (baglan.State == ConnectionState.Closed)
                        baglan.Open();
                    string kayit = "insert into KARDIYOLOJI(BOLUMU,ADI,ODANUMARASI,KAT) values (@BO,@ADI,@ON,@KAT)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@BO", comboBox1.Text);
                    komut.Parameters.AddWithValue("@ADI", textBox10.Text);
                    komut.Parameters.AddWithValue("@ON", textBox11.Text);
                    komut.Parameters.AddWithValue("@KAT", textBox13.Text);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("Doktor Kayıt İşlemi Gerçekleşti.");
                }
                catch (Exception hata)
                {
                    MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                }
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                try
                {//butona tıklandıgı  zaman mesela bolum KULAK BB bolumune yenı doktor geldı doktor ekleme yapıyoruz
                 //parameters addvıthvalou ıle gelen parametreler eklenıyor
                    if (baglan.State == ConnectionState.Closed)
                        baglan.Open();
                    string kayit = "insert into KBU(BOLUMU,ADI,ODANUMARASI,KAT) values (@BO,@ADI,@ON,@KAT)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@BO", comboBox1.Text);
                    komut.Parameters.AddWithValue("@ADI", textBox10.Text);
                    komut.Parameters.AddWithValue("@ON", textBox11.Text);
                    komut.Parameters.AddWithValue("@KAT", textBox13.Text);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("Doktor Kayıt İşlemi Gerçekleşti.");
                }
                catch (Exception hata)
                {
                    MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                }
            }
            else if (comboBox1.SelectedIndex == 7)
            {
                try
                {//butona tıklandıgı  zaman mesela bolum NOROLOJI NOROLOJI bolumune yenı doktor geldı doktor ekleme yapıyoruz
                 //parameters addvıthvalou ıle gelen parametreler eklenıyor
                    if (baglan.State == ConnectionState.Closed)
                        baglan.Open();
                    string kayit = "insert into NOROLOJI(BOLUMU,ADI,ODANUMARASI,KAT) values (@BO,@ADI,@ON,@KAT)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@BO", comboBox1.Text);
                    komut.Parameters.AddWithValue("@ADI", textBox10.Text);
                    komut.Parameters.AddWithValue("@ON", textBox11.Text);
                    komut.Parameters.AddWithValue("@KAT", textBox13.Text);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("Doktor Kayıt İşlemi Gerçekleşti.");
                }
                catch (Exception hata)
                {
                    MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                }
            }
            else if (comboBox1.SelectedIndex == 8)
            {
                try
                {//butona tıklandıgı  zaman mesela bolum ORTOPEDI ORTOPEDI bolumune yenı doktor geldı doktor ekleme yapıyoruz
                 //parameters addvıthvalou ıle gelen parametreler eklenıyor
                    if (baglan.State == ConnectionState.Closed)
                        baglan.Open();
                    string kayit = "insert into ORTOPEDI(BOLUMU,ADI,ODANUMARASI,KAT) values (@BO,@ADI,@ON,@KAT)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@BO", comboBox1.Text);
                    komut.Parameters.AddWithValue("@ADI", textBox10.Text);
                    komut.Parameters.AddWithValue("@ON", textBox11.Text);
                    komut.Parameters.AddWithValue("@KAT", textBox13.Text);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("Doktor Kayıt İşlemi Gerçekleşti.");
                }
                catch (Exception hata)
                {
                    MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                }
            }
            else if (comboBox1.SelectedIndex == 9)
            {
                try
                {//butona tıklandıgı  zaman mesela bolum UROLOJI UROLOJI bolumune yenı doktor geldı doktor ekleme yapıyoruz
                 //parameters addvıthvalou ıle gelen parametreler eklenıyor
                    if (baglan.State == ConnectionState.Closed)
                        baglan.Open();
                    string kayit = "insert into UROLOJI(BOLUMU,ADI,ODANUMARASI,KAT) values (@BO,@ADI,@ON,@KAT)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@BO", comboBox1.Text);
                    komut.Parameters.AddWithValue("@ADI", textBox10.Text);
                    komut.Parameters.AddWithValue("@ON", textBox11.Text);
                    komut.Parameters.AddWithValue("@KAT", textBox13.Text);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("Doktor Kayıt İşlemi Gerçekleşti.");
                }
                catch (Exception hata)
                {
                    MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
                }
            }
        }
        private void button10_Click_1(object sender, EventArgs e)
        {
            //combo box dan secilen sey kacıncı ıdexte ise ona gore o ındekstedı ıfadenın tablosunu data grıd vıev yazdırdık
            if (comboBox1.SelectedIndex == 0)
            {  //combo box dan secilen sey kacıncı ıdexte ise ona gore o ındekstedı ıfadenın tablosunu data grıd vıev yazdırdık
                baglan.Open();
                string kayit = "SELECT *from CILDIYE";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView4.DataSource = dt;
                baglan.Close();
            }
            else if (comboBox1.SelectedIndex == 1)
            { //combo box dan secilen sey kacıncı ıdexte ise ona gore o ındekstedı ıfadenın tablosunu data grıd vıev yazdırdık
                baglan.Open();
                string kayit = "SELECT *from COCUKHASTALIKLARI";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView4.DataSource = dt;
                baglan.Close();
            }
            else if (comboBox1.SelectedIndex == 2)
            { //combo box dan secilen sey kacıncı ıdexte ise ona gore o ındekstedı ıfadenın tablosunu data grıd vıev yazdırdık
                baglan.Open();
                string kayit = "SELECT *from DAHILIYE";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView4.DataSource = dt;
                baglan.Close();
            }
            else if (comboBox1.SelectedIndex == 3)
            { //combo box dan secilen sey kacıncı ıdexte ise ona gore o ındekstedı ıfadenın tablosunu data grıd vıev yazdırdık
                baglan.Open();
                string kayit = "SELECT *from GOZ";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView4.DataSource = dt;
                baglan.Close();
            }
            else if (comboBox1.SelectedIndex == 4)
            { //combo box dan secilen sey kacıncı ıdexte ise ona gore o ındekstedı ıfadenın tablosunu data grıd vıev yazdırdık
                baglan.Open();
                string kayit = "SELECT *from KH";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView4.DataSource = dt;
                baglan.Close();
            }
            else if (comboBox1.SelectedIndex == 5)
            { //combo box dan secilen sey kacıncı ıdexte ise ona gore o ındekstedı ıfadenın tablosunu data grıd vıev yazdırdık
                baglan.Open();
                string kayit = "SELECT *from KARDIYOLOJI";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView4.DataSource = dt;
                baglan.Close();
            }
            else if (comboBox1.SelectedIndex == 6)
            { //combo box dan secilen sey kacıncı ıdexte ise ona gore o ındekstedı ıfadenın tablosunu data grıd vıev yazdırdık
                baglan.Open();
                string kayit = "SELECT *from KBU";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView4.DataSource = dt;
                baglan.Close();
            }
            else if (comboBox1.SelectedIndex == 7)
            { //combo box dan secilen sey kacıncı ıdexte ise ona gore o ındekstedı ıfadenın tablosunu data grıd vıev yazdırdık
                baglan.Open();
                string kayit = "SELECT *from NOROLOJI";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView4.DataSource = dt;
                baglan.Close();
            }
            else if (comboBox1.SelectedIndex == 8)
            { //combo box dan secilen sey kacıncı ıdexte ise ona gore o ındekstedı ıfadenın tablosunu data grıd vıev yazdırdık
                baglan.Open();
                string kayit = "SELECT *from ORTOPEDI";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView4.DataSource = dt;
                baglan.Close();
            }
            else if (comboBox1.SelectedIndex == 9)
            { //combo box dan secilen sey kacıncı ıdexte ise ona gore o ındekstedı ıfadenın tablosunu data grıd vıev yazdırdık
                baglan.Open();
                string kayit = "SELECT *from UROLOJI";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView4.DataSource = dt;
                baglan.Close();
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {//butona tıklandıgı zaman data grıd vıevın arka planı sıyah oluyor  ve ardından tablomuz ekrana gelıyor
            dataGridView5.BackgroundColor = Color.Black;
            baglan.Open();
            string kayit = "SELECT *from ŞİKAYET";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView5.DataSource = dt;
            baglan.Close();
        }
        public void şikayet()
        {
            //butona tıklandıgı zaman data grıd vıevın arka planı sıyah oluyor  ve ardından tablomuz ekrana gelıyor
            dataGridView5.BackgroundColor = Color.Black;
            baglan.Open();
            string kayit = "SELECT *from ŞİKAYET";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView5.DataSource = dt;
            baglan.Close();
        }
        private void button13_Click(object sender, EventArgs e)
        {
            //selected rows ıle satırı sectık ve  kayıtsıl fonsıyonuna gonderdık oradakı delete komutu ıle sıldık

           
            try
            {
            foreach (DataGridViewRow drow in dataGridView5.SelectedRows)
            //selected rows ıle satırı sectık ve  kayıtsıl fonsıyonuna gonderdık oradakı delete komutu ıle sıldık
            {
                string numara = Convert.ToString(drow.Cells[0].Value);
                KayıtSil1(numara);
                MessageBox.Show("KAYIT SİLME BAŞARILI");
                baglan.Open();
                string kayit = "SELECT *from ŞİKAYET";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView5.DataSource = dt;
                baglan.Close();
            }
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }
        void KayıtSil1(string numara)
        { //numara deıskenıne gelen degerı tabloda buldu ve oldugu satırı sıldı 
           
            try
            {
            baglan.Open();
            string sql = "DELETE FROM ŞİKAYET WHERE DUZEY=@numara";
            SqlCommand komut = new SqlCommand(sql, baglan);
            komut.Parameters.AddWithValue("@numara", numara);
            komut.ExecuteNonQuery();
            baglan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }   
        private void button14_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex==0)
            {//o ındexdekı doktoun tablosunu data grıd vıeve getırdı
                baglan.Open();
                string kayit = "SELECT *from EMRE";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView6.DataSource = dt;
                baglan.Close();
            }
            else if (listBox1.SelectedIndex == 1)
            {//o ındexdekı doktoun tablosunu data grıd vıeve getırdı
                baglan.Open();
                string kayit = "SELECT *from CEREN";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView6.DataSource = dt;
                baglan.Close();
            }
            else if (listBox1.SelectedIndex == 2)
            {//o ındexdekı doktoun tablosunu data grıd vıeve getırdı
                baglan.Open();
                string kayit = "SELECT *from İSA";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView6.DataSource = dt;
                baglan.Close();
            }
            else if (listBox1.SelectedIndex == 3)
            {//o ındexdekı doktoun tablosunu data grıd vıeve getırdı
                baglan.Open();
                string kayit = "SELECT *from ALİ";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView6.DataSource = dt;
                baglan.Close();
            }
            else if (listBox1.SelectedIndex == 4)
            {//o ındexdekı doktoun tablosunu data grıd vıeve getırdı
                baglan.Open();
                string kayit = "SELECT *from GÜL";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView6.DataSource = dt;
                baglan.Close();
            }
            else if (listBox1.SelectedIndex == 5)
            {//o ındexdekı doktoun tablosunu data grıd vıeve getırdı
                baglan.Open();
                string kayit = "SELECT *from İHSAN";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView6.DataSource = dt;
                baglan.Close();
            }
            else if (listBox1.SelectedIndex == 6)
            {//o ındexdekı doktoun tablosunu data grıd vıeve getırdı
                baglan.Open();
                string kayit = "SELECT *from KENAN";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView6.DataSource = dt;
                baglan.Close();
            }
            else if (listBox1.SelectedIndex == 7)
            {//o ındexdekı doktoun tablosunu data grıd vıeve getırdı
                baglan.Open();
                string kayit = "SELECT *from ERGÜN";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView6.DataSource = dt;
                baglan.Close();
            }
            else if (listBox1.SelectedIndex == 8)
            {//o ındexdekı doktoun tablosunu data grıd vıeve getırdı
                baglan.Open();
                string kayit = "SELECT *from SELİM";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView6.DataSource = dt;
                baglan.Close();
            }
            else if (listBox1.SelectedIndex == 9)
            {//o ındexdekı doktoun tablosunu data grıd vıeve getırdı
                baglan.Open();
                string kayit = "SELECT *from ASLI";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView6.DataSource = dt;
                baglan.Close();
            }
            else if (listBox1.SelectedIndex == 10)
            {//o ındexdekı doktoun tablosunu data grıd vıeve getırdı
                baglan.Open();
                string kayit = "SELECT *from SİNEM";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView6.DataSource = dt;
                baglan.Close();
            }
            else if (listBox1.SelectedIndex ==11)
            {//o ındexdekı doktoun tablosunu data grıd vıeve getırdı
                baglan.Open();
                string kayit = "SELECT *from MURAT";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView6.DataSource = dt;
                baglan.Close();
            }
            else if (listBox1.SelectedIndex == 12)
            {//o ındexdekı doktoun tablosunu data grıd vıeve getırdı
                baglan.Open();
                string kayit = "SELECT *from KEMAL";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView6.DataSource = dt;
                baglan.Close();
            }
            else if (listBox1.SelectedIndex == 13)
            {//o ındexdekı doktoun tablosunu data grıd vıeve getırdı
                baglan.Open();
                string kayit = "SELECT *from HASAN";
                SqlCommand komut = new SqlCommand(kayit, baglan);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView6.DataSource = dt;
                baglan.Close();
            }
        }
        private void button15_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                foreach (DataGridViewRow drow in dataGridView6.SelectedRows)
                //selected rows ıle satırı sectık oradakı delete komutu ıle sıldık ve tablomuzu guncelledık
                {
                    string numara = Convert.ToString(drow.Cells[0].Value);
                    baglan.Open();
                    string sql = "DELETE FROM EMRE WHERE İSİM=@numara";
                    SqlCommand komut = new SqlCommand(sql, baglan);
                    komut.Parameters.AddWithValue("@numara", numara);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("KAYIT SİLME BAŞARILI");
                    baglan.Open();
                    string kayit = "SELECT *from EMRE";
                    komut = new SqlCommand(kayit, baglan);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView6.DataSource = dt;
                    baglan.Close();
                }
            }
            else if (listBox1.SelectedIndex == 1)
            {
                foreach (DataGridViewRow drow in dataGridView6.SelectedRows)  //Seçili Satırları Silme
                { //selected rows ıle satırı sectık oradakı delete komutu ıle sıldık ve tablomuzu guncelledık
                    string numara = Convert.ToString(drow.Cells[0].Value);
                    baglan.Open();
                    string sql = "DELETE FROM CEREN WHERE İSİM=@numara";
                    SqlCommand komut = new SqlCommand(sql, baglan);
                    komut.Parameters.AddWithValue("@numara", numara);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("KAYIT SİLME BAŞARILI");
                    baglan.Open();
                    string kayit = "SELECT *from CEREN";
                    komut = new SqlCommand(kayit, baglan);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView6.DataSource = dt;
                    baglan.Close();
                }
            }
            else if (listBox1.SelectedIndex == 2)
            {
                foreach (DataGridViewRow drow in dataGridView6.SelectedRows)  //Seçili Satırları Silme
                { //selected rows ıle satırı sectık oradakı delete komutu ıle sıldık ve tablomuzu guncelledık
                    string numara = Convert.ToString(drow.Cells[0].Value);
                    baglan.Open();
                    string sql = "DELETE FROM İSA WHERE İSİM=@numara";
                    SqlCommand komut = new SqlCommand(sql, baglan);
                    komut.Parameters.AddWithValue("@numara", numara);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("KAYIT SİLME BAŞARILI");
                    baglan.Open();
                    string kayit = "SELECT *from İSA";
                    komut = new SqlCommand(kayit, baglan);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView6.DataSource = dt;
                    baglan.Close();
                }
            }
            else if (listBox1.SelectedIndex == 3)
            {
                foreach (DataGridViewRow drow in dataGridView6.SelectedRows)  //Seçili Satırları Silme
                { //selected rows ıle satırı sectık oradakı delete komutu ıle sıldık ve tablomuzu guncelledık
                    string numara = Convert.ToString(drow.Cells[0].Value);
                    baglan.Open();
                    string sql = "DELETE FROM ALİ WHERE İSİM=@numara";
                    SqlCommand komut = new SqlCommand(sql, baglan);
                    komut.Parameters.AddWithValue("@numara", numara);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("KAYIT SİLME BAŞARILI");
                    baglan.Open();
                    string kayit = "SELECT *from ALİ";
                    komut = new SqlCommand(kayit, baglan);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView6.DataSource = dt;
                    baglan.Close();
                }
            }
            else if (listBox1.SelectedIndex == 4)
            {
                foreach (DataGridViewRow drow in dataGridView6.SelectedRows)  //Seçili Satırları Silme
                { //selected rows ıle satırı sectık oradakı delete komutu ıle sıldık ve tablomuzu guncelledık
                    string numara = Convert.ToString(drow.Cells[0].Value);
                    baglan.Open();
                    string sql = "DELETE FROM GÜL WHERE İSİM=@numara";
                    SqlCommand komut = new SqlCommand(sql, baglan);
                    komut.Parameters.AddWithValue("@numara", numara);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("KAYIT SİLME BAŞARILI");
                    baglan.Open();
                    string kayit = "SELECT *from GÜL";
                    komut = new SqlCommand(kayit, baglan);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView6.DataSource = dt;
                    baglan.Close();
                }
            }
            else if (listBox1.SelectedIndex == 5)
            {
                foreach (DataGridViewRow drow in dataGridView6.SelectedRows)  //Seçili Satırları Silme
                { //selected rows ıle satırı sectık oradakı delete komutu ıle sıldık ve tablomuzu guncelledık
                    string numara = Convert.ToString(drow.Cells[0].Value);
                    baglan.Open();
                    string sql = "DELETE FROM İHSAN WHERE İSİM=@numara";
                    SqlCommand komut = new SqlCommand(sql, baglan);
                    komut.Parameters.AddWithValue("@numara", numara);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("KAYIT SİLME BAŞARILI");
                    baglan.Open();
                    string kayit = "SELECT *from İHSAN";
                    komut = new SqlCommand(kayit, baglan);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView6.DataSource = dt;
                    baglan.Close();
                }
            }
            else if (listBox1.SelectedIndex == 6)
            {
                foreach (DataGridViewRow drow in dataGridView6.SelectedRows)  //Seçili Satırları Silme
                { //selected rows ıle satırı sectık oradakı delete komutu ıle sıldık ve tablomuzu guncelledık
                    string numara = Convert.ToString(drow.Cells[0].Value);
                    baglan.Open();
                    string sql = "DELETE FROM KENAN WHERE İSİM=@numara";
                    SqlCommand komut = new SqlCommand(sql, baglan);
                    komut.Parameters.AddWithValue("@numara", numara);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("KAYIT SİLME BAŞARILI");
                    baglan.Open();
                    string kayit = "SELECT *from KENAN";
                    komut = new SqlCommand(kayit, baglan);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView6.DataSource = dt;
                    baglan.Close();
                }
            }
            else if (listBox1.SelectedIndex == 7)
            {
                foreach (DataGridViewRow drow in dataGridView6.SelectedRows)  //Seçili Satırları Silme
                { //selected rows ıle satırı sectık oradakı delete komutu ıle sıldık ve tablomuzu guncelledık
                    string numara = Convert.ToString(drow.Cells[0].Value);
                    baglan.Open();
                    string sql = "DELETE FROM ERGÜN WHERE İSİM=@numara";
                    SqlCommand komut = new SqlCommand(sql, baglan);
                    komut.Parameters.AddWithValue("@numara", numara);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("KAYIT SİLME BAŞARILI");
                    baglan.Open();
                    string kayit = "SELECT *from ERGÜN";
                    komut = new SqlCommand(kayit, baglan);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView6.DataSource = dt;
                    baglan.Close();
                }
            }
            else if (listBox1.SelectedIndex == 8)
            {
                foreach (DataGridViewRow drow in dataGridView6.SelectedRows)  //Seçili Satırları Silme
                { //selected rows ıle satırı sectık oradakı delete komutu ıle sıldık ve tablomuzu guncelledık
                    string numara = Convert.ToString(drow.Cells[0].Value);
                    baglan.Open();
                    string sql = "DELETE FROM SELİM WHERE İSİM=@numara";
                    SqlCommand komut = new SqlCommand(sql, baglan);
                    komut.Parameters.AddWithValue("@numara", numara);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("KAYIT SİLME BAŞARILI");
                    baglan.Open();
                    string kayit = "SELECT *from SELİM";
                    komut = new SqlCommand(kayit, baglan);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView6.DataSource = dt;
                    baglan.Close();
                }
            }
            else if (listBox1.SelectedIndex == 9)
            {
                foreach (DataGridViewRow drow in dataGridView6.SelectedRows)  //Seçili Satırları Silme
                { //selected rows ıle satırı sectık oradakı delete komutu ıle sıldık ve tablomuzu guncelledık
                    string numara = Convert.ToString(drow.Cells[0].Value);
                    baglan.Open();
                    string sql = "DELETE FROM ASLI WHERE İSİM=@numara";
                    SqlCommand komut = new SqlCommand(sql, baglan);
                    komut.Parameters.AddWithValue("@numara", numara);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("KAYIT SİLME BAŞARILI");
                    baglan.Open();
                    string kayit = "SELECT *from ASLI";
                    komut = new SqlCommand(kayit, baglan);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView6.DataSource = dt;
                    baglan.Close();
                }
            }
            else if (listBox1.SelectedIndex == 10)
            {
                foreach (DataGridViewRow drow in dataGridView6.SelectedRows)  //Seçili Satırları Silme
                { //selected rows ıle satırı sectık oradakı delete komutu ıle sıldık ve tablomuzu guncelledık
                    string numara = Convert.ToString(drow.Cells[0].Value);
                    baglan.Open();
                    string sql = "DELETE FROM SİNEM WHERE İSİM=@numara";
                    SqlCommand komut = new SqlCommand(sql, baglan);
                    komut.Parameters.AddWithValue("@numara", numara);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("KAYIT SİLME BAŞARILI");
                    baglan.Open();
                    string kayit = "SELECT *from SİNEM";
                    komut = new SqlCommand(kayit, baglan);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView6.DataSource = dt;
                    baglan.Close();
                }
            }
            else if (listBox1.SelectedIndex == 11)
            {
                foreach (DataGridViewRow drow in dataGridView6.SelectedRows)  //Seçili Satırları Silme
                { //selected rows ıle satırı sectık oradakı delete komutu ıle sıldık ve tablomuzu guncelledık
                    string numara = Convert.ToString(drow.Cells[0].Value);
                    baglan.Open();
                    string sql = "DELETE FROM MURAT WHERE İSİM=@numara";
                    SqlCommand komut = new SqlCommand(sql, baglan);
                    komut.Parameters.AddWithValue("@numara", numara);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("KAYIT SİLME BAŞARILI");
                    baglan.Open();
                    string kayit = "SELECT *from MURAT";
                    komut = new SqlCommand(kayit, baglan);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView6.DataSource = dt;
                    baglan.Close();
                }
            }
            else if (listBox1.SelectedIndex == 12)
            {
                foreach (DataGridViewRow drow in dataGridView6.SelectedRows)  //Seçili Satırları Silme
                { //selected rows ıle satırı sectık oradakı delete komutu ıle sıldık ve tablomuzu guncelledık
                    string numara = Convert.ToString(drow.Cells[0].Value);
                    baglan.Open();
                    string sql = "DELETE FROM KEMAL WHERE İSİM=@numara";
                    SqlCommand komut = new SqlCommand(sql, baglan);
                    komut.Parameters.AddWithValue("@numara", numara);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("KAYIT SİLME BAŞARILI");
                    baglan.Open();
                    string kayit = "SELECT *from KEMAL";
                    komut = new SqlCommand(kayit, baglan);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView6.DataSource = dt;
                    baglan.Close();
                }
            }
            else if (listBox1.SelectedIndex == 13)
            {
                foreach (DataGridViewRow drow in dataGridView6.SelectedRows)  //Seçili Satırları Silme
                { //selected rows ıle satırı sectık oradakı delete komutu ıle sıldık ve tablomuzu guncelledık
                    string numara = Convert.ToString(drow.Cells[0].Value);
                    baglan.Open();
                    string sql = "DELETE FROM HASAN WHERE İSİM=@numara";
                    SqlCommand komut = new SqlCommand(sql, baglan);
                    komut.Parameters.AddWithValue("@numara", numara);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("KAYIT SİLME BAŞARILI");
                    baglan.Open();
                    //tablo gunelleme yenıden cagırma
                    string kayit = "SELECT *from HASAN";
                     komut = new SqlCommand(kayit, baglan);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView6.DataSource = dt;
                    baglan.Close();     
                }
            }
        }
        private void button16_Click(object sender, EventArgs e)
        {
            //once arr dızısıne combo box  da secılen ıtemı ve rıch text box dakı ogelerı ekledık dızı elemanlarını  list vıev 1 ıtems add komutu ıle ekledık
            string[] arr = new string[3];
            ListViewItem itm;
            arr[0] = Convert.ToString(comboBox2.SelectedItem);
            arr[1] = richTextBox1.Text;           
            itm = new ListViewItem(arr);
            listView1.Items.Add(itm);
        }
        private void button17_Click(object sender, EventArgs e)
        { // burada ise list vıevdekı secılen satırı vey satırları sılme ıslemı gerceklestırdık
            for (int i = listView1.SelectedIndices.Count - 1; i >= 0; i--)
            {
                listView1.Items.Remove(listView1.SelectedItems[i]);
            }  
        }
        private void kIRMIZIToolStripMenuItem_Click(object sender, EventArgs e)
        {// tool strıp menu ıtemdekı iteme tıklayımca  tablo rengı degıstırdık
            listView1.BackColor = System.Drawing.Color.Red;
        }
        private void yEŞİLToolStripMenuItem_Click(object sender, EventArgs e)
        {// tool strıp menu ıtemdekı iteme tıklayımca  tablo rengı degıstırdık
            listView1.BackColor = System.Drawing.Color.Green;
        }
        private void mAVİToolStripMenuItem_Click(object sender, EventArgs e)
        {// tool strıp menu ıtemdekı iteme tıklayımca  rengı degıstırdık
            listView1.BackColor = System.Drawing.Color.Blue;
        }
        private void tURUNCUToolStripMenuItem_Click(object sender, EventArgs e)
        {// tool strıp menu ıtemdekı iteme tıklayımca  tablo rengı degıstırdık
            listView1.BackColor = System.Drawing.Color.Orange;
        }
        private void lacivertToolStripMenuItem_Click(object sender, EventArgs e)
        {// tool strıp menu ıtemdekı iteme tıklayımca  yazı rengı degıstırdık
            listView1.ForeColor = System.Drawing.Color.DarkBlue;
        }
        private void kırmızıToolStripMenuItem_Click(object sender, EventArgs e)
        {//tool strıp menu ıtemdekı iteme tıklayımca yazı rengı degıstırdık

            listView1.ForeColor = System.Drawing.Color.Red;
        }
        private void morToolStripMenuItem_Click(object sender, EventArgs e)
        {// tool strıp menu ıtemdekı iteme tıklayımca yazı rengı degıstırdık

            listView1.ForeColor = System.Drawing.Color.Purple;
        }
        private void sarıToolStripMenuItem_Click(object sender, EventArgs e)
        {// tool strıp menu ıtemdekı sarıya tıklayınca yazı rengı degıstırdık                
         listView1.ForeColor = System.Drawing.Color.Yellow;
        }
        private void çIKIŞToolStripMenuItem_Click(object sender, EventArgs e)
        { //menu  strıp itemde çıkışa tıklarsa form kapanır
            this.Close();
        } 
        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            if(toolStripComboBox1.SelectedIndex==0)
            {
              //menu strıp ıcındekı yzı tıpı combo boxdan 0.indexe basarsa list viev yazı tıpı ıtalık olur
               listView1.Font = new Font(listView1.Font, listView1.Font.Style ^ FontStyle.Italic);
            }else if( toolStripComboBox1.SelectedIndex==1)
            {
                //menu strıp ıcındekı yzı tıpı combo boxdan 0.indexe basarsa list viev yazı tıpı underlıne olur
                listView1.Font = new Font(listView1.Font, listView1.Font.Style ^ FontStyle.Underline);
            }
        }
        private void button18_Click(object sender, EventArgs e)
        {//bu butona basıldıgı zaman lst vievde tık attigim satırı sıler
            for(int i=0;i<=listView1.CheckedItems.Count;i++)
            {
                listView1.Items.Remove(listView1.CheckedItems[i]);
            
            }
        }
        private void button19_Click_1(object sender, EventArgs e)
        {//data grıd uzerınden guncelleme yapmak için current row ıle gecerlı satırdakı
         // degısıklik yapılan yerı aldık strıng olarak degısken olarak atadım ondan sonra update ıle guncelledım
            try
            {
                if (comboBox1.SelectedIndex == 0)
                {

                    MessageBox.Show("GÜNCELLEME BAŞARILI");

                    string BOLUMU, ADI, ODANUMARASI, KAT;
                    BOLUMU = dataGridView4.CurrentRow.Cells["BOLUMU"].Value.ToString();
                    ADI = dataGridView4.CurrentRow.Cells["ADI"].Value.ToString();
                    ODANUMARASI = dataGridView4.CurrentRow.Cells["ODANUMARASI"].Value.ToString();
                    KAT = dataGridView4.CurrentRow.Cells["KAT"].Value.ToString();
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("update CILDIYE set BOLUMU='" + BOLUMU + "',ODANUMARASI='" + ODANUMARASI + "',KAT='" + KAT + "' where ADI = '" + ADI + "'", baglan);
                    komut.ExecuteNonQuery();
                    baglan.Close();

                }
                else if (comboBox1.SelectedIndex == 1)
                {//data grıd uzerınden guncelleme yapmak için current row ıle gecerlı satırdakı
                 // degısıklik yapılan yerı aldık strıng olarak degısken olarak atadım ondan sonra update ıle guncelledım
                    string BOLUMU, ADI, ODANUMARASI, KAT;
                    BOLUMU = dataGridView4.CurrentRow.Cells["BOLUMU"].Value.ToString();
                    ADI = dataGridView4.CurrentRow.Cells["ADI"].Value.ToString();
                    ODANUMARASI = dataGridView4.CurrentRow.Cells["ODANUMARASI"].Value.ToString();
                    KAT = dataGridView4.CurrentRow.Cells["KAT"].Value.ToString();
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("update COCUKHASTALIKLARI set BOLUMU='" + BOLUMU + "',ODANUMARASI='" + ODANUMARASI + "',KAT='" + KAT + "' where ADI = '" + ADI + "'", baglan);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("GÜNCELLEME BAŞARILI");
                }
                else if (comboBox1.SelectedIndex == 2)
                {//data grıd uzerınden guncelleme yapmak için current row ıle gecerlı satırdakı
                 // degısıklik yapılan yerı aldık strıng olarak degısken olarak atadım ondan sonra update ıle guncelledım
                    string BOLUMU, ADI, ODANUMARASI, KAT;
                    BOLUMU = dataGridView4.CurrentRow.Cells["BOLUMU"].Value.ToString();
                    ADI = dataGridView4.CurrentRow.Cells["ADI"].Value.ToString();
                    ODANUMARASI = dataGridView4.CurrentRow.Cells["ODANUMARASI"].Value.ToString();
                    KAT = dataGridView4.CurrentRow.Cells["KAT"].Value.ToString();
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("update DAHILIYE set BOLUMU='" + BOLUMU + "',ODANUMARASI='" + ODANUMARASI + "',KAT='" + KAT + "' where ADI = '" + ADI + "'", baglan);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("GÜNCELLEME BAŞARILI");
                }
                else if (comboBox1.SelectedIndex == 3)
                {//data grıd uzerınden guncelleme yapmak için current row ıle gecerlı satırdakı
                 // degısıklik yapılan yerı aldık strıng olarak degısken olarak atadım ondan sonra update ıle guncelledım
                    string BOLUMU, ADI, ODANUMARASI, KAT;
                    BOLUMU = dataGridView4.CurrentRow.Cells["BOLUMU"].Value.ToString();
                    ADI = dataGridView4.CurrentRow.Cells["ADI"].Value.ToString();
                    ODANUMARASI = dataGridView4.CurrentRow.Cells["ODANUMARASI"].Value.ToString();
                    KAT = dataGridView4.CurrentRow.Cells["KAT"].Value.ToString();
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("update GOZ set BOLUMU='" + BOLUMU + "',ODANUMARASI='" + ODANUMARASI + "',KAT='" + KAT + "' where ADI = '" + ADI + "'", baglan);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("GÜNCELLEME BAŞARILI");
                }
                else if (comboBox1.SelectedIndex == 4)
                {//data grıd uzerınden guncelleme yapmak için current row ıle gecerlı satırdakı
                 // degısıklik yapılan yerı aldık strıng olarak degısken olarak atadım ondan sonra update ıle guncelledım
                    string BOLUMU, ADI, ODANUMARASI, KAT;
                    BOLUMU = dataGridView4.CurrentRow.Cells["BOLUMU"].Value.ToString();
                    ADI = dataGridView4.CurrentRow.Cells["ADI"].Value.ToString();
                    ODANUMARASI = dataGridView4.CurrentRow.Cells["ODANUMARASI"].Value.ToString();
                    KAT = dataGridView4.CurrentRow.Cells["KAT"].Value.ToString();
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("update KH set BOLUMU='" + BOLUMU + "',ODANUMARASI='" + ODANUMARASI + "',KAT='" + KAT + "' where ADI = '" + ADI + "'", baglan);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("GÜNCELLEME BAŞARILI");
                }
                else if (comboBox1.SelectedIndex == 5)
                {//data grıd uzerınden guncelleme yapmak için current row ıle gecerlı satırdakı
                 // degısıklik yapılan yerı aldık strıng olarak degısken olarak atadım ondan sonra update ıle guncelledım
                    string BOLUMU, ADI, ODANUMARASI, KAT;
                    BOLUMU = dataGridView4.CurrentRow.Cells["BOLUMU"].Value.ToString();
                    ADI = dataGridView4.CurrentRow.Cells["ADI"].Value.ToString();
                    ODANUMARASI = dataGridView4.CurrentRow.Cells["ODANUMARASI"].Value.ToString();
                    KAT = dataGridView4.CurrentRow.Cells["KAT"].Value.ToString();
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("update KARDIYOLOJI set BOLUMU='" + BOLUMU + "',ODANUMARASI='" + ODANUMARASI + "',KAT='" + KAT + "' where ADI = '" + ADI + "'", baglan);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("GÜNCELLEME BAŞARILI");
                }
                else if (comboBox1.SelectedIndex == 6)
                {//data grıd uzerınden guncelleme yapmak için current row ıle gecerlı satırdakı
                 // degısıklik yapılan yerı aldık strıng olarak degısken olarak atadım ondan sonra update ıle guncelledım
                    string BOLUMU, ADI, ODANUMARASI, KAT;
                    BOLUMU = dataGridView4.CurrentRow.Cells["BOLUMU"].Value.ToString();
                    ADI = dataGridView4.CurrentRow.Cells["ADI"].Value.ToString();
                    ODANUMARASI = dataGridView4.CurrentRow.Cells["ODANUMARASI"].Value.ToString();
                    KAT = dataGridView4.CurrentRow.Cells["KAT"].Value.ToString();
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("update KBU set BOLUMU='" + BOLUMU + "',ODANUMARASI='" + ODANUMARASI + "',KAT='" + KAT + "' where ADI = '" + ADI + "'", baglan);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("GÜNCELLEME BAŞARILI");

                }
                else if (comboBox1.SelectedIndex == 7)
                {//data grıd uzerınden guncelleme yapmak için current row ıle gecerlı satırdakı
                 // degısıklik yapılan yerı aldık strıng olarak degısken olarak atadım ondan sonra update ıle guncelledım
                    string BOLUMU, ADI, ODANUMARASI, KAT;
                    BOLUMU = dataGridView4.CurrentRow.Cells["BOLUMU"].Value.ToString();
                    ADI = dataGridView4.CurrentRow.Cells["ADI"].Value.ToString();
                    ODANUMARASI = dataGridView4.CurrentRow.Cells["ODANUMARASI"].Value.ToString();
                    KAT = dataGridView4.CurrentRow.Cells["KAT"].Value.ToString();
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("update NOROLOJI set BOLUMU='" + BOLUMU + "',ODANUMARASI='" + ODANUMARASI + "',KAT='" + KAT + "' where ADI = '" + ADI + "'", baglan);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("GÜNCELLEME BAŞARILI");

                }
                else if (comboBox1.SelectedIndex == 8)
                {//data grıd uzerınden guncelleme yapmak için current row ıle gecerlı satırdakı
                 // degısıklik yapılan yerı aldık strıng olarak degısken olarak atadım ondan sonra update ıle guncelledım
                    string BOLUMU, ADI, ODANUMARASI, KAT;
                    BOLUMU = dataGridView4.CurrentRow.Cells["BOLUMU"].Value.ToString();
                    ADI = dataGridView4.CurrentRow.Cells["ADI"].Value.ToString();
                    ODANUMARASI = dataGridView4.CurrentRow.Cells["ODANUMARASI"].Value.ToString();
                    KAT = dataGridView4.CurrentRow.Cells["KAT"].Value.ToString();
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("update ORTOPEDİ set BOLUMU='" + BOLUMU + "',ODANUMARASI='" + ODANUMARASI + "',KAT='" + KAT + "' where ADI = '" + ADI + "'", baglan);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("GÜNCELLEME BAŞARILI");
                }
                else if (comboBox1.SelectedIndex == 9)
                {//data grıd uzerınden guncelleme yapmak için current row ıle gecerlı satırdakı
                 // degısıklik yapılan yerı aldık strıng olarak degısken olarak atadım ondan sonra update ıle guncelledım
                    string BOLUMU, ADI, ODANUMARASI, KAT;
                    BOLUMU = dataGridView4.CurrentRow.Cells["BOLUMU"].Value.ToString();
                    ADI = dataGridView4.CurrentRow.Cells["ADI"].Value.ToString();
                    ODANUMARASI = dataGridView4.CurrentRow.Cells["ODANUMARASI"].Value.ToString();
                    KAT = dataGridView4.CurrentRow.Cells["KAT"].Value.ToString();
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("update UROLOJI set BOLUMU='" + BOLUMU + "',ODANUMARASI='" + ODANUMARASI + "',KAT='" + KAT + "' where ADI = '" + ADI + "'", baglan);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("GÜNCELLEME BAŞARILI");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }
    }
}
