using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "State", menuName = "TC/State", order = 1)]
public class StateSO : ScriptableObject
{
	public string StateName;

	public StateSO[] NextStates;

	[MenuItem("TC/Create Example State")]
	public static void CreateExampleAssetInstance()
    {
        StateSO exampleAsset = CreateInstance<StateSO>();
		AssetDatabase.CreateAsset(exampleAsset, "Assets/ScriptableObjects/ExampleState.asset");
		AssetDatabase.Refresh();
    }
}
