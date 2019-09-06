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
        void CreateCard_B(int _RotateInterval, Vector3 _pos)
        {
            GameObject Card = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/Card"), this.transform);
            Card.transform.localPosition = _pos;
            Card.transform.localScale = new Vector3(0.6f, 0.6f,0.6f);
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
    }

}
