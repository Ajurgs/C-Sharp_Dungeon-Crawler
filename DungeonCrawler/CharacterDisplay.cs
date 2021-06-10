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
    public partial class CharacterDisplay : UserControl
    {
        Character unit;
        string name;
        string type;
        public CharacterDisplay()
        {
            InitializeComponent();
        }
        public CharacterDisplay(Character input)
        {
            unit = input;
            name = input.Name;
            type = input.Type;
            InitializeComponent();
            UpdateInfo();
        }

        public string GetName
        {
            get
            {
                return name;
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
        }
        public PictureBox GetSpriteBox
        {
            get
            {
                return SpriteBox;
            }
        }
        public Character Unit
        {
            get
            {
                return unit;
            }
        }
        public Panel Highlight
        {
            get
            {
                return panel1;
            }
        }
        public void UpdateInfo()
        {
            
            healthLbl.Text = $"{unit.HitPointsCurrent}/{unit.HitPointsMax}";
        }
    }
}
