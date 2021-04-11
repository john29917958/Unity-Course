using System.Runtime.InteropServices;
using UnityEngine;

public class Manager : MonoBehaviour
{
	[DllImport("NATIVECPPLIBRARY", EntryPoint = "displayNumber")]
	public static extern int displayNumber();

	[DllImport("NATIVECPPLIBRARY", EntryPoint = "getRandom")]
	public static extern int getRandom();

	[DllImport("NATIVECPPLIBRARY", EntryPoint = "displaySum")]
	public static extern int displaySum();

	// Use this for initialization
	void Start ()
	{
		Debug.Log(displayNumber());
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
