﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldCameraScript : MonoBehaviour
{

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");


        //LEFT AND RIGHT CAMERA ROTATION 
        //60f, 120f
        yaw = Mathf.Clamp(yaw, 60f, 120f);

        //UP AND DOWN CAMERA ROTATION 
        pitch = Mathf.Clamp(pitch, -60f, 90f);
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
