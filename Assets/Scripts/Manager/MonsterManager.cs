using UnityEngine;
using System.Collections.Generic;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MonsterManager : Singleton<MonsterManager>
{
    private PoolingObject _monsters;

    public MonsterManager()
    {
        _monsters = new PoolingObject(50, "Prefabs/Monster/Monster", "Monsters");
    }
    public void SpawnMonster()
    {
        float x = Random.Range(-4, 4);
        Monster monster = _monsters.ActiveObject().GetComponent<Monster>();
        monster.transform.position = new Vector3(x, monster.transform.position.y, 0);
        monster.SettingMonsterData(2001);
        HpBarManager.Instance.SpawnHpBar(monster);
    }
    public void DespawnMonster(Monster monster)
    {
        _monsters.DisableObject(monster.gameObject);
        ItemManager.Instance.SpawnItem(monster.transform.position);
    }
    public List<GameObject> GetSpawnMonsterList()
    {
        return _monsters.GetActiveObject();
    }
}
