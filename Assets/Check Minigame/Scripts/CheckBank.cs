using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Class that determines what fields the check should accept
/// </summary>
public class CheckBank : MonoBehaviour {

  //number of wrong words to add to the bank. Increase for difficulty.
  public int numOfWrongWords = 2;

  //how often the right words occur, by adding it more times to data structure
  public int rightWordOccurence = 2;

  //strings for the different check fields
  private string[] nameBank;
  private string[] dateBank;

  //Hash Map for amounts - maps word amounts to dollar amounts
  private Dictionary<string, string> amountBank;
  private string[] purposeBank;
  private string signature;

  //ArrayList to contain the selected words that will scroll
  private ArrayList selectedFloatWords;


	// Use this for initialization
	void Awake () {

    //Initializes all strings
    nameBank = new string[] {"Angela", "Lily", "Ricardo", "Sam", "Suzie", "Joe", "Becky"};
    dateBank = new string[] {"01/02", "02/15", "03/17", "04/01", "05/09", "06/12", "07/04", "08/20", "09/28", "10/30", "11/11", "12/19"};
    purposeBank = new string[] {"shoes", "candy", "dinner", "groceries", "glasses", "books", "toothpaste", "pencils"};
    signature = "Signature";

    //adds amounts to hash map
    amountBank = new Dictionary<string, string>();
    amountBank.Add("$500.00", "Five Hundred and 0/100");
    amountBank.Add("$100.00", "One Hundred and 0/100");
    amountBank.Add("$50.50", "Fifty and 50/100");
    amountBank.Add("$90.01", "Ninety and 1/100");
    amountBank.Add("$1000.00", "One thousand and 0/100");

	}
	
	// Update is called once per frame
	void Update () {

	
	}

  /// <summary>
  /// Randomizes the possible check fields that will spawn, and returns an ArrayList with the selected Words.
  /// </summary>
  /// <returns> ArrayList with randomized words </returns>
  public string[] getCheckFields() {

    //selects how many values will be chosen
    string[] chosenValues = new string[6];

    //creates a list out of the earlier hash map, using only keys for amount
    List<string> amountNums = new List<string>(amountBank.Keys);

    //assigns random values to the chosen values array based on all strings in the bank
    chosenValues[0] = dateBank[Random.Range(0, dateBank.Length)];
    chosenValues[1] = nameBank[Random.Range(0, nameBank.Length)];
    chosenValues[2] = amountNums[Random.Range(0, amountNums.Count)];
    amountBank.TryGetValue(chosenValues[2], out chosenValues[3]); //gets value from dictionary
    chosenValues[4] = purposeBank[Random.Range(0, purposeBank.Length)];
    chosenValues[5] = signature;

    //creates ArrayList to store the chosen values

    selectedFloatWords = new ArrayList();

    //adds all the chosen values (correct fields) however many times we want the correct option to occur
    for (int i = 0; i < rightWordOccurence; i++) {
      selectedFloatWords.Add(chosenValues[0]);
      selectedFloatWords.Add(chosenValues[1]);
      selectedFloatWords.Add(chosenValues[2]);
      selectedFloatWords.Add(chosenValues[3]);
      selectedFloatWords.Add(chosenValues[4]);
      selectedFloatWords.Add(chosenValues[5]);
    }

    //adds wrong options to the arraylist as well, for difficulty. Randomizes values that are added
    for (int i = 0; i < numOfWrongWords; i++) {

      selectedFloatWords.Add(dateBank[Random.Range(0, dateBank.Length)]);
      selectedFloatWords.Add(nameBank[Random.Range(0, nameBank.Length)]);
      selectedFloatWords.Add(amountNums[Random.Range(0, amountNums.Count)]);
      selectedFloatWords.Add(purposeBank[Random.Range(0, purposeBank.Length)]);

      string tempString;
      amountBank.TryGetValue(amountNums[Random.Range(0, amountNums.Count)], out tempString);
      selectedFloatWords.Add(tempString);

    }

    //returns the correct values
    return chosenValues;

  }

  /// <summary>
  /// Gets the incorrect values
  /// </summary>
  /// <returns>ArrayList of incorrect values</returns>
  public ArrayList getFloatWords() {

    return selectedFloatWords;

  }
}
