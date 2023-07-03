using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes_of_Battles
{
    class Program
    {
        static void Main(string[] args)
        {
            Fighter[] figters =
            {
                new Fighter("Джон", 250, 50, 0),
                new Fighter("Марк", 250, 25, 20),
                new Fighter("Алекс", 150, 100, 10),
                new Fighter("Джек", 300, 75, 5),
            };

            int fighterNumber;


            for (int i = 0; i < figters.Length; i++)
            {
                Console.Write((i + 1) + " ");
                figters[i].ShowStats();
            }

            Console.WriteLine("\n** " + new string('-', 25) + " **");
            Console.Write("\n Выберите номер первого бойца:");
            fighterNumber = Convert.ToInt32(Console.ReadLine()) - 1;
            Fighter firstFighter = figters[fighterNumber];

            Console.WriteLine("\n** " + new string('-', 25) + " **");
            Console.Write("\n Выберите номер второго бойца:");
            fighterNumber = Convert.ToInt32(Console.ReadLine()) - 1;
            Fighter secondFighter = figters[fighterNumber];

            while (firstFighter.Health > 0 && secondFighter.Health > 0)
            {
                firstFighter.TakeDamage(secondFighter.Damage);
                firstFighter.TakeDamage(firstFighter.Damage);
                firstFighter.ShowStats();
                secondFighter.ShowStats();
            }
        }

    }

    class Fighter
    {
        private string _name;
        private int _health;
        private int _armor;
        private int _damage;

        public int Health
        {
            get
            {
                return _health;
            }
        }
        public int Damage
        {
            get
            {
                return _damage;
            }
        }

        public Fighter(string name, int health, int armor, int damage)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _armor = armor;
        }
        public void ShowStats()
        {
            Console.WriteLine($"Боец - {_name}, здоровье: {_health}, наносимый урон: {_damage}, броня: {_armor}");
        }

        public void ShowCurrentHealth()
        {
            Console.WriteLine($"{_name} здоровье: {_health}");
        }

        public void TakeDamage(int damage)
        {
            _health -= damage - _armor;
        }
    }
}
