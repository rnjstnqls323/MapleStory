using UnityEngine;

public class HpBarManager : Singleton<HpBarManager>
{
    private PoolingObject _hpBars;

    public HpBarManager()
    {
        _hpBars = new PoolingObject(50, "Prefabs/HpBar", "UI/HpBars");
    }
    public void SpawnHpBar(Character owner)
    {
        HpBar hpBar = _hpBars.ActiveObject().GetComponent<HpBar>();
        hpBar.SetOwner(owner);
    }
    
}