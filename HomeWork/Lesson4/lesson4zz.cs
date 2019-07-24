using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lesson4zz : MonoBehaviour
{
	//大神的题目写的好好啊。。。沉迷故事，但是题目，全盘彻底崩溃。。。
	// Start is called before the first frame update
	//第一题
	/*
	struct SchoolInfo
	{
		public int topclassboys;
		public int topclassgirls;
		public int middleclassboys;
		public int middleclassgirls;
		public int younclassboys;
		public int younclassgirls;
	}
    */
	//第二题
	//好像不对，真的不对
	/*
	 void kids(SchoolInfo boys)
	 {
		 Debug.Log(boys.younclassboys)
	 }

	 void kids(SchoolInfo girls)
	 {
		 Debug.Log(girls.younclassgirls)
	 }

	 */
	//小班男生=男生总数-大班男生-中班男生
	//小班女生=女生总数-大班女生-中班女生3

	//总数都已知，大班男女生勉强已知，中班男女生需要计算
	//中班男生=36-（中班男生-4）
	/*
	void Start()
    {
	    int tboys = 15;
	    int mboys = 36 - (mboys - 4);
	    int tgirls = 15;
	    int mgirls = 36 - mboys;

	    int younboys = Kidsnum(60, 15, mboys);
	    int youngirls = Kidsnum(48, 15, mgirls);

	Debug.Log(younboys, youngirls);

    }
    */
	//已经不知道自己在写什么了。。。

	//第三题
	struct TraInfo
	{
		public int WbookTopcost;
		public int WbookMiddlecost;
		public int Wbookyouncost;
		public int Bbookcost;
	}
    void int badteacher( )
	{

	}

	//第四题
	struct WeaponInfo
	{
        public int redsword；
        public int blueshield；
	}
    
	// Update is called once per frame
	void Update()
    {
        
    }
}
