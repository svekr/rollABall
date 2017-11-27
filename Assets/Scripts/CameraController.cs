using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class CameraController : MonoBehaviour {
	public GameObject player;

	private Boolean _isInitialized = false;
	private Vector3 _cameraOffset;

	void Start () {
		_isInitialized = false;
		InitializeCameraOffset();
	}

	void LateUpdate() {
		if (player != null) {
			if (_isInitialized == false) {
				InitializeCameraOffset();
			}
			transform.position = player.transform.position + _cameraOffset;	
		}
	}

	private void InitializeCameraOffset() {
		if (player != null) {
			_cameraOffset = transform.position - player.transform.position;
			_isInitialized = true;
		}
	}
}
