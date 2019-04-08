using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float movementSpeed = 2.5f;
	public bool hasKey = false;

	private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		targetPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;

		if (Physics.Raycast(transform.position, transform.forward, out hit)) {
			if (GvrViewer.Instance.Triggered || Input.GetKeyDown("space")) {

				if (hit.transform.tag == "Waypoint") {
					targetPosition = new Vector3 (
						hit.transform.position.x,
						transform.position.y,
						hit.transform.position.z
					);
				} else if (hit.transform.tag == "CorrectItem") {
					hasKey = true;

					Destroy (hit.transform.gameObject);
				}

			}
		}

		transform.position = Vector3.Lerp (transform.position, targetPosition, movementSpeed * Time.deltaTime);
	}
}
