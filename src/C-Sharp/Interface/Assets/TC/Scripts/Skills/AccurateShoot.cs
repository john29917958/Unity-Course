using UnityEngine;

public class AccurateShoot : ISkill
{
    private KeyCode _triggerKey;

    public AccurateShoot(KeyCode triggerKey)
    {
        _triggerKey = triggerKey;
    }

    public void Trigger(IProperty property)
    {
        Debug.Log("Ashe_" + _triggerKey + "- 專注射擊");
        float damage = property.Ad * 2;
        Debug.Log(string.Format("Ashe_Skill" + _triggerKey + " - ad:{0}, damage:{1}", property.Ad, damage));
    }
}
