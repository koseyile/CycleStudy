using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wupeng
{
public class Control
{

    [SerializeField]
    private bool isActive = false;
    private bool canBeChange = false;
    private float timer = 1.3f;
    private Vector3 direction = new Vector3(0.0f, 0.0f, 1.0f);

    // Update is called once per frame
    public void Update()
    {
        if (isActive)
        {
            timer -= Time.deltaTime;
            if (timer < 0.0f)
            {
                canBeChange = true;
                timer = 1.3f;
            }
        }
        if (!isActive)
        {
            timer -= Time.deltaTime;
            if (timer < 0.0f)
            {
                canBeChange = true;
                timer = 1.3f;
            }
        }

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
        if (isActive == false && Input.GetKeyUp(KeyCode.Space) && canBeChange == true)
        {
                isActive = true;
                timer = 1.3f;
                canBeChange = false;
                Debug.Log("游戏开始");
        }
        if (isActive == true && Input.GetKeyDown(KeyCode.Space) && canBeChange == true)
        {
            isActive = false;
            timer = 1.3f;
            canBeChange = false;
            Debug.Log("游戏暂停");
        }


    }

    public void SetActiveState(bool _state)
    {
        this.isActive = _state;
    }

    public bool GetActiveState()
    {
        return isActive;
    }

    public Vector3 GetDirection()
    {
        return direction;
    }
}
}
