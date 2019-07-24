   void Lesson1()
    {
        // 1. 100以内所有数
        for (int i = 1; i < 100; i++)
            Debug.Log(i);

        // 2. 100以内所有偶数
        for (int i = 1; i < 100; i++)
            if (i % 2 == 0)
                Debug.Log(i);

        // 3. 100以内所有奇数
        for (int i = 1; i < 100; i++)
            if (i % 2 == 1)
                Debug.Log(i);

        // 4. 100以内所有素数
        for (int i = 2; i < 100; i++)
        {
            bool bPrimeNum = true;
            for (int j = 2; j <= i; j++)
            {
                if (i % j == 0 && i != j)
                {
                    bPrimeNum = false;
                    break;
                }
            }
            if (bPrimeNum)
                Debug.Log(i);
        }

        // 5. 100以内所有平方大于50的偶数
        for (int i = 1; i < 100; i++)
            if (i * i > 50 && i % 2 == 0)
                Debug.Log(i);

        // 6. 100以内所有平方大于50的数或偶数
        for (int i = 1; i < 100; i++)
            if (i * i > 50 || i % 2 == 0)
                Debug.Log(i);

        // 7. 100累加
        int X = 0;
        for (int i = 1; i <= 100; i++)
            X += i;
        Debug.Log(X);

        // 8. 平方小于100的最大整数
        for (int i = 100; i > 1; i--)
            if (i * i < 100)
            {
                Debug.Log(i);
                break;
            }
        // 9. 半径8.6的圆面积
        Debug.Log(8.6f * 8.6f * Mathf.PI);

        // 1. 10到99中个位数加十位数为偶数的数
        for (int i = 10; i <= 99; i++)
            if ((1 % 10 + i / 10) % 2 == 0)
                Debug.Log(i);
    }
}