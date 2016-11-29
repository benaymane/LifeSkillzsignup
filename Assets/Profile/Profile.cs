using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEditor;

public class Profile : MonoBehaviour {
    public GameObject status,
        emailInput,
        zipInput,
        board,
        zipMSG,
        updateMSG,
        profilePanel,
        currPassword,
        newPassword,
        newPasswordConf;

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
            SceneManager.LoadScene("Login");
        }
    }
	
    public void updateInfo( )
    {
        string _email = emailInput.GetComponent<InputField>().text;
        string _zip = zipInput.GetComponent<InputField>().text;

        if (!Register.emailFormat(_email))
        {
            EditorUtility.DisplayDialog("ERROR!", "Your email is not in the right format!\n Correct format: xxxx@xxx.xxx", "Retry");
            return;
        }
        else if (_zip.Length != 5)
        {
            EditorUtility.DisplayDialog("ERROR!", "Your Zip-Code should be 5 characters!", "Retry");
            return;
        }
        else if (month.value == 0 || day.value == 0 || year.value == 0)
        {
            EditorUtility.DisplayDialog("ERROR!", "Please select a date of birth", "Retry");
            return;
        }

        string dob;
        int _months = month.value,
        _day = day.value,
        _year = year.value;
        dob = _months + "/" + _day + "/" + (DateTime.Now.Year - _year + 1).ToString();

        User.updateInfo(_email, _zip, dob);

        showBoard(updateMSG);
    }

    public void changePassword( )
    {
        string currPass = currPassword.GetComponent<InputField>().text,
            newPass = newPassword.GetComponent<InputField>().text,
            newPassConf = newPasswordConf.GetComponent<InputField>().text;

        if (currPass == "" || newPass == "" || newPassConf == "" )
        {
            EditorUtility.DisplayDialog("ERROR!", "Please fill in all the fields!", "Retry");
            return;
        }

        if( currPass.Equals(User.userInfo[dbHandler.PASSWORD_INDEX]) )
        {
            if( newPass.Length < 6 || newPassConf.Length < 6)
            {
                EditorUtility.DisplayDialog("ERROR!", "Your password is less than 6 characters!", "Retry");
                return;
            }
            if( newPass.Equals(newPassConf))
            {
                User.updatePassword(newPass);

                if(Login.isTrackingLogin())
                {
                    Login.writeConfigFile(null, true, User.userInfo[dbHandler.USERNAME_INDEX], newPass);
                }

                showBoard(updateMSG);
            } else
            {
                EditorUtility.DisplayDialog("ERROR!", "The new passwords don't match!", "Retry");

            }
        }
        else
        {

            EditorUtility.DisplayDialog("ERROR!", "The Password is incorrect!", "Retry");

        }
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
        if( !profilePanel.activeSelf && User.connected && User.userInfo != null)
        {
            populateInputs();
        }
	}

    public void overworldTransfer()
    {
        SceneManager.LoadScene("OverviewMap");
    }
}
