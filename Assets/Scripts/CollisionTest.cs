using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    private PlayerController playerCtrl;
    private Animator animPlayer;
    private AudioSource audioPlayer;
    public AudioClip damage;
    public ParticleSystem blood;

    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerController>();
        animPlayer = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Fog")
        {
            Debug.Log("I'm taking damage!");
        }
        else if (other.tag == "Smoke")
        {
            playerCtrl.isGameOver = true;
            animPlayer.SetBool("Death_b", true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Smoke")
        {
            audioPlayer.PlayOneShot(damage, 1.0f);
            blood.Play();
        }
    }
}
