using UnityEngine;
using UnityEngine.AI;

public class Tracer : MonoBehaviour {
	public NavMeshAgent Navigator;
	public Transform Target;
	public bool IsTracing;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (IsTracing)
        {
			Navigator.SetDestination(Target.position);
        }
	}
}
