using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Q4
public class Animal
{
    public string name;
    public int speed;
    public string wingColour;
    public string favouriteFood;

    public Animal()
    { }

    public Animal(string n, int sp, string wc, string ff)
    {
        name = n;
        speed = sp;
        wingColour = wc;
        favouriteFood = ff;  
    }
}

public class Ostrich : Animal
{ 

    public Ostrich(string n_o, int sp_run, string wc_o, string ff_o)
    {
        name = n_o;
        speed = sp_run;
        wingColour = wc_o;
        favouriteFood = ff_o;
    }
}

public class Bird : Animal
{

    public Bird(string n_b, int sp_fly, string wc_b, string ff_b)
    {
        name = n_b;
        speed = sp_fly;
        wingColour = wc_b;
        favouriteFood = ff_b;
    }
}

//Q5
public class Product
{
    public string productname;
    public string shop;
    public string customer;
    public string currentowner;

    public Product(string pd, string s, string cn, string co)
    {
        productname = pd;
        shop = s;
        customer = cn;
        currentowner = co;
    }
}

//Q6
public class Video
{
    public string videoname;
    public string maker;
    public string audience;

    public Video(string vn, string mn, string an)
    {
        videoname = vn;
        maker = mn;
        audience = an;
    }
}

public class Maker
{
    public string name;
    public string jobcontent;

    public Maker(string name_m, string jc)
    {
        name = name_m;
        jobcontent = jc;
    }
}

public class Audience 
{
    public string audiencename;

    public Audience (string name_a)
    {
        audiencename = name_a;
    }
}

public class hongyitest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RunQ4();
        RunQ5();
        RunQ6();
    }

    public void RunQ4()
    {
        Bird seaGUll = new Bird("海鸥", 20, "灰色", "沙丁鱼");
        Debug.Log(seaGUll.name + "|奔跑速度：" + seaGUll.speed + "|翅膀颜色：" + seaGUll.wingColour + "|喜爱的食物：" + seaGUll.favouriteFood);

        Bird petrel = new Bird("海燕", 80, "棕色", "小虾");
        Debug.Log(petrel.name + "|奔跑速度：" + petrel.speed + "|翅膀颜色：" + petrel.wingColour + "|喜爱的食物：" + petrel.favouriteFood);

        Ostrich ostrich = new Ostrich("鸵鸟", 30, "褐色", "苹果");
        Debug.Log(ostrich.name + "|奔跑速度：" + ostrich.speed + "|翅膀颜色：" + ostrich.wingColour + "|喜爱的食物：" + ostrich.favouriteFood);
    }

    public void RunQ5()
    {
        Product watermelon = new Product("西瓜","水果店","宁宁","巫巫");
        Debug.Log(watermelon.productname + "来自" + watermelon.shop + "|买的人：" + watermelon.customer + "|吃的人：" + watermelon.currentowner);

        Product hat = new Product("帽子", "服装店", "宁宁", "zz");
        Debug.Log(hat.productname + "来自" + hat.shop + "|买的人：" + hat.customer + "|戴的人：" + hat.currentowner);
    }

    public void RunQ6()
    {
        Maker director = new Maker("白白", "统筹项目");
        Maker producer = new Maker("白白的朋友们", "故事剧本、人物设计、场景设计、动画制作、音乐、配乐等");
        Debug.Log(director.name + "负责" + director.jobcontent+"," + producer.name + "负责"+producer.jobcontent);

        Audience dalao = new Audience("大佬");
        Video video = new Video("小视频", "白白和她的朋友们", "大佬");
        Debug.Log(dalao.audiencename + "喜欢" + video.videoname);
    }

    // Update is called once per frame
    void Update()
    {  
    }
}
