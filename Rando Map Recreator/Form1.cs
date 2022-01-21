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

namespace Rando_Map_Recreator
{
    public partial class Form1 : Form
    {
        List<string> CheckedTransitions = new List<string>();

        public Form1()
        {
            InitializeComponent();
            textBox1.ScrollBars = ScrollBars.Vertical;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetText();
            //SortInput();
        }

        void GetText()
        {
            string FileName = @"C:\Users\User\AppData\LocalLow\Team Cherry\Hollow Knight\Randomizer 4\Recent\HelperLog.txt";
            try
            {
                using (StreamReader reader = new StreamReader(FileName))
                {
                    string line;
                    bool CorrectLine = false;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("CHECKED TRANSITIONS"))
                        {
                            CorrectLine = true;
                        }
                        if (line.StartsWith("RESPAWNING ITEMS"))
                        {
                            CorrectLine = false;
                        }

                        if (CorrectLine == true)
                        {
                            CheckedTransitions.Add(line);
                        }
                    }
                }
            }
            catch(Exception exp)
            {
                textBox1.AppendText(exp.Message);
            }
        }

        void SortInput()
        {
            //in a for loop
            //take the input
            //check for shared characters
            //separate out the right part for the room
            //get the direction and and asign it a compas and number
            //repeat once for the exit
            //check if this transition is already in the class
            //in new input into class
            //repeat for all of the transitions
        }
    }
}
