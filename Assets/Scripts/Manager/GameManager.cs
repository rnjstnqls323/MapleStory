using UnityEngine;

public class GameManager : SingletonMonobehavior<GameManager>
{
    private void Awake()
    {
        DataManager.Instance.LoadAllDatas();
        //print(DataManager.Instance.GetCharacterData(1001).Name);
    }
}
