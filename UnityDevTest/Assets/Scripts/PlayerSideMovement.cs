
using UnityEngine;

public class PlayerSideMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float sidewaysThrust = 500f;  // Variable that determines the sideways force

    void FixedUpdate()
    {
        Vector2 m_sidewayForce = new Vector2(sidewaysThrust, 0f);

        if (Input.GetKey("d"))
        {  // If the player is pressing the "d" key
            // Add a force to the right
            rb.AddForce(m_sidewayForce * Time.deltaTime, ForceMode2D.Force);
        }

        if (Input.GetKey("a"))
        {  // If the player is pressing the "a" key
            // Add a force to the left
            rb.AddForce(-m_sidewayForce * Time.deltaTime, ForceMode2D.Force);
        }
    }
}
