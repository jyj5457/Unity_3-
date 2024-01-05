using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 프로그래밍_기초_개인과제
{
    class Program
    {
        public static Character player;
        //public static Equipment[] _equipment;
        public static List<Equipment> equipmentList = new List<Equipment>();

        static void Main(string[] args)
        {
            GameDateSetting();
            GameIntro();

        }

        static void GameDateSetting()
        {
            //캐릭터 정보
            player = new Character("Chad", "전사", 01, 10, 5, 100, 1500);
            //아이템 정보
            equipmentList.Add(new Equipment("", "무쇠갑옷", "방어력", 5, 0, "무쇠로 만들어져 튼튼한 갑옷입니다."));
            equipmentList.Add(new Equipment("", "스파르타의 창", "공격력", 7, 0, "스파르타 전사들이 사용했다는 전설의 창입니다."));
            equipmentList.Add(new Equipment("", "낡은 검", "공격력", 2, 0, "쉽게 볼 수 있는 낡은 검입니다."));
            //_equipment = new Equipment[10];
            //AddItem(new Equipment("", "무쇠갑옷", "방어력", 5, 0, "무쇠로 만들어져 튼튼한 갑옷입니다."));
            //AddItem(new Equipment("", "스파르타의 창", "공격력", 7, 0, "스파르타 전사들이 사용했다는 전설의 창입니다."));
            //AddItem(new Equipment("", "낡은 검", "공격력", 2, 0, "쉽게 볼 수 있는 낡은 검입니다."));

            //steelA = new Equipment("","무쇠갑옷", "방어력", 5, 0, "무쇠로 만들어져 튼튼한 갑옷입니다.");
            //spartaS = new Equipment("","스파르타의 창", "공격력", 7, 0,"스파르타 전사들이 사용했다는 전설의 창입니다.");
            //oldS = new Equipment("","낡은 검", "공격력", 2, 0, "쉽게 볼 수 있는 낡은 검입니다.");
        }
        //static void AddItem(Equipment equipment)
        //{
        //    if (Equipment.EquipmentCnt == 10) return;
        //    _equipment[Equipment.EquipmentCnt] = equipment;
        //    Equipment.EquipmentCnt++;

        //}

        public class Character
        {
            public string Name { get; }
            public string Job { get; }
            public int Level { get; }
            public int Atk { get; }
            public int Def { get; }
            public int Hp { get; }
            public int Gold { get; }

            public Character(string name, string job, int level, int atk, int def, int hp, int gold)
            {
                Name = name;
                Job = job;
                Level = level;
                Atk = atk;
                Def = def;
                Hp = hp;
                Gold = gold;
            }
        }
        public class Equipment
        {
            public string Equiped { get; set; }
            public string eName { get; }
            public string eType { get; }
            public int eStat { get; }
            public int eGold { get; }
            public string eExp { get; }
            public static int EquipmentCnt = 0;


            public Equipment(string equiped, string Ename, string Etype, int Estat, int Egold, string Eexp)
            {
                Equiped = equiped;
                eName = Ename;
                eType = Etype;
                eStat = Estat;
                eGold = Egold;
                eExp = Eexp;
            }
        }
        class Inven
        {
            public List<Equipment> equipmentList;

            public Inven()
            {
                equipmentList = new List<Equipment>();
            }

            public void Items(Equipment equipment)
            {
                equipmentList.Add(equipment);
            }

        }
        static void GameIntro()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PlayerInfo();
                    break;

                case "2":
                    PlayerItem();
                    break;

                case "3":
                    Store();
                    break;

                default:     // 생략 가능
                    Console.WriteLine("올바른 값을 입력해주세요.");
                    break;
            }
            Console.WriteLine("게임을 종료합니다.");
        }

        static void PlayerInfo()
        {
            Console.Clear();
            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine("Lv. " + player.Level);
            Console.WriteLine($"{player.Name} ( {player.Job} )");
            Console.WriteLine("공격력 : " + player.Atk);
            Console.WriteLine("방어력 : " + player.Def);
            Console.WriteLine("체력 : " + player.Hp);
            Console.WriteLine("Gold : {0} G", player.Gold);
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            string choice1 = Console.ReadLine();

            if (choice1 == "0")
            {
                GameIntro();
            }
        }

        static void PlayerItem()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            string choice1 = Console.ReadLine();

            if (choice1 == "0")
            {
                GameIntro();
            }
            else if (choice1 == "1")
            {
                PlayerItemInfo();
            }

            void PlayerItemInfo()
            {

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("인벤토리 - 장착관리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                foreach (var equipment in equipmentList)
                {
                    Console.WriteLine(equipment);
                }
                //Console.WriteLine($"- 1 {steelA.Name}      | {steelA.Type} +{steelA.Stat} | {steelA.Exp}");
                //Console.WriteLine($"- 2 {spartaS.Name} | {spartaS.Type} +{spartaS.Stat} | {spartaS.Exp}");
                //Console.WriteLine($"- 3 {oldS.Name}       | {oldS.Type} +{oldS.Stat} | {oldS.Exp}");
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("장착할 장비의 번호를 입력해 주세요");
                Console.Write(">> ");
                string choice2 = Console.ReadLine();

                switch (choice2)
                {
                    case "0":
                        PlayerItem();
                        break;

                    case "1":

                        break;

                    case "2":

                        break;

                    case "3":

                        break;

                    default:     // 생략 가능
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }

            }



        }

        static void Store()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("상점");
            string choice1 = Console.ReadLine();

            if (choice1 == "0")
            {
                GameIntro();
            }
        }
    }

    

    
}

