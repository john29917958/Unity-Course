using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines character types.
/// </summary>
public enum CharacterTypes
{
    Ashe,
    Yi
}

public class MyCharacterScript : MonoBehaviour
{
    /// <summary>
    /// Determines the body properties of character.
    /// </summary>
    public CharacterTypes CharacterType;

    /// <summary>
    /// Character body properties.
    /// </summary>
    private IProperty _properties;

    /// <summary>
    /// The map of input key and character skill.
    /// </summary>
    private Dictionary<KeyCode, ISkill> _skillInputs = new Dictionary<KeyCode, ISkill>();    

    /// <summary>
    /// Creates character property and binds input with skills.
    /// </summary>
    private void Start()
    {
        _properties = PropertyFactory.Make(CharacterType);
        _skillInputs.Add(KeyCode.Q, new AccurateShoot(KeyCode.Q));
        _skillInputs.Add(KeyCode.W, new MillionArrow(KeyCode.W));
        _skillInputs.Add(KeyCode.E, new RushKill(KeyCode.E));
        _skillInputs.Add(KeyCode.R, new Thinking(KeyCode.R));
    }

    /// <summary>
    /// Main game logic loop.
    /// </summary>
    private void Update()
    {
        // Fires skill if corresponding key is pressed.
        foreach (KeyValuePair<KeyCode, ISkill> skillInput in _skillInputs)
        {
            if (Input.GetKeyDown(skillInput.Key))
            {
                skillInput.Value.Trigger(_properties);
            }
        }        

        // Shows character property data if space bar pressed.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(string.Format("ad:{0}, ap:{1}, ar:{2}, mr:{3}", _properties.Ad, _properties.Ap, _properties.Ar, _properties.Mr));
        }
    }
}
