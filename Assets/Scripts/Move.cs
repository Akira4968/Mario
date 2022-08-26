using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jump;
    [SerializeField] Rigidbody2D rigi;
    bool isGround;
    Animator animator;
    public AudioSource audioSource;
    [SerializeField] AudioClip jumpclip;
    public static Move instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        isGround = true;
        animator = GetComponent<Animator>();
        speed = 5;
        jump = 350;
        rigi = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = jumpclip;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal")*speed*Time.deltaTime, 0, 0);
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if(Input.GetButtonDown("Jump"))
        {
            if (isGround == true)
            {
                audioSource.clip = jumpclip;
                isGround = false;
                rigi.AddForce(transform.up * Input.GetAxis("Jump") * jump );
                animator.SetBool("jump", true);
                audioSource.Play();
            }
        }
        
        animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
            animator.SetBool("jump", false);
        }
    }
}
