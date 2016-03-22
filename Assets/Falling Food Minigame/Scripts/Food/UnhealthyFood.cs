using UnityEngine;
using System.Collections;

/// <summary>
/// Unhealthy food object.
/// </summary>
public class UnhealthyFood : Food {

  /// <summary>
  /// Checks if this food is healthy
  /// </summary>
  /// <returns>false</returns>
  /// <c>false</c>
  public override bool isHealthy() {
    
    //food is not healthy
    return false;

  }
}
