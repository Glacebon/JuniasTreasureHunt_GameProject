using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomItemSpawner : MonoBehaviour
{
    public GameObject ball;

    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(-3.5f, 0.19f, 3.448f);
        if (PlayerPrefs.GetInt("Highscore", 0) >= 4)
        {
            setBeachBall();
        }
    }

    private void setBeachBall()
    {
        Instantiate(ball, position, Quaternion.identity);
    }
}
