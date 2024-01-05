using System;
using System.Collections.Generic;

public class Inventory
{
    public List<Item> Items { get; set; }

    public Inventory()
    {
        Items = new List<Item>();
    }

    public void PrintInventory(bool isManage, bool isBuy)
    {
        Console.WriteLine("[아이템 목록]");
        for (var i = 0; i < Items.Count; i++)
        {
            if (isManage)
                Console.Write($"- {i + 1} ");
            else
                Console.Write("-  ");

            Console.Write((Items[i].isEquipped ? "[E]" : "") + $"{Items[i].name}   |   ");

            if (Items[i].itemType == ItemType.Weapon)
                Console.Write($"공격력 +{Items[i].atk}   |   {Items[i].info}   ");
            else
                Console.Write($"방어력 +{Items[i].def}   |   {Items[i].info}   ");

            if (isBuy)
                Console.WriteLine($"|   " + (Items[i].isBought ? "구매완료" : $"{Items[i].price}"));
            else
                Console.WriteLine("");
        }
    }

    public bool EquipAction(int num)
    {
        return Items[num].isEquipped = !Items[num].isEquipped;
    }

    public void ShopAction(int num)
    {
        Items[num].isBought = !Items[num].isBought;
    }

    public void AddInventory(Item item)
    {
        Items.Add(item);
    }

    public Item GetItem(int num)
    {
        return Items[num];
    }

    public int GetItemsCount()
    {
        return Items.Count;
    }

    public void RemoveItem(Item item)
    { 
        Items.Remove(item);
    }

    public ItemType CheckType(int num)
    {
        return Items[num].itemType;
    }

    public Item FindItem(Item item)
    {
        for(var i = 0; i < Items.Count; i++)
        {
            if (item.id == Items[i].id)
            {
                item = Items[i];
                break;
            }
        }
        return item;
    }
}
