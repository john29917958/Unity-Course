using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AssetBundleLoader : MonoBehaviour
{
    public IEnumerator Load()
    {
        Debug.Log("FromUnityWebRequest");
        //string path = @"file:///C:\Users\ASUS\Desktop\36. AssetBundle載入外部資料\AssetBundlePJ\AB\all.p";
        //string matpath = @"file:///C:\Users\ASUS\Desktop\36. AssetBundle載入外部資料\AssetBundlePJ\AB\m";

        /*
        Google雲端空間
        https://jerrard-liu.blogspot.com/2019/05/googlehtml.html
        https://drv.tw/

        https://drv.tw/~[username]/[drive]/[path]
        [username]	is the account email address to access cloud drive,
        [drive]	is "gd" for Google Drive and "od" for Microsoft OneDrive, and
        [path]	is the full, case-sensitive path that locates the file.
        */
        string path = "https://drv.tw/~tim931130505@gmail.com/gd/AB/allp.u3d";
        string matpath = "https://drv.tw/~tim931130505@gmail.com/gd/AB/m";

        UnityWebRequest unityWebRequest;
        unityWebRequest = UnityWebRequest.GetAssetBundle(path);
        yield return unityWebRequest.Send();

        UnityWebRequest unityWebRequest2;
        unityWebRequest2 = UnityWebRequest.GetAssetBundle(matpath);
        yield return unityWebRequest2.Send();

        AssetBundle ab = DownloadHandlerAssetBundle.GetContent(unityWebRequest);
        AssetBundle matab = DownloadHandlerAssetBundle.GetContent(unityWebRequest2);

        object[] lists = ab.LoadAllAssets();

        foreach (var o in lists)
        {
            Debug.Log(((GameObject)o).name);
            GameObject preObj = o as GameObject;
            GameObject obj = Instantiate(preObj);
        }

        yield return null;

        //AssetBundle matab = DownloadHandlerAssetBundle.GetContent(unityWebRequest2);//★材質會慢出，需要事先載完
        Debug.Log("FromUnityWebRequest_Finish");
    }
}
