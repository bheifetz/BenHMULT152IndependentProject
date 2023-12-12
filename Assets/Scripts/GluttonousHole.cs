using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GluttonousHole : MonoBehaviour
{
    private PlayerController playerCtrl;

    public TextMeshProUGUI meat1Eaten;
    public TextMeshProUGUI meat2Eaten;
    public TextMeshProUGUI meat3Eaten;
    public TextMeshProUGUI bringMeat1;
    public TextMeshProUGUI doIt;

    public GameObject nearHole;
    
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
            //Debug.Log("This is the part where the hole tells you the meat is disgusting and sends you off to get the next meat");
            StartCoroutine(Meat1Eaten());
        }
        else if(other.CompareTag("Meat2RB"))
        {
            Destroy(other.gameObject);
            //Debug.Log("The hole tells you the meat is even worse than the last one, and sends you to go get the final meat");
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
        meat1Eaten.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);    //The 10 is only temporary.  Replace it with time in seconds for the 'eaten meat 1/2/3' dialogue to play, rounded up.
        meat1Eaten.gameObject.SetActive(false);
        playerCtrl.canMove = true;
        playerCtrl.currentMeat++;
    }
    IEnumerator Meat2Eaten()
    {
        meat2Eaten.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);    //10 is temporary, see above.
        meat2Eaten.gameObject.SetActive(false);
        playerCtrl.canMove = true;
        playerCtrl.currentMeat++;
    }
    IEnumerator Meat3Eaten()
    {
        meat3Eaten.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);    //10 is temporary, see above.
        meat3Eaten.gameObject.SetActive(false);
        doIt.gameObject.SetActive(true);
        nearHole.gameObject.SetActive(false);
        playerCtrl.canMove = true;
    }
}
