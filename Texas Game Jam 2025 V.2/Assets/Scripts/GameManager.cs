using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player Stats")]
    int fakeGold = 0;
    int realGold = 0;
    public int rerolls = 0;
    public bool canRevTime = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void addGold(int amount, bool fake)
    {
        if (fake)
        {
            fakeGold += amount;
        }
        else
        {
            realGold += amount;
        }
    }
    
}
