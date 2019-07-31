using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L : MonoBehaviour
{

	/*第一题好像忘了写完...对，先去写第二大题了...
    From Naomi:
	军训回来第一次摸底考试之后，今天是选学习委员和班长的日子。班里一共20人。
    候选人一共有三人：zz数学85分，语文95，英语80分，和20个同学互换了微信成为亲密的朋友；
    wuwu数学88分，语文94分，英语82分，和13个同学互换了微信成为亲密的朋友；
    baibai数学98分，语文87分，英语90分，和5个同学互换了微信成为亲密的朋友。
	* 1.建立候选人结构体；
	* 2.写出以成绩总分最高的来选出学习委员的函数并打印学委的名字。
	* 3.写出以人缘和成绩总分来选出班长的函数并打印班长的名字。
    */
    /*
    struct Candidate
	{
		public int mathscore;
		public int chinscore;
		public int engscore;
		public int wechatnum;
		public string canname;
	}
    int Topscores(ref Candidate students)
	{
		Commissary = students.mathscore + students.chinscore + students.engscore;
		return Commissary;
	}
    int Bothtop=(ref Candidate students)
	{
		Monitor = Commissary + students.wechatnum;
		return Monitor;
	}
    //
	void Start()
    {
		Candidate first;
		first.canname = "zz";
		first.mathscore = 85;
		first.chinscore = 95;
		first.engscore = 80;
		first.wechatnum = 20;

		Candidate second;
		second.canname = "wuwu";
		second.mathscore = 88;
		second.chinscore = 94;
		second.engscore = 82;
		second.wechatnum = 13;

		Candidate third;
		third.canname = "baibai";
		third.mathscore = 98;
		third.chinscore = 87;
		third.engscore = 90;
		third.wechatnum = 5;

        
    }
    */
	/*
    From baibai:
	泰罗奥特曼 
	身高：53米
	体重：55000吨
	飞行速度：20马赫
	母亲：奥特之母
	出生地：M78星云
	现在地：仙女座星云
	
	塞文21奥特曼
	身高：56米
	体重：57000吨
	飞行速度：26马赫
	搭档：奈欧斯奥特曼
	出生地：M78星云
	现在地：M78星云
	
	* 4.定义一个奥特曼结构体，包含上述所有数据
	* 5.编写一个函数，输入参数为奥特曼结构体，打印泰罗和爱迪的速度各为多少米每秒。
	* 6.M78星云，距离地球300万光年。仙女座星云距离地球254万光年。现发现怪兽贝劳克恩第9代出现在地球。
    * 编写一个函数，输入为奥特曼结构体、星云与地球的距离，求出哪个奥特曼会先到达地球。
    */
    /*奥特曼感觉都写出来，不知道为什么没跑出来
    struct Outman
	{
		public string name;
		public int height;
		public int weight;
		public float speed;
		public string mother;
		public string partner;
		public string birthplace;
		public string currentplace;

	}
    float Outmanspeed(ref Outman manman)
	{
		return manman.speed * 340f;
	}
    void Firstoutman(ref Outman T,ref Outman S,int Td,int Sd)
	{
		float Tmanman = Td / T.speed;
		float Smanman = Sd / S.speed;

        if (Tmanman < Smanman)
		{
			Debug.Log("先到的奥特曼是：" + T.name);
		}
        else if (Smanman > Tmanman)
		{
			Debug.Log("先到的奥特曼是：" + S.name);
		}
	}
	void Start()
	{
		Outman Tai = new Outman();
		Tai.name = "泰罗";
        Tai.height = 53;
		Tai.weight = 55000;
		Tai.speed = 26;
		Tai.mother = "奥特之母";
        Tai.birthplace = "M78";
		Tai.currentplace = "仙女座星云";

		Outman Sai = new Outman();
		Sai.name = "赛文21";
        Sai.height = 56;
		Sai.weight = 57000;
		Sai.speed = 26;
		Sai.partner = "奈欧斯奥特曼";
		Sai.birthplace = "M78";
		Sai.currentplace = "M78";

		float TaiSpeed = Outmanspeed(ref Tai);
		Debug.Log("泰罗的速度是：" + TaiSpeed+"米每秒");
		float SaiSpeed = Outmanspeed(ref Sai);
		Debug.Log("赛文21的速度是：" + SaiSpeed+"米每秒");

		Firstoutman(ref Tai, ref Sai, 254, 300);
		
	}
    */
	/*
    From wupeng:
	海拉鲁平原上封印着一把上古神剑，传说中曾有四位上古英雄都在不同时间拥有过这把剑，并用它击退恶魔。
	这把神剑的神奇之处在于它会吸收主人的能力封存在剑身之中，当下一任使用者使用该剑时，只要喊出曾经英雄的名字，就可以召唤出已逝英雄的神灵来释放它的一个技能协助作战
	
	这四位上古英雄和他们的技能分别是：
	- 克里斯提娜（魔法雨 打击敌人 30伤害并减少敌人10的速度），
	- 卡罗兰约克（精准砍劈 以打击敌人50伤害，并提高自己的防御的2倍），
	- 卡尔斯鲁厄  (献祭：自损60生命值，提高自身战斗力100)，
	- 哥德史密斯（面壁：防御值增加3倍）
	* 7.如今林克得到了这把剑，他拿着这把剑来到了被恶魔缠绕的城堡门口，面对恶魔它大喊一声：“卡尔斯鲁厄”！如果林克的属性为:生命100, 攻击60, 防御40.请问他此时的属性是多少。请设计相应的数据结构并计算输出。
	
	这把剑还有一个特殊之处在于，林克只要喊出“英雄的名字” + “附身”这样的咒语，上古英雄的属性便会突然加到林克身上。假设
	- 克里斯提娜的属性生命60, 攻击100 防御 70;
	- 卡罗兰约克的属性为生命150，攻击60， 防御120；
	- 卡尔斯鲁厄的属性为 生命150，攻击90， 防御40；
	- 哥德史密斯 属性  生命70，攻击70， 防御150.
	* 8.如果这时林克大喊一身“克里斯提娜附身！”，请问这时林克的属性为多少？ 请设计或修改数据结构，并设计附身技能函数，打印并输出结果。  
	
	在于恶魔对战的过程中，林克受到了重伤，在林克弥留之际，他将上古神剑交给了呀哈哈。将自己的魂魄注入神剑，与上古英雄们重聚，成为他们的一员。如今呀哈哈拿到了神剑，但是呀哈哈对上古神剑生命的不感冒，把他丢在了角落里。
	神剑生锈了，每一年都会流逝上古英雄的能量，假设每一年上古神剑中所有英雄的属性都会流逝10%。
	* 9.请问10年后，当呀哈哈喊出“林克附身”这句话时，请打印呀哈哈的属性。假设呀哈哈的当前属性为生命30，攻击1， 防御5.
    */
    struct Hero
	{
		public string skillname;
		public int skilldamage;
		public int skilldefense;
        public int skilllife；
	}
    struct Owner
	{
		public int life;
		public int attack;
		public int defense;
	}
    //void Karls(ref Owner linka,ref Skill c)恰巧第三个英雄的属性变更部分跟下一题一样，就直接用下一题的函数了

	void Yell（ref Owner linka, ref Hero c)
	{
		int afterlife = linka.life + c.skilllife;
		int afterdamage = linka.attack + c.skilldamage;
		int afterdefense = linka.defense + c.skilldefense;
	}

	//突然发现对题目理解完全错误...
	/*
     void Together(ref Owner Yahaha, ref Owner link, ref Hero hero1, ref Hero hero2, ref Hero hero3, ref Hero hero4)
	{
        //wuwu反复提醒，这里不要忘记开头添加数据类型！
		int Yahahafinallife = Yahaha.life + link.life + hero1.skilllife + hero2.skilllife + hero3.skilllife + hero4.skilllife;
		int Yahahafinalattack = Yahaha.attack + link.attack + hero1.skilldamage + hero2.skilldamage + hero3.skilldamage + hero4.skilldamage;
		int Yahahafinaldefense = Yahaha.defense + link.defense + hero1.skilldefense + hero2.skilldefense + hero3.skilldefense + hero4.skilldefense;
	}
    */
    //临时改动，来不及思考细致...十分尴尬
	void Propertydecline(ref Owner link, ref Hero hero)
	{
		float Ownerfinallife = link.life * 0.9f;//递归？emm该怎么写下去表示10年递减。好像这个表达思路不太科学...
		float Ownerfinaldamage = link.attack * 0.9;
		float Ownerfinaldefense = link.defense * 0.9;

		float Herofinallife = hero.skilllife * 0.9;
		float Herofinaldamage = hero.skilldamage * 0.9;
		float Herofinaldefense = hero.skilldefense * 0.9;
	}
	
	void start()
	{
       
		Hero karls = new Hero();
		karls.skilldamage = 100;
		karls.skilllife = -60;

		Owner link = new Owner();
		link.life = 100;
		link.attack = 60;
		link.defense = 40;

		Owner Yahaha = new Owner();
		Yahaha.life = 30;
		Yahaha.attack = 1;
		Yahaha.defense = 5;

		//实例化旧版..写了很多，好像没必要
		Hero a = new Hero();
		a.skilllife = 60;
		a.skilldamage = 100;
		a.skilldefense = 70;

		Hero b = new Hero();
		b.skilllife = 150;
		b.skilldamage = 60;
		b.skilldefense = 120;

		Hero c = new Hero();
		c.skilllife = 150;
		c.skilldamage = 90;
		c.skilldefense = 40;

		Hero d = new Hero();
		d.skilllife = 70;
		d.skilldamage = 70;
		d.skilldefense = 40;

		int linkafterlife = Yell(ref link);
	}

	void Update()
    {
        
    }
}
