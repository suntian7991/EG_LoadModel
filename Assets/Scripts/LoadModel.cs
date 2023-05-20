using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Microsoft.MixedReality.Toolkit.Utilities.Gltf.Schema;
using Microsoft.MixedReality.Toolkit.Utilities.Gltf.Serialization;

public class LoadModel : MonoBehaviour
{
    public GltfObject gltfObject;
    private bool isStartCoroutine=false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            string url1 = Application.streamingAssetsPath + "/simplified real robot.glb";

            ChangeLoadModel(url1);
            //ConnectUrl(url1);
        }
        if (Input.GetMouseButtonDown(1))
        {
           string url2 = Application.streamingAssetsPath + "/baugruppe1.glb";

            ChangeLoadModel(url2);
            //ConnectUrl(url2);
        }

    }

    public async void ConnectUrl(string Url)
    {
        if (gltfObject != null)
        {
            DestroyImmediate(gltfObject.GameObjectReference);
            Resources.UnloadUnusedAssets();
            gltfObject = null;
        }
        Debug.Log("GltfUtility.ImportGltfObjectFromPathAsync");
        gltfObject = await GltfUtility.ImportGltfObjectFromPathAsync(Url);
        Debug.Log(Url);
        //gltfObject.GameObjectReference.transform.position = new Vector3(0.0f, 0.0f, 2.0f);
    }

    public void ChangeLoadModel(string Url)
    {
        if (isStartCoroutine == false)
        {
            StartCoroutine(LoadGlbModel(Url));
        }
        else
        {
            isStartCoroutine = false;
            StopCoroutine("LoadGlbModel");
            StartCoroutine(LoadGlbModel(Url));
        }
    }
    private IEnumerator LoadGlbModel(string Url)
    {
        Debug.Log(Url);
        isStartCoroutine = true;
        if (gltfObject != null)
        {
            DestroyImmediate(gltfObject.GameObjectReference);
            Resources.UnloadUnusedAssets();
        }
        var webRequest = UnityWebRequest.Get(Url);
        yield return webRequest.SendWebRequest();
        if (webRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError(webRequest.error);
        }
        else
        {
            if (webRequest.isDone)
            {
                gltfObject = GltfUtility.GetGltfObjectFromGlb(webRequest.downloadHandler.data);

                Debug.Log("To Construct gltfObject");
                ConstructGltf.Construct(gltfObject);
                //Debug.Log("After Construct gltfObject,model name is "+gltfObject.GameObjectReference.name);
            }
        }
    }
}
