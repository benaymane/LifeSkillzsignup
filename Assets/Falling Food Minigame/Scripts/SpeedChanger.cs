using UnityEngine;
using System.Collections;

/// <summary>
/// Speed changer interface that controls the scroll speed and updates listeners
/// </summary>
public interface SpeedChanger {

  //registers a new SpeedListener object to recieve speed updates
  void registerSpeedListener(SpeedListener scrollObject);

  //removes a SpeedListener object from the list of objects to update
  void removeSpeedListener(SpeedListener scrollObject);

  //updates all registered SpeedListener objects
  void updateSpeedListener();

}
