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
        int randNum = Random.Range(0, 2);
        switch(randNum)
        {
            case 0:
                item.Key = 5001;
                break;
            case 1:
                item.Key = 5002;
                break;
        }

    }
    private void CreateItems()
    {
        _items = new PoolingManager("Prefabs/Item/HpPotion", "Items" ,30);
    }

}
