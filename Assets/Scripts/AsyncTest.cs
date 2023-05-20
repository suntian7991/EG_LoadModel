using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class AsyncTest : MonoBehaviour
{
    public GameObject node;
    // Start is called before the first frame update
    void Start()
    {
        ShowCube();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("Wait for 3 seconds");

        //    ShowCube();
        //}
        
    }
    async Task ShowCube()
    {
        Debug.Log("start");
        await Task.Delay(3000);
        Debug.Log("first");
        node.SetActive(true);
        await Task.Delay(3000);
        Debug.Log("second");
        node.SetActive(false);
        await Task.Delay(3000);
        Debug.Log("third");
        node.SetActive(true);
        await Task.Delay(3000);
        node.SetActive(false);
        Debug.Log("end");
    }

}
