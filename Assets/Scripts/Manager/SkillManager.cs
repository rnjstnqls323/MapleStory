using UnityEngine;
using System.Collections.Generic;

public class SkillManager //던지는건지 아닌지
{
    private Character _owner;
    private List<Character> _targetList;
    private Dictionary<int, Skill> _skillList = new Dictionary<int, Skill>();
    public SkillManager(Character owner, int attackKey)
    {
        _owner = owner;
        SetSkillList(attackKey);
    }
    public void UseSkill(int key, List<Character> targetList)
    {
        _skillList[key].TargetList = targetList;
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
        HitSkill normalSkill = new HitSkill(); //3001넣던지 아니면 hit스킬로 바꿔주던지
        _skillList.Add(3001, normalSkill);

        foreach(int i in list)
        {
            HitSkill skill = new HitSkill(); //이것도 hit스킬로 바꾸기
            _skillList.Add(i,skill);
        }
    }
    private void CreateThrowSkill(List<int> list)
    {
        ThrowSkill normalSkill = new ThrowSkill(); 
        _skillList.Add(3002, normalSkill);

        foreach (int i in list)
        {
            ThrowSkill skill = new ThrowSkill(); 
            _skillList.Add(i, skill);
        }
    }

}