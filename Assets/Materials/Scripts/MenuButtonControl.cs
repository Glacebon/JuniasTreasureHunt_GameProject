using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonControl : MonoBehaviour
{
    //Menu states
    public enum MenuStates { Main, Options };
    public MenuStates currentstate;

    //Menu Panel Objects
    public GameObject mainMenu;
    public GameObject optionsMenu;

    private string goBackRef;
    private int resetHS;
    //When script first starts
    void Awake()
    {
        //Always sets first menu to main menu
        currentstate = MenuStates.Main;
        goBackRef = "Main";
    }

    void Update()
    {
        //Checks current menu state
        switch (currentstate)
        {
            case MenuStates.Main:

                //Sets active gameobject for main menu
                mainMenu.SetActive(true);
                optionsMenu.SetActive(false);

                break;

            case MenuStates.Options:

                //Sets active gameobject for options menu
                mainMenu.SetActive(false);
                optionsMenu.SetActive(true);

                break;

        }
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("JuniasTreasureHunt_RoomHub");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        currentstate = MenuStates.Main;
    }

    public void OptionsButton()
    {
        PlayerPrefs.DeleteAll();
        currentstate = MenuStates.Options;
    }

    public void CreditsButton()
    {
        PlayerPrefs.SetString("CreditsGoBackTo", goBackRef);
        SceneManager.LoadScene("Credits");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

}