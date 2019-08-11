        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
        using UnityEngine.UI;

        public class wilbert : MonoBehaviour
        {
            public Image baipingI;
            public Image dasheI;
            public Image huolieniaoI;
            public Image xiaohuobanI;
            public Image jiutongI;
            public Image yunjianI;
            public Image zzI;
            public Image jinshukuaiI;
            public Image duyeI;
            public Image huoyanI;
            public Text huolieniaoHP;
            public Text dasheHP;
            public Text xiaohuobanWA;
            public Text huolieniaoATC;
            public Text dasheATC;
            public int panduan = 1;
            public struct character
            {
                public string NAME;
                public float HP;
                public float ATC;
                public float BAOJI;
                public character(string name, float hp, float atc, float baoji)
                {
                    NAME = name;
                    HP = hp;
                    ATC = atc;
                    BAOJI = baoji;
                }
            }
            character dashe = new character("dashe", 1000f, 10f, 2f);
            character huolieniao = new character("huolieniao", 1200f, 15f, 3f);
            public void initiate_game()
            {
                    baipingI.color=new Color(1,1,1,0f);
                    jinshukuaiI.color = new Color(1,1,1,0f);
                    duyeI.color = new Color(1,1,1,0f);
                    huoyanI.color = new Color(1,1,1,0f);
                    float num = huolieniao.HP;
                    xiaohuobanWA.text=" ";
                    huolieniaoHP.text="HP: "+num.ToString();
                    num = dashe.HP;
                    dasheHP.text="HP: "+num.ToString();    
            }
                enum attack_event
            {
                initiate_attack,
                houlieniao_attack, 
                dashe_attack,
                zz_attack_fadein,
                zz_attack_keep,
                zz_attack_fadeout,
                end_attack,
            }
            attack_event current_event = attack_event.initiate_attack;
            public float current_time = 0.0f;
            public float elapsedTime1 = 0.0f;
            public float elapsedTime2 = 0.0f;
            public void dashe_hulieniao_attack()
            {
                switch(current_event)
                {
                    case attack_event.initiate_attack:////
                    {
                        current_time+=Time.deltaTime;
                        initiate_game();
                        current_event =  attack_event.houlieniao_attack;
                        current_time=0f;
                    }
                    break;
                    case attack_event.houlieniao_attack:////
                    {
                        current_time+=Time.deltaTime;
                    if(current_time>1.0f)
                        {
                        huoniao_attack_dashe();
                        current_event =  attack_event.dashe_attack;

                        current_time=0f;
                        }
                    }
                    break;
                    case attack_event.dashe_attack:////
                    {
                        current_time+=Time.deltaTime;
                    if(current_time>1.0f)
                        {
                        dashe_attack_huolieniao();
                        current_event =  attack_event.houlieniao_attack;
                        if(huolieniao.HP<1150)
                        {
                            current_event =  attack_event.zz_attack_fadein;
                            GameObject.Find("yunjian").transform.position  = new Vector3(291f, 182f, 0.0f);
                        }
                        current_time=0f;
                        }
                    }
                    break; 
                    case attack_event.zz_attack_fadein:////
                    {
                            xiaohuobanWA.text="哇！！！！！！";
                            Color c = baipingI.color;
                            if(current_time < 2.0f)
                        {
                            current_time += Time.deltaTime ;
                            c.a = Mathf.Clamp01(current_time/2.0f);
                            baipingI.color = new Color(1,1,1,c.a);
                        }
                        else
                        {
                            current_event =  attack_event.zz_attack_keep;
                            huolieniaoI.color=new Color(1,1,1,0f);
                            dasheI.color=new Color(1,1,1,0f);
                            duyeI.color = new Color(1,1,1,0f);
                            huoyanI.color = new Color(1,1,1,0f);
                            huolieniaoHP.color = new Color(1,1,1,0f);
                            dasheHP.color = new Color(1,1,1,0f);
                            xiaohuobanWA.color = new Color(1,1,1,0f);
                            huolieniaoATC.color = new Color(1,1,1,0f);
                            dasheATC.color = new Color(1,1,1,0f);
                            yunjianI.color = new Color(1,1,1,0f);
                            current_time=0f;
                        }       
                    }
                    break; 
                    case attack_event.zz_attack_keep:////
                    {
                        current_time += Time.deltaTime ;
                            if(current_time > 3.0f)
                        {
                            current_event =  attack_event.zz_attack_fadeout;
                            current_time=0f;
                        }       
                    }
                    break; 
                    case attack_event.zz_attack_fadeout:////
                    {
                            Color c = baipingI.color;
                            if(current_time < 2.0f)
                        {
                            current_time += Time.deltaTime ;
                            c.a = 1.0f - Mathf.Clamp01(current_time/2.0f);
                            baipingI.color = new Color(1,1,1,c.a);
                        }
                        else
                        {
                            current_event =  attack_event.end_attack;
                            current_time=0f;
                        }       
                    }
                    break; 
                    case attack_event.end_attack:////
                    {
                        jinshukuaiI.color=new Color(1,1,1,1f);
                        Color c = jinshukuaiI.color;
                        if(elapsedTime1 < 1.0f && panduan==1)
                        {
                            elapsedTime1 += Time.deltaTime ;
                            c.a = 1.0f - Mathf.Clamp01(elapsedTime1/2.0f);
                            jinshukuaiI.color = new Color(1,1,1,c.a);
                            //Debug.Log("1");
                        }
                        else
                        {
                            elapsedTime1=0f;
                            panduan=0;
                        }
                        if(elapsedTime2 < 1.0f && panduan==0)
                        {
                            elapsedTime2 += Time.deltaTime ;
                            c.a = Mathf.Clamp01(elapsedTime2/2.0f);
                            jinshukuaiI.color = new Color(1,1,1,c.a);
                            //Debug.Log("2");
                        }
                        else
                        {
                            elapsedTime2=0f;
                            panduan=1;
                        }
                    }
                    break; 
                }
            }

        public void huoniao_attack_dashe()
            {
                huolieniaoATC.text = " ";
                duyeI.color = new Color(1,1,1,0f);
                if(Random.Range(0,100)<=30)
                {
                    dashe.HP-= huolieniao.ATC*huolieniao.BAOJI; 
                    dasheATC.text = "受到"+ huolieniao.ATC*huolieniao.BAOJI+"伤害";
                }
                else
                {
                    dashe.HP-= huolieniao.ATC;
                    dasheATC.text = "受到"+ huolieniao.ATC+"伤害";
                }
                huoyanI.color = new Color(1,1,1,1f);
                huolieniaoHP.text="HP: "+ huolieniao.HP;
            }
            
        public void dashe_attack_huolieniao()
            {
                dasheATC.text = " ";
                huoyanI.color = new Color(1,1,1,0f);
                if(Random.Range(0,100)<=50)
                {
                    huolieniao.HP-= dashe.ATC*dashe.BAOJI;
                    huolieniaoATC.text = "受到"+ dashe.ATC*dashe.BAOJI+"伤害";
                }
                else
                {
                    huolieniao.HP-= dashe.ATC;
                    huolieniaoATC.text = "受到"+ dashe.ATC+"伤害";

                }
                duyeI.color = new Color(1,1,1,1f);
                dasheHP.text="HP: "+ dashe.HP;
            }
            // Start is called before the first frame update
            void Start()
            {
            }
            // Update is called once per frame
            void Update()
            {
                dashe_hulieniao_attack();
            }
        }   




    
        
