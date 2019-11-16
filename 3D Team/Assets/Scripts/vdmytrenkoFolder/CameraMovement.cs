using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;
    public float speed;

    public float maxDistance, minDistance;
    public float maxY, minY;
    void Start()
    {

    }

    
    void FixedUpdate()
    {
        MoveCameraOnZ();
        MoveCameraOnX();
        MoveCameraOnY();
    }

    private void MoveCameraOnX()
    {
        float centrX = (player1.transform.position.x + player2.transform.position.x) / 2;
        this.transform.position = new Vector3(centrX, this.transform.position.y, this.transform.position.z); 
    }

    private void MoveCameraOnZ()
    {
        float centrZ = (player1.transform.position.z + player2.transform.position.z) / 2;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, centrZ - 10);
    }
    private void MoveCameraOnY()
    {
        float distance = Vector3.Distance(player1.transform.position, player2.transform.position);
        float coordY;
        if (distance >= maxDistance) coordY = maxY;
        else if (distance <= minDistance) coordY = minY;
        else
        {
            float tempDistDiff = maxDistance - minDistance;
            float tempYdiff = maxY - minY;
            float ratio = tempYdiff / tempDistDiff;
            coordY = distance * ratio - 0.5f;
        }
        this.transform.position = new Vector3(this.transform.position.x, coordY, this.transform.position.z);
        //Debug.Log(distance);
    }
}
