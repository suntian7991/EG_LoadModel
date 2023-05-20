using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Utilities.Gltf.Schema;
using Microsoft.MixedReality.Toolkit.Utilities.Gltf.Serialization;
using System;
using System.Threading.Tasks;
using System.IO;


public class WebRequestTest : MonoBehaviour
{
    public GameObject model;
    public GltfObject gltfObject;
    public async void ConnectUrl1(string modelName)
    {
        //UnityWebRequest unityWebRequest = new UnityWebRequest(@"D:\ThesisMaterials\3DModels\simplified real robot.glb");
        //Application.OpenURL(unityWebRequest.url);

        //Unity 编辑器内读取文件的方式
        //GameObject modelPrefab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Models/simplified real robot.glb");
        //GameObject model = Instantiate(modelPrefab);
        string path = "D:/ThesisMaterials/3DModels/";
        //string modelName = "simplified real robot";
        string url = path + modelName + ".glb";
            //"D:/ThesisMaterials/3DModels/simplified real robot.glb"
        gltfObject = await GltfUtility.ImportGltfObjectFromPathAsync(url);
        gltfObject.GameObjectReference.transform.position = new Vector3(0.0f, 0.0f, 2.0f);
        gltfObject.GameObjectReference.transform.name=modelName;
        Debug.Log(gltfObject.GameObjectReference.transform.name);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ConnectUrl1("simplified real robot");
        }
    }

}
