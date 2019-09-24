using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// cancel 按钮不会写
// register和其他链接相似所以没做

public class hongyiui : MonoBehaviour
{
    public Image img1;
    public Image img2;

    public InputField AccountInput;
    public InputField PasswordInput;
    public Text Wrong;
    public Text Welcome;

    public void OnButton()//Button点击事件
    {
        string AccountNumber = AccountInput.text;
        string PassWordNumber = PasswordInput.text;
        if (AccountNumber == "hongyi" && PassWordNumber == "1234567")//判断是否输入正确
        {
            Welcome.gameObject.SetActive(true);
            StartCoroutine(Disappear());
            SceneManager.LoadScene("start2");
        }
        else
        {
            Wrong.gameObject.SetActive(true);
            StartCoroutine(Disappear());
        }
    }
    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(2);//产生效果两秒
        Wrong.gameObject.SetActive(false);//提示消失
        Welcome.gameObject.SetActive(false);//提示消失
    }

    public void onoff()
    {
        img1.gameObject.SetActive(false);
        img2.gameObject.SetActive(true);

    }

    // Start is called before the first frame update
    void Start()
    {
        img1.gameObject.SetActive(true);
        img2.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
