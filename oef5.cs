using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraOefening
{
    public partial class oef5 : Form
    {
        public oef5()
        {
            InitializeComponent();
        }
        //maak een lijst of class persoon
        List<Persoon> naamLijst = new List<Persoon>();
        private void button1_Click(object sender, EventArgs e)
        {   //error hanfeling
            try { 
            if (! System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[a-zA-Z'.]{1,40}$"))
            {
                MessageBox.Show("Alleen letters toegelaten");
                textBox1.Focus();
            }
            else if (! System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "^[a-zA-Z'.]{1,40}$"))
            {
                MessageBox.Show("Alleen letters toegelaten");
                textBox2.Focus();
            }
            else if (! System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[0-9]{1,3}$") || int.Parse(textBox3.Text) >= 120)
            {   
                
                int txtBox3 = Convert.ToInt32(textBox3.Text);
                if(txtBox3 >= 120) 
                { 
                MessageBox.Show("Tot 120 maximum leeftijd toegelaten?");
                textBox3.Focus();
                }
                else { MessageBox.Show("Alleen cijfers toegelaten "); }
            

            }else { //verzameling van persoon objecten in naamlijst met gebruik van textbox 
                    naamLijst.Add(new Persoon(textBox1.Text, textBox2.Text,Convert.ToInt32(textBox3.Text)));
                    int count = naamLijst.Count - 1;
                    //Cast 
                    listBox1.Items.Add(naamLijst[count]);
                    //MessageBox.Show(Convert.ToString(naamLijst[count].ToString()));
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                 }
            }
            catch
            {
                MessageBox.Show("Alleen cijfers toegelaten ");
            }

            }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Persoon naamLijst = (Persoon)listBox1.SelectedItem;

            //
            if (naamLijst != null) {
                labResultaat.Text = naamLijst.Inhoud();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Persoon selected = (Persoon)listBox1.SelectedItem;
            //Verwijdert het opgegeven object uit de verzameling
            naamLijst.Remove(selected);
            labResultaat.Text = "";
            listBox1.Items.Remove(selected);
            
         
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}