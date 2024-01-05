public class Merchant
{
    public Inventory inventory;

    public Merchant()
    {
        inventory = new Inventory();
        ItemInit();
    }

    public void ItemInit()
    {
        Item item = new Item(00, "수련자 갑옷", ItemType.Armor, 5, 0, "수련에 도움을 주는 갑옷입니다.", 1000);
        inventory.AddInventory(item);
        item = new Item(01, "무쇠 갑옷", ItemType.Armor, 9, 0, "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000);
        inventory.AddInventory(item);
        item = new Item(02, "스파르타 갑옷", ItemType.Armor, 15, 0, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500);
        inventory.AddInventory(item);
        item = new Item(03, "아이언맨 슈트", ItemType.Armor, 20, 0, "알 수 없는 최첨단의 슈트입니다. 공격능력은 없는 것 같습니다.", 10000);
        inventory.AddInventory(item);
        item = new Item(10, "낡은 검", ItemType.Weapon, 0, 2, "쉽게 볼 수 있는 낡은 검 입니다.", 600);
        inventory.AddInventory(item);
        item = new Item(11, "청동 도끼", ItemType.Weapon, 0, 5, "어디선가 사용됐던거 같은 도끼입니다.", 1500);
        inventory.AddInventory(item);
        item = new Item(12, "스파르타의 창", ItemType.Weapon, 0, 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 3000);
        inventory.AddInventory(item);
        item = new Item(13, "혼돈의 블레이드", ItemType.Weapon, 0, 10, "어느 신이 사용한 사슬이 달린 쌍검입니다. 진품인지는 모릅니다.", 10000);
        inventory.AddInventory(item);
    }

    public bool IsAlreadyBought(int num, out Item item)
    {
        item = inventory.GetItem(num - 1);
        if (item.isBought)
            return true;
        return false;
    }

    public void PrintInventory(bool isManage = false, bool isBuy = false)
    {
        inventory.PrintInventory(isManage, isBuy);
    }

    public int GetItemNumber()
    {
        return inventory.GetItemsCount();
    }

    public void ShopAction(int num)
    {
        inventory.ShopAction(num - 1);
    }

    public void SellItem(Item item)
    {
        inventory.FindItem(item).isBought = false;
    }
}
