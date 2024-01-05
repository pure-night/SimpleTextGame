using System;

public class Player
{
    public int Level { get; private set; }
    public string Name { get; private set; }
    public string Job { get; private set; }
    public int ATK { get; private set; }
    public int EquipATK { get; private set; }
    public int DEF { get; private set; }
    public int EquipDEF { get; private set; }
    public int HP { get; private set; }
    public int GOLD { get; private set; }
    public int EXP { get; private set; }
    public Inventory inventory;
    public Item equippedWeapon;
    public Item equippedArmor;

    public Player(string _name = "르탄이")
    {
        Level = 1;
        Name = _name;
        Job = "전사";
        ATK = 10;
        EquipATK = 0;
        DEF = 5;
        EquipDEF = 0;
        HP = 100;
        GOLD = 1500;
        inventory = new Inventory();
        EXP = 0;
        equippedWeapon = null;
        equippedArmor = null;
    }

    public void PrintStatus()
    {
        Console.WriteLine($"Lv : {Level:D2}");
        Console.WriteLine($"{Name} ( {Job} )");
        Console.WriteLine($"공격력 : {ATK + EquipATK}" + (EquipATK == 0 ? "" : $" (+{EquipATK})"));
        Console.WriteLine($"방어력 : {DEF + EquipDEF}" + (EquipDEF == 0 ? "" : $" (+{EquipDEF})"));
        Console.WriteLine($"체력 : {HP}");
        Console.WriteLine($"Gold : {GOLD} G");
    }

    public void PrintInventory(bool isManage = false, bool isBuy = false)
    {
        inventory.PrintInventory(isManage, isBuy);
    }

    public int GetItemsCount()
    {
        return inventory.GetItemsCount();
    }

    public void PrintGold()
    {
        Console.WriteLine("[보유 골드]");
        Console.WriteLine($"{GOLD} G\n");
    }

    public void EquipAction(int num)
    {
        var item = TryEquip(num - 1);

        if (item.itemType == ItemType.Weapon)
        {
            if (equippedWeapon != null)
            {
                if (equippedWeapon == item)
                    equippedWeapon = null;
                else
                {
                    UnEquip(equippedWeapon);
                    equippedWeapon = item;
                }
            }
            else if (equippedWeapon != item)
                equippedWeapon = item;
        }
        else
        {
            if (equippedArmor != null)
            {
                if (equippedArmor == item)
                    equippedArmor = null;
                else
                {
                    UnEquip(equippedArmor);
                    equippedArmor = item;
                }
            }
            else if (equippedArmor != item)
                equippedArmor = item;
        }
    }

    public Item TryEquip(int num)
    {
        var item = inventory.GetItem(num);
        if (inventory.EquipAction(num))
        {
            EquipATK += item.atk;
            EquipDEF += item.def;
        }
        else
        {
            EquipATK -= item.atk;
            EquipDEF -= item.def;
        }

        return item;
    }

    public void UnEquip(Item item)
    {
        item.isEquipped = false;
        EquipATK -= item.atk;
        EquipDEF -= item.def;
    }

    public bool TryBuy(Item item)
    {
        if (CheckGold(item.price))
        {
            var temp = new Item(item);
            GOLD -= temp.price;
            inventory.AddInventory(temp);
            return true;
        }
        return false;
    }

    public Item TrySell(int num)
    {
        var item = inventory.GetItem(num - 1);
        if (item.isEquipped)
            EquipAction(num);
        inventory.RemoveItem(item);
        GOLD += item.price * 85 / 100;
        return item;
    }

    public bool CheckGold(int price)
    {
        if(GOLD >= price)
            return true;
        return false;
    }

    public void Heal(int price)
    {
        GOLD -= price;
        HP += 100;
        HP = HP > 100 ? 100 : HP;
    }

    public bool IsDead(int damage)
    {
        HP -= damage;
        if (HP <= 0)
            return true;
        return false;
    }

    public void GainGold(int gold)
    {
        GOLD += gold;
    }

    public void GainEXP()
    {
        EXP++;
        if(EXP >= Level)
        {
            EXP = 0;
            LevelUp();
        }
    }

    public void LevelUp()
    {
        Console.WriteLine($"레벨 업! {Level} -> {Level + 1}");
        Level += 1;
        ATK += 1;
        DEF += 2;
    }
}
