using UnityEngine;
using System.Collections.Generic;


public class Player : Character
{
    private List<int> _skillList = new List<int>();
    private List<GameObject> _monsters;
   
    protected override void Awake()
    {
        base.Awake();
    }
    protected void Start()
    {
        SettingCharacter(PlayerManager.Instance.Key);
        HpBarManager.Instance.SpawnHpBar(this);
    }
    protected override void SettingCharacter(int key)
    {
        base.SettingCharacter(key);
        PlayerManager.Instance.MainAbility = (PlayerAbility)(_data.Type % 10);
        PlayerManager.Instance.Player = this;
    }
    protected override void SettingSkill()
    {
        base.SettingSkill();
        _skillList.Add(_data.AttackKey);
        foreach(int key in DataManager.Instance.GetSkillList(_data.Key))
            _skillList.Add(key);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _skillManager.UseSkill(_skillList[0]);
        }
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            _skillManager.UseSkill(_skillList[1]);
        }
    }
    protected override void SettingTarget()
    {
        _skillManager.TargetList = MonsterManager.Instance.GetSpawnMonsterList();
    }
}
