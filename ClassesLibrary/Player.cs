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
        private int _ghostConfidence;

        //properties
        public Race CharacterRace { get; set; }
        public TClass PClass { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public int Experience { get; set; }
        public int GhostConfidence
        {
            get { return _ghostConfidence; }
            set
            {
                if (value > 0 && value <= 100)
                {
                    _ghostConfidence = value;
                }
                else
                {
                    _ghostConfidence = 100;
                }
            }
        }
        public int Recovery { get; set; }

        //ctors - FQ
        public Player(string name, int hitChance, int block, int life, int maxLife,
            Race characterRace, TClass pclass ,Weapon equippedWeapon, int experience, int ghostConfidence, int recovery)
        {
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            CharacterRace = characterRace;
            PClass = pclass;
            EquippedWeapon = equippedWeapon;
            Experience = experience;
            GhostConfidence = ghostConfidence;
            Recovery = recovery;
        }

        //methods
        public string GetGhostConfidence()
        {
            if (GhostConfidence < 25)
            {
                return "Afraid";
            }
            if (GhostConfidence >= 25 && GhostConfidence < 50)
            {
                return "Timid";
            }
            if (GhostConfidence >= 50 && GhostConfidence < 75)
            {
                return "Ready";
            }
            else
                return "Steadfast";
        }
        public override string ToString()
        {
            return string.Format("-=-= {0} the {6}, {10} =-=-\n" +
                "Life: {1} of {2}\n" +
                "Recovery: {9}\n" +
                "Equipped Weapon: {3}\n" +
                "Accuracy: {4}%\n" +
                "Evasion: {5}%\n" +
                "Experience {7}/100\n" +
                "Ghost Status: {8}",
                Name, Life, MaxLife, EquippedWeapon.Name, HitChance, Block, CharacterRace, Experience,
                GetGhostConfidence(),Recovery, PClass);
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

