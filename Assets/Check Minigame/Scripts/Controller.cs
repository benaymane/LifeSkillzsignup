
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
  
  //some gameobjects to be dragged in
  public TextMesh promptText;
  public CheckBank checkBank;
  public CheckSlots[] checkSlots;
  public GameObject scoreScreen;

  //counters
  public static int blanksFilled = 0;
  public static int checksCompleted = 0;
  public static float elapsedTime = 0;

  //sound effect for failed check
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

  //arraylist of floating words
  private ArrayList currentLevelBank;

  private string checkPrompt;

  //how long the words take to float from one side to the other
  [SerializeField]
  private float wordFloatDuration = 10;

  //prefab for floating words
  public GameObject floatingWordPrefab;
  
  //how frequently the words spawn
  public float wordSpawnDelay = 3;

  //locations where the words should spawn and despawn
  private Vector3 offScreenStart;
  private Vector3 offScreenEnd;

  //used as a timer
  private float lastRecordedTime;

	// Use this for initializatioin
	void Start () {

    //initializes values
    FloatingWord.fieldsFilled = 0;
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

    //Timer that spawns words based on delay
    if (Time.time - lastRecordedTime >= wordSpawnDelay) {
   
      SpawnWord();
      lastRecordedTime = Time.time;

    }

    //creates a new check if all fields filled
    if (FloatingWord.fieldsFilled == 6) {

      newCheck();

    }
	}

  //Determines what fields the check should accept, and what the prompt should display
  void setCheckPrompt() {

    //calls getCheckFields method of check bank to randomize some options
    string[] checkFields = checkBank.getCheckFields();

    //builds  a string for the prompt and displays it
    checkPrompt = "It's " + checkFields[DATE_INDEX] + " today. " + checkFields[NAME_INDEX] + " needs " + checkFields[NUM_AMT_INDEX] + " for " + checkFields[PURP_INDEX] + "!";
    promptText.text = checkPrompt;

    //sets the check slots search strings to the chosen words
    for(int i = 0; i < checkFields.Length; i++) {

      checkSlots[i].setSearchString(checkFields[i]);

    }
  }
  
  /// <summary>
  /// Spawns a floating word
  /// </summary>
  void SpawnWord() {
     
      //gets a random y value in range to spawn at
      float randomY = Random.Range(2.65f, 5.0f);
    
      //determines where words should spawn and destroy
      offScreenStart = new Vector3(12, randomY, 10);
      offScreenEnd = new Vector3(-12, randomY, 10);

      //word to be created
      FloatingWord newWord;

      //spawns the new word
      newWord =   ((GameObject)GameObject.Instantiate(
                    floatingWordPrefab, offScreenStart, Quaternion.identity
                  )).GetComponent<FloatingWord>();

               
      //gets a list of all possible words to display
      ArrayList floatWords = checkBank.getFloatWords();
              
      //sets this current float word to a random float word
      newWord.GetComponent<TextMesh>().text = (string)floatWords[Random.Range(0, floatWords.Count-1)];
      newWord.transform.parent = Camera.main.transform;
      newWord.setFloatDuration(wordFloatDuration);
      newWord.setEndLocation(offScreenEnd);
      newWord.beginFloat();

  }

  /// <summary>
  /// Creates a new check
  /// </summary>
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

  /// <summary>
  /// Displays the score screen
  /// </summary>
  public void displayScoreScreen() {

    endTime = Time.time;

    Controller.elapsedTime = endTime - startTime;

    scoreScreen.SetActive(true);

  }
}
