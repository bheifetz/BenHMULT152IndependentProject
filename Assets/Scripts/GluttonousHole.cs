using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GluttonousHole : MonoBehaviour
{
    private PlayerController playerCtrl;
    
    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Meat1RB"))
        {
            Destroy(other.gameObject);
            Debug.Log("This is the part where the hole tells you the meat is disgusting and sends you off to get the next meat");
            StartCoroutine(Meat1Eaten());
        }
        else if(other.CompareTag("Meat2RB"))
        {
            Destroy(other.gameObject);
            Debug.Log("The hole tells you the meat is even worse than the last one, and sends you to go get the final meat");
            StartCoroutine(Meat2Eaten());
        }
        else if(other.CompareTag("Meat3RB"))
        {
            Destroy(other.gameObject);
            StartCoroutine(Meat3Eaten());
        }
    }

    IEnumerator Meat1Eaten()
    {
        yield return new WaitForSeconds(10);    //The 10 is only temporary.  Replace it with time in seconds for the 'eaten meat 1/2/3' dialogue to play, rounded up.
        playerCtrl.canMove = true;
        playerCtrl.currentMeat++;
    }
    IEnumerator Meat2Eaten()
    {
        yield return new WaitForSeconds(10);    //10 is temporary, see above.
        playerCtrl.canMove = true;
        playerCtrl.currentMeat++;
    }
    IEnumerator Meat3Eaten()
    {
        yield return new WaitForSeconds(10);    //10 is temporary, see above.
        //add force volumes behind Player and directly above the hole facing straight down.
    }
}
