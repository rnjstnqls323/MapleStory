using UnityEngine;

public class PlaySceneManager : MonoBehaviour
{
    private void Awake()
    {
        PlayerManager.Instance.Key = 1001;
    }
    private void Start()
    {
        MonsterManager.Instance.SpawnMonster();
        MonsterManager.Instance.SpawnMonster();
        MonsterManager.Instance.SpawnMonster();
        MonsterManager.Instance.SpawnMonster();
        MonsterManager.Instance.SpawnMonster();
    }
}
