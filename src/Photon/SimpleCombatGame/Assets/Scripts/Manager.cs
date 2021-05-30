using UnityEngine;

public class Manager : MonoBehaviour
{
    public PlayerPosition[] PlayerPositions;
    public PlayerPosition MyPosition { get; private set; }

    private void Start()
    {
        foreach (PlayerPosition position in PlayerPositions)
        {
            if (!position.IsOccupied)
            {
                position.Occupy(gameObject);
                MyPosition = position;
            }
        }
    }
}
