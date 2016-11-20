using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void signupTransfer( ) {
        SceneManager.LoadScene("Register");
    }

    public void overworldTransfer() {
        SceneManager.LoadScene("OverviewMap");
    }
}
