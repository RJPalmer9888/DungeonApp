using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibrary
{

    public abstract class Character
    {

        //fields
        private int _life;

        //properties
        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxLife { get; set; }
        public int Life
        {
            get { return _life; }
            set
            {
                if (value <= MaxLife)
                {
                    _life = value;
                }
                else
                {
                    _life = MaxLife;
                }
            }
        }
        //ctors
        public virtual int CalcBlock()
        {
            return Block;
        }

        public virtual int CalcHitChance()
        {
            return HitChance;
        }

        public virtual int CalcDamage()
        {
            return 0;
        }

        public virtual int CalcCrit()
        {
            return 0;
        }
    }
}
