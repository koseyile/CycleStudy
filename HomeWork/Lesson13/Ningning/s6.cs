using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s6 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        Baibai baibai= new Baibai();
        Animation animation_cycle=new Animation();
        Friends a = new Friends();
        Friends b = new Friends();
        Friends c = new Friends();
        Friends d = new Friends();
        Friends e = new Friends();
        Dalao dalao = new Dalao();

        baibai.assignthemission(a, ani_factory.Create_section("story"));
        baibai.assignthemission(b, ani_factory.Create_section("cast"));
        baibai.assignthemission(c, ani_factory.Create_section("scene"));
        baibai.assignthemission(d, ani_factory.Create_section("dubbing"));
        baibai.assignthemission(e, ani_factory.Create_section("music"));

        baibai.invite(dalao);
        dalao.watch(animation_cycle);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public class Ani_Section
    {

    }

    public class Story : Ani_Section
    {

    }

    public class Cast : Ani_Section
    {

    }

    public class Scene : Ani_Section
    {

    }

    public class Dubbing : Ani_Section
    {

    }

    public class Music : Ani_Section
    {

    }

    abstract class Developer
    {
        public abstract void workon(Ani_Section d);
    }
    abstract class Director
    {
        public abstract void assignthemission(Developer a,Ani_Section b);
        public abstract void invite( Dalao b);
    }

    abstract class Audience
    {
        public abstract void watch(Animation animation);
    }

    class Baibai : Director
    {
        
        
        public override void assignthemission(Developer a, Ani_Section b)
        {
            Debug.Log(a + "have to finish part" + b);
        }


        public override void invite(Dalao b)
        {
            Debug.Log("baibai invite"  +b+ "watch the animation");

        }

    }

    class Friends : Developer
    {
        public override void workon(Ani_Section d)
        {
            Debug.Log("do the part of " + d);
        }
    }

    class Dalao : Audience
    {
        public override void watch(Animation animation)
        {
            Debug.Log("Daolao watch"+animation);

        }
    }

    class Animation
    {
        private Story story;
        private Cast cast;
        private Scene scene;
        private Dubbing dubbing;
        private Music music;
      
        public Animation()
        {
            Debug.Log("made by cycle");
        }

    }

    public class ani_factory
    {
        public static Ani_Section Create_section(string idx)
        {
            switch(idx)
            {
                case "story":
                  
                    return new Story();
                    
                case "cast":
                    
                    return new Cast();
                case "scene":
                   
                    return new Scene();

                case "dubbing":

                    return new Dubbing();

                case "music":

                    return new Music();


                default:
                    return null;
            }
        }
    }



}
