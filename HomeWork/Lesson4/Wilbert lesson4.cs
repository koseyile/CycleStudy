1 2———————————

    struct StudentInfo
    {
        public string StudentName;
        public string StudentGender;
        public string StudentGrade;
    }

    void printLowGrade(StudentInfo[] studentInfoArray)
    {
        int male = 0;
        int female = 0;
        for (int i= 0; i < studentInfoArray.Length; ++i)
        {
            if (studentInfoArray[i].StudentGrade == "Low Grade")
            {
                if (studentInfoArray[i].StudentGender == "Male")
                {
                    male = male + 1;
                }
                else
                {
                    female = female + 1;
                }

            }
        }
        Debug.Log("Low grade male="+male);
        Debug.Log("Low grade famale=" + female);


    }


    void Start()
    {
        StudentInfo[] studentInfoArray = new StudentInfo[108];
        for (int i = 0; i < studentInfoArray.Length; ++i)
        {
            studentInfoArray[i].StudentName = "Student" + i;
            //High grade male 15

            if (i <= 14)
            {
                studentInfoArray[i].StudentGender = "Male";
                studentInfoArray[i].StudentGrade = "High Grade";
            }
            //High grade female 15
            else if (i > 14 && i <= 29)
            {
                studentInfoArray[i].StudentGender = "Female";
                studentInfoArray[i].StudentGrade = "High Grade";
            }
            //Middle grade male 20
            else if(i > 29 && i <= 49)
            {
                studentInfoArray[i].StudentGender = "Male";
                studentInfoArray[i].StudentGrade = "Middle Grade";
            }
            //Middle grade female 16
            else if(i > 49 && i <= 65)
            {
                studentInfoArray[i].StudentGender = "famale";
                studentInfoArray[i].StudentGrade = "Middle Grade";
            }
            //Low grade male 25
            else if (i > 65 && i <= 90)
            {
                studentInfoArray[i].StudentGender = "Male";
                studentInfoArray[i].StudentGrade = "Low Grade";
            }
            //Low grade female 17
            else 
            {
                studentInfoArray[i].StudentGender = "Female";
                studentInfoArray[i].StudentGrade = "Low Grade";
            }
        }
        printLowGrade(studentInfoArray);

    }

3 4———————————

        void printLowGrade(AgentInfo[] agentInfo1, AgentInfo[] agentInfo2)
    {
        int kickback1 = 0;
        int kickback2 = 0;
        for (int i= 0; i < agentInfo1.Length; ++i)
        {
            kickback1 = agentInfo1[i].Cost + kickback1;
        }
        for (int i = 0; i < agentInfo2.Length; ++i)
        {
            kickback2 = agentInfo2[i].Cost + kickback2;
        }
        Debug.Log(kickback1 - kickback2);
    }



    struct AgentInfo
    {
        public string Book;
        public string Grade;
        public int Cost;
    }

    void Start()
    {
        
        AgentInfo[] agentInfoWhite = new AgentInfo[108];
        for (int i = 0; i < agentInfoWhite.Length; ++i)
        {
            agentInfoWhite[i].Book = "White";
            //High grade 2000
            if (i <= 29)
            {
                agentInfoWhite[i].Cost = 2000;
                agentInfoWhite[i].Grade = "High grade";

            }
            //Middle grade 2200
            else if (i > 29 && i <= 65)
            {
                agentInfoWhite[i].Cost = 2200;
                agentInfoWhite[i].Grade = "Middle grade";
            }
            //Low grade 2500
            else
            {
                agentInfoWhite[i].Cost = 2500;
                agentInfoWhite[i].Grade = "Low grade";
            }
        }

        AgentInfo[] agentInfoBlack = new AgentInfo[108];
        for (int i = 0; i < agentInfoWhite.Length; ++i)
        {
            agentInfoBlack[i].Book = "Black";
            //High grade 1900
            if (i <= 29)
            {
                agentInfoBlack[i].Cost = 1900;
                agentInfoBlack[i].Grade = "High grade";

            }
            //Middle grade 1900
            else if (i > 29 && i <= 65)
            {
                agentInfoBlack[i].Cost = 1900;
                agentInfoBlack[i].Grade = "Middle grade";
            }
            //Low grade 1900
            else
            {
                agentInfoBlack[i].Cost = 1900;
                agentInfoBlack[i].Grade = "Low grade";
            }
        }
        printLowGrade(agentInfoWhite, agentInfoBlack);


    }
       
5 6 7—————————————

   void print1(Weapon[] WeaponALL)
    {
        float n = 0f;
        n = WeaponALL[0].LEN* WeaponALL[0].WID+ WeaponALL[1].LEN * WeaponALL[1].WID;
        Debug.Log(n+"cm2");
    }

    void print2(Weapon[] WeaponALL, float HP)
    {
        float finalHP = HP - WeaponALL[0].ATK * 2f;
        WeaponALL[1].DEF = WeaponALL[1].DEF + finalHP / 2f;

        Debug.Log(finalHP);
        Debug.Log(WeaponALL[1].DEF);
    }



    struct Weapon
    {
        public float LEN;
        public float WID;
        public float ATK;
        public float DEF;
    }

    void Start()
    {
        Weapon[] WeaponALL = new Weapon[2];
        WeaponALL[0].LEN = 2f * 33.3333333f;
        WeaponALL[0].WID = 4f * 3.3333333f;
        WeaponALL[0].ATK = 80f;
        WeaponALL[0].DEF = 20f;

        WeaponALL[1].LEN = 1f * 33.3333333f + 5f * 3.3333333f;
        WeaponALL[1].WID = 1f * 33.3333333f + 5f * 3.3333333f;
        WeaponALL[1].ATK = 30f;
        WeaponALL[1].DEF = 90f;

        print1(WeaponALL);
        print2(WeaponALL, 1000f);
    }

8 9—————————————
    void print1(XICUIPING[] XICUI)
    {
        for (int i = 0; i < XICUI.Length; ++i)
        {
            Debug.Log(XICUI[i].GEN);
            Debug.Log(XICUI[i].PRICE);
        }
    }

    struct XICUIPING
    {
        public int GEN;
        public float PRICE;
    }

    void Start()
    {
        XICUIPING[] XICUI = new XICUIPING[15];
        for(int i=0; i<XICUI.Length;++i)
        {
            if (i <= 3)
            {
                XICUI[0].GEN = 1;
                XICUI[0].PRICE = 4000f;

                XICUI[1].GEN = 2;
                XICUI[1].PRICE = XICUI[0].PRICE / 2f;

                XICUI[2].GEN = 3;
                XICUI[2].PRICE = XICUI[1].PRICE * 10f;

                XICUI[3].GEN = 4;
                XICUI[3].PRICE = XICUI[2].PRICE;
            }
            else
            {
                XICUI[i].GEN = i + 1;
                XICUI[i].PRICE = XICUI[i - 1].PRICE * 2f;
            }
        }
        print1(XICUI);
    }
10 —————————————
       void finalkickback(AgentInfo[] agentInfo1, AgentInfo[] agentInfo2, XICUIPING[] XICUI)
    {
        int kickback1 = 0;
        int kickback2 = 0;
        for (int i = 0; i < agentInfo1.Length; ++i)
        {
            kickback1 = agentInfo1[i].Cost + kickback1;
        }
        for (int i = 0; i < agentInfo2.Length; ++i)
        {
            kickback2 = agentInfo2[i].Cost + kickback2;
        }
        Debug.Log(kickback1 - kickback2);
        Debug.Log(kickback1 - kickback2 - 0.8f * XICUI[13].PRICE * 0.06389f);
    }


    struct XICUIPING
    {
        public int GEN;
        public float PRICE;
    }

    struct AgentInfo
    {
        public string Book;
        public string Grade;
        public int Cost;
    }

    void Start()
    {
        XICUIPING[] XICUI = new XICUIPING[15];
        for (int i = 0; i < XICUI.Length; ++i)
        {
            if (i <= 3)
            {
                XICUI[0].GEN = 1;
                XICUI[0].PRICE = 4000f;

                XICUI[1].GEN = 2;
                XICUI[1].PRICE = XICUI[0].PRICE / 2f;

                XICUI[2].GEN = 3;
                XICUI[2].PRICE = XICUI[1].PRICE * 10f;

                XICUI[3].GEN = 4;
                XICUI[3].PRICE = XICUI[2].PRICE;
            }
            else
            {
                XICUI[i].GEN = i + 1;
                XICUI[i].PRICE = XICUI[i - 1].PRICE * 2f;
            }
        }



        AgentInfo[] agentInfoWhite = new AgentInfo[108];
        for (int i = 0; i < agentInfoWhite.Length; ++i)
        {
            agentInfoWhite[i].Book = "White";
            //High grade 2000
            if (i <= 29)
            {
                agentInfoWhite[i].Cost = 2000;
                agentInfoWhite[i].Grade = "High grade";

            }
            //Middle grade 2200
            else if (i > 29 && i <= 65)
            {
                agentInfoWhite[i].Cost = 2200;
                agentInfoWhite[i].Grade = "Middle grade";
            }
            //Low grade 2500
            else
            {
                agentInfoWhite[i].Cost = 2500;
                agentInfoWhite[i].Grade = "Low grade";
            }
        }

        AgentInfo[] agentInfoBlack = new AgentInfo[108];
        for (int i = 0; i < agentInfoWhite.Length; ++i)
        {
            agentInfoBlack[i].Book = "Black";
            //High grade 1900
            if (i <= 29)
            {
                agentInfoBlack[i].Cost = 1900;
                agentInfoBlack[i].Grade = "High grade";

            }
            //Middle grade 1900
            else if (i > 29 && i <= 65)
            {
                agentInfoBlack[i].Cost = 1900;
                agentInfoBlack[i].Grade = "Middle grade";
            }
            //Low grade 1900
            else
            {
                agentInfoBlack[i].Cost = 1900;
                agentInfoBlack[i].Grade = "Low grade";
            }
        }

        finalkickback(agentInfoWhite, agentInfoBlack, XICUI);


    }