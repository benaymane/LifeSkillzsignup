using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckBank : MonoBehaviour {

  public int numOfWrongWords = 2;
  public int rightWordOccurence = 2;

  private string[] nameBank;
  private string[] dateBank;
  private Dictionary<string, string> amountBank;
  private string[] purposeBank;
  private string signature;

  private ArrayList selectedFloatWords;


	// Use this for initialization
	void Awake () {

    nameBank = new string[] {"Angela", "Lily", "Ricardo", "Sam", "Suzie", "Joe", "Becky"};
    dateBank = new string[] {"01/02", "02/15", "03/17", "04/01", "05/09", "06/12", "07/04", "08/20", "09/28", "10/30", "11/11", "12/19"};
    purposeBank = new string[] {"shoes", "candy", "dinner", "groceries", "glasses", "books", "toothpaste", "pencils"};
    signature = "Signature";

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

  public string[] getCheckFields() {

    string[] chosenValues = new string[6];
    List<string> amountNums = new List<string>(amountBank.Keys);

    chosenValues[0] = dateBank[Random.Range(0, dateBank.Length-1)];
    chosenValues[1] = nameBank[Random.Range(0, nameBank.Length-1)];
    chosenValues[2] = amountNums[Random.Range(0, amountNums.Count-1)];
    amountBank.TryGetValue(chosenValues[2], out chosenValues[3]);
    chosenValues[4] = purposeBank[Random.Range(0, purposeBank.Length-1)];
    chosenValues[5] = signature;

    selectedFloatWords = new ArrayList();

    for (int i = 0; i < rightWordOccurence; i++) {
      selectedFloatWords.Add(chosenValues[0]);
      selectedFloatWords.Add(chosenValues[1]);
      selectedFloatWords.Add(chosenValues[2]);
      selectedFloatWords.Add(chosenValues[3]);
      selectedFloatWords.Add(chosenValues[4]);
      selectedFloatWords.Add(chosenValues[5]);
    }

    for (int i = 0; i < numOfWrongWords; i++) {

      selectedFloatWords.Add(dateBank[Random.Range(0, dateBank.Length-1)]);
      selectedFloatWords.Add(nameBank[Random.Range(0, nameBank.Length-1)]);
      selectedFloatWords.Add(amountNums[Random.Range(0, amountNums.Count-1)]);
      selectedFloatWords.Add(purposeBank[Random.Range(0, purposeBank.Length-1)]);

      string tempString;
      amountBank.TryGetValue(amountNums[Random.Range(0, amountNums.Count-1)], out tempString);
      selectedFloatWords.Add(tempString);

    }


    return chosenValues;

  }

  public ArrayList getFloatWords() {

    return selectedFloatWords;

  }
}
