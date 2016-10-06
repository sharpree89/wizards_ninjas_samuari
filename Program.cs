using System;

namespace ConsoleApplication_WizardNinjaSamurai
{
    public class Human
    {
        public string name;
        //The { get; set; } format creates accessor methods for the field specified
        //This is done to allow flexibility
        public int health { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }

        public Human(string person)
        {
            name = person;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
        }
        public Human(string person, int str, int intel, int dex, int hp)
        {
            name = person;
            strength = str;
            intelligence = intel;
            dexterity = dex;
            health = hp;
        }
        public void attack(object obj)
        {
            if (obj.GetType() == typeof(Human))
            {
                var enemy = obj as Human;
                enemy.health -= strength * 5;
            }
            else
            {
                Console.WriteLine("Failed Attack");
            }
        }
    }
    public class Samurai : Human
    {
        public int health = 200;

        public Samurai(string person) : base(person)
        {

        }
        public int DeathBlow(Human user)
        {
            if(user.health <=50){
                user.health = 0;
                Console.WriteLine(name + " uses Death Blow! " + user.name + " is dead!");
            }
            else{
                Console.WriteLine(user.name + "'s health is too high to use Death Blow!");
            }
            return (int)health;
        }
        public int Meditate()
        {
            health = 200;
            Console.WriteLine(name + " meditates and is back to full health!");
            return (int)health;
        }
    }

    public class Ninja : Human
    {
        public int dexterity = 175;

        public Ninja(string person) : base(person)
        {

        }
        public int Steal(Human user)
        {
            health += 10;
            Console.WriteLine(name + " is stealing from " + user.name + 
            "! " + name + " now has " + health + " HP.");
            return (int)health;
        }
        public int GetAway()
        {
            health -= 60;
            Console.WriteLine(name + " is getting away! " + name + " now has " + health + " HP.");
            return (int)health;
        }
    }
    public class Wizard : Human
    {
        public int intelligence = 25;
        public int health = 50;
       
       public Wizard(string person) : base(person)
       {

       }
       public int Heal(Human user)
       {
            Console.WriteLine(name + " is healing " + user.name);
            int heal = intelligence * 10;
            user.health += heal;
            Console.WriteLine(user.name + " receives " + heal + " health and now has " + user.health + " HP!");
            return (int)health;
       }
       public int FireBall(Human user)
        {
            Console.WriteLine(name + " uses FireBall on " + user.name + "!");
            Random rand = new Random();
            int damage = rand.Next(50,250);
            user.health -= damage;
            Console.WriteLine(user.name + " receives " + damage + " damage from " + name + "'s FireBall and has " + user.health + " HP left!");
            return (int)health;
        }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            Wizard wizardA = new Wizard("Gandalf");
            Wizard wizardB = new Wizard("Saruman");
            wizardA.Heal(wizardB);
            wizardB.FireBall(wizardA);
            wizardA.FireBall(wizardB);
            wizardA.FireBall(wizardB);
            Ninja ninjaA = new Ninja("Prince Poo");
            ninjaA.Steal(wizardB);
            ninjaA.GetAway();           
            Samurai samuraiA = new Samurai("Yoshi");
            samuraiA.DeathBlow(wizardB);
            samuraiA.Meditate();
        }
    }
}
}
