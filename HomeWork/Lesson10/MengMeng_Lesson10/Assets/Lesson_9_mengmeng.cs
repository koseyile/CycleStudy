using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MengMeng
{
    public class Lesson_9_mengmeng : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Apple apple = new Apple("red", 1);
            Answer_3();
            Answer_4();
            List<Animal> CycleStudyGroup = Answer_5();
            Answer_6(CycleStudyGroup);
            Answer_7(CycleStudyGroup);
            Answer_8(CycleStudyGroup);
        }

        Apple[] CreateApples(int Num, string AppleColor, float MinWeight, float MaxWeight)
        {
            Apple[] apples = new Apple[Num];
            for (int i = 0; i < Num; i++)
            {
                apples[i] = new Apple(AppleColor, Random.Range(MinWeight, MaxWeight));
            }
            return apples;
        }

        float GetApplesWeights(Apple[] apples)
        {
            float Weights = 0;
            foreach (Apple apple in apples)
            {
                Weights += apple.weight;
            }
            return Weights;
        }

        void Answer_3()
        {
            Debug.Log("这10个苹果一共" + GetApplesWeights(CreateApples(10, "red", 0.1f, 1.5f)) + "斤");
        }

        void Answer_4()
        {
            float Money = GetApplesWeights(CreateApples(6, "red", 0.2f, 1.2f)) * 12 + GetApplesWeights(CreateApples(5, "green", 0.5f, 1.8f)) * 8;
            Debug.Log("这些苹果一共" + Money + "元");
        }

        List<Animal> Answer_5()
        {
            List<Animal> CycleStudyGroup = new List<Animal>();
            Fruits Apple = new Fruits("Apple", "red", 1);
            Fruits Orange = new Fruits("Orange", "orange", 1);
            Fruits Watermelon = new Fruits("Watermelon", "green", 5);
            Fruits Cherry = new Fruits("Cherry", "red", 0.1f);
            Fruits Hamimelon = new Fruits("Hamimelon", "green", 5);
            Fruits Banana = new Fruits("Banana", "yellow", 2);
            Animal BB = new Animal("BaiBai", true, new Fruits[2] { Apple, Orange }, null);
            Animal WW = new Animal("WuWu", true, new Fruits[2] { Apple, Watermelon }, null);
            Animal DD = new Animal("DanDan", true, new Fruits[2] { Cherry, Hamimelon }, null);
            Animal Monkey = new Animal("Monkey", false, new Fruits[1] { Banana }, null);
            BB.BestFriend = WW;
            WW.BestFriend = DD;
            DD.BestFriend = Monkey;
            Monkey.BestFriend = BB;
            CycleStudyGroup.Add(BB);
            CycleStudyGroup.Add(WW);
            CycleStudyGroup.Add(DD);
            CycleStudyGroup.Add(Monkey);
            return CycleStudyGroup;
        }

        string GetFavoriteFruitsText(Animal animal)
        {
            string FavoriteFruitsText = "";
            foreach (Fruits fruit in animal.FavoriteFruits)
            {
                FavoriteFruitsText += (fruit.color + "的" + fruit.Name + "和");
            }
            FavoriteFruitsText = FavoriteFruitsText.Remove(FavoriteFruitsText.Length - 1);
            return FavoriteFruitsText;
        }

        void Answer_6(List<Animal> CycleStudyGroup)
        {
            foreach (Animal animal in CycleStudyGroup)
            {
                if (animal.Name == "BaiBai")
                {
                    Debug.Log(animal.Name + "最喜欢吃" + GetFavoriteFruitsText(animal));
                    return;
                }
            }
        }

        void Answer_7(List<Animal> CycleStudyGroup)
        {
            foreach (Animal animal in CycleStudyGroup)
            {
                if (animal.isHuman == false)
                {
                    Debug.Log(animal.Name + "最喜欢吃" + GetFavoriteFruitsText(animal));
                    return;
                }
            }
        }

        void Answer_8(List<Animal> CycleStudyGroup)
        {
            foreach (Animal animal in CycleStudyGroup)
            {
                if (animal.Name == "BaiBai")
                {
                    Debug.Log("白白的好朋友的好朋友的好朋友最喜欢吃" + GetFavoriteFruitsText(animal.BestFriend.BestFriend.BestFriend));
                    return;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    public class Fruits
    {
        public string Name;
        public string color;
        public float weight;

        public Fruits()
        {

        }
        public Fruits(string _Name, string _color, float _weight)
        {
            Name = _Name;
            color = _color;
            weight = _weight;
        }
    }

    public class Apple : Fruits
    {
        public Apple(string Color, float Weight) : base()
        {
            Name = "Apple";
            color = Color;
            weight = Weight;
        }
    }

    //虽然我猜想这里是希望我们用一个Human和一个Monkey来继承Animal，但是只用Animal类也能解决问题，我就偷懒只用Animal了
    public class Animal
    {
        public string Name;
        public bool isHuman;
        public Fruits[] FavoriteFruits;
        public Animal BestFriend;
        public Animal(string _Name, bool _isHuman, Fruits[] _FavoriteFruits, Animal _BestFriend)
        {
            Name = _Name;
            isHuman = _isHuman;
            FavoriteFruits = _FavoriteFruits;
            BestFriend = _BestFriend;
        }
    }
}
