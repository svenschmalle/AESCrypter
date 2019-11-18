using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AESCrypter
{
    public partial class Form1 : Form
    {
        string _AESKey;
        string _ConfigFile;
        Classes.config _Config;

        public Form1()
        {
            InitializeComponent();

            // Versionsnummer in der Form anzeigen
            this.Text = $"{this.Text}  [{Assembly.GetEntryAssembly().GetName().Version}]";

            // AES Key erstellen
            if (!File.Exists("KeyFile.crt"))
            {
                _AESKey = Crypt.AES.GenerateKey(256);
                File.WriteAllText("KeyFile.crt", _AESKey);
            }

            _AESKey = File.ReadAllText("KeyFile.crt");
            
            _ConfigFile = Path.Combine(Application.StartupPath, "config.json");
            _Config = new Classes.config();

            // Initiale Config erstellen, falls noch nicht vorhanden
            if (!File.Exists(_ConfigFile))
            {
                _Config.AZ_gross = true;
                _Config.laenge_gesamt = 10;
                _Config.Zahlen09 = true;
                _Config.az_klein = true;
                _Config.Specialchars = true;
                _Config.speichern(_ConfigFile);
            }
            
            // Config einlesen
            if (File.Exists(_ConfigFile))
            {
                _Config.laden(_ConfigFile);

                checkBox_azklein.Checked = _Config.az_klein;
                checkBox_AZgross.Checked = _Config.AZ_gross;
                checkBox_09.Checked = _Config.Zahlen09;
                checkBox_special.Checked = _Config.Specialchars;
                numericUpDown_laenge.Value = _Config.laenge_gesamt;
                numericUpDown_anzahlspecial.Value = _Config.anzahl_sonderzeichen;

                if (_Config.Historie == null)
                {
                    _Config.Historie = new List<Classes.Historie>();
                }

                HistorieLaden();

                // Beim Starten soll schon ein Passwort generiert werden
                Generieren();
            }          
        }

        private void button_generieren_Click(object sender, EventArgs e)
        {
            Generieren();
        }

        private void Generieren()
        {
            string CharString = "";
            if (checkBox_azklein.Checked)
            {
                CharString += "abcdefghijkmnopqrstuvwxyz";
            }
            if (checkBox_AZgross.Checked)
            {
                CharString += "ABCDEFGHJKLMNOPQRSTUVWXYZ";
            }
            if (checkBox_09.Checked)
            {
                CharString += "0123456789";
            }

            if (!string.IsNullOrEmpty(CharString) && (int)numericUpDown_laenge.Value > 0 && numericUpDown_anzahlspecial.Value <= numericUpDown_laenge.Value)
            {
                textBox_text.Text = misc.GeneratePassword(CharString, (int)numericUpDown_laenge.Value, (int)numericUpDown_anzahlspecial.Value);
                Verschluesseln();
            }

            // Historieneintrag hinzufügen und in config speichern
            _Config.Historie.Add(new Classes.Historie() { Datum = DateTime.Now, Klartext = textBox_text.Text, Crypttext = textBox_crypt.Text });
            _Config.Historie = _Config.Historie.OrderByDescending(h => h.Datum).Take(15).ToList(); // nur die ersten 15 der Liste nehmen
            _Config.speichern(_ConfigFile);
            HistorieLaden();
        }

        private void Verschluesseln()
        {
            try
            {
                string AESCrytText = Crypt.AES.Encrypt(textBox_text.Text, _AESKey, 256);
                textBox_crypt.Text = AESCrytText;
            }
            catch (Exception)
            {
                MessageBox.Show("Fehler beim Verschlüsseln!");
            }
        }

        private void Entschluesseln()
        {
            try
            {
                string AESKlarText = Crypt.AES.Decrypt(textBox_crypt.Text, _AESKey, 256);
                textBox_text.Text = AESKlarText;
            }
            catch (Exception)
            {
                MessageBox.Show("Fehler beim Entschlüsseln!");
            }
        }

        private void checkBox_special_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown_anzahlspecial.Value = 0;
            numericUpDown_anzahlspecial.Visible = checkBox_special.Checked;
            label3.Visible = checkBox_special.Checked;
        }

        private void button_copyklartext_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox_text.Text);
        }

        private void button_copycrypt_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox_crypt.Text);
        }

        private void textBox_crypt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                Entschluesseln();
            }
        }

        private void textBox_text_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                Verschluesseln();
            }
        }

        private void textBox_text_MouseUp(object sender, MouseEventArgs e)
        {
            textBox_text.SelectAll();
        }

        private void textBox_crypt_MouseUp(object sender, MouseEventArgs e)
        {
            textBox_crypt.SelectAll();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Config.az_klein = checkBox_azklein.Checked;
            _Config.AZ_gross = checkBox_AZgross.Checked;
            _Config.Zahlen09 = checkBox_09.Checked;
            _Config.Specialchars = checkBox_special.Checked;
            _Config.laenge_gesamt = (int)numericUpDown_laenge.Value;
            _Config.anzahl_sonderzeichen = (int)numericUpDown_anzahlspecial.Value;

            _Config.speichern(_ConfigFile);
        }

        private void HistorieLaden()
        {
            listView1.Items.Clear();
            listView1.BeginUpdate();

            List<Classes.Historie> Historie = _Config.Historie.ToList();
            foreach (Classes.Historie item in Historie)
            {
                ListViewItem lvi = new ListViewItem(item.Datum.ToString()) { Tag = item };
                lvi.SubItems.Add(item.Klartext);
                lvi.SubItems.Add(item.Crypttext);
                listView1.Items.Add(lvi);
            }

            listView1.EndUpdate();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Classes.Historie hist = listView1.SelectedItems[0].Tag as Classes.Historie;
                textBox_text.Text = hist.Klartext;
                textBox_crypt.Text = hist.Crypttext;
            }
        }

        private void listView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0 && e.KeyCode==Keys.Delete)
            {
                Classes.Historie hist = listView1.SelectedItems[0].Tag as Classes.Historie;
                int index = listView1.SelectedItems[0].Index;
                _Config.Historie.Remove(hist);
                _Config.speichern(_ConfigFile);
                HistorieLaden();

                if (index > 0)
                {
                    if (index < listView1.Items.Count)
                    {
                        listView1.Items[index].Selected = true;
                    }
                    else
                    {
                        listView1.Items[index - 1].Selected = true;
                    }
                }
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView lv = sender as ListView;
            ListViewHitTestInfo hit = lv.HitTest(e.Location);
            ListViewItem lvi = hit.Item;
            int columnindex = hit.Item.SubItems.IndexOf(hit.SubItem);

            if (lvi != null)
            {
                Clipboard.SetText(lvi.SubItems[columnindex].Text);
            }
        }
    }
}
