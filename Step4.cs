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
    public partial class Step4 : Form
    {
        int exampleCount = 0, jobNumber = 1;
        int fullFields;
        public Step4()
        {
            InitializeComponent();
            design();
            step4Loading();
        }
        private void step4Loading()
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo($"Моє резюме/Досвід роботи");

                if (!di.Exists)
                    di.Create();

                FileInfo fi = new FileInfo($"Моє резюме/Досвід роботи/Робота {jobNumber}.txt");

                if (fi.Exists)
                {
                    using (StreamReader sr = new StreamReader($"Моє резюме/Досвід роботи/Робота {jobNumber}.txt"))
                    {
                        string line;
                        var list = new List<string>();

                        while ((line = sr.ReadLine()) != null)
                            list.Add(line);

                        if (list.Count > 0) organization.Text = list[0];
                        if (list.Count > 1) from.Text = list[1];
                        if (list.Count > 2) position.Text = list[2];
                        if (list.Count > 3) to.Text = list[3];
                        if (list.Count > 4) respAndAch.Text = list[4];
                    }
                }
            }
            catch (Exception) { }
        }
        private void design()
        {
            examples.BackColor = ColorTranslator.FromHtml("#757554");
            respAndAch.BackColor = ColorTranslator.FromHtml("#757554");
            jobNum.BackColor = ColorTranslator.FromHtml("#757554");

            examples.ForeColor = ColorTranslator.FromHtml("#3a311d");
            respAndAch.ForeColor = ColorTranslator.FromHtml("#3a311d");
            jobNum.ForeColor = ColorTranslator.FromHtml("#3a311d");


            organization.BackColor = ColorTranslator.FromHtml("#4c3f26");
            to.BackColor = ColorTranslator.FromHtml("#4c3f26");

            organization.ForeColor = ColorTranslator.FromHtml("#1e1607");
            to.ForeColor = ColorTranslator.FromHtml("#1e1607");

            position.BackColor = ColorTranslator.FromHtml("#1e1607");
            from.BackColor = ColorTranslator.FromHtml("#1e1607");

            position.ForeColor = ColorTranslator.FromHtml("#62502f");
            from.ForeColor = ColorTranslator.FromHtml("#62502f");

            back.Parent = background;
            next.Parent = background;
            startFromBegin.Parent = background;

            exScrollLeft.Parent = background;
            exScrollRight.Parent = background;

            jobScrollLeft.Parent = background;
            jobScrollRight.Parent = background;
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
            lastStepSaving("Step3");
            Application.Restart();
        }

        private void Step4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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

        private void jobScrollLeft_MouseMove(object sender, MouseEventArgs e)
        {
            jobScrollLeft.Image = Properties.Resources.left2;
        }

        private void jobScrollLeft_MouseLeave(object sender, EventArgs e)
        {
            jobScrollLeft.Image = Properties.Resources.left;
        }

        private void jobScrollRight_MouseMove(object sender, MouseEventArgs e)
        {
            jobScrollRight.Image = Properties.Resources.right2;
        }

        private void jobScrollRight_MouseLeave(object sender, EventArgs e)
        {
            jobScrollRight.Image = Properties.Resources.right;
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
                clearAll();
            }
            else
            {
                try
                {
                    using (StreamReader sr = new StreamReader($"Шаблони/{examples.Text}/Досвід роботи/Досвід роботи.txt"))
                    {
                        string line;
                        var list = new List<string>();

                        while ((line = sr.ReadLine()) != null)
                            list.Add(line);

                        if (list.Count != 0)
                        {
                            organization.Text = list[0];
                            from.Text = list[1];
                            position.Text = list[2];
                            to.Text = list[3];
                            respAndAch.Text = list[4];
                        }
                    }
                }
                catch (Exception) { }
            }
        }
        private void clearAll()
        {
            organization.Text = "";
            from.Text = "";
            position.Text = "";
            to.Text = "";
            respAndAch.Text = "";
        }
        private void emptinessChecking()
        {
            fullFields = 0;

            if (organization.Text != "" && organization.Text != " ") fullFields++;
            if (from.Text != "" && from.Text != " ") fullFields++;
            if (position.Text != "" && position.Text != " ") fullFields++;
            if (to.Text != "" && to.Text != " ") fullFields++;
            if (respAndAch.Text != "" && respAndAch.Text != " ") fullFields++;
        }
        private void jobLoading()
        {
            if (fullFields == 5 && jobNumber > 1)
                saveInfo();

            if (jobNumber == 1)
                saveInfo();

            if (fullFields < 5 && jobNumber > 1)
                File.Delete($"Моє резюме/Досвід роботи/Робота {jobNumber}.txt");
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

        private void startFromBegin_Click(object sender, EventArgs e)
        {
            Directory.Delete("Моє резюме", true);
            lastStepSaving("Step1");
            Application.Restart();
        }

        private void saveInfo()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter($"Моє резюме/Досвід роботи/Робота {jobNumber}.txt"))
                {
                    sw.WriteLine(organization.Text);
                    sw.WriteLine(from.Text);
                    sw.WriteLine(position.Text);
                    sw.WriteLine(to.Text);
                    sw.WriteLine(respAndAch.Text);
                }
            }
            catch (Exception) { }
        }

        private void jobScrollLeft_Click(object sender, EventArgs e)
        {
            emptinessChecking();

            if (fullFields < 5 && fullFields > 0 && jobNumber != 1)
            {
                MessageBox.Show("Будь ласка, заповніть усі поля або звільніть.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (fullFields == 5 || fullFields == 0)
            {
                jobLoading();

                if (jobNumber > 1)
                    jobNumber--;

                jobNum.Text = $"{jobNumber}";

                clearAll();
                step4Loading();
            }
        }

        private void jobScrollRight_Click(object sender, EventArgs e)
        {
            emptinessChecking();

            if (fullFields < 5)
            {
                MessageBox.Show("Будь ласка, заповніть усі поля.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                jobLoading();

                jobNumber++;
                jobNum.Text = $"{jobNumber}";

                clearAll();
                step4Loading();
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            emptinessChecking();

            if (fullFields < 5 && fullFields > 0)
            {
                MessageBox.Show("Будь ласка, заповніть або звільніть усі поля.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                jobLoading();
                lastStepSaving("Step5");
                Application.Restart();
            }
        }

        private void Step4_FormClosing(object sender, FormClosingEventArgs e)
        {
            emptinessChecking();
            jobLoading();
        }
    }
}