using UnityEngine;
using System.Collections.Generic;

public struct CharacterData
{
    public int Key;
    public int AttackKey; //스킬중에 평타 키 (이걸로 원거리 근거리 판단)
    public int Type; //몬스터인지 플레이어인지 구별 + 플레이어 필요한 타입 (11 : str/ 12 : dex/ 13 : luk/ 14: int)
    public string Name;
    public int HealthPoint;
    public int AttackPower;
    public int MoveSpeed;
}
public struct MonsterData
{
    public int Key;
    public int Experience;
    public int Level;
    public int Money;
}
public struct ItemData
{
    public int Key;
    public int Type; //1 : 회복물약 2 : 공격력 증가 버프 
    public string Name;
    public int Price;
    public float CoolTime;
    public int Value;
}
public struct SkillData
{
    public int Key;
    public int CharacterKey; //스킬 사용가능한 캐릭터
    public string Name;
    public int SkillType; //근거리 장거리 타입
    public float CoolTime;
    public float AttackPower;
    public string AnimationPath; //이펙터 경로 적을까했는데 고민해봐야될듯
    public int Range;
}
public class DataManager : Singleton<DataManager>
{
    private Dictionary<int, CharacterData> _characterDatas = new Dictionary<int, CharacterData>();
    private Dictionary<int, MonsterData> _monsterDatas = new Dictionary<int, MonsterData>();
    private Dictionary<int, ItemData> _itemDatas = new Dictionary<int, ItemData>();
    private Dictionary<int, SkillData> _skillDatas = new Dictionary<int, SkillData>();

    public void LoadAllDatas()
    {
        LoadCharacterDatas();
        LoadMonsterDatas();
        LoadItemDatas();
        LoadSkillDatas();
    }
    public CharacterData GetCharacterData(int key)
    {
        return _characterDatas[key];
    }
    

    private void LoadCharacterDatas()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Tables/CharacterTable");

        if (textAsset == null)
        {
            Debug.LogError("WorldTable not found in Resources/Tables.");
            return;
        }
        string[] lines = textAsset.text.Split("\r\n");

        for (int i = 1; i < lines.Length; i++)
        {
            string[] datas = lines[i].Split(',');
            if (datas.Length <= 1) continue;
            CharacterData data;
            data.Key = int.Parse(datas[0]);
            data.AttackKey = int.Parse(datas[1]);
            data.Type = int.Parse(datas[2]);
            data.Name = datas[3];
            data.HealthPoint = int.Parse(datas[4]);
            data.AttackPower = int.Parse(datas[5]);
            data.MoveSpeed = int.Parse(datas[6]);
            
            _characterDatas.Add(data.Key, data);
        }
    }
    private void LoadMonsterDatas()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Tables/MonsterTable");

        if (textAsset == null)
        {
            Debug.LogError("WorldTable not found in Resources/Tables.");
            return;
        }
        string[] lines = textAsset.text.Split("\r\n");

        for (int i = 1; i < lines.Length; i++)
        {
            string[] datas = lines[i].Split(',');
            if (datas.Length <= 1) continue;
            MonsterData data;
            data.Key = int.Parse(datas[0]);
            data.Experience = int.Parse(datas[1]);
            data.Level = int.Parse(datas[2]);
            data.Money = int.Parse(datas[3]);

            _monsterDatas.Add(data.Key, data);
        }
    }
    private void LoadItemDatas()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Tables/ItemTable");

        if (textAsset == null)
        {
            Debug.LogError("WorldTable not found in Resources/Tables.");
            return;
        }
        string[] lines = textAsset.text.Split("\r\n");

        for (int i = 1; i < lines.Length; i++)
        {
            string[] datas = lines[i].Split(',');
            if (datas.Length <= 1) continue;
            ItemData data;
            data.Key = int.Parse(datas[0]);
            data.Type = int.Parse(datas[1]);
            data.Name = datas[2];
            data.Price = int.Parse(datas[3]);
            data.CoolTime = float.Parse(datas[4]);
            data.Value = int.Parse(datas[5]);

            _itemDatas.Add(data.Key, data);
        }
    }
    private void LoadSkillDatas()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Tables/SkillTable");

        if (textAsset == null)
        {
            Debug.LogError("WorldTable not found in Resources/Tables.");
            return;
        }
        string[] lines = textAsset.text.Split("\r\n");

        for (int i = 1; i < lines.Length; i++)
        {
            string[] datas = lines[i].Split(',');
            if (datas.Length <= 1) continue;
            SkillData data;
            data.Key = int.Parse(datas[0]);
            data.CharacterKey = int.Parse(datas[1]);
            data.Name = datas[2];
            data.SkillType = int.Parse(datas[3]);
            data.CoolTime = float.Parse (datas[4]);
            data.AttackPower = float.Parse(datas[5]);
            data.AnimationPath = datas[6];
            data.Range = int.Parse(datas[7]);

            _skillDatas.Add(data.Key, data);
        }
    }
}
