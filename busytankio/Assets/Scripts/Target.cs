using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;

    public GameObject TargetObject;

    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Debug.Log(TargetObject.name + " has been destructed");
            Die();
        }
    }

    void Die ()
    {
        Destroy(gameObject);
    }
}
