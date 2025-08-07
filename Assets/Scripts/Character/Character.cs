using NUnit.Framework;
using UnityEngine;


public abstract class Character : MonoBehaviour
{

    protected int _healthPoint;
    protected int _attackPower;
    protected int _maxHealth;
    protected int _characterType;
    protected CharacterData _data;
    protected SkillManager _skillManager;
    protected Animator _animator;


    
    public int Key
    {
        get { return _data.Key; }
    }
    public int AttackPower
    {
        get {  return _attackPower; }
        set { _attackPower += value; }
    }
    public int CharacterType
    {
        get { return _characterType; }
    }
    public int HealthPoint
    {
        get { return _healthPoint; }
        set 
        {
            SetHealthPoint(value);
            print("체력 추가~");
        }
    }
    public virtual void GetAttacked(int power)
    {
        _healthPoint -= power;
        print("공격받음");
    }
    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    protected virtual void SettingCharacter(int key)
    {
        _data = DataManager.Instance.GetCharacterData(key);
        _maxHealth = _data.HealthPoint;
        _healthPoint = _data.HealthPoint;
        _attackPower = _data.AttackPower;
        _characterType = _data.Type / 10;
        SettingSkill();
    }
    protected virtual void SettingSkill()
    {
        _skillManager = new SkillManager(this, _data.AttackKey);
        SettingTarget();
    }
    protected void SetHealthPoint(int addHp)
    {
        _healthPoint += addHp;
        if(_healthPoint > _maxHealth) { _healthPoint = _maxHealth; }
    }
    protected abstract void SettingTarget();

}
