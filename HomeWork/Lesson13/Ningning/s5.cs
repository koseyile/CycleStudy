using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Watermelon a= new Watermelon();
        Hat b = new Hat();
        //Ningning nn = SimpleFactory2.CreateHuman("Ningning") as Ningning;
        //nn.Get(b);

        SimpleFactory2.CreateHuman("Ningning").Get(b);
        
        //SimpleFactory2.CreateHuman("Ningning").Get(b); ???????有问题ningning是不是又被转换成human了

        //Ningning ning = new Ningning("123");
        //ning.Get(a);
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public class Human
    {
        public string Name;
        public string Favouritething;
        public virtual void Get(Watermelon watermelon)
        {
            Debug.Log("human watermelon");
        }

        public virtual void Get(Hat hat)
        {
            Debug.Log("human hat");
        }

        public virtual void SentTo(Hat hat, Wuwu wuwu)
        {
        }
        public virtual void SentTo(Watermelon watermelon, zz z)
        {
        }

        public virtual void Eat()
        {
        }

        public virtual void Wear()
        {
        }

    }

    public class Fruit
    {
    }
   
    public class Watermelon: Fruit
    {
    }

    public class FruitShop
    {
    }

    public class Cloth
    {
    }

    public class Hat:Cloth
    {
    }

    public class ClothShop
    {
        public Hat hat;
    }




    public class Ningning : Human
    {
       public Ningning(string _name)
        {
            Name = _name;
            Debug.Log("new ningning");
        }

        public override void Get(Watermelon watermelon)
        {
            Debug.Log(Name + " have been to fruit store to get" + watermelon);

        }

        public override void Get(Hat hat)
        {
            Debug.Log(Name + " have been to clothstore to get" + hat);

        }

        public override void SentTo(Hat hat,Wuwu wuwu)
        {
            Debug.Log(Name+" have been to clothstore to get"+hat);

        }


        public override void SentTo(Watermelon watermelon,zz zz)
        {
            Debug.Log(Name+ " sent "+ watermelon+"to "+zz);

        }



    }

    public class Wuwu : Human
    {

        public Wuwu(string _name)
        {
            Name = _name;
        }
        public virtual void Eat(Watermelon watermelon)
        {
            Debug.Log(Name+" has eaten the " + watermelon);
        }

        public virtual void Get(Watermelon watermelon)
        {
            Debug.Log(Name+ "have been to fruit store to get" + watermelon);

        }
    }

    public class zz: Human
    {
        public zz(string _name)
        {
            Name = _name;
        }
        public virtual void Wear(Hat hat)
        {
            Debug.Log(Name + " wears " + hat);
        }

        public virtual void Get(Hat hat)
        {
            Debug.Log(Name + "gets" + hat);

        }
    }

    public class SimpleFactory2
    {
        public static Human CreateHuman(string idx)
        {
            

            switch (idx)
            {
                case "Ningning":
                  
                    return new Ningning("Ningning");
                    
                case "zz":
                    
                    return new zz("zz");
                case "Wuwu":
                   
                    return new Wuwu("Wuwu");
              

                default:
                    return null;
            }
        }

        public static Fruit CreateWatermelon(string idx)
        {


            switch (idx)
            {
                case "Watermelone":
                    return new Watermelon();
      
                default:
                    return null;
            }
        }

        public static Cloth CreateCloth(string idx)
        {


            switch (idx)
            {
                case "Hat":
                    return new Hat();

                default:
                    return null;
            }
        }
    }

}
