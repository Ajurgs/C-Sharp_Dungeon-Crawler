using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class Hero : Character
    {
        string type = "Hero";
        string name = "Hero";
        int speed = 5;
        int strength = 5;
        int inteligence = 5;
        int defence = 5;
        int hitPointsMax = 10;
        int hitPointsCurrent;
        int skillPoints = 10;
        bool isAlive = true;
        bool isDefending = false;
        bool isBuffed = false;

        public Hero()
        {
            hitPointsCurrent = hitPointsMax;
        }
        public override string Type
        {
            get
            {
                return type;
            }
        }
        public override string Name
        {
            get
            {
                return name;
            }
        }
        public override int Speed
        {
            get
            {
                return speed;
            }
        }
        public override int Strength
        {
            get
            {
                return strength;
            }
        }
        public override int Inteligence
        {
            get
            {
                return inteligence;
            }
        }
        public override int Defence
        {
            get
            {
                return defence;
            }
        }
        public override int HitPointsCurrent
        {
            get
            {
                return hitPointsCurrent;
            }

            set
            {
                hitPointsCurrent = value;
                if (hitPointsCurrent > hitPointsMax)
                {
                    hitPointsCurrent = hitPointsMax;
                }
                if (hitPointsCurrent <= 0)
                {
                    hitPointsCurrent = 0;
                    isAlive = false;
                }
            }
        }
        public override bool IsAlive
        {
            get
            {
                return isAlive;
            }

            set
            {
                isAlive = value;
            }
        }
        public override bool IsDefending
        {
            get
            {
                return isDefending;
            }
            set
            {
                isDefending = value;
            }
        }
        public override bool IsBuffed
        {
            get
            {
                return isBuffed;
            }
            set
            {
                isBuffed = value;
            }
        }
        public override int SkillPoints
        {
            get
            {
                return skillPoints;
            }
            set
            {
                skillPoints = value;
            }
        }
        public override void Attack(Character target)
        {
            Console.WriteLine($"{name} attacked {target}");
        }
        public override void Defend()
        {
            Console.WriteLine($"{Name} defended");
        }
        public override void Skill(Character target)
        {
            Console.WriteLine($"{name} used skill on {target}");
        }
        
    }
}
