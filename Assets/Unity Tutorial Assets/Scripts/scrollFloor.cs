using UnityEngine;
using System.Collections;

public class scrollFloor : MonoBehaviour {

    public float scrollSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

      Vector2 newLocation = new Vector2(transform.position.x, transform.position.y);
      newLocation.x-=scrollSpeed;
      transform.position = newLocation;
     


	}
}
