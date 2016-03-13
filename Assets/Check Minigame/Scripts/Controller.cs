
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

  public TextMesh promptText;
  public CheckBank checkBank;
  public CheckSlots[] checkSlots;
  public GameObject scoreScreen;

  public static int blanksFilled = 0;
  public static int checksCompleted = 0;
  public static float elapsedTime = 0;

  public static AudioSource failClip;

  private float startTime;
  private float endTime;

  // Fields for the check
  // 0: Date
  // 1: Name
  // 2: Number Amount
  // 3: Word Amount
  // 4: Purpose
  // 5: Signature
  private const int DATE_INDEX = 0;
  private const int NAME_INDEX = 1;
  private const int NUM_AMT_INDEX = 2;
  private const int WORD_AMT_INDEX = 3;
  private const int PURP_INDEX = 4;
  private const int SIG_INDEX = 5;

  private ArrayList currentLevelBank;

  private string checkPrompt;

  [SerializeField]
  private float wordFloatDuration = 10;

  public GameObject floatingWordPrefab;
  public float wordSpawnDelay = 3;

  private Vector3 offScreenStart;
  private Vector3 offScreenEnd;
  private float lastRecordedTime;

	// Use this for initializatioin
	void Start () {

    Controller.failClip = GetComponent<AudioSource>();
    scoreScreen.SetActive(false);
    startTime = Time.time;
    Controller.blanksFilled = 0;
    Controller.checksCompleted = 0;
    Controller.elapsedTime = 0;
    lastRecordedTime = Time.time;
    setCheckPrompt();
    FloatingWord.lockedWords = new ArrayList();
    FloatingWord.lockedWordObjects = new ArrayList();


	}

	// Update is called once per frame
	void Update () {

    if (Time.time - lastRecordedTime >= wordSpawnDelay) {
   
      SpawnWord();
      lastRecordedTime = Time.time;

    }

    Debug.Log(FloatingWord.fieldsFilled);


    if (FloatingWord.fieldsFilled == 6) {

      newCheck();

    }
	}

  void setCheckPrompt() {

    string[] checkFields = checkBank.getCheckFields();

    checkPrompt = "It's " + checkFields[DATE_INDEX] + " today. " + checkFields[NAME_INDEX] + " needs " + checkFields[NUM_AMT_INDEX] + " for " + checkFields[PURP_INDEX] + "!";
    promptText.text = checkPrompt;

    for(int i = 0; i < checkFields.Length; i++) {

      checkSlots[i].setSearchString(checkFields[i]);

    }
  }

  void SpawnWord() {
     
      float randomY = Random.Range(2.65f, 5.0f);
    
      offScreenStart = new Vector3(12, randomY, 10);
      offScreenEnd = new Vector3(-12, randomY, 10);

      FloatingWord newWord;

      newWord =   ((GameObject)GameObject.Instantiate(
                    floatingWordPrefab, offScreenStart, Quaternion.identity
                  )).GetComponent<FloatingWord>();

               

      ArrayList floatWords = checkBank.getFloatWords();
              
      newWord.GetComponent<TextMesh>().text = (string)floatWords[Random.Range(0, floatWords.Count-1)];
      newWord.transform.parent = Camera.main.transform;
      newWord.setFloatDuration(wordFloatDuration);
      newWord.setEndLocation(offScreenEnd);
      newWord.beginFloat();

  }

  void newCheck() {

    for (int i = 0; i < FloatingWord.lockedWordObjects.Count; i++) {

      GameObject.Destroy((Object)FloatingWord.lockedWordObjects[i]);

    }

      FloatingWord.lockedWordObjects.Clear();
      FloatingWord.lockedWords.Clear();
      FloatingWord.fieldsFilled = 0;

      Controller.checksCompleted++;

      setCheckPrompt();

  }

  public void displayScoreScreen() {

    endTime = Time.time;

    Controller.elapsedTime = endTime - startTime;

    scoreScreen.SetActive(true);

  }
}
