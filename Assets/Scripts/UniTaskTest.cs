using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;
using Microsoft.MixedReality.Toolkit.Utilities.Gltf.Schema;
using Microsoft.MixedReality.Toolkit.Utilities.Gltf.Serialization;
using System.Net;
using System.IO;

public class UniTaskTest : MonoBehaviour
{
    public GltfObject gltfObject;

    async void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            string url1 = Application.streamingAssetsPath + "/simplified real robot.glb";
            //string url1 = "https://localhost:7041/3DModels/simplified real robot.glb";
           
        await LoadGlbModelAsync(url1);
            //ConnectUrl(url1);
            //StartCoroutine(LoadModelCorototine(url1));
        }
        if (Input.GetMouseButtonDown(1))
        {
            string url2 = Application.streamingAssetsPath + "/AnimatedMorphCube.glb";
            //string url2 = "https://localhost:7041/3DModels/AnimatedMorphCube.glb";
            await LoadGlbModelAsync(url2);
            //ConnectUrl(url2);
        }
    }
    public IEnumerator LoadModelCorototine(string Url)
    {
        var task = LoadGlbModelAsync(Url);
        while (true)
        {
            switch (task.Status)
            {
                case UniTaskStatus.Pending:
                    Debug.Log("Pending");
                    break;
                case UniTaskStatus.Succeeded:
                    break;
                case UniTaskStatus.Faulted:
                    Debug.Log("Faulted");
                    break;


            }
        }
    }

    public async UniTask<GameObject> LoadGlbModelAsync(string Url)
    {
        Debug.Log(Url);
        if (gltfObject != null)
        {
            //Debug.Log(gltfObject != null);
            DestroyImmediate(gltfObject.GameObjectReference);
            Resources.UnloadUnusedAssets();
        }
        Debug.Log("加载数据");
        var modelData = (await UnityWebRequest.Get(Url).SendWebRequest()).downloadHandler.data;

        //var webRequest = await UnityWebRequest.Get(Url).SendWebRequest();
        //gltfObject = GltfUtility.GetGltfObjectFromGlb(webRequest.downloadHandler.data);
        Debug.Log(modelData);
        Debug.Log(modelData.Length);
        gltfObject = GltfUtility.GetGltfObjectFromGlb(modelData);
        Debug.Log(gltfObject);
        //await UniTaskExtensions.AsUniTask(ConstructGltf.ConstructAsync(gltfObject),true) ;
        var uniTask = ConstructGltf.ConstructAsync(gltfObject).AsUniTask();
         await uniTask;
        Debug.Log(uniTask.Status);
        //var task = ConstructGltf.ConstructAsync(gltfObject);
        //var uniTask = UniTask.Create()
        Debug.Log("设置gltfObject位置");
        gltfObject.GameObjectReference.transform.position = new Vector3(0.0f, 0.0f, 2.0f);
        Debug.Log("返回gltfObject.GameObjectReference");
        return gltfObject.GameObjectReference;

    }

    //public GameObject cube;
    //void Start()
    //{
    //    ShowCube();
    //}
    //async UniTask ShowCube()
    //{

    //    Debug.Log("start");
    //    await UniTask.Delay(System.TimeSpan.FromSeconds(3), ignoreTimeScale: false);
    //    Debug.Log("first");
    //    cube.SetActive(true);
    //    await UniTask.Delay(System.TimeSpan.FromSeconds(3), ignoreTimeScale: false);
    //    Debug.Log("second");
    //    cube.SetActive(false);
    //    await UniTask.Delay(System.TimeSpan.FromSeconds(3), ignoreTimeScale: false);
    //    Debug.Log("third");
    //    cube.SetActive(true);
    //    await UniTask.Delay(System.TimeSpan.FromSeconds(3), ignoreTimeScale: false);
    //    cube.SetActive(false);
    //    Debug.Log("end");
    //}

}
