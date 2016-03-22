using UnityEngine;
using System.Collections;

/// <summary>
/// Healthy food object
/// </summary>
public class HealthyFood : Food {

  /// <summary>
  /// Checks if this food is healthy
  /// </summary>
  /// <returns>true</returns>
  /// <c>false</c>
  public override bool isHealthy() {

    //food is healthy
    return true;

  }
}
