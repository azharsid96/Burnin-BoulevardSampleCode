using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feedback : MonoBehaviour
{
    private Vector3 endPos;
    public float feedbackSpeed;
    public float destroyTime;
    
    
    // Start is called before the first frame update
    void Start()
    {
        endPos = new Vector3(-20, 13, 15);
    }

    // Update is called once per frame
    void Update()
    { 
        
        transform.position = Vector3.Lerp(transform.position, endPos, feedbackSpeed * Time.deltaTime);
        //destroyTime -= Time.deltaTime * 2.5f;

        //if (destroyTime <= 0)
        //{
        //    Destroy(this.gameObject);
        //    Debug.Log("destroyed!");
        //}

        StartCoroutine(destroyFeedback());
    }

    IEnumerator destroyFeedback()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
    }
}
