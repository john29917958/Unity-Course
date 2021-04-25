#if UNITY_EDITOR
using UnityEditor;
using System.IO;
using UnityEngine;

public class AssetBundleMaker : Editor
{
    [MenuItem("AssetBundles/Make")]
    static void Make()
    {
        string bundleFolder = Path.Combine(Path.GetTempPath(), "AssetBundles");
        if (!Directory.Exists(bundleFolder))
        {
            Directory.CreateDirectory(bundleFolder);
        }

        BuildPipeline.BuildAssetBundles(bundleFolder, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
        Debug.Log("Asset bundle maked in \"" + bundleFolder + '"');
    }
}
#endif