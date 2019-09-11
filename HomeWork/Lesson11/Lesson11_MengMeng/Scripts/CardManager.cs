using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MengMeng
{
    public class CardManager : MonoBehaviour
    {
        CardController_V3[,] Cards;
        int Min_x, Min_y, Max_x, Max_y;
        float TimeCount_Q10;
        bool Q10_State = true;
        // Start is called before the first frame update
        void Start()
        {
            CreateCard_A();
            Question_7();
            Cards = Question_9();
        }

        // Update is called once per frame
        void Update()
        {
            Question_10();
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
        CardController_V3 CreateCard_C(float _RotateInterval, Vector3 _pos, float scale = 0.3f)
        {
            GameObject Card = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/Card"), this.transform);
            Card.transform.localPosition = _pos;
            Card.transform.localScale = new Vector3(scale, scale, scale);
            CardController_V3 CardController = Card.AddComponent<CardController_V3>();
            CardController.RotateInterval = _RotateInterval;
            return CardController;
        }
        CardController_V3[,] Question_9()
        {
            CardController_V3[,] Cards = new CardController_V3[40, 15];
            for (int i = 0; i < Cards.GetLength(0); i++)
            {
                for (int j = 0; j < Cards.GetLength(1); j++)
                {
                    Cards[i, j] = CreateCard_C(Random.Range(2f, 5f), new Vector3(-90 + i * 4, 20 - j * 6, 0));
                }
            }
            return Cards;
        }

        void RotateCards( bool bActive = true)
        {
            if (bActive)
            {
                int X_Length = 8, Y_Length = 6;
                Min_x = Random.Range(0, Cards.GetLength(0) - X_Length);
                Min_y = Random.Range(0, Cards.GetLength(1) - Y_Length);
                Max_x = Min_x + X_Length;
                Max_y = Min_y + Y_Length;
            }
            for (int i = Min_x; i < Max_x; i++)
            {
                for (int j = Min_y; j < Max_y; j++)
                {
                    CardController_V3 card = Cards[i, j];
                    if (bActive)
                    {
                        card.RotateInterval = 0.1f;
                    }
                    else
                    {
                        card.RotateInterval = Random.Range(2f, 5f);
                    }
                }
            }
        }

        void Question_10()
        {
            TimeCount_Q10 += Time.deltaTime;
            if(TimeCount_Q10 > 3)
            {
                TimeCount_Q10 = 0;
                RotateCards(Q10_State);
                Q10_State = !Q10_State;
            }
           
            
        }
    }

}
