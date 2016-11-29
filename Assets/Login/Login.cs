using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;

public class Login : MonoBehaviour {
    //input fields
    public GameObject username, password;

    public Toggle rememberAccount;

    //private variables
    private string _username, _password;

    //Database handler
    private dbHandler db = new dbHandler();

    private bool keepOn;
    private string savedUsername, savedPassword;
    // Use this for initialization
    void Start () {
        password.GetComponent<InputField>().text = "";
        _username = username.GetComponent<InputField>().text;

        radioButtonCheck();

        if (keepOn)
        {
            _username = savedUsername;
            _password = savedPassword;
            signinButton();
            return;            
        }

        username.GetComponent<InputField>().text = savedUsername;  
	}

    void radioButtonCheck( )
    {
        string filename = "config.txt";
        StreamWriter inFile = new StreamWriter(filename, true);

        if (new FileInfo(filename).Length == 0)
        {
            writeConfigFile(inFile, false, "username", "-");
            inFile.Close();
            return;
        }

        inFile.Close();

        StreamReader outFile = new StreamReader(filename);
        string line = outFile.ReadLine();

        if (line.Equals("ON"))
            keepOn = true;
        else
            keepOn = false;

        line = outFile.ReadLine();
        savedUsername = line;

        line = outFile.ReadLine();
        if (keepOn)
            savedPassword = line;

        outFile.Close();
    }

    public static void writeConfigFile(StreamWriter inFile, bool status, string savedUser, string savedPass)
    {
        bool newFile = false;
        if (inFile == null)
        {
            newFile = true;
            inFile = new StreamWriter("config.txt");
        }

        string value = "OFF";
        if (status)
            value = "ON";
       
        inFile.WriteLine(value);
        inFile.WriteLine(savedUser);
        inFile.Write(savedPass);

        if (newFile)
            inFile.Close();
    }

	// Update is called once per frame
	void Update () {
        _username = username.GetComponent<InputField>().text;
        _password = password.GetComponent<InputField>().text;
	}

    //Switch to register scene when register button clicked
    public void signupTransfer( ) {
        SceneManager.LoadScene("Register");
    }

    //Checks if information written is right, if so start the game. Otherwise retry.
    //TO DO: The account still doesn't live through out the game, need to set it up soon
    public void signinButton() {
        int id;

        //check fields to be non empty
        if (_username == "" || _password == "")
            UnityEditor.EditorUtility.DisplayDialog("ERROR", "Please fill in all the fields!", "Retry");

        else if ( (id = db.exist(_username, _password) ) != -1) {
            if(rememberAccount.isOn)
                writeConfigFile(null, true, _username, _password);
            else
                writeConfigFile(null, false, _username, "-");

            User.Connect(id); //populate Global User before changing scenes.
            UnityEditor.EditorUtility.DisplayDialog("Welcome", "Welcome to Overworld!", "Enter");
            SceneManager.LoadScene("OverviewMap");
        } else {
            UnityEditor.EditorUtility.DisplayDialog("ERROR", "The information you entered is incorrect!", "Retry");
        }
    }
}
