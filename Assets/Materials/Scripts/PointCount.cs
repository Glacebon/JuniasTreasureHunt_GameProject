using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PointCount : MonoBehaviour
{
    public int currentPoints;

    [SerializeField] Text pointsText;

    void Start()
    {
        currentPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = currentPoints.ToString("0");
        if (currentPoints > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", currentPoints);
        }
    }
}