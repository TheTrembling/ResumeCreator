using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ResumeCreator
{
    public partial class Step5 : Form
    {
        int exampleCount = 0, mbCount = 0;
        string driverLicense = "";

        string[] mbArr = { "Є", "Немає" };
        string[] s = { "-Без зразка-", "Зразок" };
        public Step5()
        {
            InitializeComponent();
            design();
            step5Loading();
        }
        private void step5Loading()
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo("Моє резюме/Інше");

                if (!di.Exists)
                    di.Create();

                FileInfo fi = new FileInfo("Моє резюме/Інше/Інше.txt");

                if (fi.Exists)
                {
                    using (StreamReader sr = new StreamReader("Моє резюме/Інше/Інше.txt"))
                    {
                        string line;
                        var list = new List<string>();

                        while ((line = sr.ReadLine()) != null)
                            list.Add(line);

                        if (list.Count > 0) languages.Text = list[0];
                        if (list.Count > 1)
                        { 
                            medicalBook.Text = list[1];
                            mbIndexReturn();
                        }
                        if (list.Count > 2)
                        { 
                            driverLicense = list[2];
                            driverLicensesLoad();
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void driverLicensesLoad()
        {
            string[] split = driverLicense.Split(' ');

            foreach(var i in split)
            {
                if (i == "M") m.Checked = true;
                if (i == "A") a.Checked = true;
                if (i == "B") b.Checked = true;
                if (i == "C") c.Checked = true;
                if (i == "D") d.Checked = true;
                if (i == "E") e.Checked = true;
                if (i == "TM") tm.Checked = true;
                if (i == "TB") tb.Checked = true;
            }

        }

        private void design()
        {
            examples.BackColor = ColorTranslator.FromHtml("#757554");
            examples.ForeColor = ColorTranslator.FromHtml("#3a311d");

            languages.BackColor = ColorTranslator.FromHtml("#1e1607");
            languages.ForeColor = ColorTranslator.FromHtml("#62502f");

            medicalBook.BackColor = ColorTranslator.FromHtml("#4c3f26");
            medicalBook.ForeColor = ColorTranslator.FromHtml("#1e1607");

            back.Parent = background;
            next.Parent = background;
            startFromBegin.Parent = background;

            exScrollLeft.Parent = background;
            exScrollRight.Parent = background;

            mbScrollLeft.Parent = background;
            mbScrollRight.Parent = background;

            m.Parent = background;
            a.Parent = background;
            b.Parent = background;
            c.Parent = background;
            d.Parent = background;
            e.Parent = background;
            tm.Parent = background;
            tb.Parent = background;
        }

        private void changeExample()
        {
            if (exampleCount > 1)
                exampleCount = 0;

            if (exampleCount < 0)
                exampleCount = 1;

            examples.Text = s[exampleCount];

            if (exampleCount == 1)
            {
                languages.Text = "Українська, англійська";
                a.Checked = true;
                medicalBook.Text = mbArr[0];
            }
            else
                languages.Text = "";
        }
        private void exScrollLeft_Click(object sender, EventArgs e)
        {
            exampleCount--;
            changeExample();         
        }

        private void exScrollRight_Click(object sender, EventArgs e)
        {
            exampleCount++;
            changeExample();     
        }
        private void lastStepSaving(string ls)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter($"Моє резюме/Остання Форма.txt"))
                {
                    sw.Write(ls);
                }
            }
            catch (Exception) { }
        }
        private void back_Click(object sender, EventArgs e)
        {
            saveInfo();
            lastStepSaving("Step4");
            Application.Restart();
        }

        private void mbAvScroll()
        {
            if (mbCount > 1)
                mbCount = 0;

            if (mbCount < 0)
                mbCount = 1;

            medicalBook.Text = mbArr[mbCount];
        }

        private void mbIndexReturn()
        {
            for (int i = 0; i < mbArr.Length; i++)
                if (mbArr[i] == medicalBook.Text)
                    mbCount = Convert.ToInt32(i);
        }
        private void mbScrollLeft_Click(object sender, EventArgs e)
        {
            mbCount--;
            mbAvScroll();
        }

        private void mbScrollRight_Click(object sender, EventArgs e)
        {
            mbCount++;
            mbAvScroll();
        }
        private void saveInfo()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("Моє резюме/Інше/Інше.txt"))
                {
                    sw.WriteLine(languages.Text);
                    sw.WriteLine(medicalBook.Text);
                    sw.WriteLine(driverLicense);
                }
            }
            catch (Exception) { }
        }
        private void Step5_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveInfo();
        }

        private void changeDriverLicense()
        {
            driverLicense = "";

            if (m.Checked == true) driverLicense += "M ";
            if (a.Checked == true) driverLicense += "A ";
            if (b.Checked == true) driverLicense += "B ";
            if (c.Checked == true) driverLicense += "C ";
            if (d.Checked == true) driverLicense += "D ";
            if (e.Checked == true) driverLicense += "E ";
            if (tm.Checked == true) driverLicense += "TM ";
            if (tb.Checked == true) driverLicense += "TB ";
        }

        private void m_CheckedChanged(object sender, EventArgs e)
        {
            changeDriverLicense();
        }

        private void a_CheckedChanged(object sender, EventArgs e)
        {
            changeDriverLicense();
        }

        private void b_CheckedChanged(object sender, EventArgs e)
        {
            changeDriverLicense();
        }

        private void c_CheckedChanged(object sender, EventArgs e)
        {
            changeDriverLicense();
        }

        private void d_CheckedChanged(object sender, EventArgs e)
        {
            changeDriverLicense();
        }

        private void e_CheckedChanged(object sender, EventArgs e)
        {
            changeDriverLicense();
        }

        private void tm_CheckedChanged(object sender, EventArgs e)
        {
            changeDriverLicense();
        }

        private void tb_CheckedChanged(object sender, EventArgs e)
        {
            changeDriverLicense();
        }

        private void exScrollLeft_MouseMove(object sender, MouseEventArgs e)
        {
            exScrollLeft.Image = Properties.Resources.left2;
        }

        private void exScrollLeft_MouseLeave(object sender, EventArgs e)
        {
            exScrollLeft.Image = Properties.Resources.left;
        }

        private void exScrollRight_MouseMove(object sender, MouseEventArgs e)
        {
            exScrollRight.Image = Properties.Resources.right2;
        }

        private void exScrollRight_MouseLeave(object sender, EventArgs e)
        {
            exScrollRight.Image = Properties.Resources.right;
        }

        private void mbScrollLeft_MouseMove(object sender, MouseEventArgs e)
        {
            mbScrollLeft.Image = Properties.Resources.left2;
        }

        private void mbScrollLeft_MouseLeave(object sender, EventArgs e)
        {
            mbScrollLeft.Image = Properties.Resources.left;
        }

        private void mbScrollRight_MouseMove(object sender, MouseEventArgs e)
        {
            mbScrollRight.Image = Properties.Resources.right2;
        }

        private void mbScrollRight_MouseLeave(object sender, EventArgs e)
        {
            mbScrollRight.Image = Properties.Resources.right;
        }

        private void back_MouseMove(object sender, MouseEventArgs e)
        {
            back.Image = Properties.Resources.back2;
        }

        private void back_MouseLeave(object sender, EventArgs e)
        {
            back.Image = Properties.Resources.back;
        }

        private void next_MouseMove(object sender, MouseEventArgs e)
        {
            next.Image = Properties.Resources.next2;
        }

        private void next_MouseLeave(object sender, EventArgs e)
        {
            next.Image = Properties.Resources.next;
        }

        private void startFromBegin_MouseMove(object sender, MouseEventArgs e)
        {
            startFromBegin.Image = Properties.Resources.startFromBegin2;
        }

        private void startFromBegin_MouseLeave(object sender, EventArgs e)
        {
            startFromBegin.Image = Properties.Resources.startFromBegin;
        }

        private void startFromBegin_Click(object sender, EventArgs e)
        {
            Directory.Delete("Моє резюме", true);
            lastStepSaving("Step1");
            Application.Restart();
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (languages.Text == "" || languages.Text == " ")
            {
                MessageBox.Show("Будь ласка, заповніть усі поля.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                saveInfo();
                lastStepSaving("Ready");
                Application.Restart();
            }
        }

        private void Step5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
