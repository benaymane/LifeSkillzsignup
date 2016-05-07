using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Sam (Player) controller
/// </summary>
public class SamController : MonoBehaviour {

  //the game controller
  public FallingFoodController controller;
 
  //counts of healthy and unhealthy food that Sam has collected
  private int healthyFood, unhealthyFood;
  
  // Update is called once per frame
  void Update() {

    //checks if mouse is being pressed
    if (Input.GetMouseButton(0)) {

      //sets an initial position to Sam's current location
      Vector3 newPosition = this.transform.position;

      //sets x position of new position to the mouse's x position in world
      newPosition.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;

      //sets Sam's x position to the mouse position
      this.transform.position = newPosition;

    }
  }

  /// <summary>
  /// Checks if Sam has entered a food trigger
  /// </summary>
  /// <param name="other">Food that Sam collided with.</param>
  void OnTriggerEnter2D(Collider2D other) {

    //if the collision was indeed with a piece of food
    if (other.GetComponent<Food>()) {

      //grab the food
      grabFood(other.GetComponent<Food>());

    }
  }

  /// <summary>
  /// Grabs the food.
  /// </summary>
  /// <param name="food">Food that Sam collided with.</param>
  private void grabFood(Food food) {

    //creates an Audio Source on Sam if there isn't one already
    if (!GetComponent<AudioSource>())
      gameObject.AddComponent<AudioSource>();

    //stores Sam's audio source
    AudioSource audioSource = GetComponent<AudioSource>();

    //plays the audio on the food
    audioSource.clip = food.getAudio();
    audioSource.Play();

    //checks if food is healthy, and if so, increments counter and increases speed
    if (food.isHealthy()) {

      healthyFood++;
      controller.updateScrollSpeed(1);

    }

    //checks if food is unhealthy, and if so increments counter and decreases speed
    else {

      unhealthyFood++;
      controller.updateScrollSpeed(-1);

    }

    //removes the food from existence
    food.remove();

  }

  /// <summary>
  /// Returns amount of healthy food Sam has grabbed
  /// </summary>
  /// <returns>The healthy food number.</returns>
  public int getHealthyFood() {

    return healthyFood;
  }

  /// <summary>
  /// Returns amount of unhealthy food Sam has grabbed
  /// </summary>
  /// <returns>The unhealthy food number.</returns>
  public int getUnhealthyFood() {

    return unhealthyFood;

  }
}
