using UnityEngine;

public class Character : MonoBehaviour
{
	[SerializeField]
	private Animator Animator;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Q))
        {
			Animator.SetTrigger("SayHiTrigger");
        }
	}
}
