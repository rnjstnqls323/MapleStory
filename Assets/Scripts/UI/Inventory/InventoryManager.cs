using UnityEngine;
using System.Collections.Generic;

public class InventoryManager:Singleton<InventoryManager>
{
    private PoolingObject _buttons;
    private Dictionary<int, int> _items = new Dictionary<int, int>();

    public InventoryManager()
    {
        CreateButtons();
    }
    public void GetItem(int key)
    {
        _items[key]++;
    }
    public void UseItem(int key)
    {
        _items[key]--;
        if(_items[key] == 0)
            _items[key]--;// 이거지우고 이미지 없는걸로바꾸기
    }
    private void CreateButtons()
    {
        _buttons = new PoolingObject(20, "Prefabs/UI/InventoryButton", "UI/Inventory");
        for (int i = 0; i < 20; i++)
        {
            InventoryButton btn = _buttons.ActiveObject().GetComponent<InventoryButton>();
            
        }
    }
    private void GetItemKey()
    {
        List<int> items = DataManager.Instance.GetAllItemKey();
        foreach (int i in items)
        {
            _items.Add(i, 0);
        }
    }
}
