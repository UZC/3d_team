using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;


    public float maxDistance, minDistance;
    public float maxY, minY;
    public float startForRotateY;
    public float maxAngle;
    public float zCoord;

    private Vector3 startCameraAngle;
    public static bool isReady = false;
    void Start()
    {
        startCameraAngle = this.transform.eulerAngles;
    }


    void FixedUpdate()
    {
        if (isReady)
        {
            float z = MoveCameraOnZ();
            float x = MoveCameraOnX();
            MoveCameraOnY();
            DistanceBetweenCenterAndCamera(x, z);
            RotateCamera();
        }
    }

    private float MoveCameraOnX()
    {
        float centrX = (player1.transform.position.x + player2.transform.position.x) / 2;
        this.transform.position = new Vector3(centrX, this.transform.position.y, this.transform.position.z);
        return centrX;
    }

    private float MoveCameraOnZ()
    {
        float centrZ = (player1.transform.position.z + player2.transform.position.z) / 2;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, centrZ - zCoord);
        return centrZ;
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
            coordY = (distance - minDistance) * ratio + minY; 
        }
        this.transform.position = new Vector3(this.transform.position.x, coordY, this.transform.position.z);
    }
    private void DistanceBetweenCenterAndCamera(float x, float z)
    {
        float distance = Vector3.Distance(new Vector3(x, 0, z), this.transform.position);
    }
    private void RotateCamera()
    {
        if (this.transform.position.y <= startForRotateY)
        {
            float tempForAngleDiff = startCameraAngle.x - maxAngle;
            float tempForDifferentY = startForRotateY - minY;
            float ratio = tempForAngleDiff / tempForDifferentY;

            float cameraRotationX = ((this.transform.position.y - minY) * ratio) + maxAngle;
            this.transform.eulerAngles = new Vector3(cameraRotationX, startCameraAngle.y, startCameraAngle.z);
            
        } else this.transform.eulerAngles = startCameraAngle;
    }
}
