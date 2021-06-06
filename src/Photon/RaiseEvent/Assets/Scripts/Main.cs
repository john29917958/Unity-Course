using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.Experimental.UIElements.Button;

public class Main : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField _nickNameInput;
    [SerializeField] private Button _loginButton;

    [SerializeField] private GameObject _loginPage;
    [SerializeField] private GameObject _mainPage;

    private bool _isEnabledRaiseEvent = false;

    private void Start()
    {
        _loginPage.SetActive(true);
        _mainPage.SetActive(false);
    }

    public override void OnJoinedRoom()
    {
        _mainPage.gameObject.SetActive(true);
        _loginPage.gameObject.SetActive(false);
    }

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

    public void Login()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.AutomaticallySyncScene = false;
            PhotonNetwork.AuthValues = new AuthenticationValues(_nickNameInput.text);
            PhotonNetwork.NickName = _nickNameInput.text;
            PhotonNetwork.GameVersion = Application.version;
            PhotonNetwork.NetworkingClient.AppId = PhotonNetwork.PhotonServerSettings.AppSettings.AppIdRealtime;
            PhotonNetwork.NetworkingClient.EnableLobbyStatistics = true;
            PhotonNetwork.PhotonServerSettings.AppSettings.EnableLobbyStatistics = true;
            PhotonNetwork.ConnectToRegion("jp");
        }
    }

    public void ToggleEnableEvent()
    {
        _isEnabledRaiseEvent = !_isEnabledRaiseEvent;

        if (_isEnabledRaiseEvent)
        {
            Debug.Log("Enable");
            PhotonNetwork.NetworkingClient.EventReceived += OnEvent;
        }
        else
        {
            Debug.Log("Disable");
            PhotonNetwork.NetworkingClient.EventReceived -= OnEvent;
        }
    }

    public void SendEvent()
    {
        string message = "Hello world!";
        RaiseEventOptions options = new RaiseEventOptions() {Receivers = ReceiverGroup.All};
        PhotonNetwork.RaiseEvent(1, message, options, SendOptions.SendReliable);
    }

    public void OnEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;
        if (eventCode == 1)
        {
            object obj = photonEvent.CustomData;
            Debug.Log(obj.ToString());
        }
    }
}
