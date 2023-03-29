using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz1_27._03
{
    class Program
    {
        public abstract class Professsion
        {
            public string Name { get; set; }
            public int Attack { get; set; }
            public int Speed { get; set; }
            public int Health { get; set; }
            public int Protection { get; set; }
            public abstract string Operation();
            public string ToString()
            {
                return $"Название профессии: {Name}\nАтака: {Attack}\nСкорость: {Speed}\nЗдоровье: {Health}\nЗащита: {Protection}";
            }
        }
        class Human : Professsion
        {

            public override string Operation()
            {
                Name = "Человек";
                Attack += 20;
                Speed += 20;
                Health += 150;
                Protection += 0;
                return ToString();
            }
        }
        class Elf : Professsion
        {
            public override string Operation()
            {
                Name = "Ельф";
                Attack += 15;
                Speed += 30;
                Health += 100;
                Protection += 0;
                return ToString();
            }
        }
        abstract class Decorator : Professsion
        {
            protected Professsion professsion;

            public Decorator(Professsion professsion)
            {
                this.professsion = professsion;
            }

            public void SetProfesssion(Professsion professsion)
            {
                this.professsion = professsion;
            }
            public override string Operation()
            {

                if (professsion != null)
                    return ToString();
                else
                    return null;
            }
        }

        class ManWarrior : Human
        {
            public ManWarrior(Human human)
            {
                Name = "Человек воин";
                Attack += 20;
                Speed = human.Speed + 10;
                Health = human.Health + 50;
                Protection = human.Protection + 20;
            }
            public override string Operation()
            {
                return $"{ToString()}";
            }
        }
        class Swordsman : Human
        {
            public Swordsman(ManWarrior human)
            {
                Name = "Меченосец";
                Attack = human.Attack + 40;
                Speed = human.Speed - 10;
                Health = human.Health + 50;
                Protection = human.Protection + 40;
            }

            public override string Operation()
            {
                return $"{ToString()}";
            }
        }
        class Archer : Human
        {
            public Archer(ManWarrior human)
            {
                Name = "Лучник";
                Attack = human.Attack + 20;
                Speed = human.Speed + 20;
                Health = human.Health + 50;
                Protection = human.Protection + 10;
            }

            public override string Operation()
            {
                return $"{ToString()}";
            }
        }
        class Rider : Human
        {
            public Rider(Swordsman human)
            {
                Name = "Всадник";
                Attack = human.Attack - 10;
                Speed = human.Speed + 40;
                Health = human.Health + 200;
                Protection = human.Protection + 100;
            }

            public override string Operation()
            {
                return $"{ToString()}";
            }
        }

        class ElfWarrior : Elf
        {
            public ElfWarrior(Elf elf)
            {
                Name = "Эльф воин";
                Attack = elf.Attack + 20;
                Speed = elf.Speed - 10;
                Health = elf.Health + 100;
                Protection = elf.Protection + 20;
            }
            public override string Operation()
            {
                return $"{ToString()}";
            }
        }
        class ElfMage : Elf
        {
            public ElfMage(Elf elf)
            {
                Name = "Эльф маг";
                Attack = elf.Attack + 10;
                Speed = elf.Speed + 10;
                Health = elf.Health - 50;
                Protection = elf.Protection + 10;
            }
            public override string Operation()
            {
                return $"{ToString()}";
            }
        }
        class Crossbowman : Elf
        {
            public Crossbowman(ElfWarrior elf)
            {
                Name = "Арбалетчик";
                Attack = elf.Attack + 20;
                Speed = elf.Speed + 10;
                Health = elf.Health + 50;
                Protection = elf.Protection - 10;
            }
            public override string Operation()
            {
                return $"{ToString()}";
            }
        }
        class EvilMage : Elf
        {
            public EvilMage(ElfMage elf)
            {
                Name = "Злой маг";
                Attack = elf.Attack + 70;
                Speed = elf.Speed + 20;
                Health = elf.Health + 0;
                Protection = elf.Protection + 0;
            }
            public override string Operation()
            {
                return $"{ToString()}";
            }
        }
        class KindMage : Elf
        {
            public KindMage(ElfMage elf)
            {
                Name = "Добрый маг";
                Attack = elf.Attack + 50;
                Speed = elf.Speed + 30;
                Health = elf.Health + 100;
                Protection = elf.Protection + 30;
            }
            public override string Operation()
            {
                return $"{ToString()}";
            }
        }
        public class Client
        {
            public void ClientCode(Professsion Professsion)
            {
                Console.WriteLine(Professsion.Operation());
            }
        }
        static void Main(string[] args)
        {
            Client client = new Client();
            Human human = new Human();
            client.ClientCode(human);
            ManWarrior warrior = new ManWarrior(human);
            client.ClientCode(warrior);
            Swordsman swordsman = new Swordsman(warrior);
            client.ClientCode(swordsman);
            Rider rider = new Rider(swordsman);
            client.ClientCode(rider);
            Elf elf = new Elf();
            client.ClientCode(elf);
            ElfWarrior warrior1 = new ElfWarrior(elf);
            client.ClientCode(warrior1);
            ElfMage mage = new ElfMage(elf);
            client.ClientCode(mage);
            Crossbowman crossbowman = new Crossbowman(warrior1);
            client.ClientCode(crossbowman);
            EvilMage evil = new EvilMage(mage);
            client.ClientCode(evil);
            KindMage kind = new KindMage(mage);
            client.ClientCode(kind);
        }
    }
}
