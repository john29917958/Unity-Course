using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public GameObject PhotonObject;
    public InputField Input;
    public Text MessageHistory;
    public Dropdown ChannelDropdown;
    public InputField PlayerInput;

    private int _originChannel = 0;
    private List<GameObject> _objectPool;

    private bool _createFlag;

    private void Start()
    {
        _objectPool = new List<GameObject>();
    }

    public void CreateCube()
    {
        _createFlag = !_createFlag;
        GameObject obj = PhotonNetwork.Instantiate(PhotonObject.name + (_createFlag ? string.Empty : "2"), Vector3.zero, Quaternion.identity, 0, new object[] {"Hi", 123});
        _objectPool.Add(obj);
    }

    public void CleanCubes()
    {
        Debug.Log("Before clean: " + _objectPool.Count);
        foreach (GameObject obj in _objectPool.ToArray())
        {
            PhotonNetwork.Destroy(obj);
            _objectPool.Remove(obj);
        }
        Debug.Log("After clean: " + _objectPool.Count);
    }

    public void RegisterChannel()
    {
        int channel = Convert.ToInt32(ChannelDropdown.itemText.text);

        if (_originChannel != 0) PhotonNetwork.SetInterestGroups(Convert.ToByte(_originChannel), false);
        PhotonNetwork.SetInterestGroups(Convert.ToByte(channel), true);

        _originChannel = channel;
    }

    [PunRPC]
    public void Send()
    {
        PhotonNetwork.RunRpcCoroutines = true;
        PhotonView photon = PhotonView.Get(this);
        Player player = PhotonNetwork.LocalPlayer;

        if (!string.IsNullOrWhiteSpace(PlayerInput.text))
        {
            foreach (Player other in PhotonNetwork.PlayerListOthers)
            {
                if (other.NickName == PlayerInput.text)
                {
                    photon.RpcSecure("OnReceiveMessage", other, true, player.NickName, Input.text);
                    MessageHistory.text += Environment.NewLine + player.NickName + " - " + Input.text;
                }
            }
        }
        else
        {
            photon.RPC("OnReceiveMessage", RpcTarget.All, player.NickName, Input.text);
        }
        
        Input.text = string.Empty;
    }

    [PunRPC]
    public IEnumerator OnReceiveMessage(string name, string message)
    {
        MessageHistory.text += Environment.NewLine + name + " - " + message;
        yield return new WaitForSeconds(0);
    }
}
