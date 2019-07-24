1———————————

    float SQU(float r)
    {
        return r * r * Mathf.PI;   
    }

    void Start()
    { 
        float n = 76.3f;
        float c = SQU(n);
        Debug.Log(c);
    }

2———————————

    float SQU(float[] ckg)
    {
        return ckg[0] * ckg[1] * ckg[2];   
    }

    void Start()
    { 
        float[] n = {43.2f, 54.5f, 123.9f};
        float c = SQU(n);
        Debug.Log(c);
    }
       
3—————————————
  int SQU(int a, int b)
    {
        return a+b;   
    }

    void Start()
    {

        int sum1 = 0;
        for (int n = 1; n <= 100; n++)
        {
            if (n%2!=0)
            {
                sum1 = sum1 + SQU(n, n + 1);
            }
        }
         Debug.Log(sum1);

        int sum2 = 0;
        for (int n = 4; n <= 999; n++)
        {
            if (n % 2 == 0)
            {
                sum2 = sum2 + SQU(n, n + 1);
            }
        }
        Debug.Log(sum2);
    }

4—————————————
    float SQU(float a)
    { 
        return a* 0.06f; //1JPY = 0.06CNY；
    }

    void Start()
    {
        float JPY = 1000f;
        float CNY = SQU(JPY);
        Debug.Log(CNY);
    }
5—————————————
    float SQU(float a)
    { 
        return a* 0.15f; //1CNY = 0.15USD；
    }

    void Start()
    {
        float CNY = 7000f;
        float USD = SQU(CNY);
        Debug.Log(USD);
    }
   
6—————————————

    void invertColor(Color a, Color b, ref Color c)
    {
        c.r = a.r + b.r;
        c.g = a.g + b.g;
        c.b = a.b + b.b;
    }


    void Start()
    {

        Color aa = new Color(12, 5, 2);
        Color bb = new Color(123, 42, 14);
        Color cc = new Color(0, 0, 0);
        invertColor(aa, bb, ref cc);

        Debug.Log(cc.r);
        Debug.Log(cc.g);
        Debug.Log(cc.b);
    }
       

7—————————————
          
 void invertColor(Color rgb, ref Color inv)
    {
        int RGBMAX = 255;
        inv.r = RGBMAX - rgb.r;
        inv.g = RGBMAX - rgb.g;
        inv.b = RGBMAX - rgb.b;
    }


    void Start()
    {

        Color newColor = new Color(12, 5, 2);
        Color invColor = new Color(0, 0, 0);
        invertColor(newColor, ref invColor);

        Debug.Log(invColor.r);
        Debug.Log(invColor.g);
        Debug.Log(invColor.b);
    }
8—————————————
    void count(int a)
    {
        for(int n=1; n<=a;n++)
        {
            Debug.Log("小白" + n + "号");
        }
       
    }

    void Start()
    {
        int a = 10;
        count(a);
    }
9—————————————
      float jia(float a, float b)
    {
        return a + b;
    }
    float jian(float a, float b)
    {
        return a - b;
    }
    float cheng(float a, float b)
    {
        return a * b;
    }
    float chu(float a, float b)
    {
        return a / b;
    }

    void Start()
    {
        float result;
        result = chu(jian(jia(cheng(jia(4, 9) , 8), 7),3),2);
        Debug.Log(result);
    }       
10—————————————

    float aa(float a)
    {
        return a/2;
    }
    

    void Start()
    {
        float result;
        float bb = 999.99f;
        result = aa(aa(aa(aa(aa(aa(aa(aa(aa(aa(bb))))))))));
        Debug.Log(result);
    }
      
