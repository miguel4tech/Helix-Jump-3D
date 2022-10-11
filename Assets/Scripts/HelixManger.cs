using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManger : MonoBehaviour
{
    #region VARIABLES
    public GameObject[] helixChunks;
    public float ySpawn;
    public int numberOfChunks; //created for each level
    private float chunkDistace = 5;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //Defines number of chunk per level, default as 7(levelNumber 1+6)
        numberOfChunks = GameManager.currentLevelIndex + 6;

        for (int i = 0; i < numberOfChunks; i++)
        {
            //Checks to ensure the first chunk is always safe
            if(i == 0)
            {
                SpawnChunks(0);
            }
            else
            SpawnChunks(Random.Range(0, helixChunks.Length - 1));
        }

        //After instantiating the tower per level(using the loop above), the last chunk is instantiated/created
        SpawnChunks(helixChunks.Length - 1);
    }

    public void SpawnChunks(int chunkIndex)
    {
        //Makes the chunks a child of the Towermanager
        GameObject tower = Instantiate(helixChunks[chunkIndex], transform.up * ySpawn, Quaternion.identity);
        tower.transform.parent = transform;
        ySpawn -= chunkDistace;
    }


}
