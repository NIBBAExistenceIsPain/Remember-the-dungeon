using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public enum FightMoves
{
    AttackUp,
    AttackDown,
    AttackLeft,
    AttackRight,
    DodgeUp,
    DodgeDown,
    DodgeLeft,
    DodgeRight
}

public class BattleHandle : MonoBehaviour {

    int playerC, moveC;
    int moveDelay, actionDelay;
    int enemyHitpoints;
    float speed;

    Player player;
    Enemy enemy;
    FightMoves[] playerMoves;
    FightMoves[] enemyMoves;
    public Animator patternAnimator;
    public GameObject enemyPlace;
    public GameObject playerPlace;
    bool myTurn = false;
    bool animating = false;
    bool movesSet = false;

    public Canvas canvas;
    public Transform vScreen;
    public Transform dScreen;
    Text playerHearths;
    Text enemyHearths;
    Text counter;

    public void SetUpBattle(Enemy enemy, Player player)
    {
        moveC = enemy.moveCount;
        moveDelay = enemy.moveDelay;
        enemyHitpoints = enemy.hitPoints;
        speed = enemy.speed;
        playerMoves = new FightMoves[moveC];
        enemyMoves = new FightMoves[moveC];
        this.player = player;
        this.enemy = enemy;
        playerHearths.text = player.GetHealth().ToString();
        enemyHearths.text = enemyHitpoints.ToString();
    }

	void Start () {
        if (!GameManager.started) return;
        canvas = FindObjectOfType<Canvas>();
        actionDelay = 2;
        playerC = 0;
        playerHearths = canvas.transform.GetChild(0).GetChild(1).GetChild(2).GetComponent<Text>();
        enemyHearths = canvas.transform.GetChild(0).GetChild(1).GetChild(3).GetComponent<Text>();
        counter = canvas.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>();
        SetUpBattle(GameManager.enemy, GameManager.player);
        //SetUpBattle(Enemy.GenerateEnemy(), new Player("Steve", 5));
        enemyPlace.GetComponent<Animator>().runtimeAnimatorController = ConvertTypeController(enemy.type);
    }
	
	void Update () {
        if (!GameManager.started) return;
        if (myTurn == false)
        {
            if (!animating)
            {
                animating = true;
                enemyMoves = RandomPattern(moveC);
                StartCoroutine(EnemyActions(enemyMoves));
            }
        }
        else
        {
            if (movesSet)
            {
                if (!animating)
                {
                    animating = true;
                    StartCoroutine(ExecuteMoves(enemyPlace.GetComponent<Animator>(), playerPlace.GetComponent<Animator>()));
                }
            }
        }
    }

    public void InputRegister(int index)
    {
        if (!myTurn) return;
        if (movesSet) return;
        FightMoves move;
        switch (index)
        {
            case 1:
                move = FightMoves.AttackUp;
                break;
            case 2:
                move = FightMoves.AttackDown;
                break;
            case 3:
                move = FightMoves.AttackLeft;
                break;
            case 4:
                move = FightMoves.AttackRight;
                break;
            case 5:
                move = FightMoves.DodgeUp;
                break;
            case 6:
                move = FightMoves.DodgeDown;
                break;
            case 7:
                move = FightMoves.DodgeLeft;
                break;
            case 8:
                move = FightMoves.DodgeRight;
                break;
            default:
                move = FightMoves.AttackUp;
                break;
        }
        playerMoves[playerC++] = move;
        counter.text = playerC.ToString();
        if (playerC == moveC)
            movesSet = true;
    }

    IEnumerator EnemyActions(FightMoves[] moves) 
    {
        counter.text = moveC.ToString();
        patternAnimator.SetFloat("Speed", enemy.speed);
        yield return new WaitForSeconds(5);
        for (int j=0;j<moveC;j++)
        {
            switch (moves[j])
            {
                case FightMoves.AttackUp:
                    patternAnimator.SetTrigger("AU");
                    yield return new WaitForSeconds(moveDelay);
                    break;
                case FightMoves.AttackDown:
                    patternAnimator.SetTrigger("AD");
                    yield return new WaitForSeconds(moveDelay);
                    break;
                case FightMoves.AttackRight:
                    patternAnimator.SetTrigger("AR");
                    yield return new WaitForSeconds(moveDelay);
                    break;
                case FightMoves.AttackLeft:
                    patternAnimator.SetTrigger("AL");
                    yield return new WaitForSeconds(moveDelay);
                    break;
                case FightMoves.DodgeLeft:
                    patternAnimator.SetTrigger("DL");
                    yield return new WaitForSeconds(moveDelay);
                    break;
                case FightMoves.DodgeRight:
                    patternAnimator.SetTrigger("DR");
                    yield return new WaitForSeconds(moveDelay);
                    break;
                case FightMoves.DodgeUp:
                    patternAnimator.SetTrigger("DU");
                    yield return new WaitForSeconds(moveDelay);
                    break;
                case FightMoves.DodgeDown:
                    patternAnimator.SetTrigger("DD");
                    yield return new WaitForSeconds(moveDelay);
                    break;
            }
            counter.text = (moveC - j - 1).ToString();
        }
        animating = false;
        myTurn = true;
    }

    IEnumerator ExecuteMoves(Animator enemyAnimator, Animator playerAnimator)
    {
        for(int j=0;j<moveC;j++)
        {
            switch (enemyMoves[j])
            {
                case FightMoves.AttackUp:
                    if(playerMoves[j] == FightMoves.DodgeDown)
                    {
                        enemyAnimator.SetTrigger("Attack");
                        playerAnimator.SetTrigger("Dodge");
                        yield return new WaitForSeconds(actionDelay);
                    }
                    else
                    {
                        enemyAnimator.SetTrigger("Attack");
                        playerAnimator.SetTrigger("Hurt");
                        player.TakeHit();
                        yield return new WaitForSeconds(actionDelay);
                    }    
                    
                    break;
                case FightMoves.AttackDown:
                    if (playerMoves[j] == FightMoves.DodgeUp)
                    {
                        enemyAnimator.SetTrigger("Attack");
                        playerAnimator.SetTrigger("Dodge");
                        yield return new WaitForSeconds(actionDelay);
                    }
                    else
                    {
                        enemyAnimator.SetTrigger("Attack");
                        playerAnimator.SetTrigger("Hurt");
                        player.TakeHit();
                        yield return new WaitForSeconds(actionDelay);
                    }
                    break;
                case FightMoves.AttackRight:
                    if (playerMoves[j] == FightMoves.DodgeLeft)
                    {
                        enemyAnimator.SetTrigger("Attack");
                        playerAnimator.SetTrigger("Dodge");
                        yield return new WaitForSeconds(actionDelay);
                    }
                    else
                    {
                        enemyAnimator.SetTrigger("Attack");
                        playerAnimator.SetTrigger("Hurt");
                        player.TakeHit();
                        yield return new WaitForSeconds(actionDelay);
                    }
                    break;
                case FightMoves.AttackLeft:
                    if (playerMoves[j] == FightMoves.DodgeRight)
                    {
                        enemyAnimator.SetTrigger("Attack");
                        playerAnimator.SetTrigger("Dodge");
                        yield return new WaitForSeconds(actionDelay);
                    }
                    else
                    {
                        enemyAnimator.SetTrigger("Attack");
                        playerAnimator.SetTrigger("Hurt");
                        player.TakeHit();
                        yield return new WaitForSeconds(actionDelay);
                    }
                    break;
                case FightMoves.DodgeLeft:
                    if (playerMoves[j] == FightMoves.AttackRight)
                    {
                        enemyAnimator.SetTrigger("Hurt");
                        playerAnimator.SetTrigger("Attack");
                        enemyHitpoints--;
                        yield return new WaitForSeconds(actionDelay);
                    }
                    else
                    {
                        enemyAnimator.SetTrigger("Dodge");
                        playerAnimator.SetTrigger("Attack");
                        yield return new WaitForSeconds(actionDelay);
                    }
                    break;
                case FightMoves.DodgeRight:
                    if (playerMoves[j] == FightMoves.AttackLeft)
                    {
                        enemyAnimator.SetTrigger("Hurt");
                        playerAnimator.SetTrigger("Attack");
                        enemyHitpoints--;
                        yield return new WaitForSeconds(actionDelay);
                    }
                    else
                    {
                        enemyAnimator.SetTrigger("Dodge");
                        playerAnimator.SetTrigger("Attack");
                        yield return new WaitForSeconds(actionDelay);
                    }
                    break;
                case FightMoves.DodgeUp:
                    if (playerMoves[j] == FightMoves.AttackDown)
                    {
                        enemyAnimator.SetTrigger("Hurt");
                        playerAnimator.SetTrigger("Attack");
                        enemyHitpoints--;
                        yield return new WaitForSeconds(actionDelay);
                    }
                    else
                    {
                        enemyAnimator.SetTrigger("Dodge");
                        playerAnimator.SetTrigger("Attack");
                        yield return new WaitForSeconds(actionDelay);
                    }
                    break;
                case FightMoves.DodgeDown:
                    if (playerMoves[j] == FightMoves.AttackUp)
                    {
                        enemyAnimator.SetTrigger("Hurt");
                        playerAnimator.SetTrigger("Attack");
                        enemyHitpoints--;
                        yield return new WaitForSeconds(actionDelay);
                    }
                    else
                    {
                        enemyAnimator.SetTrigger("Dodge");
                        playerAnimator.SetTrigger("Attack");
                        yield return new WaitForSeconds(actionDelay);
                    }
                    break;
            }
            //Debug.Log("Enemy move: " + enemyMoves[j] + ", your move: " + playerMoves[j]);
            enemyHearths.text = enemyHitpoints.ToString();
            playerHearths.text = player.GetHealth().ToString();
            if(enemyHitpoints == 0)
            {
                vScreen.gameObject.SetActive(true);
                StopAllCoroutines();

            }
            if(player.GetHealth() == 0)
            {
                dScreen.gameObject.SetActive(true);
                StopAllCoroutines();
            }
        }
        yield return new WaitForSeconds(actionDelay);
        playerC = 0;
        movesSet = false;
        animating = false;
        myTurn = false;

    }

    private static FightMoves RandomMove()
    {
        var moves = System.Enum.GetValues(typeof(FightMoves));
        return (FightMoves)moves.GetValue(Random.Range(0, 8));
    }

    private static FightMoves[] RandomPattern(int size)
    {
        FightMoves[] moves = new FightMoves[size];
        for(int i = 0; i < size; i++)
        {
            moves[i] = RandomMove();
        }
        return moves;
    }

    private RuntimeAnimatorController ConvertTypeController(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Slime:
                return canvas.GetComponent<AnimatorsStorage>().slime;
            case EnemyType.Skelly:
                return canvas.GetComponent<AnimatorsStorage>().skelliBoy;
            case EnemyType.RedBoss:
                return canvas.GetComponent<AnimatorsStorage>().miniBoss3;
            case EnemyType.GreenBoss:
                return canvas.GetComponent<AnimatorsStorage>().miniBoss2;
            case EnemyType.BlueBoss:
                return canvas.GetComponent<AnimatorsStorage>().miniBoss1;
            case EnemyType.BossBoss:
                return canvas.GetComponent<AnimatorsStorage>().boss;
            default:
                return canvas.GetComponent<AnimatorsStorage>().slime;

        }
    }
}
