using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    public enum enemies { Knight };
    public enemies type;

    Rigidbody2D rigidbody;
    public GameObject player;

    public bool drag;

    int t;
    public float speed;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        drag = true;
    }

    // Update is called once per frame
    void Update()
    {
        t++;
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (drag) { transform.position = new Vector2(pos.x, pos.y); }
        else
        {
            if (type == enemies.Knight)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed);
            }
        }

        if (Input.GetMouseButtonDown(0) && drag && t>130)
        {
            rigidbody.simulated = true;
            drag = false;
        }
    }
}
