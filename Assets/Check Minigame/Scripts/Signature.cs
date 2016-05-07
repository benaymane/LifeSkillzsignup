using UnityEngine;
using System.Collections;


/// <summary>
/// NOT FINISHED
/// </summary>
public class Signature : MonoBehaviour {

  private bool done = true;
  public Object signatureObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    if (Input.GetMouseButton(0) && done) {

       //checks if the user is pressing on the draggable object
       RaycastHit2D hit = Physics2D.Raycast(
         Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector3.forward);

       Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector3.forward * 1000);

       if (hit && hit.collider.gameObject == this.gameObject) {

         Debug.Log(hit.collider.gameObject.name);

         GameObject sig = (GameObject)GameObject.Instantiate(signatureObject,
                           Camera.main.ScreenToWorldPoint(Input.mousePosition),
                                this.transform.rotation);

         sig.transform.position = new Vector3(sig.transform.position.x,
                                              sig.transform.position.y,
                                              0);
       }
     }
	}

  void SetDone() {

    done = true;

  }
}
