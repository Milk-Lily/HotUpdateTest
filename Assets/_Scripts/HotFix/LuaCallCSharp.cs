using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[LuaCallCSharp]
public class LuaCallCSharp
{
    public static string Log(string content)
    {
        return "LuaCallCSharp : " + content;
    }
}
