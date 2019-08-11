using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public enum TurnRound {dashe, firebird, zz}

    public enum GameState { waiting, gameing, end}

    public TurnRound turn = TurnRound.firebird;

    public GameState gameState = GameState.waiting;

    public float timer = 3.0f;

    public float zzTimer = 5.0f;

    public bool isZzAttack = false;

    public GameObject dashe;

    public GameObject zz;

    public GameObject fireBird;


    public GameObject wuwu;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsZZAttack();
        BattleDasheandBird();
    }

    void BattleDasheandBird()
    {
        switch (gameState)
        {
            case GameState.end:
                break;
            case GameState.waiting:
                timer -= Time.deltaTime;

                if (timer < 0.0f)
                {
                    gameState = GameState.gameing;
                    timer = 3.0f;
                }
                break;
            case GameState.gameing:

                IsZZAttack();
                if (isZzAttack)
                {
                    turn = TurnRound.zz;
                    isZzAttack = false;
                }

                switch (turn)
                {
                    case TurnRound.dashe:
                        dashe.GetComponent<Charactor>().Attack();
                        turn = TurnRound.firebird;
                        gameState = GameState.waiting;
                        break;
                    case TurnRound.firebird:
                        fireBird.GetComponent<Charactor>().Attack();
                        turn = TurnRound.dashe;
                        gameState = GameState.waiting;
                        break;
                    case TurnRound.zz:
                        ZZBattle();
                        break;
                }
                break;
             
        }
    }

    void IsZZAttack()
    {
        if (fireBird.transform.GetComponent<Charactor>().hp < 500)
        {
            isZzAttack = true;
        }
    }

    void ZZBattle()
    {
        zzTimer -= Time.deltaTime;
        if (zzTimer < 0.0f)
        {
            gameState = GameState.end;
            Debug.Log("zz打击完毕");
        }
    }
}
