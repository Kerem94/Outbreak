using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hasan : MonoBehaviour
{
    private bool facingRight = true;
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseposition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        direction = new Vector2(mouseposition.x - gameObject.transform.position.x, mouseposition.y - gameObject.transform.position.y);
        gameObject.transform.up = direction;

        if(direction.y<0 &&facingRight||direction.x>0 && !facingRight)
        {
            facingRight = !facingRight;
            Vector3 thescale = transform.localScale;
            thescale.x *= -1;
            transform.localScale = thescale;
        }
    }
}
