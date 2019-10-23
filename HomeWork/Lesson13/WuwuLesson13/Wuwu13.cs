using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Wuwu { 
public class Wuwu13 : MonoBehaviour
{
    public class Bird
    {
        public string NameofB;
        public int flyspeed;
        public int runspeed;
        public string colorofswing;
        public string favoritefood;
        
        public Bird(string _name, int _flyspeed, int _runspeed, string _colorofswing, string _favoritefood)
        {
            NameofB = _name;
            flyspeed = _flyspeed;
            runspeed = _runspeed;
            colorofswing = _colorofswing;
            favoritefood = _favoritefood;
        }

    }
    public void printBird(Bird bird)
    {
        if (bird.runspeed== 0)
        {
            Debug.Log(bird.NameofB + "的飞行速度是" + bird.flyspeed + ",翅膀是" + bird.colorofswing + ",最喜欢吃的食物是" + bird.favoritefood);
            return;
        }
        if (bird.flyspeed == 0)
        {
            Debug.Log(bird.NameofB + "的步行速度是" + bird.runspeed + ",翅膀是" + bird.colorofswing + ",最喜欢吃的食物是" + bird.favoritefood);
            return;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

     Bird haiou = new Bird("海鸥", 20, 0, "灰色", "沙丁鱼");
     Bird haiyan = new Bird("海燕", 80, 0, "棕色", "小虾");
     Bird tuoniao = new Bird("鸵鸟", 0, 30, "褐色", "苹果");

        printBird(haiou);
        printBird(haiyan);
        printBird(tuoniao);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
 }
}