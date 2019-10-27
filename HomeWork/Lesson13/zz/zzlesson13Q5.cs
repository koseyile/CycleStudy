using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zzlesson13
{

    public class zzlesson13Q5 : MonoBehaviour
    {
        //Q5
        public class People
        {
            public string Name;
            public string Action;

            public People(string n,string a)
            {
                Name = n;
                Action = a;
            }
        }

        public class Shop
        {
            public string ShopName;
            public string GoodsName;

            public Shop(string sn,string gn)
            {
                ShopName = sn;
                GoodsName = gn;
            }

        }

        public class ClothingShop:Shop
        {
            public ClothingShop(string sn,string gn) : base(sn, gn)
            {

            }
        }

        public class FruitShop:Shop
        {
            public FruitShop(string sn, string gn) : base(sn, gn)
            {

            }
        }

    
        public void Story(People people,Shop shop,People friends)
        {
            if(people.Name == "Ningning")
            {
                Debug.Log("Ningning在" + shop.ShopName + "买了" + shop.GoodsName + "送给" + friends.Name);
            }

            else
            {
                Debug.Log(people.Name + "接过" + shop.GoodsName + people.Action);
            }

        }


        void Start()
        {

            People ningning = new People("Ningning", "买");
            People zz = new People("zz", "戴在头上");
            People wuwu = new People("wuwu", "吃掉了");
            People friendszz = new People("zz", null);
            People friendswuwu = new People("wuwu", null);

            ClothingShop clothingShop = new ClothingShop("服装店", "帽子");
            FruitShop fruitShop = new FruitShop("水果店", "西瓜");

            Story(ningning, clothingShop,friendszz);
            Story(ningning, fruitShop,friendswuwu);
            Story(zz, clothingShop,null);
            Story(wuwu, fruitShop,null);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

