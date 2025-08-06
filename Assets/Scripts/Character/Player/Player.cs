using UnityEngine;
using System.Collections.Generic;
using System.Threading;


public class Player : Character
{
    private readonly float InvincibilityTime = 1.0f;
    private bool _isAttack = false;
    private float _timer = 0.0f;
    private List<int> _skillList = new List<int>();
    private List<GameObject> _monsters;



    public override void GetAttacked(int power)
    {
        if (_isAttack) return;
        base.GetAttacked(power);
        _isAttack = true;
        print("캐릭터공격받음");
    }
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

        if (!_isAttack) return;
        _timer += Time.deltaTime;
        if(_timer>InvincibilityTime)
        {
            _timer = 0.0f;
            _isAttack = false;
        }
    }
    protected override void SettingTarget()
    {
        _skillManager.TargetList = MonsterManager.Instance.GetSpawnMonsterList();
    }
}
