using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : MonoBehaviour
{

    [SerializeField] private float dashDistance;
    private Vector3 TeleportPlace;
    //public Transform teleportTarget;
    public GameObject thePlayer;


    // Update is called once per frame
    public void Update()
    {
        Dash();
        //HandleMovement();
    }
    public void Dash()
    {
        if (Input.GetAxis("Horizontal") > 0 && (Input.GetKey(KeyCode.JoystickButton3)))
        {
            TeleportPlace = new Vector3(thePlayer.transform.position.x + dashDistance, thePlayer.transform.position.y, thePlayer.transform.position.z);
            transform.position = TeleportPlace;
        }
        if (Input.GetAxis("Horizontal") < 0 && (Input.GetKey(KeyCode.JoystickButton3)))
        {
            TeleportPlace = new Vector3(thePlayer.transform.position.x - dashDistance, thePlayer.transform.position.y, thePlayer.transform.position.z);
            transform.position = TeleportPlace;
        }
        if (Input.GetAxis("Vertical") > 0 && (Input.GetKey(KeyCode.JoystickButton3)))
        {
            TeleportPlace = new Vector3(thePlayer.transform.position.x, thePlayer.transform.position.y, thePlayer.transform.position.z + dashDistance);
            transform.position = TeleportPlace;
        }
        if (Input.GetAxis("Vertical") < 0 && (Input.GetKey(KeyCode.JoystickButton3)))
        {
            TeleportPlace = new Vector3(thePlayer.transform.position.x, thePlayer.transform.position.y, thePlayer.transform.position.z - dashDistance);
            transform.position = TeleportPlace;
        }

    }
}
    /*  private void HandleMovement()- Говно собачье
      {
          float speed = 50f;
          float moveX = 0f;
          float moveY = 0f;

          if (Input.GetKey(KeyCode.W))
          {
              moveY = +1f;
          }
          if (Input.GetKey(KeyCode.S))
          {
              moveY = -1f;
          }
          if (Input.GetKey(KeyCode.A))
          {
              moveY = -1f;
          }
          if (Input.GetKey(KeyCode.D))
          {
              moveY = +1f;
          }


          bool isIdle = moveX == 0 && moveY == 0;
          if (isIdle)
          {
              playerCharacterBase.PlayIdleAnimation(lastMoveDir);
          }
          else
          {
              Vector3 moveDir = new Vector3(moveX, moveY).normalized;

              Vector3 targetMovePosition = transform.position + moveDir * speed * Time.deltaTime;
              RaycastHit2D raycastHit = Physics2D.Raycast(transform.position < moveDir, speed * Time.deltaTime);
              if (raycastHit.collider == null)
              {
                  lastMoveDir = moveDir;
                  playerCharacterBase.PlayWalkingAnimation(moveDir);
                  transform.position = targetMovePosition;
              }else
              {
                  Vector3 testMoveDir = new Vector3(moveDir.x, 0f).normalized;
                  targetMovePosition = transform.position + testMoveDir * speed * Time.deltaTime;
                  raycastHit = Physics2D.Raycast(transform.position, testMoveDir, speed * Time.deltaTime);

                  if(testMoveDir.x != 0f && raycastHit.collider == null)
                  {
                      lastMoveDir = testMoveDir;
                      playerCharacterBase.PlayWalkingAnimation(testMoveDir);
                      transform.position = targetMovePosition;
                  }
                  else
                  {
                      testMoveDir = new Vector3(0f, moveDir.y).normalized;
                      targetMovePosition = transform.position + testMoveDir * speed * Time.deltaTime;
                      raycastHit = Physics2D.Raycast(transform.position, testMoveDir, speed * Time.deltaTime);
                      if (testMoveDir.y !=0f && raycastHit.collider == null)
                      {
                          lastMoveDir = testMoveDir;
                          playerCharacterBase.PlayWalkingAnimation(testMoveDir);
                          transform.position = targetMovePosition;
                      }
                      else
                      {
                          playerCharacterBase.PlayIdleAnimation(lastMoveDir);
                      }
                  }
              }
          }

      }
      */


