using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TowerRotator : MonoBehaviour
{
    public static float rotationSpeed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.isGameStarted)
            return;

        //For PC
        //if (Input.GetMouseButton(0))
        //{
        //    float mouseX = Input.GetAxisRaw("Mouse X");

        //    transform.Rotate(0, -mouseX * rotationSpeed * Time.deltaTime, 0);

        //}

        //For Android
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            float xDelta = Input.GetTouch(0).deltaPosition.x;
            transform.Rotate(0, -xDelta * rotationSpeed * Time.deltaTime, 0);
        }
    }
}
