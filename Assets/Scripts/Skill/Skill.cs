using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class Skill :MonoBehaviour
{
    protected bool _isAttack = false;
    protected float _timer = 0;
    protected int _attackPower;
    protected Character _owner;
    protected SkillData _data;
    protected Animation _animation; //쓸까말까
    protected List<Character> _targetList;

    public Character Owner
    { 
        get { return _owner; }
        set
        { 
            _owner = value;
            SettingData();
        }
    }
    public List<Character> TargetList
    {
        get { return _targetList; }
        set { TargetList = value; }
    }
    public virtual void UseSkill()
    {
        if (_isAttack) return;
        _isAttack = true;
    }
    protected void Update()
    {
        if (!_isAttack) return;
        WaitCoolTime();
    }
    protected void SettingData()
    {
        switch(_owner.CharacterType)
        {
            case 1:
            {
               Player player = (Player)_owner;
                _attackPower = player.AttackPower+(int)(PlayerManager.Instance.GetMainAblility()*_data.AttackPower);
                break;
            }
            case 2:
            {
                _attackPower = _owner.AttackPower;
                break;
            }
        } 
    }
    protected void WaitCoolTime()
    {
        _timer += Time.deltaTime;
        if (_timer < _data.CoolTime) return;

        _isAttack = false;
        _timer = 0;
    }
    
}
