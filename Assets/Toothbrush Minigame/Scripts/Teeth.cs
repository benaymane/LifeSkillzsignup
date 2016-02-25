using UnityEngine;
using System.Collections;

public class Teeth : MonoBehaviour {

    public bool touched = false;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D (Collider2D other) {
        touched = true;

    }
}
