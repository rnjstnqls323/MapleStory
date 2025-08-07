using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Screen : MonoBehaviour
{
    private bool _isIncrease = true;
    private RawImage _screen;
    private Material _material;

    private void Awake()
    {
        _screen = GetComponent<RawImage>();
        _material = _screen.material;
    }
    private void Start()
    {
        StartCoroutine(Loop());
    }
    private IEnumerator Loop()
    {
        float time = 0.0f;
        Vector4 scale;
        while (true)
        {
            if(_isIncrease)
            {
                time += Time.deltaTime;
                if (time > 1.0f)
                {
                    _isIncrease = false;
                }
            }
            else
            {
                time -= Time.deltaTime;
                if (time < 0.0f)
                {
                    _isIncrease = true;
                }

            }
                yield return null;
        }
    }
}
