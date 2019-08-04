using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WuwuLesson6 : MonoBehaviour
{
	//结构体部分
	struct Wupeng
	{
		public string Name;
		public int Energy;
		public int Attack;
		public float currentTime;

	}

	struct Doudou
	{
		public string Name;
		public int Life;
		public float currentTime;
	}

	//4.Zz是一名豆豆爱好者，有如下属性，名字叫zz，治疗力为回复5生命值 / 秒。声明一个zz结构体
	struct Zz
	{
		public string Name;
		public int CureLife;
		public float currentTime;
	}

	//6.Wuwu是一名啦啦队爱好者，有如下属性，名字叫wuwu，治疗加成为1 
	struct Wuwu
	{
		public string Name;
		public int Cureplus;
		public float currentTime;
	}

	//7.Mengmeng是鼓手，名字叫mengmeng，攻击力加成为1 
	struct Mengmeng
	{
		public string Name;
		public int AddAttack;
		public int drumcounts;
		public float currentTime;
	}

	//实例化部分
	Wupeng wupeng = new Wupeng();
	Doudou doudou = new Doudou();
	Zz zz = new Zz();
	Wuwu wuwu = new Wuwu();
	Mengmeng mengmeng = new Mengmeng();

	void Question1to7()
	{

		//1-7的实例化部分
		wupeng.Name = "wupeng";
		wupeng.Energy = 0;
		wupeng.Attack = 8;
		wupeng.currentTime = 0.0f;

		doudou.Name = "doudou";
		doudou.Life = 1000;
		doudou.currentTime = 0.0f;

		zz.Name = "zz";
		zz.CureLife = 5;
		zz.currentTime = 0.0f;

		wuwu.Name = "wuwu";
		wuwu.Cureplus = 1;
		wuwu.currentTime = 0.0f;

		mengmeng.Name = "mengmeng";
		mengmeng.AddAttack = 1;
		mengmeng.drumcounts = 4;
		mengmeng.currentTime = 0.0f;


	}


	// Start is called before the first frame update
	void Start()
	{
		Question1to7();
        
    }

	enum WupengState
	{
		WupengState_Eating,
		WupengState_Sleeping,
		WupengState_Hitting,
	}

	enum ZzState
	{
		ZzState_prepare,
		ZzState_healing,
		ZzState_remove,
	}

	enum WuwuState
	{
		WuwuState_plushealing,
		WuwuState_finishhealing,
	}


	enum LightState
	{
		LightState_red,
		LightState_green,
		LightState_yellow,
	}

	enum RocketState
	{
		RocketState_counting,
		RocketState_firing,
		RocketState_flying,
	}


	//初始化值部分
	WupengState currentWupengState = WupengState.WupengState_Eating;
	ZzState currentZzState = ZzState.ZzState_prepare;
	

	LightState currentLightState = LightState.LightState_red;
	public Image redlight;
	public Image greenlight;
	public Image yellowlight;


	RocketState currentRocketState = RocketState.RocketState_counting;
	public Image Rocket;
    
    


    void PrintQuestion1to7()
	{


		switch (currentWupengState)

		{

			case WupengState.WupengState_Eating:
				{
					wupeng.Energy = 0;
					wupeng.currentTime += Time.deltaTime;
					//在wupeng不睡觉的时候敲鼓，mengmeng每秒钟可敲4下鼓，
					//当敲第偶数下鼓的时候，能让wupeng的攻击力加成，加成效果在wupeng睡觉的时候消失。将mengmeng的功能嵌入第3题的状态机中。
					mengmeng.currentTime += Time.deltaTime;
					int countSecondsofMengmeng = 0;
					if (mengmeng.currentTime > 0.0f)
					{
						countSecondsofMengmeng++;
						if (countSecondsofMengmeng % 2 == 0)
						{
							wupeng.Attack += mengmeng.AddAttack;
						}

					}


					if (wupeng.currentTime > 3.0f)
					{
						currentWupengState = WupengState.WupengState_Hitting;
						wupeng.currentTime = 0.0f;
						Debug.Log("Wupeng begin to hit doudou");
					}

				}
				break;
			case WupengState.WupengState_Hitting:
				{

					wupeng.Energy = 100 + 2 * mengmeng.AddAttack;//前面状态机里的加成要怎么加在第二个状态机的初始值里呢?我用自己算的加上了
					doudou.Life = 1000;
					//mengmeng在这里加成攻击
					mengmeng.currentTime += Time.deltaTime;
					int countSecondsofMengmeng = 0;
					if (mengmeng.currentTime > 0.0f)
					{
						countSecondsofMengmeng++;
						if (countSecondsofMengmeng % 2 == 0)
						{
							wupeng.Attack += mengmeng.AddAttack;
						}

					}

					int countSecondsofwupeng = 0;
					if (wupeng.currentTime > 3.0f && wupeng.Energy > 0 && doudou.Life > 0)
					{
						countSecondsofwupeng++;
						doudou.Life -= wupeng.Attack * countSecondsofwupeng;
						wupeng.Energy -= 10 * countSecondsofwupeng;
					}

					if (wupeng.Energy <= 0)
					{
						currentWupengState = WupengState.WupengState_Sleeping;
						wupeng.currentTime = 0.0f;
						Debug.Log("Wupeng begin to sleep");
					}

				}
				break;

			case WupengState.WupengState_Sleeping:
				//5.Zz会在wupeng睡觉的时候为豆豆补充生命，zz为豆豆补充血量时的过程是这样的：
				//准备医疗工具1秒，为豆豆补血2秒，拆除医疗工具1秒。
				//请使用状态机实现此过程（将代码嵌入第3题的状态机中）
				{
					switch (currentZzState)
					//在zz准备工具和治疗的时候为zz加油，wuwu每秒钟能喊出3次加油，每次都能让zz回复能力加成
					//加成效果在zz治疗结束后消失 。将wuwu的功能嵌入第3题的状态机中。
					{
						case ZzState.ZzState_prepare:
							{

								zz.currentTime += Time.deltaTime;
								if (zz.currentTime > 1.0f)
								{
									currentZzState = ZzState.ZzState_healing;
									zz.currentTime = 0.0f;
									Debug.Log("zz is adding blood");
								}
							}
							break;
						case ZzState.ZzState_healing:
							{
								zz.currentTime += Time.deltaTime;
								int counssecondsofZZ = 0;
								if (zz.currentTime > 0.0f)
								{
									counssecondsofZZ++;
									doudou.Life += (3 * wuwu.Cureplus + zz.CureLife) * counssecondsofZZ;
								}

								if (zz.currentTime > 2.0f)
								{

									currentZzState = ZzState.ZzState_remove;
									zz.currentTime = 0.0f;
									Debug.Log("zz is removing tools");

								}
							}
							break;
						case ZzState.ZzState_remove:
							{
								if (zz.currentTime > 1.0f)
								{
									currentZzState = ZzState.ZzState_prepare;
									zz.currentTime = 0.0f;
									Debug.Log("zz is preparing");
								}
							}
							break;
					}


					if (wupeng.currentTime > 5.0f)
					{
						currentWupengState = WupengState.WupengState_Eating;
						Debug.Log("Wupeng begin to eat");
					}


				}

				break;
		}
	}


    float currentTime = 0.0f;


    //交通灯函数
    void PrintCurrentLight()
	{

		


		switch (currentLightState)
		{
			case LightState.LightState_red:
				{
					currentTime += Time.deltaTime;
					if (currentTime > 2.0f)
					{
						currentLightState = LightState.LightState_yellow;
						currentTime = 0.0f;
						yellowlight.color = Color.yellow;
						redlight.color = Color.black;
						greenlight.color = Color.black;

						Debug.Log("red to yellow");
					}


				}
				break;

			case LightState.LightState_yellow:
				{
					currentTime += Time.deltaTime;
					if (currentTime > 2.0f)
					{
						currentLightState = LightState.LightState_green;
						yellowlight.color = Color.black;
						redlight.color = Color.black;
						greenlight.color = Color.green;
						currentTime = 0.0f;
						Debug.Log("yellow to green");
					}
				}
				break;
			case LightState.LightState_green:
				{

					if (currentTime > 2.0f)
					{
						currentLightState = LightState.LightState_red;
						yellowlight.color = Color.black;
						redlight.color = Color.red;
						greenlight.color = Color.black;
						currentTime = 0.0f;
						Debug.Log("green to red");
					}
				}
				break;

		}

	}


	//9.每隔三秒打印当前经过的时间，使用如下格式“年：月：日：小时：分钟：秒”
	void PrintoverTime()
	{

		
		currentTime += Time.deltaTime;
		int countSeconds = 0;

		int year, month, date, hour, minute, second;

		if (currentTime > 1.0f)
		{
			countSeconds++;
			second = countSeconds % 60;
			minute = second % 60;
			hour = minute % 60;
			date = hour % 60;
			month = date % 30;
			year = month % 365;
			if (countSeconds % 3 == 0)
			{
				Debug.Log("年：" + year + "月：" + month + "日：" + date + "小时:" + hour + "分钟：" + minute + "秒:" + second);
			}
		}
	}

	void PrintRocket()
	{
        currentTime += Time.deltaTime;
        int countNumber = 0;
        int countSeconds = 0;
        int speed = 5;
        switch (currentRocketState)
		{
			case RocketState.RocketState_counting:
				{

					currentTime += Time.deltaTime;
					if (currentTime >= 1.0f && countNumber > 0)
					{
						countNumber--;
						Debug.Log(countNumber);
						if (currentTime > 10.0f)
						{
							currentRocketState = RocketState.RocketState_firing;
							currentTime = 0.0f;
						}
					}
				}
				break;
			case RocketState.RocketState_firing:
				{
					currentTime += Time.deltaTime;
					if (currentTime > 2.0f)
					{
						currentRocketState = RocketState.RocketState_flying;
						currentTime = 0.0f;
                        Debug.Log("火箭点火");

                    }

				}
				break;
			case RocketState.RocketState_flying:
				{
                    Debug.Log("火箭升空");
                    currentTime += Time.deltaTime;
                    if (currentTime > 0)
                    {
                        countSeconds++; 
                        Rocket.GetComponent<RectTransform>().anchoredPosition = new Vector3(100.0f, 1.0f + speed * countSeconds, 1.0f);
                    }

                }
				break;
		}
	}




	// Update is called once per frame
	void Update()
	{

		PrintQuestion1to7();

		PrintCurrentLight();

		PrintoverTime();

		PrintRocket();

	}
}
