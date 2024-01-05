public class Item
{
    public int id;
    public string name;
    public ItemType itemType;
    public int def;
    public int atk;
    public string info;
    public int price;
    public bool isEquipped;
    public bool isBought;

    public Item(int _id, string _name, ItemType _itemType, int _def, int _atk, string _info, int _price, bool _isEquipped = false, bool _isBought = false)
    {
        id = _id;
        name = _name;
        itemType = _itemType;
        def = _def;
        atk = _atk;
        info = _info;
        price = _price;
        isEquipped = _isEquipped;
        isBought = _isBought;
    }

    public Item(Item item)
    {
        id = item.id;
        name = item.name;
        itemType = item.itemType;
        def = item.def;
        atk = item.atk;
        info = item.info;
        price = item.price;
        isEquipped = false;
        isBought = false;
    }
}
