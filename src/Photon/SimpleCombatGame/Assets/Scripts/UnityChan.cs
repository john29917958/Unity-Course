using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class UnityChan : MonoBehaviour
{
    public int Health { get; private set; } = 100;

    public Player OwnerPhotonPlayer;

    [SerializeField] private Animator _animator;

    [SerializeField] private Rigidbody _body;

    public void TakeDamage(int value)
    {
        Health -= value;
        if (value < 0) value = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!PhotonNetwork.LocalPlayer.Equals(OwnerPhotonPlayer)) return;

        if (Input.GetKeyDown(KeyCode.C))
        {
            _animator.SetTrigger("Jab");
            transform.Translate(Vector3.forward * 10 * Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _animator.SetTrigger("SAMK");
            transform.Translate(Vector3.back * 10 * Time.deltaTime);
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                _animator.SetBool("Run", true);
                transform.Translate(Vector3.forward * 1 * Time.deltaTime);
            }
            else
            {
                _animator.SetBool("Run", false);
            }
        }
    }
}
