using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public bool IsOccupied => Owner != null;
    private GameObject Owner;

    public void Occupy(GameObject owner)
    {
        Owner = owner;
    }
}
