using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game2048Framework;
using TMPro;

namespace ZCY
{
    public class zcyNumberObject : INumberObject
    {
        private static GameObject numberGameObjPrefab;
        private GameObject numberGameObject;
        private Vector2 index;
        private static int s_id;
        private int id;

        public zcyNumberObject()
        {
            id = s_id++;
            if (numberGameObjPrefab == null)
            {
                numberGameObjPrefab = Resources.Load<GameObject>("CubeNumber");
            }
            numberGameObject = GameObject.Instantiate(numberGameObjPrefab);
        }

        public void SetIndex(Vector2 _index)
        {
            index = _index;
        }
        public Vector2 GetIndex()
        {
            return index;
        }

        public void SetPosition(Vector2 index)
        {
            numberGameObject.transform.position = new Vector3(index.x, index.y, 0.4f);
        }

        public Vector2 GetCurrentPos()
        {
            return new Vector2(numberGameObject.transform.position.x, numberGameObject.transform.position.y);
        }

        public void SetNumber(int number)
        {
            numberGameObject.GetComponentInChildren<TextMeshPro>().SetText(number.ToString());
        }

        public int GetNumber()
        {
            throw new System.NotImplementedException();
        }

        public void SetColor(Color color)
        {

        }
        
        public void SetText(string text)
        {
            //set text
        }

        public void SetText(int number)
        {
            throw new System.NotImplementedException();
        }

        public void SetLastIndex(Vector2 index)
        {
            throw new System.NotImplementedException();
        }

        public Vector2 GetLastIndex()
        {
            throw new System.NotImplementedException();
        }
    }
}
