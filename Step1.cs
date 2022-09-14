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
    public partial class Step1 : Form
    {
        int emplCount = 0, exampleCount = 0, schedCount = 0;
        bool readiness;

        string[] emplArr = { "Повна", "Часткова", "Проектна", "Стажування", "Волонтерство" };
        string[] shedArr = { "Повний день", "Змінний графік", "Гнучкий графік", "Дистанційна робота", "Вахтовий метод" };
        public Step1()
        {
            InitializeComponent();
            design();
            lastFormLoading();

        }
        private void changeSchedule()
        {
            if (schedCount > 4)
                schedCount = 0;

            if (schedCount < 0)
                schedCount = 4;

            schedules.Text = shedArr[schedCount];
        }

        private void scheduleIndexReturn()
        {
            for (int i = 0; i < shedArr.Length; i++)
                if (shedArr[i] == schedules.Text)
                    schedCount = Convert.ToInt32(i);
        }

        private void changeEmployment()
        {
            if (emplCount > 4)
                emplCount = 0;

            if (emplCount < 0)
                emplCount = 4;

            employment.Text = emplArr[emplCount];
        }
        private void employmentIndexReturn()
        {
            for (int i = 0; i < emplArr.Length; i++)
                if (emplArr[i] == employment.Text)
                    emplCount = Convert.ToInt32(i);
        }

        private void design()
        {
            surname.BackColor = ColorTranslator.FromHtml("#1e1607");
            name.BackColor = ColorTranslator.FromHtml("#4c3f26");
            patronymic.BackColor = ColorTranslator.FromHtml("#1e1607");
            position.BackColor = ColorTranslator.FromHtml("#4c3f26");

            salary.BackColor = ColorTranslator.FromHtml("#4c3f26");
            email.BackColor = ColorTranslator.FromHtml("#1e1607");
            phone.BackColor = ColorTranslator.FromHtml("#4c3f26");
            employment.BackColor = ColorTranslator.FromHtml("#1e1607");

            surname.ForeColor = ColorTranslator.FromHtml("#62502f");
            name.ForeColor = ColorTranslator.FromHtml("#1e1607");
            patronymic.ForeColor = ColorTranslator.FromHtml("#62502f");
            position.ForeColor = ColorTranslator.FromHtml("#1e1607");

            salary.ForeColor = ColorTranslator.FromHtml("#1e1607");
            email.ForeColor = ColorTranslator.FromHtml("#62502f");
            phone.ForeColor = ColorTranslator.FromHtml("#1e1607");
            employment.ForeColor = ColorTranslator.FromHtml("#62502f");


            schedules.BackColor = ColorTranslator.FromHtml("#757554");
            examples.BackColor = ColorTranslator.FromHtml("#757554");

            schedules.ForeColor = ColorTranslator.FromHtml("#3a311d");
            examples.ForeColor = ColorTranslator.FromHtml("#3a311d");

            next.Parent = background;
            emplScrollRight.Parent = background;
            emplScrollLeft.Parent = background;
            schedScrollLeft.Parent = background;
            schedScrollRight.Parent = background;
            exScrollLeft.Parent = background;
            exScrollRight.Parent = background;

        }

        private void next_MouseMove(object sender, MouseEventArgs e)
        {
            next.Image = Properties.Resources.next2;
        }

        private void next_MouseLeave(object sender, EventArgs e)
        {
            next.Image = Properties.Resources.next;
        }

        private void emplScrollLeft_MouseMove(object sender, MouseEventArgs e)
        {
            emplScrollLeft.Image = Properties.Resources.left2;
        }

        private void emplScrollLeft_MouseLeave(object sender, EventArgs e)
        {
            emplScrollLeft.Image = Properties.Resources.left;
        }

        private void emplScrollRight_MouseMove(object sender, MouseEventArgs e)
        {
            emplScrollRight.Image = Properties.Resources.right2;
        }

        private void emplScrollRight_MouseLeave(object sender, EventArgs e)
        {
            emplScrollRight.Image = Properties.Resources.right;
        }

        private void emplScrollLeft_Click(object sender, EventArgs e)
        {
            emplCount--;
            changeEmployment();
        }

        private void emplScrollRight_Click(object sender, EventArgs e)
        {
            emplCount++;
            changeEmployment();
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

        private void schedScrollLeft_MouseMove(object sender, MouseEventArgs e)
        {
            schedScrollLeft.Image = Properties.Resources.left2;
        }

        private void schedScrollLeft_MouseLeave(object sender, EventArgs e)
        {
            schedScrollLeft.Image = Properties.Resources.left;
        }

        private void schedScrollRight_MouseMove(object sender, MouseEventArgs e)
        {
            schedScrollRight.Image = Properties.Resources.right2;
        }

        private void schedScrollRight_MouseLeave(object sender, EventArgs e)
        {
            schedScrollRight.Image = Properties.Resources.right;
        }

        private void schedScrollLeft_Click(object sender, EventArgs e)
        {
            schedCount--;
            changeSchedule();
        }

        private void schedScrollRight_Click(object sender, EventArgs e)
        {
            schedCount++;
            changeSchedule();
        }

        private void changeExample()
        {
            if (exampleCount > 5)
                exampleCount = 0;

            if (exampleCount < 0)
                exampleCount = 5;

            string[] s = { "-Без зразка-", "Програміст", "Системний адміністратор", "Психолог", "Інженер", "Охоронець" };

            examples.Text = s[exampleCount];

            loadExample();
        }

        private void loadExample()
        {
            if (exampleCount == 0)
            {
                surname.Text = "";
                name.Text = "";
                patronymic.Text = "";
                position.Text = "";
                salary.Text = "";
                email.Text = "";
                phone.Text = "";
            }
            else
            {
                try
                {
                    using (StreamReader sr = new StreamReader($"Шаблони/{examples.Text}/Основна інформація/Основна інформація.txt"))
                    {
                        string line;
                        var list = new List<string>();

                        while ((line = sr.ReadLine()) != null)
                            list.Add(line);

                        if (list.Count != 0)
                        {
                            surname.Text = list[0];
                            name.Text = list[1];
                            patronymic.Text = list[2];
                            position.Text = list[3];
                            salary.Text = list[4];
                            email.Text = list[5];
                            phone.Text = list[6];
                        }
                    }
                } 
                catch(Exception) { }
            }
        }

        private void Step1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            Application.Exit();
        }

        private void saveInfo()
        {
            try
            {
                    using (StreamWriter sw = new StreamWriter("Моє резюме/Основна інформація/Основна інформація.txt"))
                    {
                        sw.WriteLine(surname.Text);
                        sw.WriteLine(name.Text);
                        sw.WriteLine(patronymic.Text);
                        sw.WriteLine(position.Text);
                        sw.WriteLine(salary.Text);
                        sw.WriteLine(email.Text);
                        sw.WriteLine(phone.Text);
                        sw.WriteLine(employment.Text);
                        sw.WriteLine(schedules.Text);
                    }
            }
            catch (Exception) { }
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

        private void Step1_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveInfo();
        }

        private void step1Loading()
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo($"Моє резюме/Основна інформація");

                if (!di.Exists) di.Create();

                FileInfo fi = new FileInfo($"Моє резюме/Основна інформація/Основна інформація.txt");

                if (fi.Exists)
                {
                    using (StreamReader sr = new StreamReader($"Моє резюме/Основна інформація/Основна інформація.txt"))
                    {
                        string line;
                        var list = new List<string>();

                        while ((line = sr.ReadLine()) != null)
                            list.Add(line);

                        if (list.Count > 0) surname.Text = list[0];
                        if (list.Count > 1) name.Text = list[1];
                        if (list.Count > 2) patronymic.Text = list[2];
                        if (list.Count > 3) position.Text = list[3];
                        if (list.Count > 4) salary.Text = list[4];
                        if (list.Count > 5) email.Text = list[5];
                        if (list.Count > 6) phone.Text = list[6];

                        if (list.Count > 7)
                        {
                            employment.Text = list[7];
                            employmentIndexReturn();
                        }

                        if (list.Count > 8)
                        {
                            schedules.Text = list[8];
                            scheduleIndexReturn();
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void step2Loading()
        {
            Step2 s2 = new Step2();
            this.Hide();
            s2.ShowDialog();
        }
        private void step3Loading()
        {
            Step3 s3 = new Step3();
            this.Hide();
            s3.ShowDialog();
        }
        private void step4Loading()
        {
            Step4 s4 = new Step4();
            this.Hide();
            s4.ShowDialog();
        }
        private void step5Loading()
        {
            Step5 s5 = new Step5();
            this.Hide();
            s5.ShowDialog();
        }
        private void step6Loading()
        {
            Ready ready = new Ready();
            this.Hide();
            ready.ShowDialog();
        }
        private void lastFormLoading()
        {
            try
            {
                FileInfo fi = new FileInfo("Моє резюме/Остання Форма.txt");
                if (fi.Exists)
                {
                    string lastForm = "";

                    using (StreamReader sr = new StreamReader("Моє резюме/Остання Форма.txt"))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                            lastForm = line;
                    }

                    if (lastForm == "Step1") step1Loading();
                    if (lastForm == "Step2") step2Loading();
                    if (lastForm == "Step3") step3Loading();
                    if (lastForm == "Step4") step4Loading();
                    if (lastForm == "Step5") step5Loading();
                    if (lastForm == "Ready") step6Loading();
                }
                else 
                    step1Loading();
            }
            catch (Exception) { }
        }

        private void readinessCheck()
        {
            readiness = true;

            if (surname.Text == "" || surname.Text == " ") readiness = false;
            if (name.Text == "" || name.Text == " ") readiness = false;
            if (surname.Text == "" || surname.Text == " ") readiness = false;
            if (patronymic.Text == "" || patronymic.Text == " ") readiness = false;
            if (position.Text == "" || position.Text == " ") readiness = false;
            if (salary.Text == "" || salary.Text == " ") readiness = false;
            if (email.Text == "" || email.Text == " ") readiness = false;
            if (phone.Text == "" || phone.Text == " ") readiness = false;
        }

        private void next_Click(object sender, EventArgs e)
        {
            readinessCheck();

            if (readiness == false)
            {
                MessageBox.Show("Усі поля повинні бути заповнені.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                saveInfo();
                lastStepSaving("Step2");
                Application.Restart();
            }
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
    }
}
