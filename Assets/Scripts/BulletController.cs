using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    float m_Speed;
    public Rigidbody2D rigi;
    public static BulletController instance;
    Animator animator;
    AudioSource audioSource;
    private void Awake()
    {
        instance = this;
        rigi = GetComponent<Rigidbody2D>();
        m_Speed = 400;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void fire(Vector2 move)
    {
        rigi.AddForce(move * m_Speed);
        
    }
    public void hit()
    {
        animator.SetBool("isHit", true);
        
        audioSource.Play();
        Destroy(this.gameObject, 1);
        
    }
}
