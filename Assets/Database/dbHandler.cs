using UnityEngine;
using System.Collections;
using System.IO;

public class dbHandler : MonoBehaviour {
    const string FILE_NAME = "LifeSkillsDB.txt";

    int id;
    StreamWriter inFile;
    StreamReader outFile;
    
    public dbHandler( )
    {
        //UnityEditor.EditorUtility.DisplayDialog("errr", "eeeeee", "ok");
        openToWrite();
        if (new FileInfo(FILE_NAME).Length == 0)
            inFile.WriteLine("ID\tUsername\tEmail\tPassword\tDoB");
 
        close();
        id = readLines();
    }

    // Use this for initialization
    void Start () {
       
    }

    public void addAccount( string username, string email, string password, string dob)
    {
        openToWrite();
        inFile.WriteLine(id+"\t"+username + "\t" + email + "\t" + password + "\t" + dob);
        id++;
        close();
    }

    public bool exist( string login, string password )
    {
        string[] user = getUser(login);

        if (user[3].Equals(password))
            return true;

        return false;
    }

    public bool exist( string value )
    {
        return getUser(value) == null ? false : true;
    }

    string[] getUser( string value )
    {
        openToRead();
        string line = outFile.ReadLine(); //Read header
        string[] choppedLine;

        while ((line = outFile.ReadLine()) != null)
        {
            choppedLine = line.Split('\t');
            if (choppedLine[1].Equals(value) || choppedLine[2].Equals(value))
            {
                close();
                return choppedLine;
            }
        }

        close();
        return null;
    }

    int readLines()
    {
        openToRead();

        int i = 0;
        while (outFile.ReadLine() != null)
            i++;

        close();
        return i;
    }

    private void openToRead()
    {
        outFile = new StreamReader(FILE_NAME);
    }

    private void openToWrite()
    {
        inFile = new StreamWriter(FILE_NAME, true);
    }

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
