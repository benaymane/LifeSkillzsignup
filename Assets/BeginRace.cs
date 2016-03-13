using UnityEngine;
using System.Collections;

public class BeginRace : MonoBehaviour {


  public static bool started = false;

	// Use this for initialization
	void Start () {

    BeginRace.started = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  public void startRace() {
 
    BeginRace.started = true;

  }
}
