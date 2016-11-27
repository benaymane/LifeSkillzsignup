using UnityEngine;
using System;
using System.Collections;
using System.IO;

public class dbHandler : MonoBehaviour {
    //Database name
    const string FILE_NAME = "LifeSkillsDB.txt";

    //Current users + 1
    int id;

    //Handles writing or reading from DB
    StreamWriter inFile;
    StreamReader outFile;
    
    //Constructor to setup the DB header if it didn't exist before
    public dbHandler( )
    {
        openToWrite();
        if (new FileInfo(FILE_NAME).Length == 0)
            inFile.WriteLine("ID\tUsername\tEmail\tPassword\tDoB");
 
        close();

        //ID is not optimal. TO DO: store an ID number at the begining 
        //so we don't need to read everything each time.
        id = readLines();
    }

    // Use this for initialization
    void Start () {
       
    }

    //Adds a new line in DB with the account information
    public void addAccount( string username, string email, string password, string dob)
    {
        openToWrite();
        inFile.WriteLine(id+"\t"+username + "\t" + email + "\t" + password + "\t" + dob);
        id++;
        close();
    }

    //Checks if username or password exist in DB, if so then checks if password is correct. If everything ok return id
    public int exist( string login, string password )
    {
        //We get the line where the user lives
        string[] user = getUser(login);

        //Check if there is such user OR if the password is the same
        if (user == null || !user[3].Equals(password))
            return -1;

        return Int32.Parse(user[0]);
    }

    //Checks if an account exists by checking if username/email is there already
    public bool exist( string value )
    {
        return getUser(value) == null ? false : true;
    }

    //Helper private methods

    //Reads line by line and if username/email found returns the account info (line)
    //as a string array where each element is the information (id, username, email...) 
    //of the account searched for.
    string[] getUser( string value )
    {
        openToRead();
        string line = outFile.ReadLine(); //Skip header
        string[] choppedLine;

        while ((line = outFile.ReadLine()) != null)
        {
            choppedLine = line.Split('\t'); //split line by tabs
            if (choppedLine[1].Equals(value) || choppedLine[2].Equals(value))
            {
                close();
                return choppedLine;
            }
        }

        close();
        return null;
    }

    /*
        Function to retrieve an account information by id then we empty the password and give back all the information.
        Notice this is a static function!
    */
    static public string[] getUser( int id )
    {

        StreamReader outFile = new StreamReader(FILE_NAME);
        string line = outFile.ReadLine(); //Skip header
        string[] choppedLine;
        int i = 0;

        while ((line = outFile.ReadLine()) != null)
        {
            i++;
            if (i == id)
                break;
        }

        outFile.Close();
        choppedLine = line.Split('\t');
        choppedLine[2] = "";
        return choppedLine;
    }

    //Reads and keep track of how many lines there are in DB
    int readLines()
    {
        openToRead();

        int i = 0;
        while (outFile.ReadLine() != null)
            i++;

        close();
        return i;
    }

    //Opens the DB to be read from
    private void openToRead()
    {
        outFile = new StreamReader(FILE_NAME);
    }

    //Opens the DB to be writen into
    private void openToWrite()
    {
        inFile = new StreamWriter(FILE_NAME, true);
    }

    //Closes the DB
    private void close()
    {
        if (inFile != null)
            inFile.Close();

        if (outFile != null)
            outFile.Close();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
