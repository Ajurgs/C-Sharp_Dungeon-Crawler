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

namespace DungeonCrawler
{
    public partial class Dungeon : Form
    {
        Random rng = new Random((int)DateTime.Now.Millisecond);
        CharacterDisplay[] heroes;
        CharacterDisplay[] monsters;
        List<CharacterDisplay> turnOrder;
        int numberOfUnits;
        int roomsCleared = 0;
        int turn = 0;
        CharacterDisplay selected = null;
        AttackDialogue attackMessage;
        SkillDialogue skillMessage;
        TextBox eventList = new TextBox();
        
        // construstor for the dungeon        
        public Dungeon()
        {
            
            InitializeComponent();
            attackBtn.Visible = false;
            defendBtn.Visible = false;
            skillBtn.Visible = false;
            heroes = GetHeroes(3);
            monsters = GetMonsters(rng.Next(0,10));
            numberOfUnits = heroes.GetLength(0) + monsters.GetLength(0);
            Console.WriteLine(numberOfUnits);
            Controls.Add(eventList);
            eventList.Location = new Point(14, 383);
            eventList.Multiline = true;
            eventList.ReadOnly = true;
            eventList.ScrollBars = ScrollBars.Vertical;
            eventList.Size = new Size(666,83);
        }

        /// <summary>
        /// Advance to the next room
        /// </summary>
        /// <param name="heroes"></param>
        /// <param name="monsters"></param>
        private void NextRoom(CharacterDisplay[] heroes, CharacterDisplay[] monsters)
        {
            room.BackgroundImage = Properties.Resources.stoneWall;
            for (int i = 0; i < heroes.GetLength(0); i++)
            {
                room.Controls.Add(heroes[i]);
            }
            for (int i = 0; i < monsters.GetLength(0); i++)
            {
                room.Controls.Add(monsters[i]);
            }

        }
        /// <summary>
        /// make the array for heroes
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private CharacterDisplay[] GetHeroes(int length)
        {
            CharacterDisplay[] temp = new CharacterDisplay[length];
            temp[0] = new CharacterDisplay(new Warrior());
            temp[0].Location = new Point(4, 4 + (106 * 0));
            setSprite(temp[0]);
            temp[1] = new CharacterDisplay(new Mage());
            temp[1].Location = new Point(4, 4 + (106 * 1));
            setSprite(temp[1]);
            temp[2] = new CharacterDisplay(new Cleric());
            temp[2].Location = new Point(4, 4 + (106 * 2));
            setSprite(temp[2]);
            return temp;
        }
        /// <summary>
        /// Get an array of monsters
        /// </summary>
        /// <returns></returns>
        private CharacterDisplay[] GetMonsters(int roomNum)
        {
            switch (roomNum)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    {
                        CharacterDisplay[] temp = new CharacterDisplay[3];
                        for (int i = 0; i < temp.GetLength(0); i++)
                        {
                            temp[i] = new CharacterDisplay(new Bandit());
                            temp[i].Location = new Point(564, 4 + (106 * i));
                            setSprite(temp[i]);
                        }
                        return temp;
                        break;
                    }
                case 4:
                case 5:
                    {
                        CharacterDisplay[] temp = new CharacterDisplay[3];
                        temp[0] = new CharacterDisplay(new Bandit());
                        temp[0].Location = new Point(564, 4);
                        setSprite(temp[0]);
                        temp[1] = new CharacterDisplay(new Ogre());
                        temp[1].Location = new Point(564, 4 + 106);
                        setSprite(temp[1]);
                        temp[2] = new CharacterDisplay(new Bandit());
                        temp[2].Location = new Point(564, 4 + 212);
                        setSprite(temp[2]);
                        return temp;
                        break;

                    }
                case 6:
                case 7:
                    {
                        CharacterDisplay[] temp = new CharacterDisplay[3];
                        temp[0] = new CharacterDisplay(new Ogre());
                        temp[0].Location = new Point(564, 4);
                        setSprite(temp[0]);
                        temp[1] = new CharacterDisplay(new Ogre());
                        temp[1].Location = new Point(564, 4 + 106);
                        setSprite(temp[1]);
                        temp[2] = new CharacterDisplay(new Bandit());
                        temp[2].Location = new Point(564, 4 + 212);
                        setSprite(temp[2]);
                        return temp;
                        break;
                    }
                case 8:
                    {
                        CharacterDisplay[] temp = new CharacterDisplay[3];
                        temp[0] = new CharacterDisplay(new Ogre());
                        temp[0].Location = new Point(564, 4);
                        setSprite(temp[0]);
                        temp[1] = new CharacterDisplay(new Ogre());
                        temp[1].Location = new Point(564, 4 + 106);
                        setSprite(temp[1]);
                        temp[2] = new CharacterDisplay(new Ogre());
                        temp[2].Location = new Point(564, 4 + 212);
                        setSprite(temp[2]);
                        return temp;
                        break;
                    }
                case 9:
                    {
                        CharacterDisplay[] temp = new CharacterDisplay[1];
                        temp[0] = new CharacterDisplay(new Dragon());
                        temp[0].Location = new Point(564, 4 + 106);
                        setSprite(temp[0]);
                        return temp;
                        break;
                    }
                default:
                    {
                        CharacterDisplay[] temp = new CharacterDisplay[3];
                        for (int i = 0; i < temp.GetLength(0); i++)
                        {
                            temp[i] = new CharacterDisplay(new Bandit());
                            temp[i].Location = new Point(564, 4 + (106 * i));
                            setSprite(temp[i]);
                        }
                        return temp;
                        break;
                    }
            }
        }
        /// <summary>
        /// Set the CharacterDisplay's SpriteBox image
        /// depending on the type of unit.
        /// </summary>
        /// <param name="display"></param>
        private void setSprite(CharacterDisplay display)
        {
            Console.WriteLine(display.GetName);
            if (display.GetName == "Warrior")
            {
                display.GetSpriteBox.Image = Properties.Resources.knightsprite;
            }
            else if (display.GetName == "Mage")
            {
                display.GetSpriteBox.Image = Properties.Resources.Mage;
            }
            else if (display.GetName == "Cleric")
            {
                display.GetSpriteBox.Image = Properties.Resources.Cleric;
            }
            else if (display.GetName == "Bandit")
            {
                display.GetSpriteBox.Image = Properties.Resources.Bandit;
            }
            else if (display.GetName == "Ogre")
            {
                display.GetSpriteBox.Image = Properties.Resources.Ogre;
            }
            else if (display.GetName == "Dragon")
            {
                display.GetSpriteBox.Image = Properties.Resources.Dragon;
            }
        }
        /// <summary>
        /// Make a list in decending order bised on speed
        /// </summary>
        /// <param name="heroes"></param>
        /// <param name="monsters"></param>
        /// <returns></returns>
        private List<CharacterDisplay> SetTurnOrder(CharacterDisplay[] heroes, CharacterDisplay[] monsters)
        {
            List<CharacterDisplay> temp = new List<CharacterDisplay>();
            for (int i = 0; i < heroes.GetLength(0); i++)
            {
                temp.Add(heroes[i]);
            }
            for (int i = 0; i < monsters.GetLength(0); i++)
            {
                temp.Add(monsters[i]);
            }
            Sort(temp);
            return temp;
        }
        /// <summary>
        /// sort list bases on speed in decending order
        /// </summary>
        /// <param name="list"></param>
        private void Sort(List<CharacterDisplay> list)
        {
            bool sorted = false;
            while (sorted != true)
            {
                sorted = true;
                for (int i = 0; i < list.Count()-1; i++)
                {
                    if (list[i].Unit.Speed < list[i + 1].Unit.Speed)
                    {
                        sorted = false;
                        Swap(list, i, i + 1);
                    }
                }
            } 
        }
        /// <summary>
        /// swap two indexes of a list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="indexA"></param>
        /// <param name="indexB"></param>
        private static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T temp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = temp;
        }
        /// <summary>
        /// highlight charaicter whoes turn it is
        /// </summary>
        /// <param name="current"></param>
        /// <param name="next"></param>
        private void ChangeSelected(CharacterDisplay current, CharacterDisplay next)
        {
            this.Update();
            if (current == null)
            {
                selected = next;
                selected.Highlight.BackColor = Color.Aquamarine;
            }
            else
            {
                current.Highlight.BackColor = Color.White;
                selected = next;
                selected.Highlight.BackColor = Color.Aquamarine;
            }
            if (selected.Unit.IsAlive == false)
            {
                GoToNextTurn();
            }
            selected.Unit.IsDefending = false;
            if (selected.Type == "Monster")
            {
                if (selected.Unit.IsStuned == true)
                {
                    this.Update();
                    eventList.AppendText($"{selected.Unit.Name} is stuned \n");
                    selected.Unit.IsStuned = false;
                    GoToNextTurn();
                }
                else
                {
                    this.Update();
                    System.Threading.Thread.Sleep(1000);
                    // add selected monsters action
                    selected.Unit.TakeAction(heroes, this);
                    GoToNextTurn();
                }
            }

        }
        /// <summary>
        /// start the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startBtn_Click(object sender, EventArgs e)
        {
            startBtn.Visible = false;
            NextRoom(heroes, monsters);
            attackBtn.Visible = true;
            defendBtn.Visible = true;
            skillBtn.Visible = true;
            turnOrder = SetTurnOrder(heroes, monsters);
            UpdateRoom();
            ChangeSelected(selected, turnOrder[turn]);
            
        }
        /// <summary>
        /// when the attack button is pressed open dialog to select
        /// who to attack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void attackBtn_Click(object sender, EventArgs e)
        {
            attackMessage = new AttackDialogue(monsters,selected,this);
            attackMessage.ShowDialog(this);
        }
        /// <summary>
        /// when the defend button is pressed defend for the turn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void defendBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Defend for Round?", "Defend", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                selected.Unit.Defend();
                eventList.AppendText($"{selected.Unit.Name} Defended for the turn \n");
                GoToNextTurn();
            }
            else if (dialogResult == DialogResult.No)
            {
                // do nothing;
            }

        }
        /// <summary>
        /// When Skill button is pressed open a diolog
        /// to select the target
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skillBtn_Click(object sender, EventArgs e)
        {
            if (selected.Unit.SkillPoints > 0)
            {
                if (selected.Unit.Name == "Cleric")
                {
                    skillMessage = new SkillDialogue(heroes, selected, this);
                    skillMessage.ShowDialog(this);
                }
                else
                {
                    skillMessage = new SkillDialogue(monsters, selected, this);
                    skillMessage.ShowDialog(this);
                }
            }
            else
            {
                MessageBox.Show("Out of Skill points");
            }
        }
        /// <summary>
        /// increment turn and either go to next round or next to take an action
        /// also if all mosnters dead go to next room or if all heroes are dead game over or restart
        /// </summary>
        public void GoToNextTurn()
        {
            UpdateRoom();
            turn += 1;
            if (RoomClear() == true)
            {
                // go to new room
                Console.WriteLine("room Cleared");
                eventList.AppendText("Room Cleard! goning to next room. \n");
                roomsCleared += 1;
                GoToNextRoom(heroes, GetMonsters(rng.Next(1, 10)));
                this.Update();
                attackBtn.Visible = true;
                defendBtn.Visible = true;
                skillBtn.Visible = true;
                GoToNextRound();
            }
            else if (HeroesDead() == true)
            {
                // game over
                Console.WriteLine("game over");
                DialogResult result = MessageBox.Show("Your party has perished\n venture again?", "Game Over", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    roomsCleared = 0;
                    eventList.Clear();
                    GoToNextRoom(GetHeroes(3), GetMonsters(rng.Next(1, 10)));
                    this.Update();
                    attackBtn.Visible = true;
                    defendBtn.Visible = true;
                    skillBtn.Visible = true;
                    GoToNextRound();
                }
                else if (result == DialogResult.No)
                {
                    this.Close();
                }
            }
            else
            {
                if (turn >= turnOrder.Count)
                {
                    System.Threading.Thread.Sleep(1000);
                    GoToNextRound();
                }
                else
                {
                    ChangeSelected(selected, turnOrder[turn]);
                }
            }
            this.Update();
            

        }
        /// <summary>
        /// once gone through entire turnOrder list reset the list and start new round
        /// </summary>
        private void GoToNextRound()
        {
            turn = 0;
            turnOrder = SetTurnOrder(heroes, monsters);
            this.Update();
            ChangeSelected(selected, turnOrder[turn]);
        }
        /// <summary>
        /// Check to see if all mosters are dead
        /// </summary>
        /// <returns></returns>
        private bool RoomClear()
        {
            bool isClear = true;
            for (int i = 0; i < monsters.GetLength(0); i++)
            {
                if (monsters[i].Unit.IsAlive == true)
                {
                    isClear = false;
                }
            }
            return isClear;
        }
        /// <summary>
        /// check to see if all heroes are dead
        /// </summary>
        /// <returns></returns>
        private bool HeroesDead()
        {
            bool areDead = true;
            for (int i = 0; i < heroes.GetLength(0); i++)
            {
                if (heroes[i].Unit.IsAlive == true)
                {
                    areDead = false;
                }
            }
            return areDead;
        }
        /// <summary>
        /// update all of the health bars 
        /// </summary>
        private void UpdateRoom()
        {
            for (int i = 0; i < turnOrder.Count(); i++)
            {
                turnOrder[i].UpdateInfo();
            }
            
        }
        /// <summary>
        /// go to the next room 
        /// </summary>
        /// <param name="newHeroes"></param>
        /// <param name="newMonsters"></param>
        private void GoToNextRoom(CharacterDisplay[] newHeroes, CharacterDisplay[] newMonsters)
        {
            
            for (int i = 0; i < heroes.GetLength(0); i++)
            {
                room.Controls.Remove(heroes[i]);
            }
            for (int i = 0; i < monsters.GetLength(0); i++)
            {
                room.Controls.Remove(monsters[i]);
            }
            heroes = newHeroes;
            monsters = newMonsters;
            room.BackgroundImage = Properties.Resources.stoneWall;
            for (int i = 0; i < heroes.GetLength(0); i++)
            {
                room.Controls.Add(heroes[i]);
            }
            for (int i = 0; i < monsters.GetLength(0); i++)
            {
                room.Controls.Add(monsters[i]);
            }
            
        }
        /// <summary>
        /// refrence to the textbox
        /// </summary>
        public TextBox EventList
        {
            get
            {
                return eventList;
            }
        }
        /// <summary>
        /// exit the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// open message box with some stats
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"you have cleared {roomsCleared} rooms");
        }
    }
}
