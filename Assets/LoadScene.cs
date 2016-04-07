using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

  /// <summary>
  /// Loads the scene at the specified index
  /// </summary>
  /// <param name="sceneIndex"> Index of the scene to load </param>
  public void loadScene(int sceneIndex) {

    SceneManager.LoadScene(sceneIndex);

  }
}
