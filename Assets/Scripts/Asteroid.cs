using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroid : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject target;
    float moveSpeed;
    Vector3 directionToTarget;
    public GameObject explosion;
    public GameObject explosion2;

    public int lifeCount = 3;
  
    public int  score = 0;

   
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        target = GameObject.Find("Earth");
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(1f, 5f);  
    }

    // Update is called once per frame
    void Update()
    {
        MoveAsteroid();
      
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Earth"))
        {
            Instantiate(explosion2, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            AsteroidControl.life -= 1;
            CameraShake.shakeDuration = 0.5f;
            
        }

    }

    private void OnMouseDown()
    {

        GenerateScore();
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
       
    }
    void MoveAsteroid()
    {
        if (target != null)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed,
                                        directionToTarget.y * moveSpeed);
        }
        else
            rb.velocity = Vector3.zero;
    }

    public void GenerateScore()
    {
        AsteroidControl.score += 1;
    }
   
}
