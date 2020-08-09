using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public GameObject player;
    public float speed;

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        gameObject.GetComponent<Animator>().SetBool("siguiendo", true);
        if (Vector2.Distance(transform.position, target.position) > 0.1f)
        {

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            
        }

       if (player.transform.position.x < transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
       
    }
}
