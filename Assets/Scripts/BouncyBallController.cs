using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBallController : MonoBehaviour
{
    public Rigidbody rb;
    public float bounceForce = 6.5f;

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = new Vector3(rb.velocity.x, bounceForce, rb.velocity.z);
        //Stores the item being collided with name
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if(materialName == "Safe (Instance)")
        {
            //The ball is safe to move-on
        }
        else if(materialName == "Unsafe (Instance)")
        {
            //The ball hits an unsafe chunk, game-over Retry
            GameManager.gameOver = true;
            rb.velocity = new Vector3(0, 0 , 0);
            Debug.Log("Game over!");


        }
        else if (materialName == "Last Chunk (Instance)")
        {
            //The ball hits last chunk, player wins
            GameManager.levelCompleted = true;
            Debug.Log("Congratulations!");
        }
    }
}
