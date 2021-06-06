using Photon.Pun;
using UnityEngine;

public class PhotonObjCallback2 : MonoBehaviour, IPunInstantiateMagicCallback
{
    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        foreach (object data in info.photonView.InstantiationData)
        {
            Debug.Log("Photon object created (2): " + info.photonView.Group + " - " + data);
            info.photonView.transform.parent = PhotonView.Find(1).transform;
        }
    }
}
