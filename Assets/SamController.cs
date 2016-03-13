using UnityEngine;
using System.Collections;

public class SamController : MonoBehaviour {

  int healthyFood = 0;
  int unhealthyFood = 0;

  public float speedChange = 0.1f;
  public float minDuration = 4;
  public float maxDuration = 20;

  private float speedPercentage;
  private float percentDifference;

  public GameObject controller;
  public static float tileMoveDuration = 10;

	// Use this for initialization
	void Start () {

	  calculateSpeedPercentage();
	}
	
	// Update is called once per frame
	void Update () {

    Debug.Log(speedPercentage + "%");

    if (Input.GetMouseButton(0)) {

      Vector3 newPosition = this.transform.position;
      newPosition.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
      this.transform.position = newPosition;


    }
   }

   void OnTriggerEnter2D(Collider2D other) {

     Food grabbedFood;
     Debug.Log("HERE");

     if (grabbedFood = other.GetComponent<Food>()) {
       if (grabbedFood.getType() == "Healthy") {

         if (SamController.tileMoveDuration > minDuration) {
         healthyFood++;
         SamController.tileMoveDuration-=speedChange;
         }

       }

       else {

         if (SamController.tileMoveDuration < maxDuration) {
         unhealthyFood++;
          SamController.tileMoveDuration+=speedChange;
         }

       }

       calculateSpeedPercentage();
       GameObject.Destroy(other.gameObject);
     }
   }

   void calculateSpeedPercentage() {

    speedPercentage = ((SamController.tileMoveDuration - minDuration) / (maxDuration - minDuration)) * 100;
    speedPercentage = 100 - speedPercentage;

   }


 }
