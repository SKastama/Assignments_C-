using System;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human human1 = new Human("Name1");
            Human human2 = new Human("Name2", 4, 4, 4, 140);
            Console.WriteLine(human1.Attack(human2));
            Console.WriteLine(human2.Attack(human1));
        }
        
    }
    class Human
    {
        // Fields for Human
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        private int health;
         
        // add a public "getter" property to access health
        public int Health
        {
            get { return health; }
        }

        // Add a constructor that takes a value to set Name, and set the remaining fields to default values
        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }

        // Add a constructor to assign custom values to all fields
        public Human(string name, int str, int intel, int dex, int hp)
        {
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            health = hp;
        }


        // Build Attack method
        public int Attack(Human target)
        {
            int damage = Strength * 5;
            target.health -= damage;
            Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage!");
            return target.health;
        }
    }


}
