using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PCItemTriggers : MonoBehaviour
{
    private string gobackref;

    /*
     * Loads different scenes based on what object
     * player objext is colliding with while pressing
     * space.
     */

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (other.tag == "Book")
            {
                gobackref = "Room";
                PlayerPrefs.SetString("CreditsGoBackTo", gobackref);
                SceneManager.LoadScene("Credits");
            }
            if (other.tag == "Door")
            {
                SceneManager.LoadScene("JuniasTreasureHunt_Forest_Scene");
            }
            if (other.tag == "BeachBall")
            {
                SceneManager.LoadScene("JuniasTreasureHunt_Beach_Scene");
            }
        }
    }
}