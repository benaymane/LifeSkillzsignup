using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	  Vector3 myPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
	  //myPosition.x = player.transform.position.x;
	  //myPosition.y = player.transform.position.y;
	  this.transform.position = myPosition;
	
	}
}
