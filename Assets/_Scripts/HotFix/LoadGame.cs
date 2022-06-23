using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.IO;
public class LoadGame : MonoBehaviour
{

    public Slider processView;

    void Start()
    {
        LoadGameMethod();
    }
    
    public void LoadGameMethod()
    {
        StartCoroutine(LoadResourceCorotine());//请求服务端的lua脚本
        StartCoroutine(StartLoading(1));//跳转-异步请求目标场景资源
    }

    private IEnumerator StartLoading(int scene)
    {
        int displayProgress = 0;//当前进度
        int toProgress = 0;//目标进度
        AsyncOperation op = SceneManager.LoadSceneAsync(scene);
        op.allowSceneActivation = false;
        while (op.progress < 0.9f)
        {
            toProgress = (int)op.progress * 100;
            while (displayProgress < toProgress)
            {
                ++displayProgress;
                SetLoadingPercentage(displayProgress);
                yield return new WaitForEndOfFrame();
            }
        }

        toProgress = 100;
        while (displayProgress < toProgress)
        {
            ++displayProgress;
            SetLoadingPercentage(displayProgress);
            yield return new WaitForEndOfFrame();
        }
        op.allowSceneActivation = true;
    }

    IEnumerator LoadResourceCorotine()
    {
    	//localhost为虚拟服务器域名
        string path = Application.streamingAssetsPath + "/Lua/Test.lua.txt";
        UnityWebRequest request = UnityWebRequest.Get(@"http://localhost:71/Test.lua.txt");
        yield return request.SendWebRequest();
        string str = request.downloadHandler.text;
        File.WriteAllText(path, str);
        UnityWebRequest request1 = UnityWebRequest.Get(@"http://localhost:71/TestDispose.lua.txt");
        yield return request1.SendWebRequest();
        string str1 = request1.downloadHandler.text;
        string path1 = Application.streamingAssetsPath + "/Lua/TestDispose.lua.txt";
        File.WriteAllText(path1, str1);
        Debug.LogError("DownLoad lua.txt Success");
    }

    private void SetLoadingPercentage(float v)
    {
        processView.value = v / 100;
    }

}

