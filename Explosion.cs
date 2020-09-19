using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    private void DestroyExplosion()
    {
        Destroy(this.gameObject.transform.parent.gameObject);
    }
}
