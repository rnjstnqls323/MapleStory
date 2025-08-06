using UnityEngine;

public class Item : MonoBehaviour
{
    private int _key;

    public int Key
    {
        get { return _key; }
        set { _key = value; }
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
