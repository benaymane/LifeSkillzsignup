using UnityEngine;
using System.Collections;

/// <summary>
/// Timer.
/// </summary>
public class Timer {

  private float lastRecordedTime;

  /// <summary>
  /// Initializes a new Timer
  /// </summary>
  public Timer() {

    //starts the timer immediatly on creation
    lastRecordedTime = Time.time;

  }

  /// <summary>
  /// Gets the elapsed time.
  /// </summary>
  /// <returns>The elapsed time.</returns>
  public float getElapsedTime() {

    return (Time.time - lastRecordedTime);

  }

  /// <summary>
  /// Reset the timer
  /// </summary>
  public void reset() {

    lastRecordedTime = Time.time;

  }

  /// <summary>
  /// Set the timer to the specified time
  /// </summary>
  /// <param name="time">Time.</param>
  public void set(float time) {

    //sets the elapsed time value
    //time = desired elapsed time
    lastRecordedTime = Time.time - time;

  }

  /// <summary>
  /// Converts the elapsed time into a string
  /// </summary>
  /// <returns>Elapsed time in the form of "m minutes and s seconds"</returns>
  public string toString() {

    //calculates minute and second values
    int minutes = (int)(Time.time - lastRecordedTime) / 60;
    int seconds = (int)(Time.time - lastRecordedTime) % 60;

    //strings to build return string with
    string minuteString;
    string secondString;
    string andString = " and ";

    //if there are no minutes, should just return s seconds
    if (minutes == 0) {
      minuteString = "";
      andString = "";
    }

    //ensures singluar "minute" is correct for 1 minute
    else if (minutes == 1) {
      minuteString = minutes + " minute";
    }

    //sets to "minutes" string if multiple minutes
    else {
      minuteString = minutes + " minutes";
    }

    //if there are no seconds, should just return m minutes
    if (seconds == 0) {
      secondString = "";
      andString = "";
    }

    //ensures singular "second" is correct for 1 second
    else if (seconds == 1) {
      secondString = seconds + " second";
    }

    //sets to "seconds" string if multiple seconds
    else {
      secondString = seconds + " seconds";
    }

    //builds and returns string based on set values
    return minuteString + andString + secondString;

  }
}
