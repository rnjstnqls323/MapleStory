using Unity.VisualScripting;
using UnityEngine;

public class HitSkill : Skill
{
    public override void UseSkill()
    {
        base.UseSkill();
        bool isFlipped = _owner.GetComponent<SpriteRenderer>().flipX;

        Vector3 pos = new Vector3(_owner.transform.position.x, _owner.transform.position.y, 0);


        foreach (Character target in _targetList)
        {
            float x = target.transform.position.x;

            if (isFlipped)
            {
                if (x <= pos.x && x >= pos.x - _data.Range)
                    target.GetAttacked(_attackPower);
            }
            else
            {
                if (x >= pos.x && x <= pos.x - _data.Range)
                    target.GetAttacked(_attackPower);
            }
        }
    }
}
