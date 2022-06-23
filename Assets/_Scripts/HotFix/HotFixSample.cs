using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

[Hotfix]
public class HotFixSample : MonoBehaviour
{
    private LuaEnv _luaEnv;

    private void Awake()
    {
        _luaEnv = new LuaEnv();
        _luaEnv.AddLoader(MyLoader);
        _luaEnv.DoString("require 'Test'");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        SetPos();
    }

    [LuaCallCSharp]
    void SetPos()
    {
        transform.position = new Vector3(1, 0, 0);
    }

    private void OnDisable()
    {
        _luaEnv.DoString("require 'TestDispose'");
        _luaEnv.Dispose();
    }

    private byte[] MyLoader(ref string filePath)
    {
        string path = Application.dataPath + "/StreamingAssets/Lua/" + filePath + ".lua.txt";
        return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(path));
    }
}
