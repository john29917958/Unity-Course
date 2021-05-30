using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviourPunCallbacks
{
    public InputField UserIdInput;

    public override void OnConnectedToMaster()
    {
        RoomOptions options = new RoomOptions
        {
            MaxPlayers = 10,
            IsOpen = true,
            IsVisible = true,
            EmptyRoomTtl = 3000,
            PlayerTtl = 3000,
            CleanupCacheOnLeave = true,
            DeleteNullProperties = true,
            CustomRoomProperties = new Hashtable { { "C0", "Default" } },
            CustomRoomPropertiesForLobby = new[] { "C0" }
        };

        PhotonNetwork.JoinOrCreateRoom("TestRoom", options, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GameScene");
    }

    public void Connect()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.AutomaticallySyncScene = false;
            PhotonNetwork.AuthValues = new AuthenticationValues(UserIdInput.text);
            PhotonNetwork.NickName = UserIdInput.text;
            PhotonNetwork.GameVersion = Application.version;
            PhotonNetwork.NetworkingClient.AppId = PhotonNetwork.PhotonServerSettings.AppSettings.AppIdRealtime;
            PhotonNetwork.NetworkingClient.EnableLobbyStatistics = true;
            PhotonNetwork.PhotonServerSettings.AppSettings.EnableLobbyStatistics = true;
            PhotonNetwork.ConnectToRegion("jp");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
