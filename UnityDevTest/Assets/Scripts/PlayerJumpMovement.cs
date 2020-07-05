using System;
using UnityEngine;
using System.Collections;


public class PlayerJumpMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float upThrust = 300f;  // Variable that determines the up force
    private float fallMultipliar = 2.5f;
    private bool isGrounded;
    private bool doubleJumpPowerUpActive;
    private bool doubleJumpPowerUpAllowed;

    void Awake()
    {
        isGrounded = true;
        doubleJumpPowerUpActive = false;
        doubleJumpPowerUpAllowed = true;
    }
    void OnCollisionStay2D()
    {
        isGrounded = true;
        doubleJumpPowerUpAllowed = true;
    }

    void OnCollisionExit2D()
    {
        isGrounded = false;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "DoubleJumpPowerUp")
        {
            // Destroy(collider.gameObject);
            collider.gameObject.SetActive(false);
            GetComponent<SpriteRenderer>().color = Color.yellow;
            doubleJumpPowerUpActive = true;
            StartCoroutine(ResetPowerUpTimer(10, ResetDoubleJumpPowerUp));
        }
    }
    private IEnumerator ResetPowerUpTimer(int seconds, Action ResetPowerUp)
    {
        yield return new WaitForSeconds(seconds);
        ResetPowerUp();
    }
    public void ResetDoubleJumpPowerUp()
    {
        Debug.Log("ResetDoubleJumpPowerUp ");
        doubleJumpPowerUpActive = false;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    void FixedUpdate()
    {
        Vector2 m_upForce = new Vector2(0f, upThrust);

        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || doubleJumpPowerUpActive))
        {
            // Add a force up
            rb.AddForce(m_upForce * Time.deltaTime, ForceMode2D.Impulse);
            if (doubleJumpPowerUpAllowed)
            {
                isGrounded = false;
                doubleJumpPowerUpAllowed = false;
            }
        }

    }

    void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultipliar - 1f) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultipliar - 1f) * Time.deltaTime;
        }
    }
}
