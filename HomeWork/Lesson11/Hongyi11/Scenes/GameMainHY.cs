using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//以下是我的问题：
//这次我没有写什么 因为从第三题我就开始不知道要怎么写了。我和巫巫从周四开始就一直在研究怎么让卡牌转起来，找到一些类似于让一张牌从北面翻到正面的，但是里面那个人用了插件我们没有。
//后来找的另一个也是跑不出来。因为我们对自己写的东西本身就不自信，自己也发现不了问题出在哪里，我们只能通过查找无限去尝试。但是尝试的结果对我们来说就是一直不成功，但是也不知道怎么弄。可能某一种方法也许是对的，但是我们跑不出来所以觉得还是错的。
//长期这样下来，我们的挫败感就会很强。因为我觉得作业的内容和上课学的根本不是一个东西，可能是因为单个的知识点我们还没有完全掌握，就加入了比较复杂的内容，多个知识点和视觉图像放在一起，完全不知道应该怎么下手。即便看别人的内容，也无法理解他们的逻辑顺序。
//他们所使用的很多专业术语是我们之前没有学到过的，虽然说可以去查，但是当我们没有任何概念的时候，也不知道应该去查哪些关键字，没有查找的入口。
//我觉得是不是可以出几道和上课内容讲的相似的题目，这样一方面可以让我们不太扎实的同学稳固一下知识点，多练习一下，然后再慢慢递进。
//有一个具体的问题：我看到很多人的代码都是分几个文档写的，比如一个是manager，另一个是卡牌本身，它们之间要怎么调用、串联呢？
//prefab这块要怎么用还是不太理解


namespace Hongyi
{
    public class GameMainHY : MonoBehaviour
    {
        public GameObject cardprefab;

        public class cardH
        {
        private GameObject CardHY;//有一个卡牌的prefab
        private float RotateSpeed;//旋转的速度
        private float Timer;//时间
        private Vector3 CurrentPos;//我觉得可能要设定一个位置，因为要让牌绕x轴转动

        public enum RotateState//枚举两个卡牌的状态
        {
            Rotate, 
            Pause,
        }
        public RotateState CardHYState;

        public cardH(GameObject _card, Vector3 _pos, float speed)
        {
            CardHY = Object.Instantiate(_card, _pos, Quaternion.identity);
            RotateSpeed = 40.0f;
            Timer = 1.0f;
            CurrentPos = new Vector3(0, 0, 0);
            CardHYState = RotateState.Pause;
        }

        public void cardRotate(float a)
        {
            CurrentPos.x += RotateSpeed * 360f * Time.deltaTime;
            CurrentPos.x = CurrentPos.x % 360f;
            CardHY.transform.eulerAngles = CurrentPos;
        }

        public void Update()
        {
            switch (CardHYState)
            {
                case RotateState.Pause:
                    {
                    }
                    break;
                case RotateState.Rotate:
                    {
                        Timer -= Time.deltaTime;
                        cardRotate(RotateSpeed * Time.deltaTime);
                        if (Timer < 0f)
                        {
                            CardHY.transform.rotation = Quaternion.identity;
                            CardHYState = RotateState.Pause;
                        }
                    }
                    break;
            }
        }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
