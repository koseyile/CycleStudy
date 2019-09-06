using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MengMeng
{
    public class CardManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            CreateCard_A();
            Question_7();
            Question_9();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void CreateCard_A()
        {
            GameObject Card = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/Card"), this.transform);
            Card.name = "Card_A";
            Card.transform.localPosition = new Vector3(-50, 40, 0);
            Card.AddComponent<CardController_V1>();
        }
        void CreateCard_B(int _RotateInterval, Vector3 _pos, float scale = 0.6f)
        {
            GameObject Card = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/Card"), this.transform);
            Card.transform.localPosition = _pos;
            Card.transform.localScale = new Vector3(scale, scale, scale);
            CardController_V2 CardController = Card.AddComponent<CardController_V2>();
            CardController.RotateInterval = _RotateInterval;
        }
        void Question_7()
        {
            CreateCard_B(0, new Vector3(40, 40, 0));
            CreateCard_B(0, new Vector3(30, 40, 0));
            CreateCard_B(1, new Vector3(20, 40, 0));
            CreateCard_B(1, new Vector3(10, 40, 0));
            CreateCard_B(60, new Vector3(0, 40, 0));
            CreateCard_B(60, new Vector3(-10, 40, 0));
            CreateCard_B(3600, new Vector3(-20, 40, 0));
            CreateCard_B(3600, new Vector3(-30, 40, 0));
        }
        void CreateCard_C(float _RotateInterval, Vector3 _pos, float scale = 0.4f)
        {
            GameObject Card = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/Card"), this.transform);
            Card.transform.localPosition = _pos;
            Card.transform.localScale = new Vector3(scale, scale, scale);
            CardController_V3 CardController = Card.AddComponent<CardController_V3>();
            CardController.RotateInterval = _RotateInterval;
        }
        void Question_9()
        {
            for(int i = 0; i< 30;i++)
            {
                for(int j = 0; j< 20;j++)
                {
                    CreateCard_C(Random.Range(0f, 10f), new Vector3(-90 + i * 6, 20 - j * 9, 0));
                }
            }
        }
    }

}
