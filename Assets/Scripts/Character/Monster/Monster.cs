using UnityEngine;

public class Monster : Character
{
    private MonsterData _monsterData;

    public void SettingMonsterData(int key)
    {
       SettingCharacter(key);
       _monsterData = DataManager.Instance.GetMonsterData(4000+PlayerManager.Instance.Level);
    }
}
