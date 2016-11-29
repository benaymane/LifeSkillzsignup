using UnityEngine;
using System.Collections;
using System;

/*
    Static class so we can keep user alive throughout the game. No signout functionality yet.
*/
public static class User {
    //changes when you signin (no signout yet)
    public static bool connected = false;

    //Holds all information of a single user in the same order as database
    public static string[] userInfo;
    
    //Used to populate the static variables within the class with the right info.
    public static void Connect(int userID)
    {
        userInfo = dbHandler.getUser(userID); //Calls getUser static function to retrive all info but the password
        connected = true;
    }   

    public static void updateInfo(string email, string zip, string dob)
    {
        userInfo[dbHandler.EMAIL_INDEX] = email;
        userInfo[dbHandler.ZIP_INDEX] = zip;
        userInfo[dbHandler.DOB_INDEX] = dob;

        dbHandler.updateAccount(Int32.Parse(userInfo[dbHandler.ID_INDEX]), userInfo);
    }
    
    public static void updatePassword(string newPassword)
    {
        User.userInfo[dbHandler.PASSWORD_INDEX] = newPassword;
        dbHandler.updateAccount(Int32.Parse(userInfo[dbHandler.ID_INDEX]), userInfo);
    }
}
