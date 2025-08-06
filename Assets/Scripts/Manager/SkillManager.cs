using UnityEngine;
using System.Collections.Generic;

public class SkillManager //던지는건지 아닌지
{
    private Character _owner;
    private List<GameObject> _targetList;
    private Dictionary<int, Skill> _skillList = new Dictionary<int, Skill>();

    public List<GameObject> TargetList
    {
        get { return _targetList; }
        set { _targetList = value; }
    }
    public SkillManager(Character owner, int attackKey)
    {
        _owner = owner;
        SetSkillList(attackKey);
    }
    public void UseSkill(int key)
    {
        _skillList[key].TargetList = _targetList;
        _skillList[key].UseSkill();
    }
    private void SetSkillList(int attackKey)
    {
        List<int> list = DataManager.Instance.GetSkillList(_owner.Key);
        if (attackKey == 3001) //때리기
        {
            CreateHitSkill(list);
        }
        else
        {
            CreateThrowSkill(list);
        }
    }
    private void CreateHitSkill(List<int> list)
    {
        HitSkill normalSkill = new HitSkill();
        normalSkill.Owner = _owner;
        normalSkill.SettingData(3001);
        _skillList.Add(3001, normalSkill);

        foreach(int i in list)
        {
            HitSkill skill = new HitSkill();
            skill.Owner = _owner;
            skill.SettingData(i);
            _skillList.Add(i,skill);
        }
    }
    private void CreateThrowSkill(List<int> list)
    {
        ThrowSkill normalSkill = new ThrowSkill();
        normalSkill.Owner = _owner;
        normalSkill.SettingData(3002);
        _skillList.Add(3002, normalSkill);

        foreach (int i in list)
        {
            ThrowSkill skill = new ThrowSkill(); 
            _skillList.Add(i, skill);
        }
    }

}