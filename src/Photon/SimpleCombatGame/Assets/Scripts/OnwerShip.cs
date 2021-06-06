using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class OnwerShip : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks, IOnPhotonViewOwnerChange
{
    [SerializeField] private Button _allowTakeOverButton;
    [SerializeField] private Button _rejectTakeOverButton;
    
    private bool _isConfirmed;
    private bool _isAllow;

    private void Start()
    {
        //PhotonNetwork.AddCallbackTarget(this);
        //PhotonNetwork.NetworkingClient.AddCallbackTarget(this);
        _allowTakeOverButton.gameObject.SetActive(false);
        _rejectTakeOverButton.gameObject.SetActive(false);
    }

    public void ConfirmOwnership(bool isAllow, PhotonView targetView, Player requestingPlayer)
    {
        _isConfirmed = true;
        _isAllow = isAllow;

        _allowTakeOverButton.gameObject.SetActive(false);
        _rejectTakeOverButton.gameObject.SetActive(false);

        if (_isAllow)
        {
            targetView.TransferOwnership(requestingPlayer);
        }
    }

    public void RequestOwnership(PhotonView view)
    {
        if (view.IsMine)
        {
            Debug.Log("Already mine");
        }
        else
        {
            Debug.Log("Taking ownership");
            view.RequestOwnership();
        }
    }

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
        if (!targetView.IsMine) return;

        _isConfirmed = false;
        _allowTakeOverButton.gameObject.SetActive(true);
        _rejectTakeOverButton.gameObject.SetActive(true);
        _allowTakeOverButton.onClick.RemoveAllListeners();
        _rejectTakeOverButton.onClick.RemoveAllListeners();
        _allowTakeOverButton.onClick.AddListener(() =>
        {
            ConfirmOwnership(true, targetView, requestingPlayer);
        });
        _rejectTakeOverButton.onClick.AddListener(() =>
        {
            ConfirmOwnership(false, targetView, requestingPlayer);
        });
    }

    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        Debug.Log("Ownership transferred from " + previousOwner.NickName + " to: " + targetView.Owner.NickName);
    }

    public void OnOwnershipTransferFailed(PhotonView targetView, Player senderOfFailedRequest)
    {
        Debug.Log(senderOfFailedRequest.NickName + " failed to take ownership");
    }

    public void OnOwnerChange(Player newOwner, Player previousOwner)
    {
        Debug.Log("Ownership transferred from " + previousOwner.NickName + " to " + newOwner.NickName);
    }
}
