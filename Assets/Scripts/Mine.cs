using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Mine : MonoBehaviour, IPointerClickHandler {

    public Sprite hidden;
    public Sprite shown;
    public Sprite flag;
    public Sprite bomb;
    public Text text;

    int number = 0;
    bool isBomb = false;
    public int id;
    bool clicked = false;

    bool marked = false;

    public void SetMine(int num, bool isbomb)
    {
        number = num;
        isBomb = isbomb;
        text.gameObject.GetComponent<RectTransform>().sizeDelta = GetComponent<RectTransform>().sizeDelta;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            GameManager.singleton.Click(id);
            if (!marked)
                Uncover();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (marked)
            {
                GetComponent<Image>().sprite = hidden;
                marked = false;
                Counter.singleton.TakeFlag();
            }
            else
            {
                GetComponent<Image>().sprite = flag;
                marked = true;
                Counter.singleton.PlaceFlag();
            }
        }
    }

    public void Uncover()
    {
        if (clicked)
            return;
        clicked = true;
        if (isBomb)
        {
            GetComponent<Image>().sprite = bomb;
            GameManager.singleton.LoseGame();
            Destroy(this);
            return;
        }
        if (number != 0)
            text.text = number.ToString();
        else 
            GameManager.singleton.mineField.UncoverNearbyFields(id);

        GetComponent<Image>().sprite = shown;
        Counter.singleton.UncoverField();
        Destroy(this);
    }
}
