using UnityEngine;
using System.Collections.Generic;


public class Player : Character
{
    private List<int> _skillList;
    private List<Character> _monsters;
   
    private void Awake()
    {
        SettingCharacter(PlayerManager.Instance.Key);
    }
    protected void Start()
    {
        //GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        //
        //foreach (GameObject m in monsters)
        //{
        //    Character c = m.GetComponent<Character>();
        //    if (c != null)
        //    {
        //        _monsters.Add(c);
        //    }
        //} => 다시하기
    }
    protected override void SettingCharacter(int key)
    {
        base.SettingCharacter(key);
        PlayerManager.Instance.MainAbility = (PlayerAbility)(_data.Type % 10);
    }
    protected override void SettingSkill()
    {
        base.SettingSkill();
        _skillList = DataManager.Instance.GetSkillList(_data.Key);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _skillManager.UseSkill(_skillList[0], _monsters);
        }
    }
}
