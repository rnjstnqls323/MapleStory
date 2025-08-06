using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    private Character _owner;
    private Slider _slider;
    private int _maxHp;

    public void SetOwner(Character owner)
    {
        _owner = owner;
        _maxHp = _owner.HealthPoint;
    }
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
    private void Update()
    {
        if(!_owner.gameObject.activeSelf)
        {
            this.gameObject.SetActive(false);
            return;
        }
        CheckHp();
        Vector3 worldPos = _owner.transform.position + Vector3.up * 0.5f;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        transform.position = screenPos;
    }
    private void CheckHp()
    {
        _slider.value = (float)_owner.HealthPoint/_maxHp;
    }

}
