using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Text.RegularExpressions;

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
        _passwordConf;

    private int _months, _day, _year;

    //Enum to declare different errors.
    private enum errorCode { UNCOMPLETE_FORM, INPUT_MISSMATCH,
        WRONG_FORMAT, WRONG_LENGTH};

    //Function to be called when "Create" button is clicked
    public void registerButton()
    {
        //Check for possible errors
        if (!complete())
            sendError(errorCode.UNCOMPLETE_FORM);

        if (!match(_email, _emailConf))
            sendError(errorCode.INPUT_MISSMATCH, "email");

        if (!match(_password, _passwordConf))
            sendError(errorCode.INPUT_MISSMATCH, "password");

        if (!emailFormat(_email))
            sendError(errorCode.WRONG_FORMAT);

        if (!lengthChecker(_password))
            sendError(errorCode.WRONG_LENGTH);

        //If successful display a welcoming message
        //TO DO need code to go back to login page
        EditorUtility.DisplayDialog("Congratulations!", "Thank you for joining us " + username, "Proceed");
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Reading inputs and DoB and store in local vars.
        _username = username.GetComponent<InputField>().text;
        _email = email.GetComponent<InputField>().text;
        _emailConf = emailConf.GetComponent<InputField>().text;
        _password = password.GetComponent<InputField>().text;
        _passwordConf = passwordConf.GetComponent<InputField>().text;

        _months = month.value++;
        _day = day.value++;
        _year = year.value++;
    }

    /* Helper methods to check for errors
       Not necessarly ordered same as in Register function */

    //Checks if there is no empty inputfields
    bool complete()
    {
        //TO DO need to check for MM/DD/YYYY
        return (_username != "" && _email != "" && _emailConf != ""
            && _password != "" && _passwordConf != "");
    }

    //Checks if the email format is of xxxxx@xxx.xxx format 
    bool emailFormat(string email)
    { 
        /* First check if there is a @, if there is then make sure the index of it is smaller than .
           Keep in mind if . doesn't exist than the index of it is -1 and if @ exists then the second 
           check will be false */
        return email.IndexOf('@') != -1 ? (email.IndexOf('@') < email.IndexOf('.') ? true : false) : false;
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
                error = "Your email is not in the right format.\n Correct format: xxxx@xxx.xxx";
                break;

            case errorCode.WRONG_LENGTH:
                error = "Your password is less than 6 characters";
                break;
        };

        EditorUtility.DisplayDialog("ERROR!", error, "Retry");

    }
}
