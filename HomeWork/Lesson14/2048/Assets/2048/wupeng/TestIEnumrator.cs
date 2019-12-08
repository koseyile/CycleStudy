using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestIEnumrator :MonoBehaviour
{

    private void Start()
    {
        Person[] pp = { new Person("a"), new Person("b"), new Person("c") };

        People ppp = new People(pp);

        foreach (Person p in ppp)
        {
            Debug.Log(p.name);
        }
    }

}

public class Person 
{
    public string name;
    public Person(string _name)
    {
        name = _name;
    }
}

public class People : IEnumerable //实现了IEnumrable接口的类可以被迭代
{
    public Person[] people;

    public People(Person[] _people)
    {
        people = new Person[_people.Length];
        for (int i = 0; i < _people.Length; i ++)
        {
            people[i] = _people[i];
        }
    }

    public IEnumerator GetEnumerator() //C#编译器会通过GetEnumrator()函数来构建一个 IEnumrator类型的迭代器
    {
        //for (int i = 0; i < people.Length; i ++)
        //{
        //    yield return people[i]; //语法糖yield创建一个实现IEnumrator接口的实例，该实例中的数组 赋值为A[]类型的 people
        //}

        return new MyEnumerator(people);
    }

    public class MyEnumerator : IEnumerator
    {
        Person[] p;
        int idx = -1;
        public MyEnumerator(Person[] t)
        {
            p = t;
        }
        public object Current
        {
            get
            {
                if (idx == -1)
                    return new IndexOutOfRangeException();
                return p[idx];
            }
        }
        public bool MoveNext()
        {
            idx++;
            return p.Length > idx;
        }
        public void Reset()
        {
            idx = -1;
        }
    }
}

