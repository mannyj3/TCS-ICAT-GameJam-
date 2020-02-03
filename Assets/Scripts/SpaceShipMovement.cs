using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShipMovement : MonoBehaviour
{
    GameManager GM;
    private Rigidbody2D rb2d;
    public float Speed;
    public float yaw;

    public float MinX;
    public float MaxX;
    public float MinY;
    public float MaxY;
    public Image finishImg;

    public Slider fuel;
    public GameObject MidPoint;

    public Image GameOverImg;
    public Text GameOverTxt;

    private Animation explosion;

    // Start is called before the first frame update
    void Start()
    {
        finishImg.enabled = false;
        rb2d = GetComponent<Rigidbody2D>();
        explosion = gameObject.GetComponent<Animation>();

    }

    void FixedUpdate()
    {
        float charX = Mathf.Clamp(transform.position.x, MidPoint.transform.position.x + MinX, MidPoint.transform.position.x + MaxX);
        float charY = Mathf.Clamp(transform.position.y, MidPoint.transform.position.y + MinY, MidPoint.transform.position.y + MaxY);


        if (rb2d.velocity.magnitude > Speed)
        {
            rb2d.velocity = rb2d.velocity.normalized * Speed;
        }

        transform.position = new Vector3(charX, charY, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * Speed);

        if (movement.x != 0 || movement.y != 0)
        {
            fuel.value -= 2;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            gameObject.transform.Rotate(0,0,yaw);
            fuel.value -= 2;
        }

        if (Input.GetKey(KeyCode.E))
        {
            gameObject.transform.Rotate(0, 0, -yaw);
            fuel.value -= 2;

        }
    }

   

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "ForceArea")
        {
           gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(3.9f,2.7f,0), 1.5f * Time.deltaTime);
        }

        rb2d.gravityScale = 0;
    }

    public void OnTriggerExit(Collider other)
    {
        rb2d.gravityScale = 0.2f;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Meteor")
        {
            //explosion.Play("Explod");
            //GM.GameOver();
            Time.timeScale = 0;
            GameOverImg.enabled = true;
            GameOverTxt.enabled = true;
        }

        if (col.gameObject.tag == "Finish")
        {
            Time.timeScale = 0;
            finishImg.enabled = true;
        }

        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Fuel")
        {
            fuel.value += 3000;
            Destroy(col.gameObject);
        }
    }
}
