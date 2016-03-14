using UnityEngine;
using System.Collections;

public class ScrollTrack : MonoBehaviour {

  public Vector3 tileSpawnLocation;
  public GameObject scoreScreen;
  public SamController sam;
  public float tileDuration = 10;

  public static float elapsedTime = 0;
  private float lastRecordedTime = 0;

  public static Object regularTrack; 
  public static Object finTrack;
  public Object regularTrackPrefab;
  public Object finTrackPrefab;

  public Object startTrack;
  public Object finishTrack;
 
	// Use this for initialization
	void Start () {

    lastRecordedTime = Time.time;
    Tile.tilesSpawned = 0;
    Tile.raceCompletedPercent = 0;
    ScrollTrack.elapsedTime = 0;
    ScrollTrack.regularTrack = regularTrackPrefab;
    ScrollTrack.finTrack = finTrackPrefab;
    Tile.tilesSpawned = 0;
    Vector3 destination = Camera.main.transform.position;
    destination.y+=Camera.main.orthographicSize*2;
    destination.z = 0;

    GameObject.Instantiate(ScrollTrack.regularTrack, destination, Quaternion.identity);


	}
	
	// Update is called once per frame
	void Update () {

    if (Time.time - lastRecordedTime >= 1) {

      ScrollTrack.elapsedTime++;
      lastRecordedTime = Time.time;

    }
	}


   public void loadScoreScreen() {

     scoreScreen.SetActive(true);
     scoreScreen.GetComponent<SetFoodFields>().setHealthyFoodValue(sam.getHealthyFood());
     scoreScreen.GetComponent<SetFoodFields>().setUnhealthyFoodValue(sam.getUnhealthyFood());
     scoreScreen.GetComponent<SetFoodFields>().updateScore();

   }
}
