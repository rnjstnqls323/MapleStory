using Unity.VisualScripting;
using UnityEngine;

public class HitSkill : Skill
{
    public override void UseSkill()
    {
        base.UseSkill();
        bool isFlipped = _owner.GetComponent<SpriteRenderer>().flipX;

        Vector3 pos = new Vector3(_owner.transform.position.x, _owner.transform.position.y, 0);


        foreach (GameObject target in _targetList)
        {
            float x = target.transform.position.x;
            Character character = target.GetComponent<Character>();
            if (!isFlipped && x <= pos.x && x >= pos.x - _data.Range)
            {
                character.GetAttacked(_attackPower);
            }
            else if(isFlipped && x >= pos.x && x <= pos.x + _data.Range)
            {
                character.GetAttacked(_attackPower);
            }
        }
    }
}
