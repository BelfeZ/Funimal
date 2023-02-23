using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask obstacleLayer;
    public LayerMask monsterZone;
    private bool isMoving;
    private Vector2 input;
    private Animator animator;
    [SerializeField] private MonsterBase player1stat;
    [SerializeField] private MonsterBase player2stat;
    public event Action OnEncountered;

    private AllMenu _allMenu;
    [SerializeField] private GameObject battleSystem;
    

    private void Awake()
    {
        player1stat.CurrentHp = player1stat.MaxHp;
        player1stat.CurrentSp = player1stat.MaxSp;
        player2stat.CurrentHp = player2stat.MaxHp;
        player2stat.CurrentSp = player2stat.MaxSp;
        player1stat.IsAlive = true;
        player2stat.IsAlive = true;
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _allMenu = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AllMenu>();
        _allMenu.notMainMenu = true;
        battleSystem.SetActive(false);
    }

    public void HandleUpdate()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            if (input.x != 0) input.y = 0;
            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (IsWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                }
            }
        }
        animator.SetBool("isMoving", isMoving);
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;

        CheckForEncounters();
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.3f, obstacleLayer) != null)
        {
            return false;
        }
        return true;
    }
    private void CheckForEncounters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, monsterZone) != null)
        {
            if (Random.Range(1, 101) <= 10)
            {
                OnEncountered();
            }
        }
    }
}
