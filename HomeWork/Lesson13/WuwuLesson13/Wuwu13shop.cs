using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Wuwu
{
    public class Wuwu13shop : MonoBehaviour
    {

        public class Human
        {
            public string Name;
            public string behavior;

            public Human(string _name, string _behavior)
            {
                Name = _name;
                behavior = _behavior;
            }

        }

        public class Shop
        {
            public string shopname;
            public string stuffname;

            public Shop(string _shopname, string _stuffname)
            {
                shopname = _shopname;
                stuffname = _stuffname;
            }
        }



        public void Purchase(Human[] humen, Shop shop)
        {

            if (shop.shopname == "水果店")
            {

                Debug.Log(humen[0].Name + "在" + shop.shopname + humen[0].behavior + shop.stuffname + "送给了" + humen[1]);
                Debug.Log(humen[1].Name + humen[1].behavior + shop.stuffname);
                return;
            }
            if (shop.shopname == "服装店")
            {

                Debug.Log(humen[0].Name + "在" + shop.shopname + "买" + shop.stuffname + "送给了" + humen[2]);
                Debug.Log(humen[2].Name + humen[2].behavior + shop.stuffname);
                return;
            }

        }




        // Start is called before the first frame update
        void Start()
        {
            Human[] humen = new Human[3];
            humen[0] = new Human("宁宁", "买");
            humen[1] = new Human("巫巫", "吃");
            humen[2] = new Human("zz", "戴");
            Shop fruitshop = new Shop("水果店", "西瓜");
            Shop clothshop = new Shop("服装店", "帽子");

            Purchase(humen, fruitshop);
            Purchase(humen, clothshop);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}