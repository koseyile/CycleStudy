using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control
{

    bool isActive;

    Vector3 direction;

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = new Vector3(0.0f, 0.0f, 1.0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = new Vector3(-1.0f, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = new Vector3(1.0f, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = new Vector3(0.0f, 0.0f, -1.0f);
        }
        if (isActive == false && Input.GetKey(KeyCode.Space))
        {
            isActive = true;
        }
        if (isActive == true && Input.GetKey(KeyCode.Space))
        {
            isActive = false;
        }

    }
}
