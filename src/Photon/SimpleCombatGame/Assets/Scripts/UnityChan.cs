using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class UnityChan : MonoBehaviour
{
    public enum Attacker { None, Head, RightHand, LeftHand, RightFoot, LeftFoot }

    public int Health { get; private set; } = 100;

    public Player OwnerPhotonPlayer;

    public bool Reverse;

    public bool IsAttacking { get; private set; }

    [SerializeField] private Animator _animator;

    [SerializeField] private Rigidbody _body;

    [SerializeField] private SphereCollider _rightFist;
    [SerializeField] private SphereCollider _LeftFist;

    public void TakeDamage(int value)
    {
        Health -= value;
        if (value < 0) value = 0;

        Debug.Log(PhotonNetwork.LocalPlayer.NickName + ": " + Health);
        _animator.SetTrigger("DamageDown");
    }

    public void FistAttackStart(Attacker attacker)
    {
        IsAttacking = true;

        switch (attacker)
        {
            case Attacker.RightHand:
                _rightFist.enabled = true;
                break;
            case Attacker.LeftHand:
                _LeftFist.enabled = true;
                break;
            default:
                _rightFist.enabled = true;
                _LeftFist.enabled = true;
                break;
        }
    }

    public void FistAttackEnd()
    {
        IsAttacking = false;
        _rightFist.enabled = false;
        _LeftFist.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!PhotonNetwork.LocalPlayer.Equals(OwnerPhotonPlayer)) return;
        KeyCode forward = Reverse ? KeyCode.LeftArrow : KeyCode.RightArrow;
        KeyCode backward = Reverse ? KeyCode.RightArrow : KeyCode.LeftArrow;

        if (Input.GetKeyDown(KeyCode.C))
        {
            _animator.SetTrigger("Jab");
            transform.Translate(Vector3.forward * 10 * Time.deltaTime);
        }
        else if (Input.GetKeyDown(backward))
        {
            _animator.SetTrigger("SAMK");
            transform.Translate(Vector3.back * 50 * Time.deltaTime);
        }
        else
        {
            if (Input.GetKey(forward))
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

    private void OnTriggerEnter(Collider col)
    {
        if (IsAttacking)
        {
            _rightFist.enabled = false;
            _LeftFist.enabled = false;
            IsAttacking = false;
            UnityChan chan = col.GetComponent<UnityChan>();
            if (chan != null) chan.TakeDamage(10);
        }
    }
}
