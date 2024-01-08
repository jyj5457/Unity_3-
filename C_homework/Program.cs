using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_homework
{
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
    public class Item
    {
        public string Name { get; }
        public string Description { get; }
        public int Type { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public bool IsEquipped { get; set; }

        public static int ItemCnt = 0;
        public Item(string name, string description, int type, int atk, int def, int hp, bool isEquipped = false)
        {
            Name = name;
            Description = description;
            Type = type;
            Atk = atk;
            Def = def;
            Hp = hp;
            IsEquipped = isEquipped;
        }

            public void PrintItemStatDescription(bool withNumber = false, int idx = 0)
        {
            Console.Write("-");
            if (withNumber)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("{0} ", idx);
                Console.ResetColor();
            }
            if (IsEquipped)
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("E");
                Console.ResetColor();
                Console.Write("]");
                Console.Write(PadRightForMixedText(Name, 12));
            }
            else Console.Write(PadRightForMixedText(Name, 15));
            Console.Write(" | ");

            if (Atk != 0) Console.Write($"Atk {(Atk >= 0 ? "+" : "")}{Atk} ");
            if (Def != 0) Console.Write($"Def {(Def >= 0 ? "+" : "")}{Def} ");
            if (Hp != 0) Console.Write($"Hp {(Hp >= 0 ? "+" : "")}{Hp} ");

            Console.Write(" | ");
            Console.WriteLine(Description);
        }

        public void PrintStoerDescription(bool withNumber = false, int idx = 0)
        {
            Console.Write("-");
            if (withNumber)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("{0} ", idx);
                Console.ResetColor();
            }
            if (IsEquipped)
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("구매완료");
                Console.ResetColor();
                Console.Write("]");
                Console.Write(PadRightForMixedText(Name, 13));
            }
            else Console.Write(PadRightForMixedText(Name, 16));
            Console.Write(" | ");

            if (Atk != 0) Console.Write($"Atk {(Atk >= 0 ? "+" : "")}{Atk} ");
            if (Def != 0) Console.Write($"Def {(Def >= 0 ? "+" : "")}{Def} ");
            if (Hp != 0) Console.Write($"Hp {(Hp >= 0 ? "+" : "")}{Hp} ");

            Console.Write(" | ");
            Console.WriteLine(Description);
        }

        public static int GetPrintableLength(string str)
        {
            int length = 0;
            foreach (char c in str)
            {
                if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
                {
                    length += 2;
                }
                else
                {
                    length += 1;
                }
            }
            return length;
        }

        private string PadRightForMixedText(string str, int totalLength)
        {
            int currentLength = GetPrintableLength(str);
            int padding = totalLength - currentLength;
            return str.PadRight(str.Length + padding);
        }
    }



    class Program
    {
        public static Character _player;
        static Item[] _items;
        //public static Equipment[] _equipment;
        //public static List<Equipment> equipmentList = new List<Equipment>();
        //public static Inven equipInven;

        static void Main(string[] args)
        {
            GameDateSetting();
            PrintStartLogo();
            StartMenu();

        }

        private static void StartMenu()
        {
            Console.Clear();
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("");

            switch (CheckValidInput(1, 3))
            {
                case 1:
                    StatusMenu();
                    break;
                case 2:
                    InventoryMenu();
                    break;
                case 3:
                    StoreMenu();
                    break;

            }

        }

        private static void StoreMenu()
        {
            Console.Clear();
            ShowHighlightedText(" ■ 상점 ■");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(_player.Gold + "G");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < Item.ItemCnt; i++)
            {
                _items[i].PrintStoerDescription();
            }
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("");
            switch (CheckValidInput(0, 1))
            {
                case 0:
                    StartMenu();
                    break;
                case 1:
                    BuyMenu();
                    break;
            }
        }

        private static void BuyMenu()
        {
            Console.Clear();

            ShowHighlightedText("■ 상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(_player.Gold + "G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < Item.ItemCnt; i++)
            {
                _items[i].PrintStoerDescription(true, i + 1);
            }
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");

            int keyInput = CheckValidInput(0, Item.ItemCnt);

            switch (keyInput)
            {
                case 0:
                    StoreMenu();
                    break;
                default:
                    ToggleEquipStatus(keyInput - 1);
                    BuyMenu();
                    break;
            }

        }

        private static void InventoryMenu()
        {
            Console.Clear();

            ShowHighlightedText(" ■ 인벤토리 ■");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < Item.ItemCnt; i++)
            {
                _items[i].PrintItemStatDescription();
            }
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("1. 장착관리");
            Console.WriteLine("");
            switch (CheckValidInput(0, 1))
            {
                case 0:
                    StartMenu();
                    break;
                case 1:
                    EquipMenu();
                    break;
            }
        }

        private static void EquipMenu()
        {
            Console.Clear();

            ShowHighlightedText("■ 인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                _items[i].PrintItemStatDescription(true, i + 1);
            }
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");

            int keyInput = CheckValidInput(0, Item.ItemCnt);

            switch (keyInput)
            {
                case 0:
                    InventoryMenu();
                    break;
                default:
                    ToggleEquipStatus(keyInput - 1);
                    EquipMenu();
                    break;
            }

        }

        private static void ToggleEquipStatus(int idx)
        {
            _items[idx].IsEquipped = !_items[idx].IsEquipped;
        }

        private static void StatusMenu()
        {
            Console.Clear();

            ShowHighlightedText("■ 상태 보기 ■");
            Console.WriteLine("캐릭터의 정보가 표기됩니다.");

            PrintTextWithHighLights("Lv.", _player.Level.ToString("00"));
            Console.WriteLine("");
            Console.WriteLine("{0} ( {1} )", _player.Name, _player.Job);

            int bounsAtk = getSumBounsAtk();
            PrintTextWithHighLights("공격력: ", (_player.Atk + bounsAtk).ToString(), bounsAtk > 0 ? string.Format(" (+{0})", bounsAtk) : "");
            int bounsDef = getSumBounsDef();
            PrintTextWithHighLights("방어력: ", (_player.Def + bounsDef).ToString(), bounsDef > 0 ? string.Format(" (+{0})", bounsDef) : "");
            int bounsHp = getSumBounsHp();
            PrintTextWithHighLights("체력: ", (_player.Hp + bounsHp).ToString(), bounsHp > 0 ? string.Format(" (+{0}", bounsHp) : "");
            PrintTextWithHighLights("골드: ", _player.Gold.ToString());
            Console.WriteLine("");
            Console.WriteLine("0. 뒤로가기");
            Console.WriteLine("");
            switch (CheckValidInput(0, 0))
            {
                case 0:
                    StartMenu();
                    break;
            }

        }

        private static int getSumBounsAtk()
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (_items[i].IsEquipped) sum += _items[i].Atk;
            }
            return sum;
        }

        private static int getSumBounsDef()
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (_items[i].IsEquipped) sum += _items[i].Def;
            }
            return sum;
        }

        private static int getSumBounsHp()
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (_items[i].IsEquipped) sum += _items[i].Hp;
            }
            return sum;
        }

        private static void ShowHighlightedText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static void PrintTextWithHighLights(string s1, string s2, string s3 = "")
        {
            Console.Write(s1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(s2);
            Console.ResetColor();
            Console.WriteLine(s3);
        }

        private static int CheckValidInput(int min, int max)
        {
            int keyInput;
            bool result;
            do
            {
                Console.WriteLine("원하시는 행동을 입력해 주세요.");
                result = int.TryParse(Console.ReadLine(), out keyInput);
            } while (result == false || CheckIfValid(keyInput, min, max) == false);

            return keyInput;
        }

        private static bool CheckIfValid(int keyInput, int min, int max)
        {
            if (min <= keyInput && keyInput <= max) return true;
            return false;
        }

        private static void PrintStartLogo()
        {
            Console.WriteLine("================================================================================");
            Console.WriteLine("  ___________________   _____  __________ ___________ _____");
            Console.WriteLine(" /   _____/ ______     /  _     ______     __    ___//  _   ");
            Console.WriteLine(" |_____  |  |     ___//  /_|  | |       _/  |    |  /  /_|  |");
            Console.WriteLine(" /        | |    |   /    |    ||    |   |  |    | /    |    |");
            Console.WriteLine("/_______  / |____|   |____|__  /|____|_  /  |____| |____|__  /");
            Console.WriteLine("        |/                   |/        |/                  |/");
            Console.WriteLine("");
            Console.WriteLine("________    ____ ___ _______        ____.___________________    _______");
            Console.WriteLine("|______ |  |    |   ||      |      |    ||_   _____/|_____  |   |      |");
            Console.WriteLine(" |    |  | |    |   //   |   |     |    | |    __)_  /   |   |  /   |   |");
            Console.WriteLine(" |    `   ||    |  //    |    |/|__|    | |        |/    |    |/    |    |");
            Console.WriteLine("/_______  /|______/ |____|__  /|________|/_______  /|_______  /|____|__  /");
            Console.WriteLine("        |/                  |/                   |/         |/         |/");
            Console.WriteLine("================================================================================");
            Console.WriteLine("                            PRESS ANYKEY TO START                               ");
            Console.WriteLine("================================================================================");
            Console.ReadKey();
        }

        private static void GameDateSetting()
        {
            //캐릭터 정보
            _player = new Character("Chad", "전사", 1, 10, 5, 100, 1500);
            //아이템 정보
            _items = new Item[10];
            //equipmentList.Add(new Equipment("", "무쇠갑옷", "방어력", 5, 0, "무쇠로 만들어져 튼튼한 갑옷입니다."));
            //equipmentList.Add(new Equipment("", "스파르타의 창", "공격력", 7, 0, "스파르타 전사들이 사용했다는 전설의 창입니다."));
            //equipmentList.Add(new Equipment("", "낡은 검", "공격력", 2, 0, "쉽게 볼 수 있는 낡은 검입니다."));
            //_equipment = new Equipment[10];
            AddItem(new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 0, 0, 5, 0));
            AddItem(new Item("스파르타의 창", "스파르타 전사들이 사용했다는 전설의 창입니다.", 1, 7, 0, 0));
            AddItem(new Item("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.", 1, 2, 0, 0));
            //상점 아이템 정보
            //_storeItems = new StoreItem();
            //equipIven = new Inven();
            //equipment1 = new Equipment("", "무쇠갑옷", "방어력", 5, 0, "무쇠로 만들어져 튼튼한 갑옷입니다.")
            //equipment2 = new Equipment("", "스파르타의 창", "공격력", 7, 0, "스파르타 전사들이 사용했다는 전설의 창입니다.")
            //equipInven.Items(equipment1);
            //equipInven.Items(equipment2);

            //steelA = new Equipment("","무쇠갑옷", "방어력", 5, 0, "무쇠로 만들어져 튼튼한 갑옷입니다.");
            //spartaS = new Equipment("","스파르타의 창", "공격력", 7, 0,"스파르타 전사들이 사용했다는 전설의 창입니다.");
            //oldS = new Equipment("","낡은 검", "공격력", 2, 0, "쉽게 볼 수 있는 낡은 검입니다.");
        }

        static void AddItem(Item item)
        {
            if (Item.ItemCnt == 10) return;
            _items[Item.ItemCnt] = item;
            Item.ItemCnt++;
        }

        //static void AddItem(Equipment equipment)
        //{
        //    if (Equipment.EquipmentCnt == 10) return;
        //    _equipment[Equipment.EquipmentCnt] = equipment;
        //    Equipment.EquipmentCnt++;

        //}


        //class Inven
        //{
        //    public List<Equipment> equipmentList;

        //    public Inven()
        //    {
        //        equipmentList = new List<Equipment>();
        //    }

        //    public void Items(Equipment equipment)
        //    {
        //        equipmentList.Add(equipment);
        //    }

        //}






    }
}

