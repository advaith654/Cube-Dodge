using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyAI : MonoBehaviour
{
    public float speed = 3f;

    private Rigidbody rb;
    private Transform player;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        GameObject target = GameObject.FindGameObjectWithTag("Player");

        if (target != null)
            player = target.transform;
    }

    private void FixedUpdate()
    {
        if (player == null)
            return;

        Vector3 direction =
            (player.position - transform.position).normalized;

        rb.MovePosition(
            rb.position +
            direction *
            speed *
            Time.fixedDeltaTime);
    }

    public void IncreaseSpeed(float amount)
    {
        speed += amount;
    }
}