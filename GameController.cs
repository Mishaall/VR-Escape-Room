using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Player player;
	public GameObject door;
	public GameObject itemContainer;
	public TextMesh gameText;

	private Vector3 originalDoorPosition;
	private float gameTimer;
	private float gameOverTimer = 3f;

	// Use this for initialization
	void Start () {
		originalDoorPosition = door.transform.position;

		for (int i = 0; i < 50; i++) {
			GameObject item1 = itemContainer.transform.GetChild(Random.Range(0, itemContainer.transform.childCount)).gameObject;
			GameObject item2 = itemContainer.transform.GetChild(Random.Range(0, itemContainer.transform.childCount)).gameObject;

			Vector3 item1position = item1.transform.position;
			item1.transform.position = item2.transform.position;
			item2.transform.position = item1position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (player.hasKey) {
			door.transform.position = Vector3.Lerp (
				door.transform.position,
				originalDoorPosition + new Vector3 (0, 10, 0),
				Time.deltaTime
			);

			gameText.text = "You won :D\nYour time: " + Mathf.FloorToInt(gameTimer);

			gameOverTimer -= Time.deltaTime;
			if (gameOverTimer <= 0) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().name);
			}
		} else {
			gameTimer += Time.deltaTime;

			gameText.text = "Find the key!\nTime: " + Mathf.FloorToInt(gameTimer);
		}
	}
}
