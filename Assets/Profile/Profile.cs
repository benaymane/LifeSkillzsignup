using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System;

public class Profile : MonoBehaviour {
    public GameObject status,
        emailInput,
        zipInput,
        board,
        zipMSG,
        updateMSG;

    public Dropdown
        month,
        day,
        year;

	// Use this for initialization
	void Start () {
        hideBoard();
        //Inserting information
        //just for testing
        if ( User.connected )
        {
            if (User.userInfo != null)
            {
                populateInputs();
                status.GetComponent<Text>().text = User.userInfo[dbHandler.USERNAME_INDEX];
            }
            else
                status.GetComponent<Text>().text = "You are connected BUT no userinfo";

        }
        else
        {
            status.GetComponent<Text>().text = "You are NOT connected";

        }
    }
	
    public void updateInfo( )
    {
        string _email = emailInput.GetComponent<InputField>().text;
        string _zip = zipInput.GetComponent<InputField>().text;

        string dob;
        int _months = month.value,
        _day = day.value,
        _year = year.value;
        dob = _months + "/" + _day + "/" + (DateTime.Now.Year - _year + 1).ToString();

        User.updateInfo(_email, _zip, dob);

        showBoard(updateMSG);
    }

    public void showBoard(GameObject msg)
    {
        board.SetActive(true);
        msg.SetActive(true);
    }

    public void hideBoard()
    {
        board.SetActive(false);
        zipMSG.SetActive(false);
        updateMSG.SetActive(false);
    }

    void populateInputs()
    {
        emailInput.GetComponent<InputField>().text = User.userInfo[dbHandler.EMAIL_INDEX];
        zipInput.GetComponent<InputField>().text = User.userInfo[dbHandler.ZIP_INDEX];

        populate_Dropbox();

        int m, d, y;
        string dob = User.userInfo[dbHandler.DOB_INDEX];

        //UnityEditor.EditorUtility.DisplayDialog("Welcome", dob.Substring(0, dob.IndexOf('/')), "Enter");
        //string dob = User.userInfo[dbHandler.DOB_INDEX];
        m = Int32.Parse(dob.Substring(0, dob.IndexOf('/')));
        dob = dob.Substring(dob.IndexOf('/')+1);
        d = Int32.Parse(dob.Substring(0, dob.IndexOf('/')));
        dob = dob.Substring(dob.IndexOf('/')+1);
        y = Int32.Parse(dob);
        
        month.value = m;
        day.value = d;
        year.value = DateTime.Now.Year - y + 1;
    }

    void populate_Dropbox()
    {
        //12 months
        for (int i = 1; i < 13; i++)
            month.options.Add(new Dropdown.OptionData(i.ToString()));

        //31 days
        for (int i = 1; i < 32; i++)
            day.options.Add(new Dropdown.OptionData(i.ToString()));

        //101 years starting from current year
        for (int i = 0; i < 102; i++)
            year.options.Add(new Dropdown.OptionData((DateTime.Now.Year - i).ToString()));
    }
    // Update is called once per frame
    void Update () {
	
	}

    public void overworldTransfer()
    {
        SceneManager.LoadScene("OverviewMap");
    }
}
