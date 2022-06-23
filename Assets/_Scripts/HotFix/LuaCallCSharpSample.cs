using System;
using UnityEngine;
using XLua;

namespace _Scripts
{
    public class LuaCallCSharpSample : MonoBehaviour
    {
        private LuaEnv luaEnv;
        private void Start()
        {
            RunLuaFile();
            DisposeLuaEnv(luaEnv);
        }

        private void RunLuaFile()
        {
            luaEnv = new LuaEnv();

            TextAsset textAsset = Resources.Load<TextAsset>("LuaScripts/FirstLua.lua");
            luaEnv.DoString(textAsset.text);
            Add add = luaEnv.Global.Get<Add>("Add");
            int result = add(2, 4, 3);
            Debug.Log(result);

            DisposeDelegate(add);
        }

        private void DisposeLuaEnv(LuaEnv luaEnv)
        {
            luaEnv.Dispose();
        }

        private void DisposeDelegate(Add add)
        {
            add = null;
        }

        public void LuaCallCSharpLog()
        {
            Debug.Log("This is a Test Method");
        }
    }
}

[CSharpCallLua]
public delegate int Add(int a, int vb, int c);