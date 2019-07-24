using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
// 1———————————
  string jj;
        string ii = "1";
        for (int n = 1; n <= 100; n++)
        {
            jj = n.ToString();
            if (jj != ii)
            {
                ii = ii + jj;
            }
        }
        Debug.Log(ii);


// 2———————————
        string ii;
        string jj = " ";
        for (int n = 1; n <= 100; n++)
        {
            ii = n.ToString();
            jj = jj + ii;
            if (n % 3 == 0)
            {
                jj = jj + "\n";
            }
        }
        Debug.Log(jj);
    }

//3 —————————————
string[] alph = new string[27];
    string ii = " ";
    int n = 1;
        for (char i = 'a'; i <= 'z'; i++)
        {
            ii = i.ToString();
            alph[n] = ii;
            n = n + 1; 
        }
int[] index = { 13, 24, 12, 7, 9, 10, 6 };
int jj;
        for (int i = 0; i<index.Length; i++)
        {
            jj = index[i];
            Debug.Log(alph[jj]);
        }

// 4—————————————
string ii;
string temp;
int Gewei;
int Shiwei;
int Baiwei;
int count;
int num;
int jj;
        for (int i = 1; i <= 1000; i++)
        {
            ii = i.ToString();
            jj = ii.Length;
            count = 0;

            if (jj == 1)
            {
                num = 1;
                count = jj - num;
                temp = ii.Substring(count, 1);
                Gewei = int.Parse(temp);
Shiwei = 0;
                Baiwei = 0;
            }
            else if (jj == 2)
            {
                num = 1;
                count = jj - num;
                temp = ii.Substring(count, 1);
                Gewei = int.Parse(temp);

num = 2;
                count = jj - num;
                temp = ii.Substring(count, 1);
                Shiwei = int.Parse(temp);
Baiwei = 0;
            }
            else
            {
                num = 1;
                count = jj - num;
                temp = ii.Substring(count, 1);
                Gewei = int.Parse(temp);

num = 2;
                count = jj - num;
                temp = ii.Substring(count, 1);
                Shiwei = int.Parse(temp);

num = 3;
                count = jj - num;
                temp = ii.Substring(count, 1);
                Baiwei = int.Parse(temp);
            }

            int a = Gewei + Shiwei;
int b = Shiwei * Baiwei;
int c = Baiwei * Gewei;

            if (a==9 && b%2 == 0 && b!=0 && c%2 !=0)
            {
                Debug.Log(i);                
            }
        }

// 5—————————————
string[] jj = new string[5];
string ii = "";
string temp = "";


        for (int n = 0; n <= 4; n++)
        {
            ii = ii + "*";
            jj[n] = ii;
        }

        foreach (string a in jj)
        {
            temp = temp + (a + "\n");
        }
        Debug.Log(temp);

//6 —————————————
string[] jj = new string[4];
string ii = "#####";
string temp = "";
int m
        for (int n = 0; n <= 3; n++)
        {
            m = 4 - n;
            ii = ii.Remove(m, 1).Insert(m, "$");
jj[n] = ii;
        }

        foreach (string a in jj)
        {
            temp = temp + (a + "\n");
        }
        Debug.Log(temp);

//7 —————————————
int value = 0;
int[] array = { 3, 8, 9, 7 };
        for (int i = 0; i< 4; i++)
        {
            for (int j = 0; j< 4; j++)
            {
                if (j == i)
                    continue;

                for (int k = 0; k< 4; k++)
                {
                    if (k == j || k == i)
                        continue;
                    for (int h = 0; h< 4; h++)
                    {
                        if (h == k || h == j || h == i)
                            continue;
                        string print = (array[i] + " " + array[j] + " " + array[k] + " " + array[h]);
Debug.Log(print);
                        value++;
                    }
                }
            }

// 8—————————————
float[] jj = new float[101];
        for (int n = 1; n <= 100 ; n++)
        {
            if (n == 1)
            {
                float temp = 2;
jj[n] = temp;
                Debug.Log(jj[n]);
            }
            else if(n>1 && n<=100)
            {
                float temp = System.Math.Abs(jj[n - 1] * 3);
jj[n] = temp;
                Debug.Log(jj[n]);
            }
            else
            {
                Debug.Log(jj[100]);
                break;
            }
        }

//9 —————————————
int num = 9;
        switch (num)
        {
            case 0:
                Debug.Log("Red");
                break;
            case 1:
                Debug.Log("Green");
                break;
            default:
                Debug.Log("Blue");
                break;
        }

//10 —————————————
string[] jj = new string[10];
        string nn = "";
        string mm = "";
        string temp = "";
        int res;
        string nm = "";
        string final = "";
        string biao = "";

        for (int n = 1; n <= 9; n++)
        {
            for (int m = 1; m <= n; m++)
            {
                nn = n.ToString();
                mm = m.ToString();
                res = m * n;
                nm = res.ToString();
                temp = mm + "X" + nn + "=" + nm +" ";
                final = final + temp;
            }
            jj[n] = final;
            final = "";
        }

        foreach (string a in jj)
        {
           biao = biao + (a + "\n");
        }
        Debug.Log(biao);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


