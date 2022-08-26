using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    float speed;
    int scale;
    Animator ani;
    public static enemyController instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        speed = 5;
        scale = 1;
        ani = GetComponent<Animator>();
        ani.SetBool("isDead", false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed*Time.deltaTime,0,0);
        transform.localScale = new Vector3(scale,1,1);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "WayBack")
        {
            
            speed = -speed;
            scale = -scale;
        }
        if (collision.gameObject.tag == "FireBall")
        {

            Dead();
            BulletController.instance.hit();

        }

    }
    
    public void Dead()
    {
        
        ani.SetBool("isDead", true);
        speed = 0;
        Destroy(this.gameObject, 1);
        Score.AddScore(300);
        
    }
}
