using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningObjectCounter : MonoBehaviour
{

    public static float objMissedCount = 0f;

    public GameObject[] burningObjs;
    //public GameObject[] extinguishedObjs;

    // Start is called before the first frame update
    void Start()
    {

        //Debug.Log("length: " + burningObjs.Length);

    }

    void OnTriggerEnter2D(Collider2D obj)
    {

        for (int i = 0; i < burningObjs.Length; i ++)
        {
            //Debug.Log((burningObjs[i].name));
            if (burningObjs[i].tag == obj.gameObject.tag)
            {
                objMissedCount++;
                //Debug.Log("obj missed: " + objMissedCount);
                break;
            }
        }
    }

}
