using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class EZClip : Form
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8

        }

        public EZClip()
        {
            InitializeComponent();
            
            RegisterHotKey(this.Handle, 1, (int)KeyModifier.Control, Keys.D1.GetHashCode());
            RegisterHotKey(this.Handle, 2, (int)KeyModifier.Control, Keys.D2.GetHashCode());
            RegisterHotKey(this.Handle, 3, (int)KeyModifier.Control, Keys.D3.GetHashCode());
            RegisterHotKey(this.Handle, 4, (int)KeyModifier.Control, Keys.D4.GetHashCode());
            RegisterHotKey(this.Handle, 5, (int)KeyModifier.Control, Keys.D5.GetHashCode());
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                KeyModifier modifier = (KeyModifier)((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
                int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.

                if (id == 1)
                {
                    button1.PerformClick();
                }

                else if (id == 2)
                {
                    button2.PerformClick();
                }

                else if (id == 3)
                {
                    button3.PerformClick();
                }

                else if (id == 4)
                {
                    button4.PerformClick();
                }

                else if (id == 5)
                {
                    button5.PerformClick();
                }


            }

        }

        private void EZClip_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, 1);
            UnregisterHotKey(this.Handle, 2);
            UnregisterHotKey(this.Handle, 3);
            UnregisterHotKey(this.Handle, 4);
            UnregisterHotKey(this.Handle, 5);
        }




        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textforclipboard;
            textforclipboard = textBox1.Text;

            if (textforclipboard.Equals(string.Empty) == false)
            {
                Clipboard.Clear();
                button1.BackColor = Color.SkyBlue;
                button2.BackColor = Color.White;
                button3.BackColor = Color.White;
                button4.BackColor = Color.White;
                button5.BackColor = Color.White;
                Clipboard.SetText(textforclipboard);
                SendKeys.Send("^v");
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string textforclipboard;
            textforclipboard = textBox2.Text;

            if (textforclipboard.Equals(string.Empty) == false)
            {
                Clipboard.Clear();
                button1.BackColor = Color.White;
                button2.BackColor = Color.SkyBlue;
                button3.BackColor = Color.White;
                button4.BackColor = Color.White;
                button5.BackColor = Color.White;
                Clipboard.SetText(textforclipboard);
                SendKeys.Send("^v");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string textforclipboard;
            textforclipboard = textBox3.Text;

            if (textforclipboard.Equals(string.Empty) == false)
            {
                Clipboard.Clear();
                button1.BackColor = Color.White;
                button2.BackColor = Color.White;
                button3.BackColor = Color.SkyBlue;
                button4.BackColor = Color.White;
                button5.BackColor = Color.White;
                Clipboard.SetText(textforclipboard);
                SendKeys.Send("^v");
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string textforclipboard;
            textforclipboard = textBox4.Text;

            if (textforclipboard.Equals(string.Empty) == false)
            {
                Clipboard.Clear();
                button1.BackColor = Color.White;
                button2.BackColor = Color.White;
                button3.BackColor = Color.White;
                button4.BackColor = Color.SkyBlue;
                button5.BackColor = Color.White;
                Clipboard.SetText(textforclipboard);
                SendKeys.Send("^v");
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string textforclipboard;
            textforclipboard = textBox5.Text;

            if (textforclipboard.Equals(string.Empty) == false)
            {
                Clipboard.Clear();
                button1.BackColor = Color.White;
                button2.BackColor = Color.White;
                button3.BackColor = Color.White;
                button4.BackColor = Color.White;
                button5.BackColor = Color.SkyBlue;
                Clipboard.SetText(textforclipboard);
                SendKeys.Send("^v");
            }
        }

        private void EZClip_Load(object sender, EventArgs e)
        {

        }

        private void EZClip_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1 && e.Modifiers == Keys.Control)

            {
                button1.PerformClick();
            }

            else if (e.KeyCode == Keys.D2 && e.Modifiers == Keys.Control)

            {
                button2.PerformClick();
            }

            else if (e.KeyCode == Keys.D3 && e.Modifiers == Keys.Control)

            {
                button3.PerformClick();
            }

            else if (e.KeyCode == Keys.D4 && e.Modifiers == Keys.Control)

            {
                button4.PerformClick();
            }

            else if (e.KeyCode == Keys.D5 && e.Modifiers == Keys.Control)

            {
                button5.PerformClick();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream openStream = null;

            OpenFileDialog openDialog1 = new OpenFileDialog();
            openDialog1.InitialDirectory = "C:\\";
            openDialog1.Filter = "Txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openDialog1.FilterIndex = 1;
            openDialog1.RestoreDirectory = true;

            if (openDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((openStream = openDialog1.OpenFile()) != null)
                    {
                        using (openStream)
                        {
                            // manipulate text file
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream saveStream = null;

            SaveFileDialog saveDialog1 = new SaveFileDialog();
            saveDialog1.InitialDirectory = "C:\\";
            saveDialog1.Filter = "Txt files (*.txt)|*.txt";
            saveDialog1.FilterIndex = 1;
            saveDialog1.RestoreDirectory = true;

            if (saveDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((saveStream = saveDialog1.OpenFile()) != null)
                    {
                        using (saveStream)
                        {
                            // manipulate text file
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.Show();
        }
    }
}
