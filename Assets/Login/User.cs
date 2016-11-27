using UnityEngine;
using System.Collections;
using System;

public static class User {
    static bool connected = false;
    public static string[] userInfo;
    
    public static void Connect(int userID)
    {
        userInfo = dbHandler.getUser(userID);
        connected = true;
    }   
    
}
