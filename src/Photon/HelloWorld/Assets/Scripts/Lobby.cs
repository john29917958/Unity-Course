using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
{
    [HideInInspector]
    public string LobbyName;
    public Text Description;

    [SerializeField]
    private Button _joinButton;

    private void Start()
    {
        _joinButton.onClick.AddListener(delegate() {
            PhotonNetwork.JoinLobby(new TypedLobby(LobbyName, LobbyType.SqlLobby));
        });
    }
}
