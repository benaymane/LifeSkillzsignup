using UnityEngine;
using System.Collections;

public class CheckSlots : MonoBehaviour {

    public string searchString;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string getSearchString() {

    return searchString;

	}

  public void setSearchString(string searchString) {

    this.searchString = searchString;

  }
}
