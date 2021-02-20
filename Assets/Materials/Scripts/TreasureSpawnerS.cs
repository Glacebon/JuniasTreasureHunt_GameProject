using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSpawnerS : MonoBehaviour
{
    public static TreasureSpawnerS instance;
    public GameObject spot;
    public int objectCount = 0;
    public float _xAxis;
    public float _zAxis;
    public float _yAxis = 0;
    private Vector3 Min;
    private Vector3 Max;
    private Vector3 ranPosition;

    /*Function: Start
     Calls another function "setRanges".*/
    void Start()
    {
        setRanges();
    }

    /*Function: Update
     If the object count is not 1, adds a new
     object on the map.*/
    void Update()
    {
        while (objectCount != 1)
        {
            instantiateObject();
        }
    }

    /*Function: setRanges
     Sets the maximum and minimum values for the
     position randomizer.*/
    private void setRanges()
    {
        Min = new Vector3(-1000, -1000, -1000);
        Max = new Vector3(1000, 1000, 1000);
    }

    /*Function: instantiateObject
     Randomizes x and z axis spot where to put a
     "treasure" object. Sets object count to one so
     only 1 object will be created at once.*/
    private void instantiateObject()
    {
        _xAxis = UnityEngine.Random.Range(Min.x, Max.x);
        _zAxis = UnityEngine.Random.Range(Min.z, Max.z);

        ranPosition = new Vector3(_xAxis, _yAxis, _zAxis);

        Instantiate(spot, ranPosition, Quaternion.identity);
        objectCount = 1;
    }
}
