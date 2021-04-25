using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelloWorld : MonoBehaviourPunCallbacks
{
    public GameObject InitialPage;
    public InputField NickNameInput;

    public GameObject MasterPage;
    public GameObject MainPage;

    #region IConnectionCallbacks
    public override void OnConnected()
    {
        Debug.Log("Connected to Photon");
        InitialPage.SetActive(false);
        MasterPage.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
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
        Debug.Log("Joined to a lobby");
    }

    public override void OnLeftLobby()
    {
        Debug.Log("Left from a lobby");
    }

    public override void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
    {
        
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

    public void JoinLobby()
    {
        PhotonNetwork.JoinLobby();
    }
}