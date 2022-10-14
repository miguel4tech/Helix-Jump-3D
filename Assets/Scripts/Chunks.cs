using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunks : MonoBehaviour
{
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > player.position.y )
        {
            //Adds 1 to the number of chunks passed.
            FindObjectOfType<AudioManager>().Play("whoosh");
            GameManager.numberOfPassedChunks++;
            GameManager.score++;
            //Destroy(gameObject);
        }
    }
}
