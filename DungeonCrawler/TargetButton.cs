using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonCrawler
{
    public partial class TargetButton : UserControl
    {

        CharacterDisplay target;
        CharacterDisplay owner;
        AttackDialogue atkForm = null;
        SkillDialogue skillForm = null;
        public TargetButton()
        {
            InitializeComponent();
        }
        public TargetButton(CharacterDisplay toTarget, CharacterDisplay attacker, AttackDialogue dialogue)
        {
            InitializeComponent();
            target = toTarget;
            owner = attacker;
            atkForm = dialogue;
            targetBtn.Text = target.GetName;

        }
        public TargetButton(CharacterDisplay toTarget, CharacterDisplay attacker, SkillDialogue dialogue)
        {
            InitializeComponent();
            target = toTarget;
            owner = attacker;
            skillForm = dialogue;
            targetBtn.Text = target.GetName;

        }
        private void targetBtn_Click(object sender, EventArgs e)
        {
            if (skillForm == null)
            {
                atkForm.Visible = false;
                atkForm.Close();
                owner.Unit.Attack(target.Unit);
                atkForm.Main.EventList.AppendText($"{owner.Unit.Name} attacked {target.Unit.Name} \n");
                atkForm.Main.GoToNextTurn();                
            }
            else if (atkForm == null)
            {
                skillForm.Visible = false;
                skillForm.Close();
                owner.Unit.Skill(target.Unit);
                skillForm.Main.EventList.AppendText($"{owner.Unit.Name} used skill on {target.Unit.Name} \n");
                skillForm.Main.GoToNextTurn();
            }
            
            
        }
    }
}
