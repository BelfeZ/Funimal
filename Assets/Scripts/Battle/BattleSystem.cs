using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public enum BattleState {Start, PlayerAction, PlayerSkill, EnemyMove, Busy}
public class BattleSystem : MonoBehaviour
{
    [SerializeField] private MonsterBase player1stat;
    [SerializeField] private MonsterBase player2stat;
    [SerializeField] private BattleUnit player1Unit;
    [SerializeField] private BattleUnit player2Unit;
    [SerializeField] private BattleUnit enemyUnit;
    [SerializeField] BattleHud player1Hud;
    [SerializeField] BattleHud player2Hud;
    [SerializeField] BattleHud enemyHud;
    [SerializeField] BattleDialog dialogBox;
    

    public event Action<bool> OnBattleOver;

    private BattleState state;
    private int currentOrder;
    private int currentSkill;
    private int playerTurn;
    private bool isKO;
    private int[] player1StatusValue = new int[4];
    private int[,] player1StatusOrder = new int[4,4];
    private int[] player2StatusValue = new int[4];
    private int[,] player2StatusOrder = new int[4,4];
    private int[] enemyStatusValue = new int[4];
    private int[,] enemyStatusOrder = new int[4,4];
    private int target;
    
    private bool _battleInventoryActive = false;
    private bool _allStart;
    private bool SwordIslevelUp;
    private bool MageIslevelUp;

   

    private SoundManager _soundManager;
    private InventoryBattle _inventoryBattle;
    private PlayerInventory _playerInventory;
    private PlayerManager _playerManager;

    private LevelUpdate _levelUpdate;
    //private AllMenu _allMenu;
    private GameObject _gameManager;

    [SerializeField] private MonsterBase swordman;
    [SerializeField] private MonsterBase mage;

    private void Start()
    {
        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        _inventoryBattle = GameObject.FindGameObjectWithTag("GameManager2").GetComponent<InventoryBattle>();
        _playerInventory = GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<PlayerInventory>();
        _playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        //_allMenu = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AllMenu>();
        _gameManager = GameObject.Find("GameManager");
        _levelUpdate = GameObject.FindGameObjectWithTag("Player").GetComponent<LevelUpdate>();
    }
    
    private void Update()
    {
        if (_battleInventoryActive && Input.GetKeyDown(KeyCode.Escape))
        {
            _inventoryBattle.CloseBattleInventory();
        }
    }

    public void StartBattle(Monster monster)
    {
        StartCoroutine(SetupBattle(monster));
        SoundManager.instace.Stop(SoundManager.SoundName.ThemeSong);
    }

    public IEnumerator SetupBattle(Monster monster)
    {
        player1Unit.Setup();
        player2Unit.Setup();
        enemyUnit.MonsterSetup(monster);
        player1Hud.SetData(player1Unit.monster);
        player2Hud.SetData(player2Unit.monster);
        enemyHud.SetData(enemyUnit.monster);
        dialogBox.SetSkillNamesForPlayer1(player1Unit.monster.Moves);
        dialogBox.SetSkillNamesForPlayer2(player2Unit.monster.Moves);
        
        yield return dialogBox.TypeDialog($"Your party have encounter the {enemyUnit.monster.Base.name}!!");
        yield return new WaitForSeconds(1f);
        if (player1stat.IsAlive)
        {
            Player1Action(); 
        }
        else
        {
            Player2Action();
        }
    }

    IEnumerator StartNewTurn()
    {
        if (swordman.IsAlive == false && mage.IsAlive == false)
        {
            StartCoroutine(dialogBox.TypeDialog("Your party had been wiped out..."));
            yield return new WaitForSeconds(2f);
            StartCoroutine(dialogBox.TypeDialog("Game over..."));
            yield return new WaitForSeconds(2f);
            //Gameover go to checkpoint.
            //_allMenu.findBattle = false;
            _inventoryBattle.battleOn = false;
            _gameManager.SetActive(true);
            _playerManager.isGameOver = true;
            yield return new WaitForSeconds(3f);
        }
        player1Unit.monster.SavePlayerHP(player1stat);
        player2Unit.monster.SavePlayerHP(player2stat);
        StartCoroutine(dialogBox.TypeDialog("Your Turn!"));
        if (_inventoryBattle._swordAtkBootsActived == true)
        {
            _inventoryBattle._swordAtkBootsActive -= 1;
        }

        if (_inventoryBattle._mageAtkBootsActived == true)
        {
            _inventoryBattle._mageAtkBootsActive -= 1;
        }
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 4; i++)
        {
            for (int j = 1; j < 4; j++)
            {
                if (player1StatusOrder[i, j] > 0)
                {
                    player1StatusOrder[i, j] -= 1;
                    if (player1StatusOrder[i, j] == 0)
                    {
                        SoundManager.instace.Play(SoundManager.SoundName.Debuff);
                        player1Unit.monster.ReturnStatus(j,player1StatusValue[i]);
                        yield return dialogBox.TypeDialog("Swordman buff had ran out.");
                        yield return new WaitForSeconds(1f);
                        dialogBox.RemoveStatusForPlayer1(i);
                        break;
                    }
                }
                if (player2StatusOrder[i, j] > 0)
                {
                    player2StatusOrder[i, j] -= 1;
                    if (player2StatusOrder[i, j] == 0)
                    {
                        SoundManager.instace.Play(SoundManager.SoundName.Debuff);
                        player2Unit.monster.ReturnStatus(j,player2StatusValue[i]);
                        yield return dialogBox.TypeDialog("Mage buff had ran out.");
                        yield return new WaitForSeconds(1f);
                        dialogBox.RemoveStatusForPlayer2(i);
                        break;
                    }
                }
                if (enemyStatusOrder[i, j] > 0)
                {
                    enemyStatusOrder[i, j] -= 1;
                    if (enemyStatusOrder[i, j] == 0)
                    {
                        SoundManager.instace.Play(SoundManager.SoundName.Debuff2);
                        enemyUnit.monster.ReturnStatus(j,enemyStatusValue[i]);
                        yield return dialogBox.TypeDialog($"Some of {enemyUnit.name} buff had ran out!");
                        yield return new WaitForSeconds(2f);
                        break;
                    }
                }
            }
        }
        
        if (mage.IsAlive)
        {
            player2Unit.monster.RegenSP();
            player2Hud.UpdateSP(player2Unit.monster);
        }
        if (swordman.IsAlive)
        {
            player1Unit.monster.RegenSP();
            player1Hud.UpdateSP(player1Unit.monster);
            Player1Action();
        }
        else
        {
            Player2Action();
        }
    }
    
    void Player1Action()
    {
        _inventoryBattle.playerPlay = 1;
        playerTurn = 1;
        state = BattleState.PlayerAction;
        StartCoroutine(dialogBox.TypeDialog("Choose your order for Swordman..."));
        dialogBox.EnableSkillSelector(false, 1);
        dialogBox.EnableOrderSelector(true);
    }

    void Player1Skill()
    {
        state = BattleState.PlayerSkill;
        StartCoroutine(dialogBox.TypeDialog("Choose Swordman skill..."));
        dialogBox.EnableOrderSelector(false);
        dialogBox.EnableSkillSelector(true , 1);
    }
    
    void Player2Action()
    {
        _inventoryBattle.playerPlay = 2;
        playerTurn = 2;
        state = BattleState.PlayerAction;
        StartCoroutine(dialogBox.TypeDialog("Choose your order for Mage..."));
        dialogBox.EnableSkillSelector(false, 2);
        dialogBox.EnableOrderSelector(true);
    }

    void Player2Skill()
    {
        state = BattleState.PlayerSkill;
        StartCoroutine(dialogBox.TypeDialog("Choose Mage skill..."));
        dialogBox.EnableOrderSelector(false);
        dialogBox.EnableSkillSelector(true, 2);
    }

    void PlayerAttack()
    {
        dialogBox.EnableOrderSelector(false);
        dialogBox.EnableSkillSelector(false, 1);
        StartCoroutine(PerformPlayerAttack());
    }

    IEnumerator PerformPlayerAttack() 
    {
        SoundManager.instace.Play(SoundManager.SoundName.normalAttack);
        state = BattleState.Busy;
        yield return dialogBox.TypeDialog($"Normal attack to {enemyUnit.monster.Base.name}!!");
        yield return new WaitForSeconds(1f);
        if (playerTurn == 1)
        {
            if (enemyUnit.monster.isSuperEffective(player1Unit.monster))
            {
                yield return dialogBox.TypeDialog("It very effective!!!");
                yield return new WaitForSeconds(1f);
            }
            else if (enemyUnit.monster.isNotEffective(player1Unit.monster))
            {
                yield return dialogBox.TypeDialog("It not effective...");
                yield return new WaitForSeconds(1f);
            }
            isKO = enemyUnit.monster.TakeNormalDamage(player1Unit.monster);
        }
        else if (playerTurn == 2)
        {
            if (enemyUnit.monster.isSuperEffective(player2Unit.monster))
            {
                yield return dialogBox.TypeDialog("It very effective!!!");
                yield return new WaitForSeconds(1f);
            }
            else if (enemyUnit.monster.isNotEffective(player2Unit.monster))
            {
                yield return dialogBox.TypeDialog("It not effective...");
                yield return new WaitForSeconds(1f);
            }
            isKO = enemyUnit.monster.TakeNormalDamage(player2Unit.monster);
        }
        enemyHud.UpdateHP(enemyUnit.monster);
        if (isKO)
        {
            _playerInventory.coin += enemyUnit.monster.Base.MoneyDrop;
            yield return dialogBox.TypeDialog($"You received the coin " + enemyUnit.monster.Base.MoneyDrop);
            yield return new WaitForSeconds(1f);
            if (enemyUnit.monster.Base.IsBoss)
            {
                SceneManager.LoadScene("End");
            }
            else
            {
                StartCoroutine(WinBattle(enemyUnit));
            }
        }
        else
        {
            yield return new WaitForSeconds(1f);
            if (playerTurn == 1 && player2stat.IsAlive)
            {
                Player2Action();
            }
            else if (playerTurn == 1 && !player2stat.IsAlive)
            {
                StartCoroutine(EnemyMove());
            }
            else if (playerTurn == 2)
            {
                StartCoroutine(EnemyMove());
            }
        }
    }

    IEnumerator PerformPlayer1Skill()
    {
        state = BattleState.Busy;
        var move = player1Unit.monster.Moves[currentSkill];
        SoundManager.instace.Play(move.Base.Sound);
        yield return dialogBox.TypeDialog($"Swordman using {move.Base.Name}!!");
        yield return new WaitForSeconds(1f);
        if (move.Base.IsBuff)
        {
            for (int i = 0; i < 4; i++)
            {
                if (player1StatusValue[i] == 0)
                {
                    if (move.Base.IsAtkBuff && move.Base.IsDefBuff == false)
                    {
                        yield return dialogBox.TypeDialog("Swordman attack up!!");
                        yield return new WaitForSeconds(1f);
                        player1Unit.monster.GetBuffed(move, i);
                        player1StatusOrder[i,1] = move.Base.Turn;
                        player1StatusValue[i] = move.Base.AtkGain;
                        dialogBox.UpdateStatusForPlayer1(1);
                        Player2Action();
                        break;
                    }
                    else if (move.Base.IsDefBuff && move.Base.IsAtkBuff == false)
                    {
                        yield return dialogBox.TypeDialog("Swordman defence up!!");
                        yield return new WaitForSeconds(1f);
                        player1Unit.monster.GetBuffed(move, i);
                        player1StatusOrder[i,2] = move.Base.Turn;
                        player1StatusValue[i] = move.Base.DefGain;
                        dialogBox.UpdateStatusForPlayer1(2);
                        Player2Action();
                        break;
                    }
                    else if (move.Base.IsDefBuff && move.Base.IsAtkBuff)
                    {
                        yield return dialogBox.TypeDialog("Swordman attack & defence up!!");
                        yield return new WaitForSeconds(1f);
                        player1Unit.monster.GetBuffed(move, i);
                        player1StatusOrder[i,3] = move.Base.Turn;
                        //player1StatusValue[i] = move.Base.Turn;
                        dialogBox.UpdateStatusForPlayer1(3);
                        Player2Action();
                        break;
                    }
                }
            }
        }
        else
        {
            bool hitted = player1Unit.monster.isHitted(move.Base.Accuracy);
            if (hitted)
            {
                if (enemyUnit.monster.isSuperEffective(player1Unit.monster))
                {
                    yield return dialogBox.TypeDialog("It very effective!!!");
                    yield return new WaitForSeconds(1f);
                }
                else if (enemyUnit.monster.isNotEffective(player1Unit.monster))
                {
                    yield return dialogBox.TypeDialog("It not effective...");
                    yield return new WaitForSeconds(1f);
                }
                bool isKO = enemyUnit.monster.TakeSkillDamage(move, player1Unit.monster);
                enemyHud.UpdateHP(enemyUnit.monster);
        
                if (isKO)
                {
                    _playerInventory.coin += enemyUnit.monster.Base.MoneyDrop;
                    yield return dialogBox.TypeDialog($"You received the coin " + enemyUnit.monster.Base.MoneyDrop);
                    yield return new WaitForSeconds(1f);
                    if (enemyUnit.monster.Base.IsBoss)
                    {
                        SceneManager.LoadScene("End");
                    }
                    else
                    {
                        StartCoroutine(WinBattle(enemyUnit));
                    }
                }
                else
                {
                    yield return new WaitForSeconds(1f);
                    if (player2stat.IsAlive)
                    {
                        Player2Action();
                    }
                    else
                    {
                        StartCoroutine(EnemyMove());
                    }
                }
            }
            else
            {
                yield return dialogBox.TypeDialog($"Missed...");
                yield return new WaitForSeconds(1f);
                if (player2stat.IsAlive)
                {
                    Player2Action();
                }
                else
                {
                    StartCoroutine(EnemyMove());
                }
                
            }
        }
    }
    
    IEnumerator PerformPlayer2Skill()
    {
        state = BattleState.Busy;
        var move = player2Unit.monster.Moves[currentSkill];
        SoundManager.instace.Play(move.Base.Sound);
        yield return dialogBox.TypeDialog($"Mage using {move.Base.Name}!!");
        yield return new WaitForSeconds(1f);
        if (move.Base.IsBuff)
        {
            for (int i = 0; i < 4; i++)
            {
                if (player2StatusValue[i] == 0)
                {
                    if (move.Base.IsAtkBuff && move.Base.IsDefBuff == false)
                    {
                        yield return dialogBox.TypeDialog("Mage attack up!!");
                        yield return new WaitForSeconds(1f);
                        player2Unit.monster.GetBuffed(move, i);
                        player2StatusOrder[i,1] = move.Base.Turn;
                        player2StatusValue[i] = move.Base.AtkGain;
                        dialogBox.UpdateStatusForPlayer2(1);
                        StartCoroutine(EnemyMove());
                        break;
                    }
                    else if (move.Base.IsDefBuff && move.Base.IsAtkBuff == false)
                    {
                        yield return dialogBox.TypeDialog("Mage defence up!!");
                        yield return new WaitForSeconds(1f);
                        player2Unit.monster.GetBuffed(move, i);
                        player2StatusOrder[i,2] = move.Base.Turn;
                        player2StatusValue[i] = move.Base.DefGain;
                        dialogBox.UpdateStatusForPlayer2(2);
                        StartCoroutine(EnemyMove());
                        break;
                    }
                    else if (move.Base.IsDefBuff && move.Base.IsAtkBuff)
                    {
                        yield return dialogBox.TypeDialog("Mage attack & defence up!!");
                        yield return new WaitForSeconds(1f);
                        player2Unit.monster.GetBuffed(move, i);
                        player2StatusOrder[i,3] = move.Base.Turn;
                        //player2StatusValue[i] = move.Base.AtkGain;
                        dialogBox.UpdateStatusForPlayer2(3);
                        StartCoroutine(EnemyMove());
                        break;
                    }
                }
            }
        }
        else
        {
            bool hitted = player2Unit.monster.isHitted(move.Base.Accuracy);
            if (hitted)
            {
                if (enemyUnit.monster.isSkillSuperEffective(move))
                {
                    yield return dialogBox.TypeDialog("It very effective!!!");
                    yield return new WaitForSeconds(1f);
                }
                else if (enemyUnit.monster.isSkillNotEffective(move))
                {
                    yield return dialogBox.TypeDialog("It not effective...");
                    yield return new WaitForSeconds(1f);
                }
                bool isKO = enemyUnit.monster.TakeSkillDamage(move, player2Unit.monster);
                enemyHud.UpdateHP(enemyUnit.monster);
        
                if (isKO)
                {
                    _playerInventory.coin += enemyUnit.monster.Base.MoneyDrop;
                    yield return dialogBox.TypeDialog($"You received the coin " + enemyUnit.monster.Base.MoneyDrop);
                    yield return new WaitForSeconds(1f);
                    if (enemyUnit.monster.Base.IsBoss)
                    {
                        SceneManager.LoadScene("End");
                    }
                    else
                    {
                        StartCoroutine(WinBattle(enemyUnit));
                    }
                }
                else
                {
                    yield return new WaitForSeconds(1f);
                    StartCoroutine(EnemyMove());
                }
            }
            else
            {
                yield return dialogBox.TypeDialog($"Missed...");
                yield return new WaitForSeconds(1f);
                StartCoroutine(EnemyMove());
            }
        }
    }

    IEnumerator PerformEscape()
    {
        state = BattleState.Busy;
        if (enemyUnit.monster.Base.IsBoss)
        {
            yield return dialogBox.TypeDialog($"You can't escape from boss!!");
            yield return new WaitForSeconds(1f);
            if (playerTurn == 1)
            {
                Player1Action();
            }
            else if (playerTurn == 2)
            {
                Player2Action();
            }
        }
        else
        {
            int r = Random.Range(1, 101);
            yield return dialogBox.TypeDialog($"Trying to escape...");
            yield return new WaitForSeconds(1f);
            if (r <= 40)
            {
                yield return dialogBox.TypeDialog($"Success!!");
                yield return new WaitForSeconds(1f);
                EndBattle();
            }
            else
            {
                yield return dialogBox.TypeDialog($"Failed to escape...");
                yield return new WaitForSeconds(1f);
                StartCoroutine(EnemyMove());
            }
        }
    }
    
    IEnumerator EnemyMove()
    {
        state = BattleState.EnemyMove;
        var move = enemyUnit.monster.GetRandomMove();
        if (swordman.IsAlive && mage.IsAlive == false)
        {
            target = 1;
        }
        else if (mage.IsAlive && swordman.IsAlive == false)
        {
            target = 2;
        }
        else
        {
            target = Random.Range(1, 3);
        }
        bool isKO;
        if (target == 1)
        {
            yield return dialogBox.TypeDialog($"{enemyUnit.monster.Base.Name} using {move.Base.Name} to Swordman!!");
            SoundManager.instace.Play(move.Base.Sound);
            yield return new WaitForSeconds(1f);
            bool hitted = enemyUnit.monster.isHitted(move.Base.Accuracy);
            if (hitted)
            {
                isKO = player1Unit.monster.TakeSkillDamage(move, enemyUnit.monster);
                player1Hud.UpdateHP(player1Unit.monster);

                if (isKO)
                {
                    swordman.IsAlive = false;
                    yield return dialogBox.TypeDialog($"Swordman had been slain!!");
                    yield return new WaitForSeconds(1f);
                    StartCoroutine(StartNewTurn());
                }
                else
                {
                    StartCoroutine(StartNewTurn());
                }
            }
            else
            {
                yield return dialogBox.TypeDialog($"Missed!!");
                yield return new WaitForSeconds(1f);
                StartCoroutine(StartNewTurn());
            }
        }
        else if (target == 2)
        {
            yield return dialogBox.TypeDialog($"{enemyUnit.monster.Base.Name} using {move.Base.Name} to Mage!!");
            yield return new WaitForSeconds(1f);
            bool hitted = enemyUnit.monster.isHitted(move.Base.Accuracy);
            if (hitted)
            {
                isKO = player2Unit.monster.TakeSkillDamage(move, enemyUnit.monster);
                player2Hud.UpdateHP(player2Unit.monster);

                if (isKO)
                {
                    mage.IsAlive = false;
                    yield return dialogBox.TypeDialog($"Mage had been slain!!");
                    yield return new WaitForSeconds(1f);
                    StartCoroutine(StartNewTurn());
                }
                else
                {
                    StartCoroutine(StartNewTurn());
                }
            }
            else
            {
                yield return dialogBox.TypeDialog($"Missed!!!");
                yield return new WaitForSeconds(1f);
                StartCoroutine(StartNewTurn());
            }
        }
    }
    
    public void HandleUpdate()
    {
        if (state == BattleState.PlayerAction)
        {
            HandleOrderSelection();
        }
        else if (state == BattleState.PlayerSkill)
        {
            HandleSkillSelection();
        }
    }

    void HandleOrderSelection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SoundManager.instace.Play(SoundManager.SoundName.clickBattle);
            if (currentOrder == 0 ||  currentOrder == 2)
            {
                currentOrder++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SoundManager.instace.Play(SoundManager.SoundName.clickBattle);
            if (currentOrder == 1 ||  currentOrder == 3)
            {
                currentOrder--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SoundManager.instace.Play(SoundManager.SoundName.clickBattle);
            if (currentOrder == 0 ||  currentOrder == 1)
            {
                currentOrder += 2;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SoundManager.instace.Play(SoundManager.SoundName.clickBattle);
            if (currentOrder == 2 ||  currentOrder == 3)
            {
                currentOrder -= 2;
            }
        }
        dialogBox.UpdateOrderSelection(currentOrder);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            SoundManager.instace.Play(SoundManager.SoundName.clickBattle);
            if (currentOrder == 0)
            {
                PlayerAttack();
            }
            else if (currentOrder == 1)
            {
                if (playerTurn == 1)
                {
                    Player1Skill();
                }
                else if (playerTurn == 2)
                {
                    Player2Skill();
                }
            }
            else if (currentOrder == 2)
            {
                Inventory();
            }
            else if (currentOrder == 3)
            {
                StartCoroutine(PerformEscape());
            }
        }
    }

    void Inventory()
    {
        _inventoryBattle.BattleInventory();
        _battleInventoryActive = true;
    }
    void HandleSkillSelection()
    {
        if (playerTurn == 1)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SoundManager.instace.Play(SoundManager.SoundName.clickBattle);
                if (currentSkill < player1Unit.monster.Moves.Count - 1)
                {
                  currentSkill++;
                }
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                SoundManager.instace.Play(SoundManager.SoundName.clickBattle);
                if (currentSkill > 0)
                {
                    currentSkill--;
                } 
            }
            dialogBox.UpdateSkillSelection(currentSkill, player1Unit.monster.Moves[currentSkill], 1);
        }
        else if (playerTurn == 2)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SoundManager.instace.Play(SoundManager.SoundName.clickBattle);
                if (currentSkill < player2Unit.monster.Moves.Count - 1)
                {
                    currentSkill++;
                }
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                SoundManager.instace.Play(SoundManager.SoundName.clickBattle);
                if (currentSkill > 0)
                {
                    currentSkill--;
                } 
            }
            dialogBox.UpdateSkillSelection(currentSkill, player2Unit.monster.Moves[currentSkill], 2);
        }
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SoundManager.instace.Play(SoundManager.SoundName.clickBattle);
            if (playerTurn == 1)
            {
                bool usable = player1Unit.monster.UsableSkill(player1Unit.monster.Moves[currentSkill]);
                if (usable)
                {
                    dialogBox.EnableSkillSelector(false, 1);
                    player1Hud.UpdateSP(player1Unit.monster);
                    StartCoroutine(PerformPlayer1Skill());
                }
                else
                {
                    dialogBox.TypeDialog("Insufficient SP to use...");
                }
            }
            else if (playerTurn == 2)
            {
                bool usable = player2Unit.monster.UsableSkill(player2Unit.monster.Moves[currentSkill]);
                if (usable)
                {
                    dialogBox.EnableSkillSelector(false, 2);
                    player2Hud.UpdateSP(player2Unit.monster);
                    StartCoroutine(PerformPlayer2Skill());
                }
                else
                {
                    dialogBox.TypeDialog("Insufficient SP to use...");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            SoundManager.instace.Play(SoundManager.SoundName.clickBattle);
            if (playerTurn == 1)
            {
                Player1Action();
            }
            else if (playerTurn == 2)
            {
                Player2Action();
            }
        }
    }

    public IEnumerator WinBattle(BattleUnit enemy)
    {
        yield return dialogBox.TypeDialog($"{enemyUnit.monster.Base.name} had been slain!!");
        yield return new WaitForSeconds(1f);
        int expGain = (enemy.monster.Base.ExpYield * enemy.monster.level);
        if (swordman.IsAlive)
        {
            player1Unit.monster.Exp += expGain;
            yield return dialogBox.TypeDialog($"Swordman gained {expGain} exp!");
            yield return new WaitForSeconds(1f);
            while (player1Unit.monster.CheckForLevelUp())
            {
                player1Unit.SaveLevel();
                player1Hud.SetLevel();
                yield return dialogBox.TypeDialog($"Swordman level up to {player1Unit.monster.level}!");
                _levelUpdate.levelUp();
                SwordIslevelUp = true;
                yield return new WaitForSeconds(1f);
            }
        }

        if (mage.IsAlive)
        {
            player2Unit.monster.Exp += expGain;
            yield return dialogBox.TypeDialog($"Mage gained {expGain} exp!");
            yield return new WaitForSeconds(1f);
            while (player2Unit.monster.CheckForLevelUp())
            {
                player2Unit.SaveLevel();
                player2Hud.SetLevel();
                yield return dialogBox.TypeDialog($"Mage level up to {player2Unit.monster.level}!");
                _levelUpdate.levelUp();
                MageIslevelUp = true;
                yield return new WaitForSeconds(1f);
            }
        }
        EndBattle();
    }
    void EndBattle()
    {
        player1Unit.monster.SavePlayerHP(player1stat);
        player2Unit.monster.SavePlayerHP(player2stat);
        if (SwordIslevelUp && MageIslevelUp)
        {
            player1stat.CurrentHp = player1stat.MaxHp;
            player1stat.CurrentSp = player1stat.MaxSp;
            player2stat.CurrentHp = player2stat.MaxHp;
            player2stat.CurrentSp = player2stat.MaxSp;
            SwordIslevelUp = false;
            MageIslevelUp = false;
        }
        else if (SwordIslevelUp)
        {
            player1stat.CurrentHp = player1stat.MaxHp;
            player1stat.CurrentSp = player1stat.MaxSp;
            SwordIslevelUp = false;
        }
        else if (MageIslevelUp)
        {
            player2stat.CurrentHp = player1stat.MaxHp;
            player2stat.CurrentSp = player2stat.MaxSp;
            MageIslevelUp = false;
        }
        OnBattleOver(true);
    }
}
