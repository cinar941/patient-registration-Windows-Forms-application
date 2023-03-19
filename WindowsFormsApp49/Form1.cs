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


namespace WindowsFormsApp49
{
    public partial class Form1 : Form
    {
        private int sayi = 0;
        SqlConnection bağlan = new SqlConnection("Data Source=DESKTOP-RLCKHNM\\SQLEXPRESS;Initial Catalog=sbo;Integrated Security=True;Pooling=False");
        public Form1()
        {
            InitializeComponent();
        }         
        public void gir()
        {//textbox 1 ve textbox 2 dekıverıler taplomuzdakı ıle eslesıyosa form4 e gecmesını ıstedık
            bağlan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM admin where kullanıcadı='" + textBox1.Text + "' AND şifre='" + maskedTextBox1.Text + "'", bağlan);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                Form4 fr1 = new Form4();
                fr1.Show();
            }
            else
            {
                MessageBox.Show("kullanıcı adı veya şifre hatalı!!! ");
            }
            bağlan.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.TextChanged += TextBox1_TextChanged;//textboxun ıcıne bısey yazılınca neyı tetıklıyecegını belırlemek ıcın kullanılır
            notifyIcon1.Icon = SystemIcons.Exclamation;
            notifyIcon1.BalloonTipTitle = "BİLDİR";//balon tip başlıgı
            notifyIcon1.BalloonTipText = "Saglıklı Bir Hayat Dileriz..";//balon tıp ın ne yazıcagı
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;//uyarının sag altta ıkon gozukmesı saglanır
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
            notifyIcon1.BalloonTipShown += NotifyIcon1_BalloonTipShown;
            timer1.Tick += Timer1_Tick;
            notifyIcon1.BalloonTipClosed += NotifyIcon1_BalloonTipClosed;//balon tıp ıle gelen bıldırım kapandıgında bir olay olması ıcın aktıf ettım
            notifyIcon1.BalloonTipClicked += NotifyIcon1_BalloonTipClicked;//balon tıp ıle gelen bıldırıme tıklandıgında bir olay olması ıcın aktıf ettım
            textBox1.MouseUp += TextBox1_MouseUp;//textbox mousun ozellıgı ıle textboxa tıklandıgı zaman bır iş yapar
            maskedTextBox1.MouseUp += MaskedTextBox1_MouseUp;//masked textbox mousun ozellıgı ıle textboxa tıklandıgı zaman bır iş yapar
            button1.EnabledChanged += Button1_EnabledChanged;//butonun enable changed aktıf ettım
            label5.Text = Convert.ToString(sayi);
            timer1.Interval = 1000;//tımerdekı surenın kacar kacar artacagını belırledık mılı sanıye cınsınden 1000ms=1sanıye
            timer1.Start();
            this.pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;//pıctıre box 1  dekı goruntuyu ortaya alacak sekılde yaptık  
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {//text box ın ıcıne kulancı adı yazıldıgı zaman şifre bolumu yanı masked textbox arka plan acık mavı oluyor
            maskedTextBox1.BackColor = Color.LightBlue;
        }
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //checked box a tıklı ıse sıfreyı gosterır tıklı degıl ıse yazılan sıfreyı gızler
            if (checkBox1.Checked)
            {
                //karakteri göster.
                maskedTextBox1.PasswordChar = '\0';
                checkBox1.Text = "gizli degil";
            }
            //değilse karakterlerin yerine * koy.
            else
            {
                maskedTextBox1.PasswordChar = '*';
                checkBox1.Text = "gizli";
            }
        }
        private void NotifyIcon1_BalloonTipShown(object sender, EventArgs e)
        {
            //notıfıcylon bıldırım verınce resım eskı halıne donuyor 
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;//pıctıre box 1  dekı goruntuyu ilk halıne alıcak sekılde yaptık  

        }
        private void Timer1_Tick(object sender, EventArgs e)
        {//sayıya her sanıyede 1 eklıyor ve label 5 eyazıyor buda işlem suremızı gosterıyor
            sayi = sayi + 1;
            label5.Text = Convert.ToString(sayi);
        }
        private void NotifyIcon1_BalloonTipClosed(object sender, EventArgs e)
        {
            //Ekranınn sag alt tarafında gozuken bildirim  kapanıca ekrana mesajla bu uyarıyı verır
            MessageBox.Show("SAGLIGIMIZ İÇİN SOSYAL MESAFEMİZE LÜTFEN DİKKAT EDELİM");
        }
        private void NotifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            //ekrana gelen baloon tıp ıkouna tıklandıgı zaman form 1 i gizler
            //istersek tekrardan sag alttakı notıfıkaylon ıkanuna yıklayıp goster diyebiliriz
            this.Hide();      
        }
        private void MaskedTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //maskedtextboxa içine birsey yazılmak için tıklandıgı zaman arka plan rengı degısıyor
            maskedTextBox1.BackColor = Color.Aqua;
        }
        private void TextBox1_MouseUp(object sender, MouseEventArgs e)
        {//textboxa içine birsey yazılmak için tıklandıgı zaman arka plan rengı degısıyor
            textBox1.BackColor = Color.Aqua;
        }
        private void Button1_EnabledChanged(object sender, EventArgs e)
        {//buton un enablesı degısırse label 3 yanı kayıt ıslemı kapansın
            label3.Enabled = false;
        }
        private void AddVisibleChangedEventHandler()
        {
            label3.VisibleChanged += new EventHandler(this.label3_VisibleChanged);//label 3 un vısıble changedozllıgı ayarladık
        }
        private void label3_VisibleChanged(object sender, EventArgs e)
        {
            //label 3 vısıblesı degıtgı zaman buton 1 ın arka planı kırmızı oluyor
            button1.BackColor = Color.Red;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {//pucture box 2 ye bastıgımzı zaman baloon tıp ıle sag altta bıldırı vermsını sagladık
            Form3 frd = new Form3();//form 3 e gecıs ı yaptık
            frd.Show();
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;//baloon tıp ın ne cesıt uyarı verııcegın belırledık
            notifyIcon1.BalloonTipTitle = "BİLDİRİ";//baloon tıp ın baslıgını yazdık
            notifyIcon1.BalloonTipText = "SAGLIKLI BİR HAYAT DİLERİZ";//baloon tıp ın metnını belırledık baslıgın altında yazan
            notifyIcon1.ShowBalloonTip(3000);//bunnla bellı zaman aralıgında baloncuk gosterıyor
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            gir();//textbox 1 ve textbox 2 dekıverıler taplomuzdakı ıle eslesıyosa form4 e gecmesını ıstedık gır fok ıle
            button1.Enabled = false;  //buton 2 ye basına buton bır enable false oluyor      
        }
        private void button1_Click_1(object sender, EventArgs e)
        {//textbox 1 ve textbox 2 dekı verıler gir taplomuzdakı ıle eslesıyosa form3 e gecmesını ıstedık
            try
            {
            bağlan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM gir where kullanıcadı='" + textBox1.Text + "' AND şifre='" + maskedTextBox1.Text + "'", bağlan);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                Form3 fr1 = new Form3();
                fr1.Show();
                //form 3 e gectıkten sonra  buton uzerınde giriş yapıldı yazsın 
                button1.Text = "GİRİŞ YAPILDI";
                //form 3 e gectıkten sonra  buton enable ozellıgı false olsun
                button1.Enabled = false;
            }
            else
            {
                MessageBox.Show("kullanıcı adı veya şifre hatalı!!! ");
            }
            bağlan.Close();
            }catch(Exception hata)
            {
                MessageBox.Show("İŞLEM SIRASINDA BİR HATA OLUŞTU" + hata);
            }
            
        }
        private void label3_Click_1(object sender, EventArgs e)
        {
            Form2 frn = new Form2();
            frn.Show();//label 3 e tıklandıgı zaman form 2 ye gecer form 1 ı thıs.hıde ıle gızler  ve label 3 un vızıblesını faalse yapar
            this.Hide();
            label3.Visible = false;
            //burada yenı kayıt ıcın form ıkıye gıttık 
        }
        private void gösterToolStripMenuItem_Click(object sender, EventArgs e)
        {//burada notıfıcylon a context menu strıp ekledık burada context menu strıp sag alt tarafta 
          //gozuken ıcona cıft tılandıgı zaman menu strıp olarak yazdıklarımız gozukurburada goster
          // gızlı ve cıkıs olarak 3 e ayırdım ve tıklanırsa ne olacagını belırttım
            this.Show();
        }
        private void gizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //burada notıfıcylon a context menu strıp ekledık burada context menu strıp sag alt tarafta 
            //gozuken ıcona cıft tılandıgı zaman menu strıp olarak yazdıklarımız gozukurburada goster
            // gızlı ve cıkıs olarak 3 e ayırdım ve tıklanırsa ne olacagını belırttım
            this.Hide();
        }
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //burada notıfıcylon a context menu strıp ekledık burada context menu strıp sag alt tarafta 
            //gozuken ıcona cıft tılandıgı zaman menu strıp olarak yazdıklarımız gozukurburada goster
            // gızlı ve cıkıs olarak 3 e ayırdım ve tıklanırsa ne olacagını belırttım
            this.Close();
        }
        
    }
}
