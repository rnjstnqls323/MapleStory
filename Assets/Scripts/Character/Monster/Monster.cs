using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Monster : Character
{
    private bool _isDie = false;
    private MonsterData _monsterData;

    public void SettingMonsterData(int key)
    {
        _isDie = false;
       SettingCharacter(key);
       _monsterData = DataManager.Instance.GetMonsterData(4000+PlayerManager.Instance.Level);
    }
    public override void GetAttacked(int power)
    {
        base.GetAttacked(power);
        if(_healthPoint>0)
        {
            _animator.SetInteger("State", 2);
        }
        else
        {
            _animator.SetInteger("State", 3);
            _isDie = true;
        }
    }
    protected void Update()
    {
        if (_isDie) return;
        _animator.SetInteger("State", 0);

        _skillManager.UseSkill(_data.AttackKey);
    }
    protected void LateUpdate()
    {
        if (_isDie)
        {
            MonsterManager.Instance.SpawnMonster();
            MonsterManager.Instance.DespawnMonster(this);
            PlayerManager.Instance.AddExp(_monsterData.Experience);
        }
    }
    protected override void SettingTarget()
    {
        List<GameObject> target = new List<GameObject>();
        target.Add(PlayerManager.Instance.Player.gameObject);
        _skillManager.TargetList = target;
    }
}
