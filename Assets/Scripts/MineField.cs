using UnityEngine;

public class MineField : MonoBehaviour {

    public GameObject mine;

    int x;
    int y;
    int numberOfElements;
    int numberOfBombs;
    Mine[] mines;

    void Start()
    {
        GameManager.singleton.StartGame();
    }

    public void GenerateMineField(int x, int y, int numberOfBombs)
    {
        this.x = x;
        this.y = y;
        this.numberOfBombs = numberOfBombs;
        mines = new Mine[x * y];

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                mines[i * y + j] = Instantiate(mine, new Vector2(0, 0), Quaternion.identity, transform).GetComponent<Mine>();
                mines[i * y + j].id = i * y + j;
            }
        }
        UpdateFieldSize();
    }

    public void GenerateBombs()
    {
        numberOfElements = x * y;
        bool[] bombs = new bool[numberOfElements];
        for (int i = 0; i < numberOfElements; i++)
        {
            bombs[i] = false;
        }

        for (int i = 0; i < numberOfBombs; i++)
        {
            while (true)
            {
                int num = Random.Range(0, numberOfElements);
                if (!bombs[num])
                {
                    bombs[num] = true;
                    break;
                }
            }
        }

        for (int i = 0; i < numberOfElements; i++)
        {
            if (bombs[i])
            {
                transform.GetChild(i).GetComponent<Mine>().SetMine(9, true);
            }
            else
            {
                int num = 0;
                if (i - y - 1 >= 0 && i%y != 0 && bombs[i - y - 1])
                    num++;
                if (i - y >= 0 && bombs[i - y])
                    num++;
                if (i - y + 1 >= 0 && i % y != 9 && bombs[i - y + 1])
                    num++;

                if (i - 1 >= 0 && i % y != 0 && bombs[i - 1])
                    num++;
                if (i + 1 < numberOfElements && i % y != 9 && bombs[i + 1])
                    num++;

                if (i + y - 1 < numberOfElements && i % y != 0 && bombs[i + y - 1])
                    num++;
                if (i + y < numberOfElements && bombs[i + y])
                    num++;
                if (i + y + 1 < numberOfElements && i % y != 9 && bombs[i + y + 1])
                    num++;

                transform.GetChild(i).GetComponent<Mine>().SetMine(num, false);
            }
        }
    }

    public void GenerateBombs(int id)
    {
        numberOfElements = x * y;
        bool[] bombs = new bool[numberOfElements];
        for (int i = 0; i < numberOfElements; i++)
        {
            bombs[i] = false;
        }

        bombs[id] = true;

        for (int i = 0; i < numberOfBombs; i++)
        {
            while (true)
            {
                int num = Random.Range(0, numberOfElements);
                if (!bombs[num])
                {
                    bombs[num] = true;
                    break;
                }
            }
        }

        bombs[id] = false;

        for (int i = 0; i < numberOfElements; i++)
        {
            if (bombs[i])
            {
                transform.GetChild(i).GetComponent<Mine>().SetMine(9, true);
            }
            else
            {
                int num = 0;
                if (i - y - 1 >= 0 && i % y != 0 && bombs[i - y - 1])
                    num++;
                if (i - y >= 0 && bombs[i - y])
                    num++;
                if (i - y + 1 >= 0 && i % y != 9 && bombs[i - y + 1])
                    num++;

                if (i - 1 >= 0 && i % y != 0 && bombs[i - 1])
                    num++;
                if (i + 1 < numberOfElements && i % y != 9 && bombs[i + 1])
                    num++;

                if (i + y - 1 < numberOfElements && i % y != 0 && bombs[i + y - 1])
                    num++;
                if (i + y < numberOfElements && bombs[i + y])
                    num++;
                if (i + y + 1 < numberOfElements && i % y != 9 && bombs[i + y + 1])
                    num++;

                transform.GetChild(i).GetComponent<Mine>().SetMine(num, false);
            }
        }
    }

    public void UpdateFieldSize()
    {
        Vector2 size = GetComponent<RectTransform>().sizeDelta;
        float scale = Mathf.Min(size.x / x, size.y / y);
        Vector2 offset = new Vector2((size.x - (scale * x)) / 2, (size.y - (scale * y)) / 2);

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                GameObject go = transform.GetChild(i * y + j).gameObject;
                go.GetComponent<RectTransform>().sizeDelta = new Vector2(scale, scale);
                go.GetComponent<RectTransform>().anchoredPosition = new Vector2(scale * i, scale * j) + offset;
            }
        }
    }

    public void UncoverNearbyFields(int id)
    {
        if (id - y - 1 >= 0 && id % y != 0 && mines[id - y - 1] != null)
            mines[id - y - 1].Uncover();
        if (id - y >= 0 && mines[id - y] != null)
            mines[id - y].Uncover();
        if (id - y + 1 >= 0 && id % y != 9 && mines[id - y + 1] != null)
            mines[id - y + 1].Uncover();

        if (id - 1 >= 0 && id % y != 0 && mines[id - 1] != null)
            mines[id - 1].Uncover();
        if (id + 1 < numberOfElements && id % y != 9 && mines[id + 1] != null)
            mines[id + 1].Uncover();

        if (id + y - 1 < numberOfElements && id % y != 0 && mines[id + y - 1] != null)
            mines[id + y - 1].Uncover();
        if (id + y < numberOfElements && mines[id + y] != null)
            mines[id + y].Uncover();
        if (id + y + 1 < numberOfElements && id % y != 9 && mines[id + y + 1] != null)
            mines[id + y + 1].Uncover();
    }
}
