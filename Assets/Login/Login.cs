using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {
    //input fields
    public GameObject username, password;

    //private variables
    private string _username, _password;

    //Database handler
    private dbHandler db = new dbHandler();

    // Use this for initialization
    void Start () {
	
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
        if (db.exist(_username, _password)) {
            SceneManager.LoadScene("OverviewMap");
            UnityEditor.EditorUtility.DisplayDialog("Welcome", "Welcome to Overworld!", "Enter");
        } else {
            UnityEditor.EditorUtility.DisplayDialog("ERROR", "The information you entered is incorrect!", "Retry");
        }
    }
}
