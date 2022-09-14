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
    public partial class Ready : Form
    {
        Bitmap bmp;
        Graphics g;
        int photoWidth = 286, photoHeight = 350, photoX = 0, photoY = 0;
        
        string photosPath = "";

        string surname, name, patronymic;
        string position, salary, email, phone, employment, schedule;

        string address, citizenship, dateOfBirth, moving, sex, marriage, children;

        string languages, medicalBook, driverLicense;

        string education = "", workExpirience = "";

        StringFormat sf = new StringFormat();

        private void loadPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    photosPath = openFileDialog.FileName;
                }
            }
            pnt();
            resume.Invalidate();
        }
        private void refreshResume()
        {
            if (resume.Image != null)
            {
                resume.Image.Dispose();
                resume.Image = null;
                bmp = new Bitmap(resume.Width, resume.Height);
                resume.Image = bmp;
                pnt();
            }
            resume.Invalidate();
        }
        private void w_ValueChanged(object sender, EventArgs e)
        {
            photoWidth = Convert.ToInt32(w.Value);
            refreshResume();
        }

        private void h_ValueChanged(object sender, EventArgs e)
        {
            photoHeight = Convert.ToInt32(h.Value);
            refreshResume();
        }

        private void x_ValueChanged(object sender, EventArgs e)
        {
            photoX = Convert.ToInt32(x.Value);
            refreshResume();
        }

        private void y_ValueChanged(object sender, EventArgs e)
        {
            photoY = Convert.ToInt32(y.Value);
            refreshResume();
        }

        public Ready()
        {
            InitializeComponent();
            design();

            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            bmp = new Bitmap(resume.Width, resume.Height);

            resume.Image = bmp;

            loadMainInfo();
            loadPersonalInfo();
            loadOtherInfo();
            loadEducationInfo();
            loadWorkExpInfo();
            pnt();
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (resume.Image != null) 
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        bmp.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void loadWorkExpInfo()
        {
            DirectoryInfo di = new DirectoryInfo("Моє резюме/Досвід роботи");

            for (int i = 0; i < di.GetFiles().Count(); i++)
            {
                using (StreamReader sr = new StreamReader($"Моє резюме/Досвід роботи/Робота {i + 1}.txt"))
                {
                    string line;
                    var list = new List<string>();

                    while ((line = sr.ReadLine()) != null)
                        list.Add(line);

                    workExpirience += $"{list[1]} - {list[3]}:   {list[0]}. {list[2]}. {list[4]}\n\n";
                }
            }
        }

        private void loadEducationInfo()
        {
            DirectoryInfo di = new DirectoryInfo("Моє резюме/Освіта");

            for (int i = 0; i < di.GetFiles().Count(); i++)
            {
                using (StreamReader sr = new StreamReader($"Моє резюме/Освіта/Освіта {i+1}.txt"))
                {
                    string line;
                    var list = new List<string>();

                    while ((line = sr.ReadLine()) != null)
                        list.Add(line);

                    education += $"{list[0]}, {list[1]}, {list[2]}, {list[3]}, {list[4]}\n\n";
                }
            }
        }
        private void loadOtherInfo()
        {
            using (StreamReader sr = new StreamReader("Моє резюме/Інше/Інше.txt"))
            {
                string line;
                var list = new List<string>();

                while ((line = sr.ReadLine()) != null)
                    list.Add(line);

                languages = list[0];
                medicalBook = list[1];
                driverLicense = list[2];
            }
        }
        private void loadPersonalInfo()
        {
            using (StreamReader sr = new StreamReader("Моє резюме/Особиста інформація/Особиста інформація.txt"))
            {
                string line;
                var list = new List<string>();

                while ((line = sr.ReadLine()) != null)
                    list.Add(line);

                address = list[0];
                citizenship = list[1];
                dateOfBirth = list[2];
                moving = list[3];
                sex = list[4];
                marriage = list[5];
                children = list[6];
            }
        }
        private void loadMainInfo()
        {
            using(StreamReader sr = new StreamReader("Моє резюме/Основна інформація/Основна інформація.txt"))
            {
                string line;
                var list = new List<string>();

                while ((line = sr.ReadLine()) != null)
                    list.Add(line);

                surname = list[0];
                name = list[1];
                patronymic = list[2];
                position = list[3];
                salary = list[4];
                email = list[5];
                phone = list[6];
                employment = list[7];
                schedule = list[8];
            }
        }

        private void pnt()
        {
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            try
            {
                if(photosPath != "")
                    g.DrawImage(Image.FromFile(photosPath), photoX, photoY, photoWidth, photoHeight);
                g.DrawImage(Properties.Resources.resume_bg, 0, 0, 795, 1121);
            }
            catch (Exception) { }
            
            using (Font font1 = new Font("Impact", 30))
            {
                RectangleF rectF1 = new RectangleF(285, 45, 509, 105);

                g.DrawString($"{surname} {name}\n{patronymic}", font1, Brushes.Black, rectF1, sf);
            }

            using (Font font1 = new Font("Trebuchet MS", 17, FontStyle.Italic))
            {
                RectangleF rectF1 = new RectangleF(285, 172, 509, 70);

                g.DrawString($"{position}", font1, Brushes.Black, rectF1, sf);
            }
            using (Font font1 = new Font("Segoe UI", 13, FontStyle.Italic))
            {
                g.DrawString(salary, font1, Brushes.Black, 446, 311);
                g.DrawString(employment, font1, Brushes.Black, 463, 346);
                g.DrawString(schedule, font1, Brushes.Black, 486, 381);

                g.DrawString(dateOfBirth, font1, Brushes.Black, 521, 483);
                g.DrawString(citizenship, font1, Brushes.Black, 486, 519);
                g.DrawString(sex, font1, Brushes.Black, 415, 553);
                g.DrawString(marriage, font1, Brushes.Black, 490, 586);
                g.DrawString(children, font1, Brushes.Black, 398, 617);
                g.DrawString(moving, font1, Brushes.Black, 419, 650);
            }

            g.DrawString(driverLicense, new Font("Segoe UI", 13), Brushes.Black, 495, 984);

            g.DrawString(medicalBook, new Font("Segoe UI", 13, FontStyle.Italic), Brushes.Black, 506, 1018);


            using (Font font1 = new Font("Segoe UI", 13, FontStyle.Italic))
            {
                Rectangle rectF1 = new Rectangle(398, 1052, 368, 53);
                g.DrawString(languages, font1, Brushes.Black, rectF1);
            }

            using (Font font1 = new Font("Segoe UI", 10, FontStyle.Italic, GraphicsUnit.Point))
            {
                RectangleF rectF1 = new RectangleF(70, 350, 210, 122);
                g.DrawString(address, font1, Brushes.White, rectF1);
            }


            g.DrawString(phone, new Font("Segoe UI", 12, FontStyle.Italic), Brushes.White, 67, 424);
            g.DrawString(email, new Font("Segoe UI", 10, FontStyle.Italic), Brushes.White, 75, 491);

            using (Font font1 = new Font("Segoe UI", 10, FontStyle.Bold, GraphicsUnit.Point))
            {
                RectangleF rectF1 = new RectangleF(30, 630, 255, 400);

                g.DrawString(education, font1, Brushes.White, rectF1);
            }

       //     g.DrawString("Корінь АНБУ.", new Font("Segoe UI", 10, FontStyle.Bold), Brushes.Black, 318, 738);
       //     g.DrawString("01.01.2005 - 02.06.2010", new Font("Segoe UI", 8, FontStyle.Bold), Brushes.Silver, 320, 758);

            using (Font font1 = new Font("Segoe UI", 9, FontStyle.Italic))
            {
                Rectangle rectF1 = new Rectangle(318, 736, 445, 185);
                g.DrawString(workExpirience, font1, Brushes.Black, rectF1);
               // g.DrawRectangle(Pens.Black, rectF1);
            }
        }
        private void design()
        {
            back.Parent = background;
            startFromBegin.Parent = background;
            save.Parent = background;
            loadPhoto.Parent = background;
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

        private void back_MouseMove(object sender, MouseEventArgs e)
        {
            back.Image = Properties.Resources.back2;
        }

        private void back_MouseLeave(object sender, EventArgs e)
        {
            back.Image = Properties.Resources.back;
        }

        private void startFromBegin_MouseMove(object sender, MouseEventArgs e)
        {
            startFromBegin.Image = Properties.Resources.startFromBegin2;
        }

        private void startFromBegin_MouseLeave(object sender, EventArgs e)
        {
            startFromBegin.Image = Properties.Resources.startFromBegin;
        }

        private void save_MouseMove(object sender, MouseEventArgs e)
        {
            save.Image = Properties.Resources.save2;
        }

        private void save_MouseLeave(object sender, EventArgs e)
        {
            save.Image = Properties.Resources.save;
        }

        private void loadPhoto_MouseMove(object sender, MouseEventArgs e)
        {
            loadPhoto.Image = Properties.Resources.loadPhoto2;
        }

        private void loadPhoto_MouseLeave(object sender, EventArgs e)
        {
            loadPhoto.Image = Properties.Resources.loadPhoto;
        }

        private void Ready_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void startFromBegin_Click(object sender, EventArgs e)
        {
            Directory.Delete("Моє резюме", true);
            lastStepSaving("Step1");
            Application.Restart();
        }

        private void back_Click(object sender, EventArgs e)
        {
            lastStepSaving("Step5");
            Application.Restart();
        }
    }
}
