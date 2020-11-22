using UnityEngine;

public class MillionArrow : ISkill
{
    private KeyCode _triggerKey;

    public MillionArrow(KeyCode triggerKey)
    {
        _triggerKey = triggerKey;
    }

    public void Trigger(IProperty property)
    {
        Debug.Log("Ashe_" + _triggerKey + "- 萬箭齊發");
        float damage = property.Ad * 1;
        Debug.Log(string.Format("Ashe_Skill" + _triggerKey + " - ad:{0}, damage:{1}", property.Ad, damage));
    }
}
