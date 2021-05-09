using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    [HideInInspector]
    public string RoomName;

    [HideInInspector]
    public bool IsOpen;

    [HideInInspector]
    public int PlayerCount;

    [HideInInspector]
    public int MaxPlayerCount;

    public Text Description;   

    [SerializeField]
    private Button _joinButton;

    private void Start()
    {
        _joinButton.onClick.AddListener(delegate ()
        {
            if (!IsOpen)
            {
                Debug.Log("Room is not open!");
                return;
            }

            if (PlayerCount >= MaxPlayerCount)
            {
                Debug.Log("Room is full!");
                return;
            }

            PhotonNetwork.JoinRoom(RoomName);
        });
    }
}
