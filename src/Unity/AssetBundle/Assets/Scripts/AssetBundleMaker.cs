using System.IO;
using UnityEditor;
using UnityEngine;

public class AssetBundleMaker : Editor
{
    [MenuItem("AssetBundles/Make")]
    private static void Make()
    {
        string bundleFolder = "AssetBundles";
        if (!Directory.Exists(bundleFolder))
        {
            Directory.CreateDirectory(bundleFolder);
        }

        BuildPipeline.BuildAssetBundles(bundleFolder, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
        Debug.Log("Asset bundle maked");
    }
}