using UnityEngine;
using System.Collections;

public class Finished : MonoBehaviour {
    public GameObject teethMom;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void finish(){
        bool clean = true;
        foreach(Transform tooth in teethMom.transform)
        {
            if (tooth.gameObject.GetComponent<Teeth>().isClean == false)
                clean = false;
        }

        if (clean)
            Debug.Log("CLEAN!");
        else
            Debug.Log("Dirty!! :C");

       
        
    }

}
