using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mastermind
{
    public partial class Form2 : Form
    {
        private int trenutno_polje, potvrda = 0;
        private int[] sastav = {0, 0, 0, 0, 0, 0};
        private bool flag = false;
        private HashSet<string> S = new HashSet<string>();


        public Form2()
        {
            InitializeComponent();
            Load += new EventHandler(Igra_Load);
        }

        private void Igra_Load(object sender, System.EventArgs e)
        {
            trenutno_polje = 1;
            Random rd = new Random();

            for (int i = 0; i < 4; i++)
            {

                int rand = rd.Next(1, 7);

                PictureBox sledeci = (PictureBox)this.Controls["PictureBox1_" + (i + 1)];
                Button odredjivacBoje = (Button)this.Controls["Button" + rand];

                if (rand == 1) sastav[0]++;
                else if (rand == 2) sastav[1]++;
                else if (rand == 3) sastav[2]++;
                else if (rand == 4) sastav[3]++;
                else if (rand == 5) sastav[4]++;
                else if (rand == 6) sastav[5]++;

                sledeci.BackgroundImage = odredjivacBoje.BackgroundImage;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (trenutno_polje % 4 == 1 && trenutno_polje != potvrda * 4 + 1)
                {
                    throw new Exception();
                }
                PictureBox trenutno = (PictureBox)this.Controls["PictureBox" + trenutno_polje];
                trenutno.BackgroundImage = button1.BackgroundImage;

                trenutno_polje = trenutno_polje + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Morate pogadjati da bi nastavili dalje sa unosom!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (trenutno_polje % 4 == 1 && trenutno_polje != potvrda * 4 + 1)
                {
                    throw new Exception();
                }
                PictureBox trenutno = (PictureBox)this.Controls["PictureBox" + trenutno_polje];
                trenutno.BackgroundImage = button2.BackgroundImage;

                trenutno_polje = trenutno_polje + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Morate pogadjati da bi nastavili dalje sa unosom!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (trenutno_polje % 4 == 1 && trenutno_polje != potvrda * 4 + 1)
                {
                    throw new Exception();
                }
                PictureBox trenutno = (PictureBox)this.Controls["PictureBox" + trenutno_polje];
                trenutno.BackgroundImage = button3.BackgroundImage;

                trenutno_polje = trenutno_polje + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Morate pogadjati da bi nastavili dalje sa unosom!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (trenutno_polje % 4 == 1 && trenutno_polje != potvrda * 4 + 1)
                {
                    throw new Exception();
                }
                PictureBox trenutno = (PictureBox)this.Controls["PictureBox" + trenutno_polje];
                trenutno.BackgroundImage = button4.BackgroundImage;

                trenutno_polje = trenutno_polje + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Morate pogadjati da bi nastavili dalje sa unosom!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (trenutno_polje % 4 == 1 && trenutno_polje != potvrda * 4 + 1)
                {
                    throw new Exception();
                }
                PictureBox trenutno = (PictureBox)this.Controls["PictureBox" + trenutno_polje];
                trenutno.BackgroundImage = button5.BackgroundImage;

                trenutno_polje = trenutno_polje + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Morate pogadjati da bi nastavili dalje sa unosom!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (trenutno_polje % 4 == 1 && trenutno_polje != potvrda * 4 + 1)
                {
                    throw new Exception();
                }
                PictureBox trenutno = (PictureBox)this.Controls["PictureBox" + trenutno_polje];
                trenutno.BackgroundImage = button6.BackgroundImage;

                trenutno_polje = trenutno_polje + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Morate pogadjati da bi nastavili dalje sa unosom!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (trenutno_polje == 1) throw new Exception();
                else if(trenutno_polje == potvrda * 4 + 1) throw new Exception();
                trenutno_polje -= 1;

                PictureBox trenutno = (PictureBox)this.Controls["PictureBox" + trenutno_polje];
                trenutno.BackgroundImage = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Na pocetku ste i ne mozete da brisete!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (trenutno_polje % 4 != 1 || trenutno_polje == 1 || flag == true) throw new Exception();

                int n = 5;
                int[] sastav_pom = refreshNiz();
                int broj_pogodaka = refreshPogodci();

                for (int i = 1; i < n; i++)
                {
                    PictureBox trenutno = (PictureBox)this.Controls["PictureBox" + (trenutno_polje - n + i)];
                    PictureBox pogodak = (PictureBox)this.Controls["PictureBox1_" + i];

                    if (trenutno.BackgroundImage == pogodak.BackgroundImage)
                    {
                        if (trenutno.BackgroundImage == button1.BackgroundImage) sastav_pom[0] -= 1;
                        else if (trenutno.BackgroundImage == button2.BackgroundImage) sastav_pom[1] -= 1;
                        else if (trenutno.BackgroundImage == button3.BackgroundImage) sastav_pom[2] -= 1;
                        else if (trenutno.BackgroundImage == button4.BackgroundImage) sastav_pom[3] -= 1;
                        else if (trenutno.BackgroundImage == button5.BackgroundImage) sastav_pom[4] -= 1;
                        else sastav_pom[5] -= 1;

                        trenutno = (PictureBox)this.Controls["PictureBox" + (trenutno_polje - n + i + 40)];
                        trenutno.BackColor = Color.LimeGreen;

                        broj_pogodaka++;
                    }
                    else
                    {
                        trenutno = (PictureBox)this.Controls["PictureBox" + (trenutno_polje - n + i + 40)];
                        trenutno.BackColor = Color.Red;
                    }
                }

                for (int i = 1; i < n; i++)
                {
                    PictureBox trenutno = (PictureBox)this.Controls["PictureBox" + (trenutno_polje - n + i)];
                    

                    if (trenutno.BackgroundImage == button1.BackgroundImage && sastav_pom[0] > 0 && this.Controls["PictureBox" + (trenutno_polje - n + i + 40)].BackColor != Color.LimeGreen)
                    {
                        sastav_pom[0] -= 1;
                        trenutno = (PictureBox)this.Controls["PictureBox" + (trenutno_polje - n + i + 40)];
                        trenutno.BackColor = Color.Yellow;
                    }
                    else if (trenutno.BackgroundImage == button2.BackgroundImage && sastav_pom[1] > 0 && this.Controls["PictureBox" + (trenutno_polje - n + i + 40)].BackColor != Color.LimeGreen)
                    {
                        sastav_pom[1] -= 1;
                        trenutno = (PictureBox)this.Controls["PictureBox" + (trenutno_polje - n + i + 40)];
                        trenutno.BackColor = Color.Yellow;
                    }
                    else if (trenutno.BackgroundImage == button3.BackgroundImage && sastav_pom[2] > 0 && this.Controls["PictureBox" + (trenutno_polje - n + i + 40)].BackColor != Color.LimeGreen)
                    {
                        sastav_pom[2] -= 1;
                        trenutno = (PictureBox)this.Controls["PictureBox" + (trenutno_polje - n + i + 40)];
                        trenutno.BackColor = Color.Yellow;
                    }
                    else if (trenutno.BackgroundImage == button4.BackgroundImage && sastav_pom[3] > 0 && this.Controls["PictureBox" + (trenutno_polje - n + i + 40)].BackColor != Color.LimeGreen)
                    {
                        sastav_pom[3] -= 1;
                        trenutno = (PictureBox)this.Controls["PictureBox" + (trenutno_polje - n + i + 40)];
                        trenutno.BackColor = Color.Yellow;
                    }
                    else if (trenutno.BackgroundImage == button5.BackgroundImage && sastav_pom[4] > 0 && this.Controls["PictureBox" + (trenutno_polje - n + i + 40)].BackColor != Color.LimeGreen)
                    {
                        sastav_pom[4] -= 1;
                        trenutno = (PictureBox)this.Controls["PictureBox" + (trenutno_polje - n + i + 40)];
                        trenutno.BackColor = Color.Yellow;
                    }
                    else if (trenutno.BackgroundImage == button6.BackgroundImage && sastav_pom[5] > 0 && this.Controls["PictureBox" + (trenutno_polje - n + i + 40)].BackColor != Color.LimeGreen)
                    {
                        sastav_pom[5] -= 1;
                        trenutno = (PictureBox)this.Controls["PictureBox" + (trenutno_polje - n + i + 40)];
                        trenutno.BackColor = Color.Yellow;
                    }
                }
                if (broj_pogodaka == 4)
                {
                    flag = true;
                    pictureBox1_1.Visible = true;
                    pictureBox1_2.Visible = true;
                    pictureBox1_3.Visible = true;
                    pictureBox1_4.Visible = true;
                    MessageBox.Show("Igra je gotova!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (potvrda == 5) throw new Exception();

                potvrda += 1;
            }
            catch
            {
                if (potvrda == 5)
                {
                    pictureBox1_1.Visible = true;
                    pictureBox1_2.Visible = true;
                    pictureBox1_3.Visible = true;
                    pictureBox1_4.Visible = true;
                    MessageBox.Show("Igra je gotova!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (flag) MessageBox.Show("Igra je gotova!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Ne mozete pogadjati dok ne unesete sva 4 karaktera!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int[] refreshNiz()
        {
            int[] pom_sastav = new int[6];
            for(int i = 0; i < 6; i++)
            {
                pom_sastav[i] = sastav[i];
            }
            return pom_sastav;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refreshPool()
        {

        }

        private int refreshPogodci()
        {
            int pogodci = 0;
            return pogodci;
        }
    }
}
