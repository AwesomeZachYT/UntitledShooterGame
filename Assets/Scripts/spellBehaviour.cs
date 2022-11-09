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
        current = transform.position;

        if (check) { transform.position = Vector2.MoveTowards(transform.position, mPos, speed); }
        
        past = transform.position;

        if (current != past) { increment = past - current; }
        else
        {
            check = false;
            transform.position += increment;
        }

        print(past - current);
        print(increment);
    }
}
