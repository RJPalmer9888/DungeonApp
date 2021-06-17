using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibrary
{
    public class Monster : Character
    {
        //fields
        private int _minDamage;

        //props
        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }

        //ctors
        public Monster() { }

        public Monster(string name, int life, int maxLife, int hitChance, int block,
            int minDamage, int maxDamage, string description)
        {
            MaxLife = maxLife;
            MaxDamage = maxDamage;
            Name = name;
            Life = life;
            HitChance = hitChance;
            Block = block;
            MinDamage = minDamage;
            Description = description;
        }

        //methods
        public override string ToString()
        {
            return string.Format("***** {0} *****\n" +
                "Life: {1} of {2}\n" +
                "Damage: {3} to {4}\n" +
                "Evasion: {5}\n" +
                "{6}\n",
                Name, Life, MaxLife, MinDamage, MaxDamage, Block, Description);
        }

        public override int CalcDamage()
        {
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);
        }
        public override int CalcCrit()
        {
            return (MaxDamage + 5);
        }
    }
}
