using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    private readonly int MaxExp = 100;
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
    private void Update()
    {
        CheckExp();
    }
    private void CheckExp()
    {
        _slider.value = (float)PlayerManager.Instance.Exp / MaxExp;
    }

}
