using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour
{
    private float endOfScene = 2050f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > endOfScene)
            Destroy(gameObject);
    }
}
