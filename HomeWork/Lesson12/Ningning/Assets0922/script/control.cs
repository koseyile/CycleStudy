using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public GameObject _level1;
    public GameObject _level2;
    public GameObject _level3;

    float MoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        MoveSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localPosition.x <1.4f&& transform.localPosition.x > -1)
        {
            if(transform.localPosition.z>-16.87f&& transform.localPosition.z<- 16)
            {
                _level1.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }

        }



        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.forward * MoveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-transform.forward * MoveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * MoveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-transform.right * MoveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Translate(-transform.up * MoveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(transform.up * MoveSpeed * Time.deltaTime);
        }


    }
}
