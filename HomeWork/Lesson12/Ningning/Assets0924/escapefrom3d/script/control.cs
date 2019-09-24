using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                _level3.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

                _level1.transform.localScale = new Vector3(1f, 1f, 1f);
                _level2.transform.localScale = new Vector3(1f, 1f, 1f);

                if (Input.GetKeyUp(KeyCode.Q))
                {

                    SceneManager.LoadScene(1);

                }


            }

            if (transform.localPosition.z > -18.43f && transform.localPosition.z < -17.94f)
            {
                _level2.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

                _level1.transform.localScale = new Vector3(1f, 1f, 1f);
                _level3.transform.localScale = new Vector3(1f, 1f, 1f);

                if (Input.GetKeyUp(KeyCode.Q))
                {

                    SceneManager.LoadScene(1);

                }


            }

            if (transform.localPosition.z > -20.77f && transform.localPosition.z < -20.22f)
            {
                _level1.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

                _level2.transform.localScale = new Vector3(1f, 1f, 1f);
                _level3.transform.localScale = new Vector3(1f, 1f, 1f);

                if (Input.GetKeyUp(KeyCode.Q))
                {

                    SceneManager.LoadScene(1);

                }


            }

        }
        else
        {
            _level1.transform.localScale = new Vector3(1f, 1f, 1f);
            _level2.transform.localScale = new Vector3(1f, 1f, 1f);
            _level3.transform.localScale = new Vector3(1f, 1f, 1f);
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
