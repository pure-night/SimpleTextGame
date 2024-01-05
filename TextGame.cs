using System;

public class TextGame
{
    public int scene;
    public Player player;
    public Merchant merchant;

    public TextGame()
    {
        player = new Player();
        merchant = new Merchant();
        MainScene();
    }

    public void MainScene()
    {
        Console.Clear();
        var input = -1;
        while (input != 0)
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("\n1. 상태 보기\n2. 인벤토리\n3. 상점\n4. 던전입장\n5. 휴식하기\n0. 종료하기");

            var top = Console.CursorTop;
            while (true)
            {
                ScreenRemover(top);
                input = GetAction();
                if (input == 1)
                    ShowStatus();
                else if (input == 2)
                    ShowInventory();
                else if (input == 3)
                    ShowMerchantShop();
                else if (input == 4)
                    EnterDungeon();
                else if (input == 5)
                    Rest();
                else if (input == 0)
                    break;
                else
                {
                    Console.WriteLine("잘못된 입력입니다.\t\t\t\n");
                    continue;
                }
                break;
            }
        }
    }

    public void ShowStatus()
    {
        Console.Clear();
        var input = -1;
        while (input != 0)
        {
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            player.PrintStatus();
            Console.WriteLine("\n0. 나가기");

            var top = Console.CursorTop;
            while (true)
            {
                ScreenRemover(top);
                input = GetAction();
                if (input == 0)
                    break;
                else
                    Console.WriteLine("잘못된 입력입니다.\t\t\t\n");
            }
        }
        Console.Clear();
    }

    public void ShowInventory()
    {
        Console.Clear();
        var input = -1;
        while (input != 0)
        {
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            player.PrintInventory();
            Console.WriteLine("\n1. 장착관리");
            Console.WriteLine("0. 나가기");

            var top = Console.CursorTop;
            while (true)
            {
                ScreenRemover(top);
                input = GetAction();
                if (input == 1)
                {
                    EquipmentManage();
                    break;
                }
                else if (input == 0)
                    break;
                else
                    Console.WriteLine("잘못된 입력입니다.\t\t\t\n");
            }
        }
        Console.Clear();
    }

    public void EquipmentManage()
    {
        Console.Clear();
        var input = -1;
        while (input != 0)
        {
            Console.WriteLine("인벤토리 - 장착관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            player.PrintInventory(true);
            Console.WriteLine("\n0. 나가기");

            var top = Console.CursorTop;
            while (true)
            {
                ScreenRemover(top);
                input = GetAction();
                if (input <= player.GetItemsCount() && input > 0)
                {
                    Console.Clear();
                    player.EquipAction(input);
                    break;
                }
                else if (input == 0)
                    break;
                else
                    Console.WriteLine("잘못된 입력입니다.\t\t\t\n");
            }
        }
        Console.Clear();
    }

    public void ShowMerchantShop()
    {
        Console.Clear();
        var input = -1;
        while (input != 0)
        {
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            player.PrintGold();
            merchant.PrintInventory(false, true);
            Console.WriteLine("\n1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기");

            var top = Console.CursorTop;
            while (true)
            {
                ScreenRemover(top);
                input = GetAction();
                if (input == 1)
                    BuyMerChantShop();
                else if (input == 2)
                    SellMerChantShop();
                else if (input == 0)
                    break;
                else
                {
                    Console.WriteLine("잘못된 입력입니다.\t\t\t\n");
                    continue;
                }
                break;
            }
        }
        Console.Clear();
    }

    public void BuyMerChantShop()
    {
        Console.Clear();
        var input = -1;
        while (input != 0)
        {
            Console.WriteLine("상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            player.PrintGold();
            merchant.PrintInventory(true, true);
            Console.WriteLine("\n0. 나가기");

            var top = Console.CursorTop;
            while (true)
            {
                ScreenRemover(top);
                input = GetAction();
                if (input <= merchant.GetItemNumber() && input > 0)
                {
                    if (merchant.IsAlreadyBought(input, out Item item))
                    {
                        Console.WriteLine("이미 구매한 아이템입니다.\t\t\t\n");
                    }
                    else
                    {
                        if (player.TryBuy(item))
                        {
                            top = Console.CursorTop;
                            Console.Clear();
                            Console.SetCursorPosition(0, top);
                            Console.WriteLine("구매를 완료했습니다.\t\t\t\n");
                            Console.SetCursorPosition(0, 0);
                            merchant.ShopAction(input);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("골드가 부족합니다.\t\t\t\n");
                        }
                    }
                }
                else if (input == 0)
                    break;
                else
                {
                    Console.WriteLine("잘못된 입력입니다.\t\t\t\n");
                }
            }
        }
        Console.Clear();
    }

    public void SellMerChantShop()
    {
        Console.Clear();
        var input = -1;
        while (input != 0)
        {
            Console.WriteLine("상점 - 아이템 판매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            player.PrintGold();
            player.PrintInventory(true, true);
            Console.WriteLine("\n0. 나가기");

            var top = Console.CursorTop;
            while (true)
            {
                ScreenRemover(top);
                input = GetAction();
                if (input <= player.GetItemsCount() && input > 0)
                {
                    top = Console.CursorTop;
                    Console.Clear();
                    Console.SetCursorPosition(0, top - 1);
                    player.EquipAction(input);
                    merchant.SellItem(player.TrySell(input));
                    Console.WriteLine("판매를 완료했습니다.\t\t\t\n\t\t\t\t");
                    Console.SetCursorPosition(0, 0);
                    break;
                }
                else if (input == 0)
                    break;
                else
                    Console.WriteLine("잘못된 입력입니다.\t\t\t\n");
            }
        }
        Console.Clear();
    }

    public void EnterDungeon()
    {
        Console.Clear();
        var input = -1;
        while (input != 0)
        {
            Console.WriteLine("던전입장");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
            Console.WriteLine("1. 쉬운 던전    |   방어력 5 이상 권장");
            Console.WriteLine("2. 일반 던전    |   방어력 11 이상 권장");
            Console.WriteLine("3. 어려운 던전  |   방어력 17 이상 권장");
            Console.WriteLine("0. 나가기");

            var top = Console.CursorTop;
            while (true)
            {
                ScreenRemover(top);
                input = GetAction();
                if (input <= 3 && input > 0)
                {
                    Dungeon(input);
                    break;
                }
                else if (input == 0)
                    break;
                else
                    Console.WriteLine("잘못된 입력입니다.\t\t\t\n");
            }
        }
        Console.Clear();
    }

    public void Dungeon(int difficulty)
    {
        var targetDef = 0;
        if (difficulty == 1)
            targetDef = 5;
        else if (difficulty == 2)
            targetDef = 11;
        else if (difficulty == 3)
            targetDef = 17;

        if (targetDef > player.DEF && new Random().Next(0, 10) < 4)
            DungeonFail(targetDef, difficulty);
        else
            DungeonClear(targetDef, difficulty);
    }

    public void DungeonClear(int targetDef, int difficulty)
    {
        Console.Clear();
        var damage = DungeonDamage(targetDef);
        var reward = DungeonReward(difficulty);
        Console.Clear();
        Console.WriteLine("던전 클리어");
        Console.WriteLine("축하합니다!!");
        if (difficulty == 1)
            Console.WriteLine("쉬운 던전을 클리어 하셨습니다.");
        else if (difficulty == 2)
            Console.WriteLine("일반 던전을 클리어 하셨습니다.");
        else if (difficulty == 3)
            Console.WriteLine("어려운 던전을 클리어 하셨습니다.");

        Console.WriteLine("\n[탐험 결과]");
        player.GainEXP();
        Console.WriteLine($"체력 {player.HP + damage} -> {player.HP}");
        Console.WriteLine($"Gold {player.GOLD - reward} -> {player.GOLD}");
        Console.WriteLine("\n0. 나가기");

        var top = Console.CursorTop;
        while (true)
        {
            ScreenRemover(top);
            var input = GetAction();
            if (input == 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.\t\t\t\n");
            }
        }
        Console.Clear();
    }

    public void DungeonFail(int targetDef, int difficulty)
    {
        Console.Clear();
        Console.WriteLine("던전 실패\n");
        var damage = DungeonDamage(targetDef, true);
        Console.WriteLine("[탐험 결과]");
        Console.WriteLine($"체력 {player.HP + damage} -> {player.HP}");
        Console.WriteLine("\n0. 나가기");
        var top = Console.CursorTop;
        while (true)
        {
            ScreenRemover(top);
            var input = GetAction();
            if (input == 0)
                break;
            else
                Console.WriteLine("잘못된 입력입니다.\t\t\t\n");
        }
        Console.Clear();
    }

    public int DungeonDamage(int targetDef, bool isFail = false)
    {
        var damage = new Random().Next(25, 36) - player.DEF + targetDef;
        if (isFail)
            damage /= 2;

        if (player.IsDead(damage))
        {
            Console.WriteLine("던전 실패\n");
            Console.WriteLine("[탐험 결과]");
            Console.WriteLine($"{damage}의 피해를 입었습니다.\n");
            Console.WriteLine("플레이어 사망. 게임 오버.\n");
            Environment.Exit(0);
        }

        return damage;
    }

    public int DungeonReward(int difficulty)
    {
        var reward = 0;
        if (difficulty == 1)
            reward = 1000;
        else if (difficulty == 2)
            reward = 1700;
        else if (difficulty == 3)
            reward = 2500;
        reward = (reward * new Random().Next(player.ATK, player.ATK * 2 + 1) / 100) + reward;

        player.GainGold(reward);

        return reward;
    }

    public void Rest()
    {
        Console.Clear();
        var input = -1;
        while (input != 0)
        {
            Console.WriteLine("휴식하기");
            Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {player.GOLD} G)\n");
            Console.WriteLine("1. 휴식하기");
            Console.WriteLine("0. 나가기");

            var top = Console.CursorTop;
            while (true)
            {
                ScreenRemover(top);
                input = GetAction();
                if (input == 1)
                {
                    if (player.CheckGold(500))
                    {
                        player.Heal(500);
                        top = Console.CursorTop;
                        Console.Clear();
                        Console.SetCursorPosition(0, top);
                        Console.WriteLine("회복되었습니다.\t\t\t\n");
                        Console.SetCursorPosition(0, 0);
                        break;
                    }
                    else
                        Console.WriteLine("돈이 부족합니다.\t\t\t\n");
                }
                else if (input == 0)
                    break;
                else
                    Console.WriteLine("잘못된 입력입니다.\t\t\t\n");
            }
        }
        Console.Clear();
    }

    public int GetAction()
    {
        Console.WriteLine("\n원하시는 행동을 입력해주세요.");
        Console.Write(">> ");
        var input = -1;
        if(int.TryParse(Console.ReadLine(), out input))
            return input;
        return -1;
    }

    public void ScreenRemover(int top)
    {
        Console.SetCursorPosition(0, top);
        Console.WriteLine("                                    ");
        Console.WriteLine("                                    ");
        Console.WriteLine("                                    ");
        Console.SetCursorPosition(0, top);
    }
}
