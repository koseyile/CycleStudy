using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Monster Bird;
    public Monster Snake;
    public Transform Sword;
    public RawImage WhiteImage;
    float StartDistance;

    void Start()
    {
        StartCoroutine(InitializeData());
    }

    // Update is called once per frame
    float CurrentTime = 0;
    void Update()
    {
        SceneStateMachine(ref CurrentTime);
    }

    IEnumerator InitializeData()
    {
        StartDistance = Vector3.Distance(Sword.position, Bird.transform.position);
        Bird.state = Monster.State.Attack;
        yield return new WaitForSeconds(0.5f);
        Snake.state = Monster.State.Attack;
    }

    enum SceneState { Normal, SlayBird, peopleYell, FadeinFadeOut };
    SceneState scenestate = SceneState.Normal;
    bool yelled = false;
    void SceneStateMachine(ref float CurrentTime)
    {
        CurrentTime += Time.deltaTime;
        switch (scenestate)
        {
            case SceneState.Normal:
                if (Bird.CurrentHP < 500)
                {
                    scenestate = SceneState.SlayBird;
                    CurrentTime = 0;
                }
                break;
            case SceneState.SlayBird:
                if (CurrentTime < 5f)
                {
                    float distance = Vector3.Distance(Sword.position, Bird.transform.position);
                    Vector3 MoveToBird = Vector3.MoveTowards(Sword.position, Bird.transform.position, StartDistance / (5f / Time.deltaTime));
                    Sword.position = MoveToBird;
                }
                else
                {
                    scenestate = SceneState.peopleYell;
                    CurrentTime = 0;
                }
                break;
            case SceneState.peopleYell:
                if (CurrentTime < 2)
                {
                    if (!yelled)
                    {
                        yelled = true;
                        PeopleYell(yelled);
                    }

                }
                else
                {
                    PeopleYell(false);
                    scenestate = SceneState.FadeinFadeOut;
                    screenstate = ScreenState.fadein;
                    CurrentTime = 0;
                }
                break;
            case SceneState.FadeinFadeOut:
                FadeInFadeOut(ref CurrentTime);
                break;
        }

    }


    void PeopleYell(bool yell)
    {
        foreach (Transform People in transform.Find("/Canvas/Characters"))
        {
            People.Find("Yell").gameObject.SetActive(yell);
        }
    }

    enum ScreenState { normal, white, fadein, fadeout };
    ScreenState screenstate = ScreenState.normal;
    void FadeInFadeOut(ref float CurrentTime)
    {
        CurrentTime += Time.deltaTime;
        //Debug.Log(screenstate);
        //Debug.Log(CurrentTime);
        switch (screenstate)
        {
            case ScreenState.fadein:
                if (CurrentTime < 2)
                {
                    WhiteImage.color = new Color(1, 1, 1, CurrentTime / 2f);
                }
                else
                {
                    screenstate = ScreenState.white;
                    CurrentTime = 0;
                    Bird.gameObject.SetActive(false);
                    Snake.gameObject.SetActive(false);
                }
                break;
            case ScreenState.white:
                if (CurrentTime > 3)
                {
                    screenstate = ScreenState.fadeout;
                    CurrentTime = 0;
                }
                break;
            case ScreenState.fadeout:
                if (CurrentTime < 2)
                {
                    WhiteImage.color = new Color(1, 1, 1, 1 - CurrentTime / 2f);
                }
                else
                {
                    screenstate = ScreenState.normal;
                    CurrentTime = 0;
                }
                break;
        }


    }
}
