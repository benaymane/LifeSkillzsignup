using UnityEngine;
using System.Collections;

public class Teeth : MonoBehaviour {

    public bool touched = false;
	public GameObject toothbrush;
	public float maxRange = 0f;
	public float minRange = -1f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vecCollide = toothbrush.GetComponent<CircleCollider2D> ().transform.position - GetComponent<BoxCollider2D> ().transform.position;
		if (vecCollide.y < maxRange && vecCollide.y > minRange) {
			Debug.Log ("clean clean clean");
		}
		//Debug.Log (vecCollide);
	}

    void OnTriggerEnter2D (Collider2D other) {
        touched = true;
		Debug.Log ("teeth");
    }
}
