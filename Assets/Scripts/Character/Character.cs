using UnityEngine;


public abstract class Character : MonoBehaviour
{
    protected CharacterData _data;
    protected int _healthPoint;
    protected int _attackPower;
    protected int _maxHealth;

    protected virtual void SettingCharacter()
    {
        _maxHealth = _data.HealthPoint;
        _healthPoint = _data.HealthPoint;
        _attackPower = _data.AttackPower;

    }
    protected abstract void GetAttacked();
}
