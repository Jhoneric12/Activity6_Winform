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

namespace Activity6_Aton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open File Dialog
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Open File";
            openFile.Filter = "txt files (*.txt)|*.txt|All Files (*.*) |*.*";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamR = new StreamReader(openFile.FileName);
                rtxtText.Text = streamR.ReadToEnd();
                streamR.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Save File Dialog
            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (Stream str = File.Open(saveFile.FileName, FileMode.CreateNew))
                using (StreamWriter strWrite = new StreamWriter(str))
                {
                    strWrite.Write(rtxtText.Text);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Close the program
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fDialog = new FontDialog();
            if (rtxtText.SelectedText != string.Empty)
            {
                fDialog.ShowDialog();
                rtxtText.SelectionFont = fDialog.Font; // Will change the font of the selected text
            }
            else
            {
                fDialog.ShowDialog();
                rtxtText.Font = fDialog.Font; // Will change the font of the text in rtxtText
            }
        }

        private void fColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog fColor = new ColorDialog();
            if (rtxtText.SelectedText != string.Empty)
            {
                fColor.ShowDialog();
                rtxtText.SelectionColor = fColor.Color; // Will change the forecolor of the selected text
            }
            else
            {
                fColor.ShowDialog();
                rtxtText.ForeColor = fColor.Color; // Will change the forecolor of the text in rtxtText
            }
        }

        private void bgColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Change background color of rtxtText
            ColorDialog bgColor = new ColorDialog();
            bgColor.ShowDialog();
            rtxtText.BackColor = bgColor.Color;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Display messagebox
            MessageBox.Show("MENUS, TOOLBAR, STATUS BAR \n\n BY ME....", "DEMO");
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            // Open File Dialog
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Open File";
            openFile.Filter = "txt files (*.txt)|*.txt|All Files (*.*) |*.*";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamR = new StreamReader(openFile.FileName);
                rtxtText.Text = streamR.ReadToEnd();
                streamR.Close();
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            // Save File Dialog
            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (Stream str = File.Open(saveFile.FileName, FileMode.CreateNew)) 
                using (StreamWriter strWrite = new StreamWriter(str))
                {
                    strWrite.Write(rtxtText.Text);
                }
            }
        }

        private void txbExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Close the program
        }

        private void tsmFont_Click(object sender, EventArgs e)
        {
            FontDialog fDialog = new FontDialog();
            if (rtxtText.SelectedText != string.Empty)
            {
                fDialog.ShowDialog();
                rtxtText.SelectionFont = fDialog.Font; // Will change the font of the selected text
            }
            else
            {
                fDialog.ShowDialog();
                rtxtText.Font = fDialog.Font; // Will change the font of the text in rtxtText
            }
        }

        private void tsmFontColor_Click(object sender, EventArgs e)
        {
            ColorDialog fColor = new ColorDialog();
            if (rtxtText.SelectedText != string.Empty)
            {
                fColor.ShowDialog();
                rtxtText.SelectionColor = fColor.Color; // Will change the forecolor of the selected text
            }
            else
            {
                fColor.ShowDialog();
                rtxtText.ForeColor = fColor.Color; // Will change the forecolor of the text in rtxtText
            }
        }

        private void tsmBGColor_Click(object sender, EventArgs e)
        {
            // Change background color of rtxtText
            ColorDialog bgColor = new ColorDialog();
            bgColor.ShowDialog();
            rtxtText.BackColor = bgColor.Color;
        }

        private void tsmCut_Click(object sender, EventArgs e)
        {
            // Cut text
            RichTextBox rtb = this.ActiveControl as RichTextBox;
            if (rtb.SelectedText != string.Empty)
            {
                Clipboard.SetData(DataFormats.Text, rtb.SelectedText);
            }
            rtb.SelectedText = string.Empty; 
        }

        private void tsmCopy_Click(object sender, EventArgs e)
        {
            // Copy Text
            RichTextBox rtb = this.ActiveControl as RichTextBox;
            if (rtb.SelectedText != string.Empty)
            {
                Clipboard.SetData(DataFormats.Text, rtb.SelectedText);
            }
        }

        private void tsmPaste_Click(object sender, EventArgs e)
        {
            // Paste text
            int position = ((RichTextBox)this.ActiveControl).SelectionStart;
            this.ActiveControl.Text = this.ActiveControl.Text.Insert(position, Clipboard.GetText()); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tssNotify.Text = "Status Notifier Ready....!";
            timer.Enabled = true;
            // Display Date
            DateTime date = DateTime.Now;
            string format = "MMMM dd, dddd, yyyy";
            tssDate.Text = date.ToString(format);

            Application.Idle += CapsLock;
            Application.Idle += NumLock;
            Application.Idle += ScrollLock;
            Application.Idle += Insert;
        }
        // This method is to activate tssCaps when capslock key is pressed
        private void CapsLock(object sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                tssCaps.Enabled = true;
            }
            else
            {
                tssCaps.Enabled = false;
            }
        }
        // This method is to activate tssNum when numlock key is pressed
        private void NumLock(object sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.NumLock))
            {
                tssNum.Enabled = true;
            }
            else
            {
                tssNum.Enabled = false;
            }
        }
        // This method is to activate tssScrl when scroll lock key is pressed 
        private void ScrollLock(object sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.Scroll))
            {
                tssScrl.Enabled = true;
            }
            else
            {
                tssScrl.Enabled = false;
            }
        }
        // This method is to activate tssIns when insert key is pressed
        private void Insert(object sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.Insert))
            {
                tssIns.Text = "OVR";
            }
            else
            {
                tssIns.Text = "INS";
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // Display Time
            tssTime.Text = DateTime.Now.ToLongTimeString(); 
        }

        private void tssDate_Click(object sender, EventArgs e)
        {
            // 
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // Display messagebox
            MessageBox.Show("MENUS, TOOLBAR, STATUS BAR \n\n BY ME....", "DEMO");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Background
            panel1.BackColor = Color.FromArgb(90, 0, 0, 0);
        }
    }
}
