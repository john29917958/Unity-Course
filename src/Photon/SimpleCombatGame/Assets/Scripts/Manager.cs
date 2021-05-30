using Photon.Pun;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public PlayerPosition[] PlayerPositions;
    public PlayerPosition MyPosition { get; private set; }

    public UnityChan ChanPrefab;

    private void Start()
    {
        Debug.Log("Player instances: " + PhotonNetwork.PlayerList.Length);

        if (PhotonNetwork.CountOfPlayers == 0 || (PhotonNetwork.CountOfPlayers == 1 && PhotonNetwork.PlayerList[0].Equals(PhotonNetwork.LocalPlayer)))
        {
            PlayerPosition position = PlayerPositions[0];
            position.Occupy(gameObject);
            MyPosition = position;
            GameObject chan = PhotonNetwork.Instantiate(ChanPrefab.name, position.transform.position, Quaternion.Euler(0, 90, 0));
            chan.GetComponent<UnityChan>().OwnerPhotonPlayer = PhotonNetwork.LocalPlayer;
        }
        else
        {
            PlayerPosition position = PlayerPositions[1];
            position.Occupy(gameObject);
            MyPosition = position;
            GameObject chan = PhotonNetwork.Instantiate(ChanPrefab.name, position.transform.position, Quaternion.Euler(0, -90, 0));
            chan.GetComponent<UnityChan>().OwnerPhotonPlayer = PhotonNetwork.LocalPlayer;
        }

        return;

        for (int i = 0; i < PlayerPositions.Length; i++)
        {
            PlayerPosition position = PlayerPositions[i];

            if (!position.IsOccupied)
            {
                position.Occupy(gameObject);
                MyPosition = position;
                PhotonNetwork.Instantiate(ChanPrefab.name, position.transform.position, Quaternion.Euler(0, i == 0 ? 90 : -90, 0));
                break;
            }
        }
    }
}
