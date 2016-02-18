using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOnClicks: MonoBehaviour {

	public void LoadScene(int level)
	{
		SceneManager.LoadScene (level);
		//Application.LoadLevel(level);
	}
		

}
