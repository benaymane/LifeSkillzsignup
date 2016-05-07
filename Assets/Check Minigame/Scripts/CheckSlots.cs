using UnityEngine;
using System.Collections;

/// <summary>
/// Class to place on check fields, will determine what fields can be placed on check
/// </summary>
public class CheckSlots : MonoBehaviour {

  //the string this check field is looking for
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
