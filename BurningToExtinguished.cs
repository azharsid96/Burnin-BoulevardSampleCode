using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningToExtinguished : MonoBehaviour
{
    public static int Score;

    bool isWater = false;
    public bool isExtinguished = false;
    public static float countSavedVehicles = 0;
    public static float maxSavesPerLevel = 2;
    private float maxThresholdSpeed = 10.0f;
    private float waveSpeedIncrement = 2.0f;
    private bool switchLevel = false;
    private AudioSource scoreAudio;
    Vehicle vehicleType;
    public GameObject feedback;
    private float startTime;
    private float feedbackMovingDist;
    private Vector3 feedbackInitialPos;
    private GameObject feedbackSpawner;
    public Vector3 feedbackSpawnPos;
    private AudioSource levelChangeAudio;
    //ObjectSpawner vehicleWave;
    //public GameObject feedbackDestination;

    private void Start()
    {
        scoreAudio = GameObject.Find("Audio/Score").GetComponent<AudioSource>();
        levelChangeAudio = GameObject.Find("Audio/LevelChange").GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Water")
        {
            isWater = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isWater)
        {
            if (!isExtinguished)
            {
                SpawnExtingusihedObject(gameObject);
            }
        }

    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Water")
        {
            isWater = false;
        }
    }


    private void SpawnExtingusihedObject(GameObject burningObj)
    {
        if (gameObject.GetComponent<Vehicle>().timeToExtinguish <= 0f)
        {
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<Vehicle>().extinguishedSprite;
            gameObject.tag = "Extinguished";
            gameObject.transform.parent.gameObject.tag = "Extinguished";
            countSavedVehicles++;
            if (countSavedVehicles % maxSavesPerLevel == 0 && countSavedVehicles!=0)
            {
                switchLevel = true;
                Debug.Log("Level change: " + switchLevel);

                //Increase speed of Cars per level if max threshold not reached
                if (Mathf.Abs(ObjectSpawner.initialSpeed.x) < maxThresholdSpeed)
                {
                    ObjectSpawner.startWave = false;
                    levelChangeAudio.Play();
                    if (gameObject.GetComponent<ObjectMovementLeft>())
                    {
                        ObjectSpawner.initialSpeed += new Vector2(waveSpeedIncrement, 0);
                        Debug.Log("Left speed: " + ObjectSpawner.initialSpeed);
                    }
                    else
                    {
                        ObjectSpawner.initialSpeed += new Vector2(waveSpeedIncrement, 0);
                        Debug.Log("Right speed: " + ObjectSpawner.initialSpeed);
                    }
                }
                //countSavedVehicles = 0;
             
            }

            // add score here for the corresponding vehicle
            Score = Score + gameObject.GetComponent<Vehicle>().vehicleScore;
            scoreAudio.Play();

            feedbackSpawner = Instantiate(feedback, gameObject.transform.position, Quaternion.identity) as GameObject;

            isExtinguished = true;

        }
        else {
            gameObject.GetComponent<Vehicle>().timeToExtinguish -= Time.deltaTime * 2.5f;
        }

    }
    //Getter for countSavedVehicles
    public float GetCountSavedVehicles() {
        return countSavedVehicles;
    }
}
