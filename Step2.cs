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
    public partial class Step2 : Form
    {
        int movingCount = 0, sexCount = 0, mrgCount = 0, exCount = 0, chCount = 0;

        string[] movingArr = { "Можливий", "Неможливий", "Бажаний", "Небажаний" };
        string[] mrgArr = { "Одружений", "Неодружений", "Заміжня", "Незаміжня" };
        string[] chStatusArr = { "Немає", "Є" };
        string[] sexArr = { "Чоловіча", "Жіноча" };

        bool isEmpty;

        public Step2()
        {
            InitializeComponent();
            design();
            step2Loading();
        }
        private void changeMoving()
        {
            if (movingCount > 3)
                movingCount = 0;

            if (movingCount < 0)
                movingCount = 3;

            moving.Text = movingArr[movingCount];
        }

        private void movingIndexReturn()
        {
            for (int i = 0; i < movingArr.Length; i++)
                if (movingArr[i] == moving.Text)
                    movingCount = Convert.ToInt32(i);
        }

        private void changeMrg()
        {
            if (mrgCount > 3)
                mrgCount = 0;

            if (mrgCount < 0)
                mrgCount = 3;

            marriage.Text = mrgArr[mrgCount];
        }

        private void mrgIndexReturn()
        {
            for (int i = 0; i < mrgArr.Length; i++)
                if (mrgArr[i] == marriage.Text)
                    movingCount = Convert.ToInt32(i);
        }

        private void changeChildrenStatus()
        {
            if (chCount > 1)
                chCount = 0;

            if (chCount < 0)
                chCount = 1;

            children.Text = chStatusArr[chCount];
        }

        private void chIndexReturn()
        {
            for (int i = 0; i < chStatusArr.Length; i++)
                if (chStatusArr[i] == children.Text)
                    chCount = Convert.ToInt32(i);
        }

        private void changeSex()
        {
            if (sexCount > 1)
                sexCount = 0;

            if (sexCount < 0)
                sexCount = 1;

            sex.Text = sexArr[sexCount];
        }

        private void sexIndexReturn()
        {
            for (int i = 0; i < sexArr.Length; i++)
                if (sexArr[i] == sex.Text)
                    sexCount = Convert.ToInt32(i);
        }
        private void design()
        {
            por.BackColor = ColorTranslator.FromHtml("#1e1607");
            citizenship.BackColor = ColorTranslator.FromHtml("#4c3f26");
            dateOfBirth.BackColor = ColorTranslator.FromHtml("#1e1607");

            moving.BackColor = ColorTranslator.FromHtml("#4c3f26");
            sex.BackColor = ColorTranslator.FromHtml("#1e1607");
            marriage.BackColor = ColorTranslator.FromHtml("#4c3f26");

            por.ForeColor = ColorTranslator.FromHtml("#62502f");
            citizenship.ForeColor = ColorTranslator.FromHtml("#1e1607");
            dateOfBirth.ForeColor = ColorTranslator.FromHtml("#62502f");

            moving.ForeColor = ColorTranslator.FromHtml("#1e1607");
            sex.ForeColor = ColorTranslator.FromHtml("#62502f");
            marriage.ForeColor = ColorTranslator.FromHtml("#1e1607");


            children.BackColor = ColorTranslator.FromHtml("#757554");
            examples.BackColor = ColorTranslator.FromHtml("#757554");

            children.ForeColor = ColorTranslator.FromHtml("#3a311d");
            examples.ForeColor = ColorTranslator.FromHtml("#3a311d");

            next.Parent = background;
            back.Parent = background;
            exScrollLeft.Parent = background;
            exScrollRight.Parent = background;
            chScrollLeft.Parent = background;
            chScrollRight.Parent = background;

            movingScrollRight.Parent = background;
            movingScrollLeft.Parent = background;
            sexScrollLeft.Parent = background;
            sexScrollRight.Parent = background;
            mrgScrollLeft.Parent = background;
            mrgScrollRight.Parent = background;
            startFromBegin.Parent = background;
        }

        private void Step2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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

        private void chScrollLeft_MouseMove(object sender, MouseEventArgs e)
        {
            chScrollLeft.Image = Properties.Resources.left2;
        }

        private void chScrollLeft_MouseLeave(object sender, EventArgs e)
        {
            chScrollLeft.Image = Properties.Resources.left;
        }

        private void chScrollRight_MouseMove(object sender, MouseEventArgs e)
        {
            chScrollRight.Image = Properties.Resources.right2;
        }

        private void chScrollRight_MouseLeave(object sender, EventArgs e)
        {
            chScrollRight.Image = Properties.Resources.right;
        }

        private void csScrollLeft_MouseMove(object sender, MouseEventArgs e)
        {
            movingScrollLeft.Image = Properties.Resources.left2;
        }

        private void csScrollLeft_MouseLeave(object sender, EventArgs e)
        {
            movingScrollLeft.Image = Properties.Resources.left;
        }

        private void csScrollRight_MouseMove(object sender, MouseEventArgs e)
        {
            movingScrollRight.Image = Properties.Resources.right2;
        }

        private void csScrollRight_MouseLeave(object sender, EventArgs e)
        {
            movingScrollRight.Image = Properties.Resources.right;
        }

        private void sexScrollLeft_MouseMove(object sender, MouseEventArgs e)
        {
            sexScrollLeft.Image = Properties.Resources.left2;
        }

        private void sexScrollLeft_MouseLeave(object sender, EventArgs e)
        {
            sexScrollLeft.Image = Properties.Resources.left;
        }

        private void sexScrollRight_MouseMove(object sender, MouseEventArgs e)
        {
            sexScrollRight.Image = Properties.Resources.right2;
        }

        private void sexScrollRight_MouseLeave(object sender, EventArgs e)
        {
            sexScrollRight.Image = Properties.Resources.right;
        }

        private void mrgScrollLeft_MouseMove(object sender, MouseEventArgs e)
        {
            mrgScrollLeft.Image = Properties.Resources.left2;
        }

        private void mrgScrollLeft_MouseLeave(object sender, EventArgs e)
        {
            mrgScrollLeft.Image = Properties.Resources.left;
        }

        private void msgScrollRight_MouseMove(object sender, MouseEventArgs e)
        {
            mrgScrollRight.Image = Properties.Resources.right2;
        }

        private void msgScrollRight_MouseLeave(object sender, EventArgs e)
        {
            mrgScrollRight.Image = Properties.Resources.right;
        }

        private void csScrollLeft_Click(object sender, EventArgs e)
        {
            movingCount--;
            changeMoving();
        }

        private void csScrollRight_Click(object sender, EventArgs e)
        {
            movingCount++;
            changeMoving();
        }

        private void sexScrollLeft_Click(object sender, EventArgs e)
        {
            sexCount--;
            changeSex();
        }
        private void sexScrollRight_Click(object sender, EventArgs e)
        {
            sexCount++;
            changeSex();
        }

        private void changeExample()
        {
            if (exCount > 1)
                exCount = 0;

            if (exCount < 0)
                exCount = 1;

            string[] s = { "-Без зразка-", "Зразок" };

            examples.Text = s[exCount];

            if(exCount == 0)
            {
                por.Text = "";
                citizenship.Text = "";
                dateOfBirth.Text = "";
            }
            else
            {
                por.Text = "м. Чернігов, вул. Шевченка, 9, кв. 45";
                citizenship.Text = "Україна";
                dateOfBirth.Text = "28.09.1991";
            }
        }

        private void exScrollLeft_Click(object sender, EventArgs e)
        {
            exCount--;
            changeExample();
        }

        private void exScrollRight_Click(object sender, EventArgs e)
        {
            exCount++;
            changeExample();
        }

        private void back_Click(object sender, EventArgs e)
        { 
            saveInfo();
            lastStepSaving("Step1");
            Application.Restart();
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

        private void chScrollLeft_Click(object sender, EventArgs e)
        {
            chCount--;
            changeChildrenStatus();
        }

        private void chScrollRight_Click(object sender, EventArgs e)
        {
            chCount++;
            changeChildrenStatus();
        }

        private void step2Loading()
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo($"Моє резюме/Особиста інформація");

                if (!di.Exists) 
                    di.Create();

                FileInfo fi = new FileInfo("Моє резюме/Особиста інформація/Особиста інформація.txt");

                if (fi.Exists)
                {
                    using (StreamReader sr = new StreamReader($"Моє резюме/Особиста інформація/Особиста інформація.txt"))
                    {
                        string line;
                        var list = new List<string>();

                        while ((line = sr.ReadLine()) != null)
                            list.Add(line);

                        if (list.Count > 0) por.Text = list[0];
                        if (list.Count > 1) citizenship.Text = list[1];
                        if (list.Count > 2) dateOfBirth.Text = list[2];
                        if (list.Count > 3) 
                        { 
                            moving.Text = list[3];
                            movingIndexReturn();
                        }
                        if (list.Count > 4)
                        {
                            sex.Text = list[4];
                            sexIndexReturn();
                        }
                        if (list.Count > 5)
                        {
                            marriage.Text = list[5];
                            mrgIndexReturn();
                        }
                        if (list.Count > 6)
                        { 
                            children.Text = list[6];
                            chIndexReturn();
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void saveInfo()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter($"Моє резюме/Особиста інформація/Особиста інформація.txt"))
                {
                    sw.WriteLine(por.Text);
                    sw.WriteLine(citizenship.Text);
                    sw.WriteLine(dateOfBirth.Text);
                    sw.WriteLine(moving.Text);
                    sw.WriteLine(sex.Text);
                    sw.WriteLine(marriage.Text);
                    sw.WriteLine(children.Text);
                }
            }
            catch (Exception) { }
        }
        
        private void Step2_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveInfo();
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
        private void emptinessCheck()
        {
            isEmpty = true;

            if (por.Text != "" && por.Text != " ") isEmpty = false;
            if (citizenship.Text != "" && citizenship.Text != " ") isEmpty = false;
            if (dateOfBirth.Text != "" && dateOfBirth.Text != " ") isEmpty = false;
        }

        private void next_Click(object sender, EventArgs e)
        {
            emptinessCheck();

            if (isEmpty == true)
            {
                MessageBox.Show("Усі поля повинні бути заповнені.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                saveInfo();
                lastStepSaving("Step3");
                Application.Restart();
            }
        }

        private void next_MouseLeave(object sender, EventArgs e)
        {
            next.Image = Properties.Resources.next;
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
        private void mrgScrollLeft_Click(object sender, EventArgs e)
        {
            mrgCount--;
            changeMrg();
        }

        private void mrgScrollRight_Click(object sender, EventArgs e)
        {
            mrgCount++;
            changeMrg();
        }  
    }
}
