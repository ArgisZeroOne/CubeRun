
using UnityEngine;

public class EnemyOrHelperControler : MonoBehaviour
{
    [SerializeField] private float _speed = -0.1f;
    private void FixedUpdate()
    {
        transform.Translate(0f, 0f, _speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EndMap")
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.GetComponent<PlayerScript>())
        {
            if (this.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<PlayerScript>().Hirt();
            }
            else if (this.gameObject.tag == "Healer")
            {
                other.gameObject.GetComponent<PlayerScript>().Heal(1);
            }
            else if (this.gameObject.tag == "Money")
            {
                GameObject.FindWithTag("GameLogic").GetComponent<GameLogicScript>().GetMoney(1);

            }

            Destroy(this.gameObject);
        }
    }
}
