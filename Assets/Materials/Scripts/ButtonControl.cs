using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("JuniasTreasureHunt_Forest_Scene");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

}