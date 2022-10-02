using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager_Splash : MonoBehaviour
{
    private string assetBundleUrl = "https://drive.google.com/uc?export=download&id=1ZpgYG4QVu7NYBp4Qb_XXmxDz7rGsked0";

    public static Texture2D ballTexture;
    
    private void Start()
    {
        UtilityManager.SetaScreenTimeOut();

        DownloadAssetBundle();
    }

    private void LoadHomeScreen()
    {
        ScenesManager.LoadScene(ScenesManager.Home);
    }

    private void DownloadAssetBundle()
    {
        WWW www = new WWW(assetBundleUrl);
        StartCoroutine(WebRequest(www));
    }

    private IEnumerator WebRequest(WWW www)
    {
        yield return www;

        while (www.isDone == false)
        {
            yield return null;
        }

        try
        {
            if (www.error == null)
            {
                Debug.Log("asset bundle download success");

                AssetBundle bundle = www.assetBundle;

                ballTexture = bundle.LoadAsset<Texture2D>("red_ball");

                if (ballTexture == null)
                {
                    Debug.Log("asset bundle download error : no such asset present in bundle");
                }
            }
            else
            {
                Debug.Log("asset bundle download error : " + www.error);
            }
        }
        catch (System.Exception e)
        {
            Debug.Log("asset bundle download error : " + e.ToString());
        }

        LoadHomeScreen();
    }
}
