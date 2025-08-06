using System.Collections.Generic;
using UnityEngine;

public enum PlayerAbility
{
    Str = 1, Dex, Int, Luk
}
public class PlayerManager : Singleton<PlayerManager>
{
    private int _key;
    private int _exp;
    private int _level = 1;
    private int _money;
    private Player _player;
    private Dictionary<PlayerAbility, int> _ability = new Dictionary<PlayerAbility, int>();
    private PlayerAbility _mainAbility;

    public PlayerManager()
    {
        _ability.Add(PlayerAbility.Str, 0);
        _ability.Add(PlayerAbility.Dex, 0);
        _ability.Add(PlayerAbility.Int, 0);
        _ability.Add(PlayerAbility.Luk, 0);
    }
    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }
    public int Key
    {
        get { return _key; }
        set { _key = value; }
    }
    public int Exp
    { 
        get { return _exp; }
    }
    public int Level
        { get { return _level; } }
    public int Money
    { 
        get { return _money; }
        set { _money += value; }
    }
    public PlayerAbility MainAbility
    {
        get { return _mainAbility; }
        set { _mainAbility = value; }
    }

    public int GetMainAblility()
    {
        return _ability[_mainAbility];
    }
    public void AddAbility(PlayerAbility key, int value)
    {
        _ability[key] = value;
    }

    public void AddExp(int exp)
    {
        _exp += exp;
        if(_level * 100 <_exp)
        {
            _exp -= _level * 100;
            _level++;
        }
    }
}
