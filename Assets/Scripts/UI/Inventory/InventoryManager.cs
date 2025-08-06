using UnityEngine;
using System.Collections.Generic;

public class InventoryManager:Singleton<InventoryManager>
{
    private PoolingObject _buttons;
    private List<GameObject> _buttonList;
    private Dictionary<int, int> _items = new Dictionary<int, int>();

    public InventoryManager()
    {
        CreateButtons();
        GetItemKey();
    }
    public void GetItem(int key)
    {
        _items[key]++; // 켤때 초기화하자
    }
    public void UseItem(int key)
    {
        _items[key]--;
        UpdateButtons();
    }
    public int GetNum(int key)
    {
        return _items[key];
    }
    public void UpdateButtons()
    {
        AllNone();
        int count = 0;
        foreach (int key in _items.Keys)
        {
            if (_items[key] > 0)
            {
                InventoryButton btn = _buttonList[count].GetComponent<InventoryButton>();
                count++;
                btn.ItemKey = key;
                btn.ChangeImageToItem();
            }
        }
    }
    private void CreateButtons()
    {
        _buttons = new PoolingObject(20, "Prefabs/UI/InventoryButton", "UI/Inventory");
        for (int i = 0; i < 20; i++)
        {
            _buttons.ActiveObject();
        }
        _buttonList = _buttons.GetActiveObject();
    }
    private void GetItemKey()
    {
        List<int> items = DataManager.Instance.GetAllItemKey();
        foreach (int i in items)
        {
            _items.Add(i, 0);
        }
    }

    private void AllNone()
    {
        foreach (GameObject obj in _buttonList)
        {
            InventoryButton btn = obj.GetComponent<InventoryButton>();
            if (btn.IsNone) return;
            btn.ChangeImageToNone();
        }

    }
}
