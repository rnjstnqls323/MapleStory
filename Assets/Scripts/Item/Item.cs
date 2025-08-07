using UnityEngine;

public class Item : MonoBehaviour
{
    private int _key;
    private int _type;

    public int Key
    {
        get { return _key; }
        set { _key = value; }
    }
    public int Type
    {
        get { return _type; }
    }

    private void AddInventory()
    {
        InventoryManager.Instance.GetItem(_key);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AddInventory();
            gameObject.SetActive(false);
        }
    }
}
