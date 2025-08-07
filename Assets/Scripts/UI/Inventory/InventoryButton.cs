using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryButton : MonoBehaviour
{
    private int _itemKey = 0;
    private bool _isNone = true;
    private Button _button;
    private TextMeshProUGUI _text;
    private Player _player;

    public int ItemKey
    {
        get { return _itemKey; }
        set { _itemKey = value; }
    }    
    public bool IsNone
    {
        get { return _isNone; }
    }
    
    public void ChangeImageToNone()
    {
        _isNone = true;
        _text.text = "";
        _button.image.sprite = Resources.Load<Sprite>("Textures/UI/InventoryButton/None");
    }
    public void ChangeImageToItem()
    {
        _isNone = false;
        _text.text = DataManager.Instance.GetItemData(_itemKey).Name + " * "+InventoryManager.Instance.GetNum(_itemKey);
        _button.image.sprite = Resources.Load<Sprite>("Textures/UI/InventoryButton/Item");
    }
    private void Awake()
    {
        _button = GetComponent<Button>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _button.onClick.AddListener(OnButtonClick);
    }
    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void OnButtonClick()
    {
        if (_isNone) return;
        if(DataManager.Instance.GetItemData(_itemKey).Type == 1)
        {
            _player.HealthPoint = DataManager.Instance.GetItemData(_itemKey).Value;
            InventoryManager.Instance.UseItem(_itemKey);
        }
        else
        {
            _player.AttackPower = DataManager.Instance.GetItemData(_itemKey).Value;
            InventoryManager.Instance.UseItem(_itemKey);
        }

    }

}
