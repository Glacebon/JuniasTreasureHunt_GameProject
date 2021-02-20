using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro; // TextMesh Pro Namespace


public class CountdownTextTMP : MonoBehaviour
{
    public TMP_Text m_TextComponent;
    public PointCount bool_PointScript;

    public float currentTime = 0.0f;
    public float startingTime = 90.0f;
    public int min;
    public int sec;

    void Start()
    {
        currentTime = startingTime;
    }

    void Awake()
    {
        // Get a reference to the text component.
        m_TextComponent = GetComponent<TMP_Text>();
    }

    void Update()
    {

        currentTime -= 1 * Time.deltaTime;


        min = Mathf.FloorToInt(currentTime / 60);
        sec = Mathf.FloorToInt(currentTime % 60);
        m_TextComponent.text = min.ToString("00") + ":" + sec.ToString("00");




        if (currentTime < 10.0f)
        {
            m_TextComponent.color = Color.red;
        } else
        {
            m_TextComponent.color = Color.white;
        }
        if (currentTime < 0.1f)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}