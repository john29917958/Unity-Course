using System.Runtime.InteropServices;
using UnityEngine;

public class Manager : MonoBehaviour
{
	[DllImport("NativeCppLibrary", EntryPoint = "displayNumber")]
	public static extern int displayNumber();

	[DllImport("NativeCppLibrary", EntryPoint = "getRandom")]
	public static extern int getRandom();

	[DllImport("NativeCppLibrary", EntryPoint = "displaySum")]
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
