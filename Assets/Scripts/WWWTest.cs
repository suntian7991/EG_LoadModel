using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Utilities.Gltf.Schema;
using Microsoft.MixedReality.Toolkit.Utilities.Gltf.Serialization;

public class WWWTest : MonoBehaviour
{
    public GameObject model;
    public Transform modelPos;
    public GltfObject gltfObject;
    private string url1;
    private string url2;
    private bool isStartCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        url1 = @"D:\ThesisMaterials\3DModels\simplified real robot.glb";
        //url1 = @"D:\ThesisMaterials\3DModels\mill stand AM195.glb";
        url2 = @"D:\ThesisMaterials\3DModels\Baugruppe1.glb";
        //url1 = @"D:\ThesisMaterials\ExcavatorTest.glb";
        //url1 = @"D:\ThesisMaterials\gearbox.glb";
        //url1 = @"D:\ThesisMaterials\3DModels\input pinion shaft assem.glb";
        //url1 = @"D:\ThesisMaterials\3DModels\Mercedes F1 Concept.glb";
        //url1 = @"D:\ThesisMaterials\3DModels\铆压热熔机.glb";
        //model = GameObject.Find("Main Camera");
        

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //if (isStartCoroutine==true)
            //{
            //    isStartCoroutine = false;
            //    StopCoroutine("LoadModelData");
            //}
            //else 
            //{
            //    isStartCoroutine= true;
            StartCoroutine(LoadModelData(url1));
            Invoke("LoadModel", 10f);

            //}

            //LoadModel();
        }
        //if (Input.GetMouseButtonDown(1))
        //{
        //    if (isStartCoroutine == true)
        //    {
        //        isStartCoroutine = false;
        //        StopCoroutine("LoadModelData");
        //    }
        //    else
        //    {
        //        isStartCoroutine = true;
        //        StartCoroutine(LoadModelData(url2));
        //        Invoke("LoadModel", 0.1f);

        //    }

        //}
        //Invoke("LoadModel", 0.1f);
    }
    private IEnumerator LoadModelData(string Url)
    {

        //"https://www.xuefei.net.cn/unitywebgl/WaterBottle.glb"
        //https://google.de
        var webRequest = UnityWebRequest.Get(Url);
        yield return webRequest.SendWebRequest();
        //if (webRequest.result != UnityWebRequest.Result.Success)
        if (webRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("网络有问题");
            Debug.LogError(webRequest.error);
        }
        else
        {
            Debug.Log("连接成功");
            if (webRequest.isDone)
            {
                Debug.Log("加载完成");
                gltfObject = GltfUtility.GetGltfObjectFromGlb(webRequest.downloadHandler.data);


                //GameObject node = gltfObject.GameObjectReference;
                //model = Instantiate(node, modelPos);
                //Debug.Log(gltfObject.GameObjectReference);

                
                ConstructGltf.Construct(gltfObject);
                //gltfObject.GameObjectReference.transform.position = new Vector3(0.0f, 0.0f, 2.0f);
                //model.transform.position = modelPos.position;
                //Debug.Log("-----------");

            }
            //Debug.Log(webRequest.downloadHandler.text);
            //loadGo = Importer.LoadFromBytes(request.downloadHandler.data);

            //gltfObject = GltfUtility.GetGltfObjectFromGlb(webRequest.downloadHandler.data);
            //gltfObject.GameObjectReference.transform.position = modelPos.position;

        }
    }
    public async void LoadModel()
    {
        //if (model != null)
        //{
        //    DestroyImmediate(model);
        //    Resources.UnloadUnusedAssets();
        //}
        //else
        //{
        //    model = await gltfObject.ConstructAsync();
        //    model.transform.position = modelPos.position;
        //}
        //model = GameObject.Find("Main Camera");
        //model.transform.position = new Vector3(0.0f, 0.0f, -2.0f);
    }


 }
