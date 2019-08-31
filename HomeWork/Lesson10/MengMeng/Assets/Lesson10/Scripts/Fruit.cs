using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace MengMeng
{
    //[ScriptableObject]
    public class Fruit 
    {
        public string Name;
        private string colorname;
        private GameObject FruitObj;

        public Fruit(string _name, string _colorname, Vector3 _pos, GameObject _Object)
        {
            Name = _name;
            colorname = _colorname;
            FruitObj = GameObject.Instantiate(_Object, _pos, Quaternion.identity);
            MeshRenderer renderer = FruitObj.GetComponent<MeshRenderer>();
            Material BodyMat = new Material(Shader.Find("Standard"));
            renderer.material = BodyMat;
            if (renderer != null)
            {
                switch (colorname)
                {
                    case "colorful":
                        BodyMat.color = new Color32(214, 213, 27, 1);
                        break;
                    case "red":
                        BodyMat.color = new Color(0.5f, 0, 0);
                        break;
                    case "yellow":
                        BodyMat.color = new Color(1, 1, 0);
                        break;
                    case "green":
                        BodyMat.color = new Color(0, 1, 0);
                        break;
                    case "pink":
                        BodyMat.color = new Color32(214, 21, 179,1);
                        break;
                    default:
                        BodyMat.color = Color.gray;
                        break;

                }
            }
        }

        public Vector3 GetPosition()
        {
            return FruitObj.transform.position;
        }
        public Color GetObjColor()
        {
            return FruitObj.GetComponent<MeshRenderer>().material.color;
        }
        public void DestroyFruit()
        {
            FruitObj.SetActive(false);
        }
    }
}
