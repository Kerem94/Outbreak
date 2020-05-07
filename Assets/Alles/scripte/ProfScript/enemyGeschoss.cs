using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGeschoss : MonoBehaviour
{
    public float speed;
    public float damage;

    private Transform player;
  
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        if (player == true)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            target = new Vector2(player.position.x, player.position.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyHealth ex = (enemyHealth)FindObjectOfType(typeof(enemyHealth));
            ex.addDamage(damage);
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
