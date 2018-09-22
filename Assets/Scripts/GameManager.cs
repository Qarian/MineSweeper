using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool firstCheckSafe = true;

    public int x = 10;
    public int y = 10;
    public int bombs = 5;

    public GameObject WinScreen;
    public GameObject LoseScreen;

    [HideInInspector]
    public MineField mineField;
    Timer timer;

    bool firstClick;

    #region Singleton
    public static GameManager singleton;

    void Awake()
    {
        if (singleton != null)
        {
            Destroy(gameObject);
            return;
        }
        singleton = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public void StartGame()
    {
        mineField = FindObjectOfType<MineField>();
        timer = FindObjectOfType<Timer>();

        firstClick = true;

        mineField.GenerateMineField(x, y, bombs);
        Counter.singleton.StartGame(x*y, bombs);
        if (!firstCheckSafe)
            mineField.GenerateBombs();
    }

    public void Click(int id)
    {
        if (firstClick)
        {
            firstClick = false;
            FirstClick(id);
        }
    }

    void FirstClick(int id)
    {
        if(firstCheckSafe)
            mineField.GenerateBombs(id);
        timer.StartTimer();
    }

    public void WinGame()
    {
        Instantiate(WinScreen, Counter.singleton.transform.parent);
        timer.StopTimer();
    }

    public void LoseGame()
    {
        Instantiate(LoseScreen, Counter.singleton.transform.parent);
        timer.StopTimer();
    }
}
