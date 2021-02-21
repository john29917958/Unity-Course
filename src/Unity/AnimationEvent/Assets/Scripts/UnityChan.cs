using UnityEngine;

public class UnityChan : MonoBehaviour
{
	public bool IsInComboSection { get; private set; }

	public void ActivateComboSection()
    {
        IsInComboSection = true;
    }

    public void DisableComboSection()
    {
        IsInComboSection = false;
    }
}
