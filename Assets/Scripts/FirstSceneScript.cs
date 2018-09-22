using UnityEngine;
using UnityEngine.UI;

public class FirstSceneScript : MonoBehaviour {

    public InputField x;
    public InputField y;
    public InputField bombs;
    public Toggle firstSafe;

    void Start()
    {
        x.text = GameManager.singleton.x.ToString();
        y.text = GameManager.singleton.y.ToString();
        bombs.text = GameManager.singleton.bombs.ToString();
        firstSafe.isOn = GameManager.singleton.firstCheckSafe;
    }

    public void ChangeX(string number)
    {
        GameManager.singleton.x = int.Parse(number);
        if (GameManager.singleton.bombs > GameManager.singleton.x * GameManager.singleton.y - 1)
        {
            GameManager.singleton.bombs = GameManager.singleton.x * GameManager.singleton.y - 1;
            bombs.text = GameManager.singleton.bombs.ToString();
        }
    }

    public void ChangeY(string number)
    {
        GameManager.singleton.y = int.Parse(number);
        if (GameManager.singleton.bombs > GameManager.singleton.x * GameManager.singleton.y - 1)
        {
            GameManager.singleton.bombs = GameManager.singleton.x * GameManager.singleton.y - 1;
            bombs.text = GameManager.singleton.bombs.ToString();
        }   
    }

    public void ChangeBombs(string number)
    {
        int bombsNum = int.Parse(number);
        if (bombsNum > GameManager.singleton.x * GameManager.singleton.y - 1)
        {
            bombsNum = GameManager.singleton.x * GameManager.singleton.y - 1;
            bombs.text = bombsNum.ToString();
        }   
        Debug.Log(GameManager.singleton.x * GameManager.singleton.y - 1);
        GameManager.singleton.bombs = bombsNum;
    }

    public void ChangeFirstSafe(bool safe)
    {
        GameManager.singleton.firstCheckSafe = safe;
    }
}
