using System;

namespace wizardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Baldur = new Human("Baldur");
            Wizard Zinbella = new Wizard("Zinbella");
            Ninja Wayward = new Ninja("Wayward the Witless");
            Samurai Tabatha = new Samurai("Tabatha the Titan");
            Console.WriteLine(Baldur.Attack(Zinbella));
            Console.WriteLine(Zinbella.WizAttack(Tabatha));
            Console.WriteLine(Wayward.NinjaAttack(Baldur));
            Console.WriteLine(Tabatha.Attack(Wayward));
            Console.WriteLine(Zinbella.Heal(Wayward));
            Console.WriteLine(Tabatha.Meditate());
            Console.WriteLine(Wayward.Steal(Baldur));
        }
    }
    class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        protected int health;
         
        public int Health
        {
            get { return health; }
            set { health = value;}
        }
        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }
         
        public Human(string name, int str, int intel, int dex, int hp)
        {
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            health = hp;
        }
         
        // Build Attack method
        public virtual string Attack(Human target)
        {
            int dmg = Strength * 3;
            target.health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} with {dmg} damage!");
            return $"{target.Name} is at {target.health} hit points";
        }
    }

    class Wizard : Human
    {
        public Wizard(string name) : base(name)
        {
            Name = name;
            Intelligence = 25;
            health = 50;
        }
        public string WizAttack(Human target)
        {
            int dmg = Intelligence * 5;
            target.Health -= dmg;
            Health += dmg;
            Console.WriteLine($"{Name} attacked {target.Name} with {dmg} damage!");
            return $"{target.Name} is at {target.Health} hit points";
        }

        public string Heal(Human target)
        {
            int heal = Intelligence * 10;
            target.Health += heal;
            Console.WriteLine($"{Name} healed {target.Name} {heal} hit point's!");
            return $"{Name} is at {Health} hit points";
        }
    }

    class Ninja : Human
    {
        public Ninja(string name) : base(name)
        {
            Name = name;
            Dexterity = 75;
        }

        public string NinjaAttack(Human target)
        {
            Random rand = new Random();
            int dmg = Dexterity * 5;
            target.Health -= dmg;
            int extraDmg= rand.Next(1,10);
            Console.WriteLine($"{Name} attacked {target.Name} with {dmg} damage!");
            if (extraDmg <= 2)
            {
                target.Health -= 10;
                Console.WriteLine($"{Name} delt 10 extra damage!");
            }
            return $"{target.Name} is at {target.Health} hit points";
        }
        public string Steal(Human target)
        {
            int dmg = 5;
            target.Health -= dmg;
            Health += dmg;
            Console.WriteLine($"{Name} stole {target.Name}'s health and healed {dmg} hit points!");
            return $"{target.Name} is at {target.Health} hit points";
        }
    }

    class Samurai : Human
    {
        public Samurai(string name) : base(name)
        {
            Name = name;
            health = 200;
        }
        public override string Attack(Human target)
        {
            base.Attack(target);
            if (target.Health > 50) 
            {
                target.Health = 0;
                Console.WriteLine($"{Name} got a criticl hit, {target.Name}'s health plummented to zero!!");
            }
            return $"{target.Name} is at {target.Health} hit points";
        }
        public string Meditate()
        {
            Health = 200;
            Console.WriteLine($"{Name} healed to full health!");
            return $"{Name} is at {Health} hit points";
        }
    }
}
