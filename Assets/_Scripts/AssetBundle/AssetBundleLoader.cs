using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using _Scripts;
using UnityEngine;

public class AssetBundleLoader
{
    private AssetBundle _assetBundle;

    public void LoadGameObject(Action<GameObject> finishAction)
    {
        if (_assetBundle)
        {
            finishAction?.Invoke(_assetBundle.LoadAsset<GameObject>("Cube"));
            return;
        }

        GlobalController.Instance().StartCoroutine(LoadGameObjectSync(finishAction));
    }

    // Start is called before the first frame update
    IEnumerator LoadGameObjectSync(Action<GameObject> finishAction)
    {
        string path = Application.streamingAssetsPath + "/editor.ab";
        // WWW reader = new WWW(path);
        // while (!reader.isDone)
        // {
        //     
        // }
        //
        // string content = reader.text;
        AssetBundle ab = AssetBundle.LoadFromFile(path);
        _assetBundle = ab;
        finishAction?.Invoke(_assetBundle.LoadAsset<GameObject>("Cube"));
        yield return null;
    }
}
