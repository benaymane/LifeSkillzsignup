using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ProfileDesign : MonoBehaviour {
    public GameObject profilePanel;
    public GameObject giftPanel;
    public GameObject signoutPanel;
    public GameObject passwordPanel;

    public GameObject profileTab, giftTab, signoutTab;
    int activeTab = 1;
	// Use this for initializationsl
	void Start () {
        showPanel(profilePanel);
    }
	
    public void profilePanelButton()
    {
        showPanel(profilePanel);
       // profilePanel.SetActive(false);
       // Vector2 pos = profileTab.transform.position;
       // pos.x = -323;
       // profileTab.transform.position = pos;
       // profileTab.GetComponent<RectTransform>().sizeDelta = new Vector2(164, 55);

        highlightTab(profileTab);
        activeTab = 1;
    }

    public void giftPanelButton()
    {
        showPanel(giftPanel);
        highlightTab(giftTab);
        activeTab = 2;
    }

    public void signoutPanelButton()
    {
        showPanel(signoutPanel);
        highlightTab(signoutTab);

        activeTab = 3;
    }

    public void passwordChangeButton()
    {
        showPanel(passwordPanel);
    }

    void highlightTab(GameObject tab)
    {
        if( activeTab == -1 )
        {
            activeTab = 1;
            return;
        }
        //-323 to -337
        //76 to 131
        //164 to 191
        GameObject active;

        switch(activeTab)
        {
            case 2:
                active = giftTab;
                break;
            case 3:
                active = signoutTab;
                break;
            default:
                active = profileTab;
                break;
        }

        reshapeTab(active, 14, 164);

        reshapeTab(tab, -14, 191);
    }

    void reshapeTab(GameObject tab, int posX, int width)
    {
        Vector3 pos = tab.transform.position;
        pos.x += posX;
        tab.transform.position = pos;
        tab.GetComponent<RectTransform>().sizeDelta = new Vector2(width, 55);
    }

    void showPanel(GameObject panel)
    {
        profilePanel.SetActive(false);
        giftPanel.SetActive(false);
        signoutPanel.SetActive(false);
        passwordPanel.SetActive(false);

        panel.SetActive(true);
    }

    public void signout()
    {
        User.connected = false;
        SceneManager.LoadScene("Login");
    }
    // Update is called once per frame
    void Update () {
	
	}
}
