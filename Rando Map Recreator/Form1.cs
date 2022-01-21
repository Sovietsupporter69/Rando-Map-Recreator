using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rando_Map_Recreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void GetText()
        {
            string[] lines = File.ReadAllLines(r'C:\Users\User\AppData\LocalLow\Team Cherry\Hollow Knight\Randomizer 4\Recent');

            foreach (string line in lines)
                Console.WriteLine(line);
        }
    }
}
