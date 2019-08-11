using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIstate { hide, show, still}

public class UIBase : MonoBehaviour
{
    public float timer;
    public float timeTem;
    string info;
    public Color color;

    public UIstate state;

    // Start is called before the first frame update
    void Start()
    {
        timeTem = timer;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case UIstate.show:
                ShowDamage();
                break;
            case UIstate.hide:
                HideDamage();
                break;
            case UIstate.still:
                break;
        }
    }

    public void ShowDamage()
    {
        this.gameObject.transform.GetComponent<Text>().text = info;
        this.gameObject.transform.GetComponent<Text>().color = new Color(color.r, color.g, color.b, 1.0f);
        timeTem -= Time.deltaTime;
        if (timeTem < 0.0f)
        {
            state = UIstate.hide;
            timeTem = timer;
        }
        
    }

    public void HideDamage()
    {
        timeTem -= Time.deltaTime;
        float a = timeTem / timer;
        this.gameObject.transform.GetComponent<Text>().color = new Color(color.r, color.g, color.b, a);

        if (timeTem < 0.0f)
        {
            state = UIstate.still;
            timeTem = timer;
        }
    }

    public void Show(string info, Color color)
    {
        this.info = info;
        this.color = color;
        this.state = UIstate.show;
    }
}
