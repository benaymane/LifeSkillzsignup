using UnityEngine;
using System.Collections;

public class GenerateFloatees : MonoBehaviour {
	private float savedTime;
	public float spawnDelay;
	public float x;
	public Vector2 yRange;
	public Object spawnObject;

	//Floatees are the text floating across the screen at the beginning of the mini-game
	string[] floatees = new string[]{"500", "02/12/16", "For Deposit Only", "Angela Brannon-Baptiste", "Five Hundred Only"};
	int[] floateesSize = new int[]{ 90, 100, 60, 90, 60 };
	bool[] usedFloatees = new bool[] {false, false, false, false, false};

	void Start () {
		savedTime = Time.time;
	}

	void Update(){

		if (Time.time - savedTime > spawnDelay) {
			savedTime = Time.time;

			int floateeNumber = Random.Range (0, floatees.Length);
			int speed = Random.Range (100, 200);

			//if floatee has not been created, create it
			if (!usedFloatees [floateeNumber]) {
				GameObject newText = (GameObject)GameObject.Instantiate (
					spawnObject, new Vector2 (x, Random.Range(yRange.x, yRange.y)), 
					this.transform.rotation);
				newText.AddComponent<TextMesh>();
				newText.GetComponent<TextMesh> ().text = floatees [floateeNumber];
				newText.GetComponent<TextMesh> ().fontSize = floateesSize [floateeNumber];
				usedFloatees [floateeNumber] = true;
			}


		}

	}

}