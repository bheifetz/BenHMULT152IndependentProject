using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    private PlayerController playerCtrl;

    void Start()
    {
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerCtrl.hasMeat = true;
            Destroy(this.gameObject);
        }
    }
}
