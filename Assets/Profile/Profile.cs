using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Profile : MonoBehaviour {
    public GameObject status;

	// Use this for initialization
	void Start () {
        //just for testing
        if( User.connected )
        {
            if (User.userInfo != null)
                status.GetComponent<Text>().text = User.userInfo[1];
            else
                status.GetComponent<Text>().text = "You are connected BUT no userinfo";

        }
        else
        {
            status.GetComponent<Text>().text = "You are NOT connected";

        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void overworldTransfer()
    {
        SceneManager.LoadScene("OverviewMap");
    }
}
