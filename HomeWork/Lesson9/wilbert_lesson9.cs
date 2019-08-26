using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public class furit
    {
        public string name;
        public string color;
        public float weight;
    }
    public class apple: furit
    {}
    public class oringe: furit
    {}
    public class watermelon: furit
    {}
    public class melon: furit
    {}
    public class cherry: furit
    {}
    public class banana: furit
    {}

    public class life
    {
        public string name;
        public furit favourite01;
        public furit favourite02;
        public life friend;
    }
    public class human: life
    {}
    public class animal: life
    {}
    public class baibai: human
    {}
    public class wuwu: human
    {}
    public class dandan: human
    {}
    public class monkey: animal
    {}

public class wilbert_lesson9 : MonoBehaviour
{
    // Start is called before the first frame update

    private apple red_apple;
    void Start()
    {

// 1. 声明一个水果类，具有如下成员：颜色，名称，重量。
// 2. 声明一个苹果类继承自水果类，实例化一个1斤重的红色苹果。
        red_apple = new apple();
        red_apple.name = "red apple";
        red_apple.color = "red";
        red_apple.weight = 1.0f;

//3. 随机实例化10个0.1到1.5斤重的红色苹果，求出这些苹果的总重量。
        furit[] red_apples00 = new furit[10];
        float n = 0f;
        for(int i=0; i<red_apples00.Length; ++i)
        {
            red_apples00[i]=new apple();
            red_apples00[i].name = "red apple";
            red_apples00[i].color = "red";
            red_apples00[i].weight = Random.Range(0.1f,1.5f);
            n+=red_apples00[i].weight;
        }
        Debug.Log("这些苹果的总重量："+n);

//4. 已知绿色苹果8元/斤，红色苹果12元/斤，实例化5个0.5到1.8斤重的绿苹果，实例化6个0.2到1.2斤重的红苹果。求这些苹果的总价钱。
        furit[] red_apples01 = new furit[6];
        float n1 = 0f;
        for(int i=0; i<red_apples01.Length; ++i)
        {
            red_apples01[i]=new apple();
            red_apples01[i].name = "red apple";
            red_apples01[i].color = "red";
            red_apples01[i].weight = Random.Range(0.2f,1.2f);
            n1+=red_apples01[i].weight;
        }
        //Debug.Log(n1);
        furit[] green_apples01 = new furit[5];
        float n2 = 0f;
        for(int i=0; i<green_apples01.Length; ++i)
        {
            green_apples01[i]=new apple();
            green_apples01[i].name = "green apple";
            green_apples01[i].color = "green";
            green_apples01[i].weight = Random.Range(0.5f,1.8f);
            n2+=green_apples01[i].weight;
        }
        //Debug.Log(n2);
        float money = 0f;
        money = n1*12f+n2*8f;
        Debug.Log("这些苹果的总价钱："+money);

//5. 白白喜欢吃的水果有苹果，桔子。巫巫喜欢吃的水果有苹果，西瓜。淡淡喜欢吃的水果有樱桃，哈密瓜。小猴子最喜欢吃的水果有香蕉。请声明数组存储三个人类和一只猴子。
        furit[] furits = new furit[6];
        furits[0] = new apple();
        furits[0].name = "apple";
        furits[0].color = "red color";
        furits[1] = new oringe();
        furits[1].name = "oringe";
        furits[1].color = "oringe color";
        furits[2] = new watermelon();
        furits[2].name = "watermelon";
        furits[2].color = "green color";
        furits[3] = new melon();
        furits[3].name = "melon";
        furits[3].color = "green color";
        furits[4] = new cherry();
        furits[4].name = "cherry";
        furits[4].color = "pink color";
        furits[5] = new banana();
        furits[5].name = "banana";
        furits[5].color = "yellow color";

        life[] lifes = new life[4];
        lifes[0] = new baibai();
        lifes[0].name = "baibai";
        lifes[0].favourite01 = furits[0];
        lifes[0].favourite02 = furits[1];
        lifes[1] = new wuwu();
        lifes[1].name = "wuwu";
        lifes[1].favourite01 = furits[0];
        lifes[1].favourite02 = furits[2];
        lifes[2] = new dandan();
        lifes[2].name = "dandan";
        lifes[2].favourite01 = furits[3];
        lifes[2].favourite02 = furits[4];
        lifes[3] = new monkey();
        lifes[3].name = "monkey";
        lifes[3].favourite01 = furits[5];
        lifes[3].favourite02 = furits[5];

// 6. 遍历数组，打印出白白喜欢吃的水果的名称和颜色。
// 7. 遍历数组，打印数组里非人类喜欢吃的水果的名称和颜色。
        for(int i=0; i<lifes.Length; ++i)
        {
            if(lifes[i].name =="baibai")
            {
                Debug.Log("白白喜欢吃的水果的名称："+lifes[i].favourite01.name+"和"+lifes[i].favourite02.name);
                Debug.Log("白白喜欢吃的水果的颜色："+lifes[i].favourite01.color+"和"+lifes[i].favourite02.color);
            }
            if(lifes[i] is human == false)
            {
                Debug.Log("非人类喜欢吃的水果的名称："+lifes[i].favourite01.name+"和"+lifes[i].favourite02.name);
                Debug.Log("非人类喜欢吃的水果的颜色："+lifes[i].favourite01.color+"和"+lifes[i].favourite02.color);
            }
        }

//8. 已知白白最好的朋友是巫巫，巫巫最好的朋友是淡淡，淡淡最好的朋友是小猴子，小猴子最好的朋友是白白，打印出白白的好朋友的好朋友的好朋友喜欢吃的水果的名称和颜色。
        lifes[0].friend = lifes[1];
        lifes[1].friend = lifes[2];
        lifes[2].friend = lifes[3];
        lifes[3].friend = lifes[0];
        Debug.Log("白白的好朋友的好朋友的好朋友喜欢吃的水果的名称是："+lifes[0].friend.friend.friend.favourite01.name+"和"+lifes[0].friend.friend.friend.favourite02.name);
        Debug.Log("白白的好朋友的好朋友的好朋友喜欢吃的水果的颜色是："+lifes[0].friend.friend.friend.favourite01.color+"和"+lifes[0].friend.friend.friend.favourite02.color);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
