using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BBBB;

public class baibaiHW13 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Q4
        RunQ4();

        //Q5
        RunQ5();

        //Q6
        RunQ6();
    }


    void RunQ4() {
        /*
         * 海鸥的飞行速度是20，翅膀为灰色，最喜欢吃的食物是沙丁鱼。
         * 海燕的飞行速度是80，翅膀为棕色，最喜欢吃的食物是小虾。
         * 鸵鸟的奔跑速度是30，翅膀为褐色，最喜欢吃的食物是苹果。
         * */
        Seagull seagull = new Seagull(20, "grey", "sardine");
        Petrel petrel = new Petrel(80, "brown", "shrimp");
        Ostrich ostrich = new Ostrich(30, "brown", "apple");

        Debug.Log("海鸥飞行速度" + seagull.flySpeed + " 翅膀颜色" + seagull.wingColor + " 爱吃" + seagull.favoriteFood);
        Debug.Log("海燕飞行速度" + petrel.flySpeed + " 翅膀颜色" + petrel.wingColor + " 爱吃" + petrel.favoriteFood);
        Debug.Log("鸵鸟奔跑速度" + ostrich.runSpeed + " 翅膀颜色" + ostrich.wingColor + " 爱吃" + ostrich.favoriteFood);

    }

    void RunQ5() {

        Person ninging = new Person("Ningning");
        Person wuwu = new Person("Wuwu");
        Person zz = new Person("ZZ");

        WaterMelon waterMelon = new WaterMelon("sweetWaterMelon", 5.0f);
        FruitShop fruitShop = new FruitShop(waterMelon, 2);

        Hat niceHat = new Hat("niceHat", 120.0f);
        ClothingShop clothingShop = new ClothingShop(niceHat, 1);

        ninging.BuyItem(fruitShop, 10.0f, waterMelon);
        ninging.BuyItem(clothingShop, 200.0f, niceHat);
        ninging.Gifting(ninging.ownedItems[0], wuwu);
        ninging.Gifting(ninging.ownedItems[0], zz);
        wuwu.EatFood((BBBB.Food)wuwu.ownedItems[0]);
        zz.PutOn((BBBB.Clothing)zz.ownedItems[0]);
    }

    void RunQ6()
    {
        Client client = new Client();
        Episode nataku = new Episode("nataku", 6);
        client.Order(nataku);

        Director baibai = new Director("baibai", nataku);
        nataku.parts[0] = "Story";
        nataku.parts[1] = "Charater";
        nataku.parts[2] = "Scene";
        nataku.parts[3] = "Animation";
        nataku.parts[4] = "Music";
        nataku.parts[5] = "Vo";
        
        baibai.ConstructProduct();
        baibai.Deliver(nataku, client);

    }

}
