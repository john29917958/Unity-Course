using Photon.Pun;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject[] PlayerPositions;
    public GameObject MyPosition { get; private set; }

    public UnityChan ChanPrefab;

    private void Start()
    {
        if (PhotonNetwork.CountOfPlayers == 0 || (PhotonNetwork.CountOfPlayers == 1 && PhotonNetwork.PlayerList[0].Equals(PhotonNetwork.LocalPlayer)))
        {
            GameObject position = PlayerPositions[0];
            MyPosition = position;
            GameObject chan = PhotonNetwork.Instantiate(ChanPrefab.name, position.transform.position, Quaternion.Euler(0, 90, 0));
            chan.GetComponent<UnityChan>().OwnerPhotonPlayer = PhotonNetwork.LocalPlayer;
            chan.GetComponent<UnityChan>().Reverse = false;
        }
        else
        {
            GameObject position = PlayerPositions[1];
            MyPosition = position;
            GameObject chan = PhotonNetwork.Instantiate(ChanPrefab.name, position.transform.position, Quaternion.Euler(0, -90, 0));
            chan.GetComponent<UnityChan>().OwnerPhotonPlayer = PhotonNetwork.LocalPlayer;
            chan.GetComponent<UnityChan>().Reverse = true;
        }
    }
}
