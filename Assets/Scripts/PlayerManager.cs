using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool isGameOver;
    public GameObject gameOverScreen;

    public static Vector2 lastCheckPointPos = new Vector2(1,0);

    private Merchant _merchant;
    public GameObject merchant;
    //private AllMenu _allMenu;
    [SerializeField] private MonsterBase player1stats;
    [SerializeField] private MonsterBase player2stats;
    [SerializeField] private BattleUnit player1;
    [SerializeField] private BattleUnit player2;
 
    private void Awake()
    {
        isGameOver = false;
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //_allMenu = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AllMenu>();
        _merchant = merchant.GetComponent<Merchant>();
        _merchant.allStartActive = false;
       // _allMenu.findBattle = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
    }

    public void ReplayLevel()
    {
        Cursor.visible = false;
        _merchant.allStartActive = false;
        //_allMenu.findBattle = false;
        isGameOver = false;
        Time.timeScale = 1f;
        UseCheckPoint();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UseCheckPoint()
    {
        player1.monster.Base.IsAlive = true;
        player2.monster.Base.IsAlive = true;
        player1.level = player1stats.SavedLevel;
        player1.monster.Exp = player1stats.SavedExp;
        player1.monster.HP = player1stats.SavedHp;
        player1.monster.SP = player1stats.SavedSp;
        player2.level = player2stats.SavedLevel;
        player2.monster.Exp = player2stats.SavedExp;
        player2.monster.HP = player2stats.SavedHp;
        player2.monster.SP = player2stats.SavedSp;
    }
}
