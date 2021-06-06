using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class OnwerShip : MonoBehaviour, IPunOwnershipCallbacks
{
    [SerializeField] private PhotonView _view;

    public void RequestOwnership()
    {
        Debug.Log("Taking ownership");
        _view.RequestOwnership();
    }

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
        if (true)
        {
            targetView.TransferOwnership(requestingPlayer);
        }
    }

    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        Debug.Log("Ownership transferred to: " + PhotonNetwork.LocalPlayer.NickName);
    }

    public void OnOwnershipTransferFailed(PhotonView targetView, Player senderOfFailedRequest)
    {
        Debug.Log(senderOfFailedRequest.NickName + " failed to take ownership");
    }
}
