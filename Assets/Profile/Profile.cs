using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Profile : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void overworldTransfer()
    {
        SceneManager.LoadScene("OverviewMap");
    }
}
