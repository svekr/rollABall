using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Rotator : MonoBehaviour {

	public float delayY = 0.0f;
	public float movementY = 0.1f;
	public float speedY = 1.0f;

	private Vector3 _rotation;
	private float _counter;
	private int _index;

	static private int _rotatorsCount = 0;

	void Start() {
		_rotation.Set (60f * Random.value, 30f * Random.value, 45f * Random.value);
		_counter = 0.0f;
		_index = _rotatorsCount;
		_rotatorsCount = _rotatorsCount + 1;
	}

	void Update() {
		float deltaTime = Time.deltaTime;
		_counter = _counter + deltaTime;
		transform.Rotate(_rotation * deltaTime);
		float coefficient = Mathf.Sin((_counter * speedY) + (delayY * _index));
		transform.Translate(0, (coefficient * movementY), 0, Space.World);
	}
}
