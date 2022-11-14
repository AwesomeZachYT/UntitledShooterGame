using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellBehaviour : MonoBehaviour
{
    Vector3 mPos;
    Vector3 current;
    Vector3 past;
    Vector3 increment;
    
    public float speed;

    bool check = true;

    void Start()
    {
        mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = GameObject.Find("Player").transform.position;
        print(mPos);
    }

    void FixedUpdate()
    {
        past = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, mPos, speed);
        current = transform.position;

        if (current != past) { increment = current - past; }
        else
        {
            //transform.position += increment;
            mPos += increment * 1000;

            if (check)
            {
                past = transform.position;
                transform.position = Vector2.MoveTowards(transform.position, mPos, speed);
                current = transform.position;
            }

            check = false;
        }

        print(new Vector2(current.x, current.y) - new Vector2(past.x, past.y));
        //print(increment);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
