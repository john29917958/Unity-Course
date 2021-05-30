using Photon.Pun;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public PlayerPosition[] PlayerPositions;
    public PlayerPosition MyPosition { get; private set; }

    public UnityChan ChanPrefab;

    private void Start()
    {
        foreach (PlayerPosition position in PlayerPositions)
        {
            if (!position.IsOccupied)
            {
                position.Occupy(gameObject);
                MyPosition = position;
                PhotonNetwork.Instantiate(ChanPrefab.name, position.transform.position, Quaternion.Euler(0, 90, 0));
                break;
            }
        }
    }
}
