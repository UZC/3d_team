using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour
{
    public float time;
    public GameObject go;
    public CameraMovement cm;

    void Start()
    {
        go.SetActive(false);
        StartCoroutine(BeforeStartPause());
    }

    
    void Update()
    {
        
    }
    public IEnumerator BeforeStartPause()
    {
        yield return new WaitForSeconds(time);
        go.SetActive(true);
        CameraMovement.isReady = true;
    }
}
