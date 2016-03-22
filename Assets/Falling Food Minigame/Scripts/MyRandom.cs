using UnityEngine;
using System.Collections;

/// <summary>
/// Random class that gets useful random values
/// </summary>
public class MyRandom {
 
  /// <summary>
  /// Gets the random index.
  /// </summary>
  /// <returns>The random index.</returns>
  /// <param name="listSize">List size.</param>
  public static int Index(int listSize) {

    //returns a random index between 0 and the size of the listen (exclusive)
    return (Random.Range(0, listSize));

  }

  /// <summary>
  /// Gets a random 2D location based on 2D bounds
  /// </summary>
  /// <param name="locationBounds">Location bounds.</param>
  public static Vector2 Location2D(Bounds locationBounds) {

    //initializes a new random vector2
    Vector2 randomLoc = new Vector2();

    //sets x value of random location to random x within bounds
    randomLoc.x = Random.Range(locationBounds.min.x, locationBounds.max.x);

    //sets y value of random location to random y within bounds
    randomLoc.y = Random.Range(locationBounds.min.y, locationBounds.max.y);

    //returns the random location
    return randomLoc;

  }

  /// <summary>
  /// Gets a random 2D location based on a center, width, and height of a space
  /// </summary>
  /// <returns>The random are.</returns>
  /// <param name="center">Center of area.</param>
  /// <param name="width">Width of the area</param>
  /// <param name="height">Height of the area</param>
  public static Vector3 Location2D(Vector2 center, float width, float height) {

    //initializes a random vector2 for random value
    Vector2 randomLoc = new Vector2();

    //sets the x value of random location to random x in area
    randomLoc.x = Random.Range(center.x - width, center.x + width);

    //sets the y value of random location to random y in area
    randomLoc.y = Random.Range(center.y - height, center.y + height);

    return randomLoc;

  }
}
