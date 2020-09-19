using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour

{

    public List<GameObject> objectsLeftToRight;
    public List<GameObject> objectsRightToLeft;
    public List<GameObject> spawnPos;
    public float respawnTime;
    public float delayBetweenLevels;
    public static bool startWave = true;
    private Vector2 screenBounds;
    public static float spawnCount = 0;
    public static Vector2 initialSpeed = new Vector2(4.0f, 0.0f);
    public Timer gameOver;

    void Start()
    {
        
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        StartCoroutine(objectsRToLWave());

        StartCoroutine(delayBetweenLAndRWaves());

        StartCoroutine(objectsLToRWave());
    }

    private void spawnObjectsRightToLeft()
    {
        //select a random gameobject to spawn
        GameObject objectToSpawn = objectsRightToLeft[Random.Range(0, objectsRightToLeft.Count)];
        objectToSpawn = Instantiate(objectToSpawn) as GameObject;
        spawnCount++;

        //spawn the object on the right side 
        //int chosenSpawnPoint = Random.Range(0, spawnPos.Count);
        objectToSpawn.transform.position = new Vector2(spawnPos[0].transform.position.x, spawnPos[0].transform.position.y);
    }

    private void spawnObjectsLeftToRight()
    {
        //select a random gameobject to spawn
        GameObject objectToSpawn = objectsLeftToRight[Random.Range(0, objectsLeftToRight.Count)];
        objectToSpawn = Instantiate(objectToSpawn) as GameObject;
        spawnCount++;
        //Debug.Log(objectToSpawn.transform.GetChild(0).GetComponent<Rigidbody2D>().velocity);
        //spawn the object on the left side 
        objectToSpawn.transform.position = new Vector2(spawnPos[1].transform.position.x, spawnPos[1].transform.position.y);
    }

    IEnumerator objectsRToLWave()
    {
        Debug.Log("getting here");
        while (true)
        {
            if(startWave && (gameOver.IsGameOver()  != true))
            {
                yield return new WaitForSeconds(respawnTime);
                spawnObjectsRightToLeft();
            }
            else if (!startWave && (gameOver.IsGameOver() != true))
            {
                yield return new WaitForSeconds(delayBetweenLevels);
                startWave = true;
            }
            else if (gameOver.IsGameOver() == true)
            {
                break;
            }
            
        }
        
    }

    IEnumerator delayBetweenLAndRWaves()
    {
        yield return new WaitForSeconds(2f);

    }



    IEnumerator objectsLToRWave()
    {
        while (true)
        {
            if (startWave && (gameOver.IsGameOver() != true))
            {
                yield return new WaitForSeconds(respawnTime);
                spawnObjectsLeftToRight();
            }
            else if (!startWave && (gameOver.IsGameOver() != true))
            {
                yield return new WaitForSeconds(delayBetweenLevels);
                startWave = true;
            }
            else if (gameOver.IsGameOver() == true)
            {
                break;
            }

        }

    }

}
