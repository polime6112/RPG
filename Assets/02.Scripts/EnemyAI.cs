using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum State
    {
        PATROL,
        TRACE,
        ATTACK,
        DIE
    }

    public State state = State.PATROL;

    private Transform playerTr;

    private Transform enemyTr;

    public float attackDist = 1.0f;
    public float traceDist = 5.0f;

    public bool isDie = false;

    private WaitForSeconds ws;

    private MoveAgent moveAgent;

    void Awake()
    {
        
        var player = GameObject.FindGameObjectWithTag("Enemy");
        if (player != null)
        {
            playerTr = player.GetComponent<Transform>();
        }

        enemyTr = GetComponent<Transform>();

        moveAgent = GetComponent<MoveAgent>();

        ws = new WaitForSeconds(0.3f);
        
    }

    void OnEnable()
    {
        StartCoroutine(CheckState());
        StartCoroutine(Action());
    }

    IEnumerator CheckState()
    {
        while (!isDie)
        {
            if (state == State.DIE)
            {
                yield break;
            }
            float dist = Vector3.Distance(playerTr.position, enemyTr.position);

            if (dist <= attackDist)
            {
                state = State.ATTACK;
            }
            else if (dist <= traceDist)
            {
                state = State.TRACE;
            }
            else
            {
                state = State.PATROL;
            }

            yield return ws;
        }
    }

    IEnumerator Action()
    {
        while (!isDie)
        {
            yield return ws;
            switch (state)
            {
                case State.PATROL:
                    moveAgent.patrolling = true;
                    break;
                case State.TRACE:
                    moveAgent.traceTarget = playerTr.position;
                    break;
                case State.ATTACK:
                    moveAgent.Stop();
                    break;
                case State.DIE:
                    moveAgent.Stop();
                    break;
            }
        }
    }
}
