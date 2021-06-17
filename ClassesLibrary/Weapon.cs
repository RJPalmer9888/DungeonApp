using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibrary
{
    public class Weapon
    {
        //fields

        //properties
        public int BodyDamage { get; set; }
        public int CritDamage { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BonusHitChance { get; set; }
        public bool Disintegrator { get; set; }
        public bool IsObtained { get; set; }

        //ctors
        public Weapon(int bodyDamage, int critDamage, string name, int bonusHitChance, bool disintegrator, bool isObtained, string description)
        {
            BodyDamage = bodyDamage;
            CritDamage = critDamage;
            Name = name;
            Description = description;
            BonusHitChance = bonusHitChance;
            Disintegrator = disintegrator;
            IsObtained = isObtained;
        }

        //methods
        public override string ToString()
        {
            return string.Format("{0}\n{5}\nDamage: {1} Body / {2} Critical \n" +
                "Accuracy: {3}%\t{4}",
                Name, BodyDamage, CritDamage, BonusHitChance,
                Disintegrator ? "Disintegrator" : "Conventional",
                Description);
        }

    }
}
