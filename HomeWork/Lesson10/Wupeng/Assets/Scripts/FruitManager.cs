using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wupeng
{

public class FruitManager 
{
    [SerializeField]
    private string fruitpath = "Prefab/";

    private List<Fruit> fruits;

    private Vector3[] poses;//初始化8个位置
    private FRUITKIND[] fruitsTemp;

    public void Initiate()
    {
        fruits = new List<Fruit>();

        //Temple Code 初始化10个位置
        poses = new Vector3[8];

        poses[0] = new Vector3(-7, 0, -3);
        poses[1] = new Vector3(6, 0, 6);
        poses[2] = new Vector3(2, 0, 4);
        poses[3] = new Vector3(-4, 0, -9);
        poses[4] = new Vector3(-5, 0, 1);
        poses[5] = new Vector3(-6, 0, 5);
        poses[6] = new Vector3(-4, 0, -4);
        poses[7] = new Vector3(8, 0, -4);

        //Temlpe Code
        fruitsTemp = new FRUITKIND[8] { FRUITKIND.Apple, FRUITKIND.Mango, FRUITKIND.Strawberry, FRUITKIND.Strawberry, FRUITKIND.Peach, FRUITKIND.Peach, FRUITKIND.Peach, FRUITKIND.Watermelon};

    }

    public Fruit GenerateFruit(FRUITKIND _kind, Vector3 _position)
    {
        string kind = "";
        switch (_kind)
        {
            case FRUITKIND.Apple:
                kind = "Apple";
                break;
            case FRUITKIND.Mango:
                kind = "Mango";
                break;
            case FRUITKIND.Peach:
                kind = "Peach";
                break;
            case FRUITKIND.Strawberry:
                kind = "Strawberry";
                break;
            case FRUITKIND.Watermelon:
                kind = "Watermelon";
                break;
            default:
                Debug.Log("水果类型未知");
                break;
        }
        GameObject prefab = Resources.Load(fruitpath + kind) as GameObject;

        Fruit fruit = new Fruit(kind, prefab, _position);
        fruits.Add(fruit);
        return fruit;
    }

    //Temple Code
    public List<Fruit> GenerateFruits()
    {

        for (int i = fruitsTemp.Length - 1; i >= 0; i --)
        {
            GenerateFruit(fruitsTemp[i], poses[i]);
        }

        return fruits;
    }
}
}
