using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MengMeng
{
    public class UIManager : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            Button RotateController = this.transform.Find("Button_Rotate").GetComponent<Button>();
            InputField FrontNumberController = this.transform.Find("InputField_Front").GetComponent<InputField>();
            InputField BackNumberController = this.transform.Find("InputField_Back").GetComponent<InputField>();

            RotateController.onClick.AddListener(() => OnClickButton_RotateCard());
            FrontNumberController.onValueChanged.AddListener(OnEdit_FrontNumber);
            BackNumberController.onValueChanged.AddListener(OnEdit_BackNumber);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnClickButton_RotateCard()
        {
            Transform CardManager = transform.Find("/CardManager");
            CardController_V1 cardRotater = CardManager.GetComponentInChildren<CardController_V1>();
            cardRotater.cardstate = CardController_V1.CardState.Rotate;
        }
        void OnEdit_FrontNumber( string text)
        {
            Transform CardManager = transform.Find("/CardManager");
            CardController_V1 cardRotater = CardManager.GetComponentInChildren<CardController_V1>();
            cardRotater.SetFrontNumber(text);
        }
        void OnEdit_BackNumber(string text)
        {
            Transform CardManager = transform.Find("/CardManager");
            CardController_V1 cardRotater = CardManager.GetComponentInChildren<CardController_V1>();
            cardRotater.SetBackNumber(text);
        }
    }
}

