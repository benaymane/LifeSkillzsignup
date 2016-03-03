using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

  public string[] wordBank;

  [SerializeField]
  private float wordFloatDuration = 10;

  public GameObject floatingWordPrefab;
  public float wordSpawnDelay = 3;

  private Vector3 offScreenStart;
  private Vector3 offScreenEnd;
  private float lastRecordedTime;

	// Use this for initializatioin
	void Start () {

    lastRecordedTime = Time.time;
	
	}

	// Update is called once per frame
	void Update () {

    if (Time.time - lastRecordedTime >= wordSpawnDelay) {
   
      SpawnWord();
      lastRecordedTime = Time.time;

    }
	}


  void SpawnWord() {
     
      float randomY = Random.Range(3.3f, 5.5f);
    
      offScreenStart = new Vector3(12, randomY, 10);
      offScreenEnd = new Vector3(-12, randomY, 10);

      FloatingWord newWord;

      newWord =   ((GameObject)GameObject.Instantiate(
                    floatingWordPrefab, offScreenStart, Quaternion.identity
                  )).GetComponent<FloatingWord>();

      newWord.GetComponent<TextMesh>().text = wordBank[Random.Range(0, wordBank.Length)];
      newWord.transform.parent = Camera.main.transform;
      newWord.setFloatDuration(wordFloatDuration);
      newWord.setEndLocation(offScreenEnd);
      newWord.beginFloat();

  }
}
