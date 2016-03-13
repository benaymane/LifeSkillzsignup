using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadOnClicks: MonoBehaviour {

	//public GameObject panel;
	public float fadeDuration = 3;

	public void LoadScene(int level)
	{

		//StartCoroutine (FadeIn ());
		SceneManager.LoadScene (level);
		//Application.LoadLevel(level);
	}

	/*
	IEnumerator FadeIn() {
      
		Color startColor = copyColor(panel.GetComponent<Image> ().color);
		Color endColor = copyColor (startColor);
		endColor.a = 1;

		for (float i = 0; i < fadeDuration; i += Time.deltaTime) {

			Debug.Log ("TEST");
			panel.GetComponent<Image>().color = Color.Lerp (startColor, endColor, i / fadeDuration);

			yield return null;
		}
	}*/

	Color copyColor(Color colorToCopy) {

		Color newColor = new Color ();
		newColor.r = colorToCopy.r;
		newColor.g = colorToCopy.g;
		newColor.b = colorToCopy.b;

		return newColor;


	}
}
