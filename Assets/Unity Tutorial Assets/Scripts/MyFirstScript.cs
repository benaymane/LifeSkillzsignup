using UnityEngine;
using System.Collections;

public class MyFirstScript : MonoBehaviour {

  public float spawnHeight;

  public Vector2 xRange;

  public Object spawnObject;

  public float spawnDelay;

  private float savedTime;
  
	// Use this for initialization
	void Start () {

	  savedTime = Time.time;
	
	}
	
	// Update is called once per frame
	void Update () {

	//1006
	//1009

	  if (Time.time - savedTime > spawnDelay) {
	    
	    savedTime = Time.time;

			GameObject newSphere = (GameObject)GameObject.Instantiate(
			  spawnObject, new Vector2(Random.Range(xRange.x, xRange.y), spawnHeight), 
			  this.transform.rotation);

			Material randMat = new Material(newSphere.GetComponent<MeshRenderer>().material);
			Color newColor = new Color(Random.Range(0, 1f),
			                           Random.Range(0,1f),
			                           Random.Range(0,1f));
			randMat.SetColor("_Color", newColor);
			newSphere.GetComponent<MeshRenderer>().material = randMat;
			
        

	  }
	
	}


	public void spawnSphere() {


	}
}
