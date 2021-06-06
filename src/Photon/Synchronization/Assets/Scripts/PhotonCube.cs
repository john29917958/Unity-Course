using Photon.Pun;
using UnityEngine;

public class PhotonCube : MonoBehaviour, IPunObservable
{
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsReading)
        {
            object obj = stream.ReceiveNext();
            Debug.Log(obj.ToString());
        }
        else
        {
            stream.SendNext("SDF");
        }
    }
}
