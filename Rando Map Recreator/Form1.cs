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
        List<Transition_link> Transitions = new List<Transition_link>();

        public Form1()
        {
            InitializeComponent();
            textBox1.ScrollBars = ScrollBars.Vertical;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetText();
            SortInput();
        }

        void GetText()
        {
            string FileName = @"C:\Users\User\AppData\LocalLow\Team Cherry\Hollow Knight\Randomizer 4\Recent\HelperLog.txt";
            try
            {
                using (StreamReader reader = new StreamReader(FileName)) //opens the file
                {
                    string line;
                    bool CorrectLine = false;
                    while ((line = reader.ReadLine()) != null) //while there is a line to read
                    {
                        if (line.StartsWith("CHECKED TRANSITIONS"))  //if you find 'CHECKED TRANSITIONS' start saving lines
                        {
                            CorrectLine = true;
                        }
                        if (line.StartsWith("RESPAWNING ITEMS")) //stop recording lines once you get to the next section
                        {
                            CorrectLine = false;
                        }

                        if (CorrectLine == true)
                        {
                            CheckedTransitions.Add(line); //record the lines that are are meant to be
                        }
                    }
                }
            }
            catch(Exception exp)
            {
                textBox1.AppendText(exp.Message); //give an error if recording goes wrong
            }
        }

        void SortInput()
        {
            char[] CheckingChars = {']', '[', ' '};
            char[] CheckingNumb = { '0', '1', '2', '3', '4', '5' };
            bool Repeat = false;
            for (int i = 1; i < (CheckedTransitions.Count); i++)
            {
                string[] words = CheckedTransitions[i].Split(CheckingChars); //splits the raw line into devisions
                Repeat = false;

                for (int b = 0; b < Transitions.Count; b++) //checks if this transition is already recorded
                {
                    if ((Transitions[b].EntryRoom == words[8] && Transitions[b].ExitRoom == words[2]) || (Transitions[b].EntryRoom == words[2] && Transitions[b].ExitRoom == words[8]))
                    {
                        Repeat = true;
                    }
                }
                if (Repeat == false) //if the transition is new
                {
                    Transitions[i-1].EntryRoom = words[2]; //and saves them in the class list (Rooms)
                    Transitions[i-1].ExitRoom = words[8];

                    string[] DirecNumb = CheckedTransitions[1].Split(CheckingNumb); //splits directions so that the number can be found
                    textBox1.AppendText($"<{DirecNumb}>");
                }
            }

            //get the direction and and asign it a compas and number
        }
    }
}
