using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelloWorld : MonoBehaviourPunCallbacks
{
    public GameObject[] Pages;

    public GameObject InitialPage;
    public InputField NickNameInput;

    public GameObject LobbiesPage;
    public InputField LobbyNameInput;

    public GameObject RoomsPage;
    public InputField RoomNameInput;

    public GameObject RoomPage;

    #region IConnectionCallbacks
    public override void OnConnected()
    {
        Debug.Log("Connected to Photon");

        if (PhotonNetwork.InLobby)
        {
            SwitchToPage(RoomsPage);
        }
        else
        {
            SwitchToPage(LobbiesPage);
        }        
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master server");
    }

    public override void OnCustomAuthenticationFailed(string debugMessage)
    {
        Debug.Log("Custom authentication failed: " + debugMessage);
    }

    public override void OnCustomAuthenticationResponse(Dictionary<string, object> data)
    {
        Debug.Log("Custom authenticated: " + data);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected: " + cause.ToString());
        SwitchToPage(InitialPage);
    }

    public override void OnRegionListReceived(RegionHandler regionHandler)
    {
        string message = string.Empty;

        foreach (Region region in regionHandler.EnabledRegions)
        {
            message += "Code: " + region.Code + " | Cluster: " + region.Cluster + " | Host and port: " + region.HostAndPort + " | Ping:" + region.Ping + " | Was pinged: " + region.WasPinged + Environment.NewLine;
        }

        Debug.Log("Regions: " + Environment.NewLine + message);
    }
    #endregion

    #region ILobbyCallBacks
    public override void OnJoinedLobby()
    {
        Debug.Log("Joined to lobby: " + PhotonNetwork.CurrentLobby.Name);
        SwitchToPage(RoomsPage);
    }

    public override void OnLeftLobby()
    {
        Debug.Log("Left from lobby: " + PhotonNetwork.CurrentLobby.Name);
        SwitchToPage(LobbiesPage);
    }

    public override void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
    {
        string message = string.Empty;

        foreach (TypedLobbyInfo lobbyInfo in lobbyStatistics)
        {
            message += "Lobby name: " + lobbyInfo.Name + " | Lobby type: " + lobbyInfo.Type + " | Player count: " + lobbyInfo.PlayerCount + " | Is Default: " + lobbyInfo.IsDefault + " | Info: " + lobbyInfo.ToString();
        }

        Debug.Log("Lobby updated" + Environment.NewLine + message);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        string message = string.Empty;

        foreach (RoomInfo room in roomList)
        {
            message += "Name: " + room.Name + " | PlayerCount: " + room.PlayerCount + " | MaxPlayers: " + room.MaxPlayers + " | IsOpen: " + room.IsOpen + " | IsVisible: " + room.IsVisible + " | RemovedFromList: " + room.RemovedFromList + " | MasterClientId: " + room.masterClientId + Environment.NewLine;
        }

        Debug.Log("Room list updated:" + Environment.NewLine + message);
    }
    #endregion

    #region IInRoomCallbacks
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        Debug.Log("Mater client switched to player: " + newMasterClient.NickName);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("New player entered: " + Environment.NewLine
            + "User ID: " + newPlayer.UserId
            + "Nick name: " + newPlayer.NickName
            + "Actor number: " + newPlayer.ActorNumber
            + "Is master client: " + newPlayer.IsMasterClient
            + "Is local: " + newPlayer.IsLocal
            + "Has rejoined: " + newPlayer.HasRejoined
            + "Custom properties: " + newPlayer.CustomProperties
            + "Tag object: " + newPlayer.TagObject
        );
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("Player left: " + Environment.NewLine
            + "User ID: " + otherPlayer.UserId
            + "Nick name: " + otherPlayer.NickName
            + "Actor number: " + otherPlayer.ActorNumber
            + "Is master client: " + otherPlayer.IsMasterClient
            + "Is local: " + otherPlayer.IsLocal
            + "Has rejoined: " + otherPlayer.HasRejoined
            + "Custom properties: " + otherPlayer.CustomProperties
            + "Tag object: " + otherPlayer.TagObject
        );
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        Debug.Log("Player's property updated: " + Environment.NewLine
            + "User ID: " + targetPlayer.UserId
            + "Nick name: " + targetPlayer.NickName
            + "Actor number: " + targetPlayer.ActorNumber
            + "Is master client: " + targetPlayer.IsMasterClient
            + "Is local: " + targetPlayer.IsLocal
            + "Has rejoined: " + targetPlayer.HasRejoined
            + "Custom properties: " + targetPlayer.CustomProperties
            + "Tag object: " + targetPlayer.TagObject
            + "Changed properties: " + JsonUtility.ToJson(changedProps)
        );
    }

    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
    {
        Debug.Log("Room properties updated: " + Environment.NewLine + JsonUtility.ToJson(propertiesThatChanged));
    }
    #endregion

    #region IMatchmakingCallbacks
    public override void OnFriendListUpdate(List<FriendInfo> friendList)
    {
        string message = string.Empty;

        foreach(FriendInfo friendInfo in friendList)
        {
            message += "User ID: " + friendInfo.UserId + " | Name: " + friendInfo.Name + " | Is online: " + friendInfo.IsOnline + " | Is in room: " + friendInfo.IsInRoom + " | Room: " + friendInfo.Room + Environment.NewLine;
        }

        Debug.Log("Friend list updated: " + Environment.NewLine + message);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created a room");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create a room. Return code: " + returnCode + ". Error message: " + message);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room");
        SwitchToPage(RoomPage);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join a room. Return code: " + returnCode + ". Error message: " + message);
    }

    public override void OnLeftRoom()
    {
        Debug.Log("Left a room");
        SwitchToPage(RoomsPage);
    }
    #endregion

    public void Connect()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.NickName = NickNameInput.text;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
    }

    public void JoinLobby()
    {
        if (string.IsNullOrWhiteSpace(LobbyNameInput.text))
        {
            PhotonNetwork.JoinLobby();
        }
        else
        {
            PhotonNetwork.JoinLobby(new TypedLobby(LobbyNameInput.text, LobbyType.SqlLobby));
        }
    }

    public void LeaveLobby()
    {
        PhotonNetwork.LeaveLobby();
    }

    public void JoinRoom()
    {
        if (string.IsNullOrWhiteSpace(RoomNameInput.text))
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            RoomOptions options = new RoomOptions();
            options.MaxPlayers = 10;
            options.IsOpen = true;
            options.IsVisible = true;
            options.EmptyRoomTtl = 3000;
            options.PlayerTtl = 3000;
            options.CleanupCacheOnLeave = false;
            options.DeleteNullProperties = false;
            options.CustomRoomProperties = new Hashtable { { "WelcomeMessage", "Hello" } };
            options.CustomRoomPropertiesForLobby = new string[] { "WelcomeMessage" };
            TypedLobby lobbyType = new TypedLobby(LobbyNameInput.text, LobbyType.SqlLobby);

            if (PhotonNetwork.JoinOrCreateRoom(RoomNameInput.text, options, lobbyType))
            {
                Debug.Log("Joined room");
            }
            else
            {
                Debug.Log("Failed to join room");
            }
        }
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    private void Start()
    {
        SwitchToPage(InitialPage);
    }

    private void SwitchToPage(GameObject targetPage)
    {
        foreach (GameObject page in Pages)
        {
            if (page == targetPage)
            {
                page.SetActive(true);
            }
            else
            {
                page.SetActive(false);
            }            
        }
    }
}