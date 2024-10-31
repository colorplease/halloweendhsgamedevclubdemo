using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("References")]
    [SerializeField]TextMeshProUGUI healthText;
    [Header("Stats")]
    public float speed;
    public float jumpHeight;
    public float health;
    Rigidbody2D rb;
    float horizontal;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
        }
    }

    public void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed,  rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "ground")
        {
            isGrounded = true;
        }
        if(other.transform.tag == "bat")
        {
            health -= 10;
            healthText.SetText(health.ToString() + " HP");
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.transform.tag == "ground")
        {
            isGrounded = false;
        }
    }
}
