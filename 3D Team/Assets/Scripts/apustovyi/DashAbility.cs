using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : MonoBehaviour
{

    [SerializeField] private float dashDistance;
    [SerializeField] private float cooldownTime;
    private Vector3 teleportPlace;
    private string horizontal, vertical;
    private float nextTeleportTime = 0;

    [SerializeField]
    SkillCooldown sc;
    
    public void Update() // Update is called once per frame
    {

    }
    public void Dash(string horizontal, string vertical)
    {
       if (Time.time > nextTeleportTime)
        {
            sc.StartCooldown(cooldownTime);
        if (Input.GetAxis(horizontal) > 0)
        {
            teleportPlace = new Vector3(this.transform.position.x + dashDistance, this.transform.position.y, this.transform.position.z);
            transform.position = teleportPlace;
            nextTeleportTime = Time.time + cooldownTime;
        }
        if (Input.GetAxis(horizontal) < 0)
        {
            teleportPlace = new Vector3(this.transform.position.x - dashDistance, this.transform.position.y, this.transform.position.z);
            transform.position = teleportPlace;
            nextTeleportTime = Time.time + cooldownTime;
        }
        if (Input.GetAxis(vertical) > 0 )
        {
            teleportPlace = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + dashDistance);
            transform.position = teleportPlace;
            nextTeleportTime = Time.time + cooldownTime;
        }
        if (Input.GetAxis(vertical) < 0 )
        {
            teleportPlace = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - dashDistance);
            transform.position = teleportPlace;
            nextTeleportTime = Time.time + cooldownTime;
        }
            
        }


    }
    
}


