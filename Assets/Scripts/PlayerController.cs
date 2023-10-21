using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 15.0f;
    private float turnSpeed = 60.0f;

    private float speedThresh;

    private float horizontalInput;
    private float verticalInput;

    private Animator animPlayer;
    private AudioSource audioPlayer;
    //public AudioClip movement;
    public AudioClip damage;

    //Health variable (int)
    public bool isGameOver = false;
    private bool canMove = true;

    //meat counter (should be an array with 3 slots)
    
    // Start is called before the first frame update
    void Start()
    {
        animPlayer = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bool wDown = Input.GetKeyDown(KeyCode.W);
        bool sDown = Input.GetKeyDown(KeyCode.S);
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");



        if (canMove && !isGameOver)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
            if (wDown || sDown)
            {
                speedThresh = Mathf.Abs(verticalInput * speed);
                animPlayer.SetBool("moving_b", true);
                animPlayer.SetFloat("Speed_f", speedThresh);
                //audioPlayer.Stop();
                //audioPlayer.loop = true;
                //audioPlayer.clip = movement;
                //audioPlayer.Play();
            }
            else if (!wDown && !sDown)
            {
                speedThresh = 0;
                animPlayer.SetBool("moving_b", false);
            }

            if(isGameOver)
            {
                animPlayer.SetBool("Death_b", true);

            }
        }

        //This code keeps the worm upright
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);

        //when meat is touched...
            //if tag is meat1, meat2, or meat3
                //hasMeat is true
        
        //if player hits collider around hole
            //disable player input until hole is done speaking (use delays)
            //if hasMeat is true
                //fire meat[meatCount] into the hole
                //set hasMeat to false
            //else if hasMeat is false
                //hole tells player "why are you still here? Bring me meat!"

        //when delivering meat to hole...
            //if tag is meat1
                //have the hole say "this meat sucks, get me the one over by the shit pipes"
                //add 1 to meatCount
                //instantiate meat2
            //else if tag is meat2
                //have hole say "this meat also sucks, there's one more by the ruins"
                //add 1 to meatCount
                //instantiate meat3
            //else if tag is meat3
                //disable player input (if !gameover && not touching hole collider, allow movement.  Else if touching hole collider, only allow player to move in reverse after hole is done speaking)
                //have hole say "there is no more meat...except you"
                //despawn collider around hole
                //spawn force volumes behind player and push player into hole
        
        //if player hits collider at the bottom of the hole
            //stop all audio
            //cut to title splash screen
        
        //if player collides with dirt
            //add 10 health
            //destroy dirt
        
        //if player is colliding with object of tag 'fog'
            //wait 3 sec
            //take 10 damage
            //if player health <= 0
                //kill player
        //else if player is colliding with object of tag 'smoke'
            //kill player
    }
}
