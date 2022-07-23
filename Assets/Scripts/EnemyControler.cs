
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    [SerializeField] private float _speed = -0.1f;
    private void FixedUpdate()
    {
        transform.Translate(0f,0f,_speed);
    }
}
