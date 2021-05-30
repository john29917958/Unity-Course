using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject PhotonObject;

    private List<GameObject> _objectPool;

    private void Awake()
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
}
