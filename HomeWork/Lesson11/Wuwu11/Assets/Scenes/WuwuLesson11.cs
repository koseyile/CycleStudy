using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace wuwu
{


	//一个也没跑出来，越写越不知道自己在写什么，脚本分别写了以后怎么挂脚本啊什么的，完全不知道诶。。。好晕。。。更别提要写manager那种了

	public class Card
	{
		private GameObject cardobj;
		private float m_speed;
		private float rotateTimer;

		private Vector3 x_dir;
		private Quaternion m_rotate;

		public Card()
		{

		}

		public enum CardState
		{
			Front,
			Back
		}

		public CardState mCardState = CardState.Front;


		public Card(GameObject _prefab, Vector3 _position, Quaternion _rotate)
		{
			m_speed = 50.0f;
			rotateTimer = 2.0f;
			x_dir = new Vector3(-1, 0, 0);
			m_rotate = _rotate;
			cardobj = GameObject.Instantiate(_prefab, _position, _rotate);
			mCardState = CardState.Front;
		}

		//3. 编写一个class A，输入为上述prefab和旋转速度，编写一个卡片绕X轴旋转的动画函数
		public void Cardrotate(GameObject cardobj, float m_speed)
		{
			switch (mCardState)
			{
				case CardState.Front:
					{
						m_speed = 50.0f;
						rotateTimer = 2.0f;
						//想写进状态机，但旋转的时候，rotate的vector3是个什么范围菜是正面 和反面，不知道怎么对应起来写
						cardobj.transform.Rotate(new Vector3(Time.deltaTime * m_speed, 0, 0));
						cardobj.transform.rotation = Quaternion.identity;
						mCardState = CardState.Back;
					}
					break;
				case CardState.Back:
					{
					}
					break;
			}
		}
		public float begintime = 0.0f;
		public void Begin(GameObject cardobj)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				begintime += Time.deltaTime;

			}
		}

	}




	//6. 编写一个class B继承自A，请自由发挥，为class B赋予这样的功能：每旋转一次，卡片的文本会变化。
	public class CardB : Card
	{
		public CardB(GameObject _prefab, Vector3 _position, Quaternion _rotate) : base(_prefab, _position, _rotate)
		{

		}
		public CardB()
		{

		}
	}
	//8. 编写一个class C继承自A，请自由发挥，为class B赋予这样的功能：每旋转一次，卡片的文本会自加一次。（假设文本只能显示数字和字母）
	public class CardC : Card
	{
		public CardC(GameObject _prefab, Vector3 _position, Quaternion _rotate) : base(_prefab, _position, _rotate)
		{

		}
		public CardC()
		{

		}
	}

	public class WuwuLesson11 : MonoBehaviour
	{

		public GameObject cardPrefab;
		private Card maincard;

		public Text hourten;
		public Text hourone;
		public Text minuteten;
		public Text minuteone;
		public Text secondten;
		public Text secondone;

		public Button clicktest;

		//不知道怎么把鼠标和button的click对应起来，unity里的click拖进这个脚本 不知道怎么写。
		public void ClickBegin(GameObject cardPrefab, Button clicktest)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				maincard.Begin(cardPrefab);
			}
		}
		//
		private int hour;
		private int minute;
		private int second;

		// Start is called before the first frame update
		void Start()
		{

			maincard = new Card(cardPrefab, new Vector3(0, 0, 0), Quaternion.Euler(90, 0, 0));
			//7. 实例化8个B，分别代表小时，分钟，秒，毫秒（为方便制作，我们定义1秒=60毫秒）。
			//实现计时功能，毫秒卡片在飞速旋转变化，秒卡片每隔一秒旋转变化，分钟卡片每隔一分钟旋转变化，小时卡片每隔一小时旋转变化。
			CardB[] Timecards = new CardB[8];
			for (int i = 0; i < 8; i++)
			{
				Timecards[i] = new CardB();
			}

			maincard.begintime += Time.deltaTime;

			hour = (int)maincard.begintime / 3600;
			minute = ((int)maincard.begintime - hour * 3600) / 60;
			second = (int)maincard.begintime - hour * 3600 - minute * 60;

			int hour10 = (int)hour / 10;
			int hour1 = (int)hour % 10;

			int minute10 = (int)minute / 10;
			int minute1 = (int)minute % 10;

			int second10 = (int)second / 10;
			int second1 = (int)second % 10;

			hourten.text = hour10.ToString();
			hourone.text = hour1.ToString();
			minuteten.text = minute10.ToString();
			minuteone.text = minute1.ToString();
			secondten.text = second10.ToString();
			secondone.text = second1.ToString();
		}

		// Update is called once per frame
		void Update()
		{
			ClickBegin(cardPrefab, clicktest);

		}

	}

}

