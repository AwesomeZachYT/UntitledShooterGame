using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehaviour : MonoBehaviour
{
    Vector2 pos;
    //Vector2 neoPos;

    public GameObject spell;
    public GameObject knightSpawn;

    public float cooldownAmount;
    public float speed;
    float xVel;
    float yVel;
    float div;
    float cooldown;

    void Start()
    {
        div = 1;
        cooldown = cooldownAmount;
    }

    void Update()
    {
        cooldown -= Time.deltaTime;

        if (Input.GetAxis("Horizontal") > 0) { xVel = 1; }
        else if (Input.GetAxis("Horizontal" ) < 0) { xVel = -1; }
        else { xVel = 0; }

        if (Input.GetAxis("Vertical") > 0) { yVel = 1; }
        else if (Input.GetAxis("Vertical") < 0) { yVel = -1; }
        else { yVel = 0; }

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
        { div = 1.3f; }
        else { div = 1; }

        if (Input.GetMouseButtonDown(0) && knightSpawn.GetComponent<enemyCreation>().hover <= 0 && Mathf.Ceil(cooldown) <= 0)
        {
            Instantiate(spell);
            cooldown = cooldownAmount;
        }

        //Debug.Log("X: " + xVel + " Y: " + yVel);
        //Debug.Log(keyCount);
    }

    void FixedUpdate()
    {
        pos = transform.position;
        transform.position = new Vector2(Mathf.Clamp(pos.x + speed / 100 * xVel / div, -11.72441f, 11.72441f), Mathf.Clamp(pos.y + speed / 100 * yVel / div, -4.509478f, 4.509478f));
    }
}
