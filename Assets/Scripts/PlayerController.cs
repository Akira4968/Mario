using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [SerializeField] Collider2D coli;
    public Animator ani;
    public AudioSource audioSource;
    [SerializeField] AudioClip Deadclip;
    [SerializeField] AudioClip collectCoin;
    [SerializeField] GameObject bullet;
    Vector2 look = new Vector2(-1,0);
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        coli = GetComponent<Collider2D>();
        ani = GetComponent<Animator>();
        audioSource =GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        
        
        if(moveX<0)
        {
            look = new Vector2(-1,0);
        }else if(moveX >0)
        {
            look = new Vector2(1, 0);
        }
        Attack();
    }
    public void Dead()
    {
        
        coli.isTrigger = true;
        ani.SetBool("isDead", true);
        audioSource.clip = Deadclip;
        audioSource.Play();
        StartCoroutine(dead());
    }
    IEnumerator dead()
    {

        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
        GameManager.instance.Dead();
    }
    public void Attack()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            GameObject fire = Instantiate(bullet);
            fire.transform.position = transform.localPosition;
            BulletController.instance.fire(look);

            Destroy(fire, 2);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && ani.GetBool("jump") == true)
        {
            enemyController.instance.Dead();
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            dead();
        }
        else if(collision.gameObject.tag == "coin")
        {
            CollectCoin();
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Box"&& ani.GetBool("jump")==true)
        {
            
            Destroy(collision.gameObject);
        }
        
        
    }
    public void CollectCoin()
    {
        audioSource.clip = collectCoin;
        audioSource.Play();
        Score.AddScore(300);
        
    }
}
