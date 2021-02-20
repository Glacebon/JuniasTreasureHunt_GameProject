using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCTreasureFinder : MonoBehaviour
{
    public AudioSource BarkSource;
    public GameObject treasure;
    public GameObject counter;
    public GameObject timebonus;
    private TreasureSpawnerS bool_TreasureSpawnScript;
    private PointCount bool_PointTextScript;
    private CountdownTextTMP bool_CountdownTextTMPScript;
    public bool treasureFound;
    public GameObject objectToActivate; // BonusTimeText activator

    /*Function: Start
     Gets the scripts of TreasureSpawner, PointText and CountDownText
     because they will be modified based on this script. 
     Sets found to false.*/

    private void Start()
    {
        bool_TreasureSpawnScript = treasure.GetComponent<TreasureSpawnerS>();
        bool_PointTextScript = counter.GetComponent<PointCount>();
        bool_CountdownTextTMPScript = timebonus.GetComponent<CountdownTextTMP>();
        treasureFound = false;

        if (objectToActivate.activeInHierarchy)
            objectToActivate.SetActive(false);

    }

    /*Function: OnTriggerStay
     During collission with the treasure object, checks if
     spacebar is pressed, if so, sets found to true,
     destroys the treasure object, sets the object
     count to 0, adds to points and if points
     are multiples of 5, adds extra seconds to timer.*/

    private void OnTriggerStay(Collider treasure)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            treasureFound = true;
            Destroy(treasure.gameObject);
            bool_TreasureSpawnScript.objectCount = 0;
            bool_PointTextScript.currentPoints += 1;
            if (bool_PointTextScript.currentPoints % 5 == 0) // Adds extra seconds based on points
            {
                bool_CountdownTextTMPScript.currentTime += 30.0f;
                StartCoroutine(ActivationRoutine());
            }
        }
    }

    /*Function: Update
     Checks per frame if you have found the treasure 
     if so, let's Junia bark happily and sets found to false!*/

    void Update()
    {
        if (treasureFound == true)
        {
            BarkSource.Play();
            treasureFound = false;
        }
    }

    private IEnumerator ActivationRoutine()
    {
        //Turn BonusTimeText that is set to false(off) to True(on).
        objectToActivate.SetActive(true);

        //Turn the BonusTimeText back off after 2 sec.
        yield return new WaitForSeconds(2);

        //BonusTimeText will turn off
        objectToActivate.SetActive(false);
    }
}
