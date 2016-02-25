using UnityEngine;
using System.Collections;

public class GenerateFloatees : MonoBehaviour {
	private float savedTime;
	public float spawnDelay;
	public Vector2 xRange;

	//Floatees are the 
	string[] floatees = new string[]{"500", "02/12/16", "For Deposit Only", "Angela Brannon-Baptiste", "Five Hundred Only"};
	boolean[] usedFloatees = new boolean[] {false, false, false, false, false};

	void Start () {
		savedTime = Time.time;
	}

	void Update(){

		if (Time.time - savedTime > spawnDelay) {
			savedTime = Time.time;

			int floateeNumber = Random.Range (floatees.Length);
			//if floatee has not been created
			if (!usedFloatees [floateeNumber]) {
				GameObject newText = (GameObject)GameObject.Instantiate (
					             		spawnObject, new Vector2 (Random.Range (xRange.x, xRange.y), spawnHeight), 
					                    this.transform.rotation);
				
			}


		}

	}
		
}
