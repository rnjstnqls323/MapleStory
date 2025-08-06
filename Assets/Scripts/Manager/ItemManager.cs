using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    private PoolingManager _items;

    public ItemManager()
    {
        CreateItems();
    }
    public void SpawnItem(Vector3 pos)
    {
        Item item = _items.Pop().GetComponent<Item>();
        item.transform.position = pos;
        item.Key = 5001;
    }
    private void CreateItems()
    {
        _items = new PoolingManager("Prefabs/Item/HpPotion", "Items" ,30);
    }

}
