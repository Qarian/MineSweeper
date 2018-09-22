using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour {

    public Text emptyField;
    public Text flag;

    int fieldSize;
    int bombs;

    int flags;
    int uncoveredFields;

    public static Counter singleton;

    private void Awake()
    {
        singleton = this;
    }

    public void StartGame(int fieldSize, int bombs)
    {
        this.fieldSize = fieldSize - bombs;
        this.bombs = bombs;

        flags = 0;
        uncoveredFields = 0;

        UpdateFieldsCounter();
        UpdateFlagsCounter();
    }

    public void UncoverField()
    {
        uncoveredFields++;
        UpdateFieldsCounter();
    }

    public void PlaceFlag()
    {
        flags++;
        UpdateFlagsCounter();
    }

    public void TakeFlag()
    {
        flags--;
        UpdateFlagsCounter();
    }

    void UpdateFieldsCounter()
    {
        emptyField.text = string.Format("{0}/{1}", uncoveredFields, fieldSize);
        if (uncoveredFields == fieldSize)
            GameManager.singleton.WinGame();
    }

    void UpdateFlagsCounter()
    {
        flag.text = string.Format("{0}/{1}", flags, bombs);
    }
}
