using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed = 1.0f;
	public Text text;
	public GameObject winText;

	private Rigidbody _rigidbody;
	private int _targetsCount = 0;
	private Vector3 _movementVector;

	public void Start() {
		_rigidbody = GetComponent<Rigidbody>();
		_targetsCount = GetActiveTargetsCount();
	}

	public void FixedUpdate() {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		_movementVector.Set(horizontal, 0.0f, vertical);
		_movementVector = _movementVector * speed;
		if (_rigidbody != null) {
			_rigidbody.AddForce(_movementVector);
		}
	}

	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Pickup")) {
			other.gameObject.SetActive(false);
			int targetsLeft = GetActiveTargetsCount();
			UpdatePickupText(_targetsCount - targetsLeft);
			if (targetsLeft == 0) {
				ShowWinText();
			}
		}
	}

	private void UpdatePickupText(int count) {
		if (text != null) {
			text.text = "Count: " + count.ToString();	
		}
	}

	private int GetActiveTargetsCount() {
		int result = 0;
		GameObject[] targets = GameObject.FindGameObjectsWithTag ("Pickup");
		if (targets != null) {
			foreach (GameObject target in targets) {
				if (target != null && target.activeSelf) {
					result = result + 1;
				}
			}
		}
		return result;
	}

	private void ShowWinText() {
		if (winText != null) {
			winText.gameObject.SetActive(true);
		}
	}
}
