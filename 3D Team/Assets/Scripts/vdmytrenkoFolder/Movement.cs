﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidBody;
    public float speed;
    public float rotateSpeed;
    public bool firstPlayer;
    string horizontal, vertical, xbut, sbut, cbut, tbut;

    private bool isLocked;
    void Start()
    {
        if (firstPlayer)
        {
            horizontal = "JoystickHorizontal1";
            vertical = "JoystickVertical1";
            xbut = "Xbut1";
            sbut = "Sqbut1";
            cbut = "Cbut1";
            tbut = "Tbut1";
        }
        else
        {
            horizontal = "JoystickHorizontal2";
            vertical = "JoystickVertical2";
            xbut = "Xbut2";
            sbut = "Sqbut2";
            cbut = "Cbut2";
            tbut = "Tbut2";
        }
        rigidBody = this.GetComponent<Rigidbody>();
        isLocked = false;
    }
    
    void FixedUpdate()
    {
        if (!isLocked)
        {
            Vector3 movement = new Vector3(Input.GetAxis(horizontal), 0.0f, Input.GetAxis(vertical));
            Move(movement);
            Rotate(rotateSpeed, movement);
            if (Input.GetButtonDown(xbut))
            {
                
            }
            if (Input.GetButtonDown(sbut))
            {
                this.GetComponent<MeleeAttack>().DoMeeleAttack();
            }
            if (Input.GetButtonDown(cbut))
            {
                this.GetComponent<BearVerticalHit>().DoVerticalAttack();
            }
            if (Input.GetButtonDown(tbut))
            {

            }
        }
    }

    public void Unlock()
    {
        isLocked = false;
    }
    public void Lock()
    {
        isLocked = true;
    }
    public void Move(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    public void Rotate(float speed, Vector3 movement)
    {
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), speed * Time.deltaTime);
        }
    }

}
