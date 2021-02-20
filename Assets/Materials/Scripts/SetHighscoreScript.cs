using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SetHighscoreScript : MonoBehaviour
{
    [SerializeField] Text highscoreText;
    void Start()
    {
        highscoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }
}
