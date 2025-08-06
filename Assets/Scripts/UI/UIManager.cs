using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class UIManager : MonoBehaviour
{
    private GameObject _inventoryPanel;
    private bool _isInventoryPanel = false;
    private void Start()
    {
        _inventoryPanel = transform.Find("Inventory").gameObject;
        InventoryManager.Instance.UpdateButtons();
        _inventoryPanel.SetActive(false); 
    }
    private void Update()
    {
        OnUIPanel();
    }
    private void OnUIPanel()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            if(_isInventoryPanel)
            {
                _isInventoryPanel = false;
                _inventoryPanel.SetActive(false);
                return;
            }
            _isInventoryPanel = true;
            _inventoryPanel.SetActive(true);
            InventoryManager.Instance.UpdateButtons();
        }
        else if(Input.GetKeyUp(KeyCode.Escape))
        {
            _isInventoryPanel = false;
            _inventoryPanel.SetActive(false);
        }
    }
}
