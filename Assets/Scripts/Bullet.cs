using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public float speed;
    protected Vector2 direction;
    [SerializeField] protected int damage;

    private float delay;

    private bool canDealDamage;

    protected SpriteRenderer rend;
    protected Rigidbody2D body;

    public virtual void Initialize()
    {
        rend = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();

        HideMe();
    }

    public virtual void Refresh()
    {
        rend.color = Color.white;
        body.velocity = Vector2.zero;
        canDealDamage = true;
    }

    public virtual void Activate(Vector2 pos, Vector2 direction, float delay)
    {
        this.transform.position = pos;
        this.direction = direction;
        Invoke("SetInMotion", delay);
    }

    private void HideMe()
    {
        rend.color = Color.clear;
    }

    public bool GetCanDealDamage()
    {
        return canDealDamage;
    }

    public void SetCanDealDamage(bool value)
    {
        canDealDamage = value;
    }

    public virtual void HandleCollision(GameObject target)
    {
        IDamageable dmg = target.GetComponent<IDamageable>();
        if (dmg != null && canDealDamage)
        {
            canDealDamage = false;
            dmg.TakeDamage(damage, direction);
        }
    }

    public virtual void SetInMotion()
    {
        body.velocity = direction * speed;
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        HandleCollision(collision.gameObject);
    }
}
