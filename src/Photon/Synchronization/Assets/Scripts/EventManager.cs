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

    private List<GameObject> _objectPool;

    private void Start()
    {
        _objectPool = new List<GameObject>();
    }

    public void CreateCube()
    {
        GameObject obj = PhotonNetwork.Instantiate(PhotonObject.name, Vector3.zero, Quaternion.identity, 0, new object[] {"Hi", 123});
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

    [PunRPC]
    public void Send()
    {
        PhotonNetwork.RunRpcCoroutines = true;
        PhotonView photon = PhotonView.Get(this);
        Player player = PhotonNetwork.LocalPlayer;
        photon.RPC("OnReceiveMessage", RpcTarget.All, player.NickName, Input.text);
        Input.text = string.Empty;
    }

    [PunRPC]
    public IEnumerator OnReceiveMessage(string name, string message)
    {
        MessageHistory.text += Environment.NewLine + name + " - " + message;
        yield return new WaitForSeconds(0);
    }
}
