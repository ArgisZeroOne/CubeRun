
using UnityEngine;

public class GameLogicScript : MonoBehaviour
{
    [SerializeField] private int _money = 0;
    public void GetMoney(int Value)
    {
        _money += Value;
    }

}
