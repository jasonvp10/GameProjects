﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public bool lockCursor;
	public float mouseSensitivity = 10;
	public Transform target;
	public float distFromTarget = 2;
	public Vector2 pitchMinMax = new Vector2(-40,85);

	public float rotationSmoothTime = .12f;
	Vector3 rotationSmoothVelocity;
	Vector3 currentRotation;

 	public bool paused = false;

	float yaw;
	float pitch;

	private void Start() {
		if (lockCursor) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}

	private void LateUpdate() {
		if(paused)
           return;

		yaw += Input.GetAxis ("Mouse X") * mouseSensitivity;
		pitch -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		pitch = Mathf.Clamp (pitch, pitchMinMax.x, pitchMinMax.y);

		currentRotation = Vector3.SmoothDamp (currentRotation, new Vector3 (pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
		transform.eulerAngles = currentRotation;

		Vector3 e = transform.eulerAngles;
		e.x = 0;

		target.eulerAngles = e;
		transform.position = target.position - transform.forward * distFromTarget;



	}

}