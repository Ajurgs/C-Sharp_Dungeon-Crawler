using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    class Dragon : Monster
    {
        string type = "Monster";
        string name = "Dragon";
        int speed = 1;
        int strength = 10;
        int inteligence = 10;
        int defence = 6;
        int hitPointsMax = 50;
        int hitPointsCurrent;
        int skillPoints = 4;
        bool isAlive = true;
        bool isDefending = false;
        bool isBuffed = false;
        bool isStuned = false;

        public Dragon()
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
        public override bool IsStuned
        {
            get
            {
                return isStuned;
            }
            set
            {
                isStuned = value;
            }
        }
        /// <summary>
        /// randomly choose what action to take
        /// </summary>
        /// <param name="targets"></param>
        /// <param name="from"></param>
        public override void TakeAction(CharacterDisplay[] targets, Dungeon from)
        {
            base.TakeAction(targets, from);
            Random rng = new Random((int)DateTime.Now.Millisecond);
            int act = rng.Next(0, 3);
            switch (act)
            {
                case 0:
                    // attack
                    Attack(GetTarget(targets).Unit);
                    from.EventList.AppendText($"{name} attacked {GetTarget(targets).Unit.Name} \n");
                    break;
                case 1:
                    // defend
                    Defend();
                    from.EventList.AppendText($"{name} defended for the turn \n");
                    break;
                case 2:
                    // skill
                    if (skillPoints <= 0)
                    {
                        // attack
                        goto case 0;
                    }
                    else
                    {
                        // use skill
                        Skill(targets);
                        from.EventList.AppendText($"{name} used fire breath \n");
                    }
                    break;
            }
        }
        /// <summary>
        /// attack the target
        /// </summary>
        /// <param name="target"></param>
        public override void Attack(Character target)
        {
            base.Attack(target);
            int damage = strength + (inteligence / 4);
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
        /// <summary>
        /// use fire breath attck
        /// </summary>
        /// <param name="targets"></param>
        public void Skill(CharacterDisplay[] targets)
        {
            Console.WriteLine("Dragon used skill");
            int damage = inteligence / 3;
            for (int i = 0; i < targets.GetLength(0); i++)
            {
                targets[i].Unit.HitPointsCurrent -= damage;
            }
            skillPoints -= 1;
        }
    }
}
