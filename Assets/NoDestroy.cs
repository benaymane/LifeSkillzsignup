using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NoDestroy : MonoBehaviour {

  void Awake() {

    DontDestroyOnLoad(this);

  }

	// Use this for initialization
	void OnLevelWasLoaded () {

    if (SceneManager.GetActiveScene().buildIndex == 0 ||
        SceneManager.GetActiveScene().buildIndex == 1 ||
        SceneManager.GetActiveScene().buildIndex == 3 ||
        SceneManager.GetActiveScene().buildIndex == 5) {
       
        //do nothing

    }

    else {

      Destroy(this.gameObject);

    }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
  
}
