using UnityEngine;

public class RushKill : ISkill
{
    private KeyCode _triggerKey;

    public RushKill(KeyCode triggerKey)
    {
        _triggerKey = triggerKey;
    }

    public void Trigger(IProperty property)
    {
        Debug.Log("Yi_" + _triggerKey + "- 先聲奪人");
        float damage = property.Ad * 1.2f;
        Debug.Log(string.Format("Yi_Skill" + _triggerKey + " - ad:{0}, damage:{1}", property.Ad, damage));
    }
}
