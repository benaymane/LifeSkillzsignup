using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour {
    //Input field vars
    public GameObject username,
        email,
        emailConf,
        password,
        passwordConf;

    //DoB dropdown
    public Dropdown month, day, year;

    private string _username,
        _email,
        _emailConf,
        _password,
        _passwordConf,
        dob;

    private int _months, _day, _year;

    //Database object
    private dbHandler db = new dbHandler();

    //Enum to declare different errors.
    private enum errorCode { UNCOMPLETE_FORM, INPUT_MISSMATCH,
        WRONG_FORMAT, WRONG_LENGTH, ACCOUNT_EXISTS};
    private bool errorOccur = false;

    // Use this for initialization
    void Start () {
        populate_Dropbox();
    }

    // Update is called once per frame
    void Update () {
        //Reading inputs and DoB and store in local vars.
        _username = username.GetComponent<InputField>().text;
        _email = email.GetComponent<InputField>().text.ToLower(); //Emails are not case sensative.
        _emailConf = emailConf.GetComponent<InputField>().text.ToLower();
        _password = password.GetComponent<InputField>().text;
        _passwordConf = passwordConf.GetComponent<InputField>().text;

        _months = month.value;
        _day = day.value;
        _year = year.value;

        dob = _months + "/" + _day + "/" + (DateTime.Now.Year - _year + 1).ToString();
    }

    /* Functionality of page */

    //Called when "Create" button is clicked to create a new profile
    public void registerButton()
    {
        errorOccur = false;
        //Check for possible errors
        if (!complete())
            sendError(errorCode.UNCOMPLETE_FORM);

        else if (!match(_email, _emailConf))
            sendError(errorCode.INPUT_MISSMATCH, "email");

        else if (!match(_password, _passwordConf))
            sendError(errorCode.INPUT_MISSMATCH, "password");

        else if (!emailFormat(_email))
            sendError(errorCode.WRONG_FORMAT);

        else if (!lengthChecker(_password))
            sendError(errorCode.WRONG_LENGTH);
        //If successful display a welcoming message
        //TO DO need code to go back to login page
        else if (db.exist(_email))
            sendError(errorCode.ACCOUNT_EXISTS, "email");
        else if (db.exist(_username))
            sendError(errorCode.ACCOUNT_EXISTS, "username");

        if (errorOccur)
            return;

        EditorUtility.DisplayDialog("Congratulations!", "Thank you for joining us " + _username + " !\nWe are simply delighted!!", "Proceed");
        db.addAccount(_username, _email, _password, dob);
        loginTransfer();
    }

    bool accountVerify( )
    {
        return (!db.exist(_username) && !db.exist(_email));
    }
    //Takes user back to login page. Also attached to "return" button
    public void loginTransfer()
    {
        SceneManager.LoadScene("Login");
    }

    /* Helper methods to check for errors
       There is no order */

    //Checks if there is no empty inputfields and DoB selected
    bool complete()
    {
        return (_username != "" && _email != "" && _emailConf != ""
            && _password != "" && _passwordConf != ""
            && _day != 0 && _months != 0 && _year != 0);
    }

    //Checks if the email format is of *@*.* format where * is any combination of alphabets
    bool emailFormat(string email)
    { 
        /* 
            This method is weak, needs better coding for better checking.

            First check if there is a @, if there is then make sure the index of it is smaller than .
            Keep in mind if . doesn't exist than the index of it is -1 and if @ exists then the second 
            check will be false */
        return email.IndexOf('@') != -1 ? (email.IndexOf('@') < email.LastIndexOf('.') ? true : false) : false;
    }

    //Checks if 2 strings are the same
    bool match(string arg1, string arg2)
    {
        return arg1.Equals(arg2);
    }

    //Checks if the length of a string is 6 or more
    bool lengthChecker(string arg)
    {
        return arg.Length >= 6;
    }
    
    //Handles different errors. Notice the second parameter is not always necessary and thus has a default
    void sendError(errorCode code, string field = "")
    {
        errorOccur = true;
        string error = "";

        switch (code)
        {
            case errorCode.UNCOMPLETE_FORM:
                error = "Please fill in all the fields!";
                break;

            case errorCode.INPUT_MISSMATCH:
                error = "Your " + field + " do not match!";
                break;

            case errorCode.WRONG_FORMAT:
                error = "Your email is not in the right format!\n Correct format: xxxx@xxx.xxx";
                break;

            case errorCode.WRONG_LENGTH:
                error = "Your password is less than 6 characters!";
                break;
            case errorCode.ACCOUNT_EXISTS:
                error = "The " + field + " you have entered is already in use. Please pick a different one!";
                break;
        };

        EditorUtility.DisplayDialog("ERROR!", error, "Retry");

    }

    //Automatically adds options to DoB dropbox
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

}
