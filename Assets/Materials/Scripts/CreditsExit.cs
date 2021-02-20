// Exit from Credits scene using any button

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsExit : MonoBehaviour
{
    private string goesBackTo;
    // Start is called before the first frame update
    void Start()
    {
        goesBackTo = PlayerPrefs.GetString("CreditsGoBackTo", "Main");
        Debug.Log(goesBackTo);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (goesBackTo == "Room")
                SceneManager.LoadScene("JuniasTreasureHunt_RoomHub");
            else if (goesBackTo == "Main")
                SceneManager.LoadScene("MainMenu");
        }
    }
}
