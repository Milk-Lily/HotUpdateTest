using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CreateAssetBundle
{
    [MenuItem("Tools/Build AssetBundles")]
    public static void BuildAssetBundles()
    {
        string dir = "Assets/StreamingAssets";
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.Android);
    }
}
