using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonCrawler
{
    public partial class AttackDialogue : Form
    {

        private Dungeon main = null;
        TargetButton[] choices;
        public AttackDialogue()
        {
            InitializeComponent();
        }
        public AttackDialogue(CharacterDisplay[] targets, CharacterDisplay implementor,Dungeon callingForm)
        {
            choices = new TargetButton[targets.GetLength(0)];
            main = callingForm;
            InitializeComponent();
            for (int i = 0; i < targets.GetLength(0); i++)
            {
                choices[i] = new TargetButton(targets[i],implementor,this);
                choices[i].Location = new Point(5, 5 + (30 * i));
                this.Controls.Add(choices[i]);
            }
        }
        public Dungeon Main
        {
            get
            {
                return main;
            }
        }

    }
}
