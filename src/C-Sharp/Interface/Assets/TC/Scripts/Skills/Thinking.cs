using UnityEngine;

public class Thinking : ISkill
{
    private KeyCode _triggerKey;

    public Thinking(KeyCode triggerKey)
    {
        _triggerKey = triggerKey;
    }


    public void Trigger(IProperty property)
    {
        Debug.Log("Yi_" + _triggerKey + "- 冥想");
        int localar = property.Ar;
        float heal = property.Ap * 4;
        float outar = property.Ar * 4;
        property.Ar = (int)outar;
        Debug.Log(string.Format("Yi_Skill" + _triggerKey + " - ap:{0}, ar:{1}, heal:{2}, outar:{3}", property.Ap, localar, heal, outar));
    }
}
