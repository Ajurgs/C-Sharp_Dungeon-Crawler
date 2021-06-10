using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    class Cleric : Hero
    {
        string type = "Hero";
        string name = "Cleric";
        int speed = 5;
        int strength = 6;
        int inteligence = 5;
        int defence = 4;
        int hitPointsMax = 20;
        int hitPointsCurrent;
        int skillPoints = 15;
        bool isAlive = true;
        bool isDefending = false;
        bool isBuffed = false;

        public Cleric()
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
        public override int HitPointsMax
        {
            get
            {
                return hitPointsMax;
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
            base.Attack(target);
            int damage = strength + (inteligence / 4);
            target.PrevHp = target.HitPointsCurrent;
            if (target.IsDefending == true)
            {
                target.HitPointsCurrent -= (damage - (target.Defence));
            }
            else
            {
                target.HitPointsCurrent -= (damage - (target.Defence / 2));
            }
            Console.WriteLine($"{name} did {damage} target is at {target.HitPointsCurrent} health");
        }
        public override void Defend()
        {
            base.Defend();
            isDefending = true;
        }
        public override void Skill(Character target)
        {
            base.Skill(target);
            int healthReturned = inteligence;
            target.HitPointsCurrent += healthReturned;
            if (target.HitPointsCurrent >= target.HitPointsMax)
            {
                target.HitPointsCurrent = target.HitPointsMax;
            }
            target.IsAlive = true;
            skillPoints -= 1;
        }
    }
}
