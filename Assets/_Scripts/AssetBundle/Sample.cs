using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[Hotfix]
public class Sample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AssetBundleLoader assetBundleLoader = new AssetBundleLoader();
        assetBundleLoader.LoadGameObject(InstantiateObj);
    }

    [LuaCallCSharp]
    private void InstantiateObj(GameObject obj)
    {
        Instantiate(obj, new Vector3(0, GetPosY(), 0), Quaternion.Euler(0, 0, 0));
    }

    private float GetPosY()
    {
        return 5;
    }
}
