using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    [SerializeField] private int _posIndex = 0;
    private float _heightIndex = -1.5f;
    [SerializeField] private float _speed = 0.1f;
    [SerializeField] private int _lifes = 3;
    [SerializeField] private int _maxLifes = 3;
    private void Movement()
    {
        transform.Translate((_posIndex - transform.position.x) * _speed, (_heightIndex - transform.position.y) * _speed, 0f);

    }
    public void Heal(int Value)
    {
        if (_lifes < _maxLifes)
        {
            _lifes += Value;
        }

    }

    public void LeftMove()
    {
        if (_posIndex > -1)
        {
            _posIndex--;

        }
    }
    public void RightMove()
    {
        if (_posIndex < 1)
        {
            _posIndex++;
        }
    }
    public void DownMove()
    {
        if (_heightIndex != -1.5f)
        {
            _heightIndex = -1.5f;
        }
    }
    public void UpMove()
    {
        if (_heightIndex != 1.5)
        {
            _heightIndex = 1.5f;
        }
    }
    public void Hirt()
    {
        if (_lifes > 1)
        {
            _lifes--;
        }
        else
        {
            Dead();
        }

    }
    private void Dead()
    {
        Destroy(this.gameObject);
        Time.timeScale = 0f;
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            RightMove();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            LeftMove();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            UpMove();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            DownMove();
        }


        Movement();


    }
}