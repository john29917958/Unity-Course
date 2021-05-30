using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField NickNameInput;

    [SerializeField] private Button LoginButton;

    public override void OnConnectedToMaster()
    {
        RoomOptions options = new RoomOptions
        {
            MaxPlayers = 2,
            IsOpen = true,
            IsVisible = true,
            EmptyRoomTtl = 3000,
            PlayerTtl = 3000,
            CleanupCacheOnLeave = true,
            DeleteNullProperties = true,
            CustomRoomProperties = new Hashtable {{"C0", "Default"}},
            CustomRoomPropertiesForLobby = new[] {"C0"}
        };

        PhotonNetwork.JoinOrCreateRoom("TestRoom", options, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GameScene");
    }

    public void Login()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.AutomaticallySyncScene = false;
            PhotonNetwork.AuthValues = new AuthenticationValues(NickNameInput.text);
            PhotonNetwork.NickName = NickNameInput.text;
            PhotonNetwork.GameVersion = Application.version;
            PhotonNetwork.NetworkingClient.AppId = PhotonNetwork.PhotonServerSettings.AppSettings.AppIdRealtime;
            PhotonNetwork.NetworkingClient.EnableLobbyStatistics = true;
            PhotonNetwork.PhotonServerSettings.AppSettings.EnableLobbyStatistics = true;
            PhotonNetwork.ConnectToRegion("jp");
        }
    }
}
