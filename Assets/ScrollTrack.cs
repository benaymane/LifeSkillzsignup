using UnityEngine;
using System.Collections;

public class ScrollTrack : MonoBehaviour {

  public Vector3 tileSpawnLocation;
  public float tileDuration = 10;

  public static Object regularTrack;
  public Object regularTrackPrefab;

  public Object startTrack;
  public Object finishTrack;

  private ArrayList trackTiles;

	// Use this for initialization
	void Start () {

    ScrollTrack.regularTrack = regularTrackPrefab;

    trackTiles = new ArrayList();
    Vector3 destination = Camera.main.transform.position;
    destination.y+=Camera.main.orthographicSize*2;
    destination.z = 0;

    GameObject newTrack = (GameObject)(GameObject.Instantiate
      (ScrollTrack.regularTrack, destination, Quaternion.identity));


	}
	
	// Update is called once per frame
	void Update () {
  

	}
}
