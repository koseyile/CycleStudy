using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fruit
{
    private Color color;
    public string name;
    private float weight;
    public void Getname()
    {
        Debug.Log(name);
    }

    public void SetWeight(float a)
    {
        weight = a;
    }

}

public class Apple : Fruit
{
    public Apple()
    {
        name = "Apple";
    }
}

public class Orange : Fruit
{
    public Orange()
    {
        name = "Orange";
    }
}
public class Watermelon : Fruit
{
    public Watermelon()
    {
        name = "Watermelon";
    }
}
public class Cherry : Fruit
{
    public Cherry()
    {
        name = "cherry";
    }
}
public class Hamigua : Fruit
{
    public Hamigua()
    {
        name = "Hamigua";
    }
}
public class Banana : Fruit
{
    public Banana()
    {
        name = "banana";
    }
}



public class life
{
    public life friend;
    public Fruit[] favouritefruit;
    public string name;


}


public class human:life
{


}

public class animal :life
{


}



public class lesson9 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        //题目2
        Fruit a = new Fruit();
        a = new Apple();
        a.SetWeight(1);

        //题目3
        Fruit[] b = new Fruit[10];
        float[] weight = new float[10];
        float sum = 0;
        for (int n = 0; n < b.Length; n++)
        {
            b[n] = new Apple();
            weight[n] = Random.Range(0.1f, 1.5f);
            b[n].SetWeight((float)weight[n]);

            sum += weight[n];

        }

    

        Debug.Log(sum);

        //题目4
        Fruit[] c = new Fruit[5];
        float[] weight2 = new float[5];
        float money_green = 0;
        for (int n = 0; n < c.Length; n++)
        {
            b[n] = new Apple();
            weight2[n] = Random.Range(0.5f, 1.8f);
            b[n].SetWeight((float)weight2[n]);
            money_green += (weight2[n] * 8);
        }

        Fruit[] d = new Fruit[6];
        float[] weight3 = new float[6];
        float money_red = 0;
        for (int n = 0; n < d.Length; n++)
        {
            b[n] = new Apple();
            weight3[n] = Random.Range(0.2f, 1.2f);
            b[n].SetWeight((float)weight3[n]);
            
            money_red += (weight3[n] * 12);

        }
        float money_sum = money_green + money_red;
        Debug.Log(money_sum);


        life[] e = new life[4];
        e[0] = new human();
        e[1] = new human();
        e[2] = new human();
        e[3] = new animal();

        e[0].name = "Baibai";
        e[1].name = "Wuwu";
        e[2].name = "Dandan";
        e[3].name = "Houzi";

        e[0].favouritefruit = new Fruit[2];
        e[0].favouritefruit[0] = new Apple();
        e[0].favouritefruit[1] = new Orange();

        e[1].favouritefruit = new Fruit[2];
        e[1].favouritefruit[0] = new Apple();
        e[1].favouritefruit[1] = new Watermelon();

        e[2].favouritefruit = new Fruit[2];
        e[2].favouritefruit[0] = new Cherry();
        e[2].favouritefruit[1] = new Hamigua();

        e[3].favouritefruit = new Fruit[1];
        e[3].favouritefruit[0] = new Banana();

        //遍历数组 寻找出叫白白的？ 打印出白白喜欢吃的水果的名称和颜色。 颜色？？
        for (int n = 0; n < e[0].favouritefruit.Length; n++)
        {

        e[0].favouritefruit[n].Getname();
        
        }

        //遍历数组， 寻找非人类???怎么找？？？ 打印数组里非人类喜欢吃的水果的名称和颜色。
        for (int n = 0; n < e[3].favouritefruit.Length; n++)
        {

            e[3].favouritefruit[n].Getname();

        }

        e[0].friend = e[1];
        e[1].friend = e[2];
        e[2].friend = e[3];
        e[3].friend = e[0];

        for (int n = 0; n < e[0].friend.friend.friend.favouritefruit.Length; n++)
        {
            e[0].friend.friend.friend.favouritefruit[n].Getname();
        }


    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
