using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    private int _key;

    public int Key
    {
        get { return _key; }
        set { _key = value; }
    }
}
