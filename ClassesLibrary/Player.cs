using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibrary
{
    public sealed class Player : Character 
    {

        //fields
        //None

        //properties
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }

        //ctors - FQ
        public Player(string name, int hitChance, int block, int life, int maxLife, Race characterRace, Weapon equippedWeapon)
        {
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
        }

        //methods
        public override string ToString()
        {
            return string.Format("-=-= {0} the {6} =-=-\n" +
                "Life: {1} of {2}\n" +
                "Equipped Weapon: {3}\n" +
                "Accuracy: {4}%\n" +
                "Evasion: {5}\n",
                Name, Life, MaxLife, EquippedWeapon.Name, HitChance, Block, CharacterRace);
        }

        public override int CalcDamage()
        {
            Random rand = new Random();
            int damage = EquippedWeapon.BodyDamage;
            return damage;
        }
        public override int CalcCrit()
        {
            int damage = EquippedWeapon.BodyDamage;
            return damage;
        }
        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }
    }
}

