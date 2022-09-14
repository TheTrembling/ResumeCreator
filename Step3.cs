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
    public partial class Step3 : Form
    {
        int educNumber = 1, exampleCount = 0, foeCount = 0;
        string[] foeArr = { "Очна", "Заочна", "Очно-заочна(вечірня)", "Дистанційна" };
        int fullFields;
        public Step3()
        {
            InitializeComponent();
            design();
            step3Loading();
        }
        private void step3Loading()
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo($"Моє резюме/Освіта");

                if (!di.Exists)
                    di.Create();

                FileInfo fi = new FileInfo($"Моє резюме/Освіта/Освіта {educNumber}.txt");

                if (fi.Exists)
                {
                    using (StreamReader sr = new StreamReader($"Моє резюме/Освіта/Освіта {educNumber}.txt"))
                    {
                        string line;
                        var list = new List<string>();

                        while ((line = sr.ReadLine()) != null)
                            list.Add(line);

                        if (list.Count > 0) educInst.Text = list[0];
                        if (list.Count > 1) faculty.Text = list[1];
                        if (list.Count > 2)
                        {
                            formOfEduc.Text = list[2];
                            foeIndexReturn();
                        }
                        if (list.Count > 3) speciality.Text = list[3];
                        if (list.Count > 4) graduation.Text = list[4];
                    }
                }
            }
            catch (Exception) { }
        }

        private void design()
        {
            examples.BackColor = ColorTranslator.FromHtml("#757554");
            educInst.BackColor = ColorTranslator.FromHtml("#757554");
            educNum.BackColor = ColorTranslator.FromHtml("#757554");

            educInst.ForeColor = ColorTranslator.FromHtml("#3a311d");
            educNum.ForeColor = ColorTranslator.FromHtml("#3a311d");
            examples.ForeColor = ColorTranslator.FromHtml("#3a311d");

            faculty.BackColor = ColorTranslator.FromHtml("#4c3f26");
            graduation.BackColor = ColorTranslator.FromHtml("#4c3f26");

            faculty.ForeColor = ColorTranslator.FromHtml("#1e1607");
            graduation.ForeColor = ColorTranslator.FromHtml("#1e1607");

            speciality.BackColor = ColorTranslator.FromHtml("#1e1607");
            formOfEduc.BackColor = ColorTranslator.FromHtml("#1e1607");

            speciality.ForeColor = ColorTranslator.FromHtml("#62502f");
            formOfEduc.ForeColor = ColorTranslator.FromHtml("#62502f");

            exScrollLeft.Parent = background;
            exScrollRight.Parent = background;
            foeScrollLeft.Parent = background;
            foeScrollRight.Parent = background;
            edNumScrollLeft.Parent = background;
            edNumScrollRight.Parent = background;

            back.Parent = background;
            next.Parent = background;
            startFromBegin.Parent = background;
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
            emptinessChecking();
            educLoading();
            lastStepSaving("Step2");
            Application.Restart();
        }

        private void saveInfo()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter($"Моє резюме/Освіта/Освіта {educNumber}.txt"))
                {
                    sw.WriteLine(educInst.Text);
                    sw.WriteLine(faculty.Text);
                    sw.WriteLine(formOfEduc.Text);
                    sw.WriteLine(speciality.Text);
                    sw.WriteLine(graduation.Text);
                }
            }
            catch (Exception) { }
        }

        private void Step3_FormClosing(object sender, FormClosingEventArgs e)
        {
            emptinessChecking();
            educLoading();
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

        private void foeScrollLeft_MouseMove(object sender, MouseEventArgs e)
        {
            foeScrollLeft.Image = Properties.Resources.left2;
        }

        private void foeScrollLeft_MouseLeave(object sender, EventArgs e)
        {
            foeScrollLeft.Image = Properties.Resources.left;
        }

        private void foeScrollRight_MouseMove(object sender, MouseEventArgs e)
        {
            foeScrollRight.Image = Properties.Resources.right2;
        }

        private void foeScrollRight_MouseLeave(object sender, EventArgs e)
        {
            foeScrollRight.Image = Properties.Resources.right;
        }

        private void edNumScrollLeft_MouseMove(object sender, MouseEventArgs e)
        {
            edNumScrollLeft.Image = Properties.Resources.left2;
        }

        private void edNumScrollLeft_MouseLeave(object sender, EventArgs e)
        {
            edNumScrollLeft.Image = Properties.Resources.left;
        }

        private void edNumScrollRight_MouseMove(object sender, MouseEventArgs e)
        {
            edNumScrollRight.Image = Properties.Resources.right2;
        }

        private void edNumScrollRight_MouseLeave(object sender, EventArgs e)
        {
            edNumScrollRight.Image = Properties.Resources.right;
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

        private void emptinessChecking()
        {
            fullFields = 0;

            if (educInst.Text != "" && educInst.Text != " ") fullFields++;
            if (faculty.Text != "" && faculty.Text != " ") fullFields++;
            if (speciality.Text != "" && speciality.Text != " ") fullFields++;
            if (graduation.Text != "" && graduation.Text != " ") fullFields++;
        }

        private void educLoading()
        {
            if (fullFields == 4 && educNumber > 1)
                saveInfo();

            if (educNumber == 1)
                saveInfo();

            if (fullFields < 4 && educNumber > 1)
                File.Delete($"Моє резюме/Освіта/Освіта {educNumber}.txt");
        }

        private void edNumScrollLeft_Click(object sender, EventArgs e)
        {
            emptinessChecking();

            if (fullFields < 4 && fullFields > 0 && educNumber != 1)
            {
                MessageBox.Show("Будь ласка, заповніть усі поля або звільніть.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (fullFields == 4 || fullFields == 0)
            {
                educLoading();

                if (educNumber > 1)
                    educNumber--;

                educNum.Text = $"{educNumber}";

                clearAll();
                step3Loading();
            }
        }

        private void edNumScrollRight_Click(object sender, EventArgs e)
        {
            emptinessChecking();

            if (fullFields < 4)
            {
                MessageBox.Show("Будь ласка, заповніть усі поля.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                educLoading();

                educNumber++;
                educNum.Text = $"{educNumber}";

                clearAll();
                step3Loading();
            }
        }
        private void clearAll()
        {
            educInst.Text = "";
            faculty.Text = "";
            speciality.Text = "";
            graduation.Text = "";
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
                    using (StreamReader sr = new StreamReader($"Шаблони/{examples.Text}/Освіта/Освіта.txt"))
                    {
                        string line;
                        var list = new List<string>();

                        while ((line = sr.ReadLine()) != null)
                            list.Add(line);

                        if (list.Count != 0)
                        {
                            educInst.Text = list[0];
                            faculty.Text = list[1];
                            speciality.Text = list[2];
                            graduation.Text = list[3];
                        }
                    }
                }
                catch (Exception) { }
            }
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
        private void exScrollRight_Click(object sender, EventArgs e)
        {
            exampleCount++;
            changeExample();
        }

        private void exScrollLeft_Click(object sender, EventArgs e)
        {
            exampleCount--;
            changeExample();
        }
        private void changeFoe()
        {
            if (foeCount > 3)
                foeCount = 0;
            
            if (foeCount < 0)
                foeCount = 3;

            formOfEduc.Text = foeArr[foeCount];
        }

        private void foeIndexReturn()
        {
            for (int i = 0; i < foeArr.Length; i++)
                if (foeArr[i] == formOfEduc.Text)
                    foeCount = Convert.ToInt32(i);
        }

        private void Step3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void startFromBegin_Click(object sender, EventArgs e)
        {
            Directory.Delete("Моє резюме", true);
            lastStepSaving("Step1");
            Application.Restart();
        }

        private void next_Click(object sender, EventArgs e)
        {
            emptinessChecking();

            if (fullFields < 4 && fullFields > 0)
            {
                MessageBox.Show("Будь ласка, заповніть або звільніть усі поля.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                educLoading();
                lastStepSaving("Step4");
                Application.Restart();
            }
        }

        private void foeScrollLeft_Click(object sender, EventArgs e)
        {
            foeCount--;
            changeFoe();
        }

        private void foeScrollRight_Click(object sender, EventArgs e)
        {
            foeCount++;
            changeFoe();
        }     
    }
}
