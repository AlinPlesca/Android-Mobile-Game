using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    [SerializeField] private Text healthTxt;
    [SerializeField] private AudioSource DethEffect;
    [SerializeField] private AudioSource HealthUp;
    [SerializeField]private GameObject pl;
    [SerializeField] private Transform PlayerPos;
    [SerializeField] public GameObject enemy;
    [SerializeField] private GameObject strawberry;

    public ParticleSystem ps;
    public ParticleSystem FireDam;
    public ParticleSystem HealthParticle;

    public HealthBar healthBar;
    public FireTrap FT;

    public int maxSHealth = 100;
    public int currentHealth;

    public int damage = 20;

    public fallingPlatformScript FP;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxSHealth;
        healthBar.SetMaxHealth(maxSHealth);
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            rb.velocity = new Vector2(rb.velocity.x, 12);

            StartCoroutine(TakeDamge());
        }
        if (collision.gameObject.CompareTag("NewTrampoline"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 20);
        }

        if (currentHealth <= 0 )
        {
            Die();
            DethEffect.Play();
        }

        if (collision.gameObject.CompareTag("fallingPlatform"))
        {
            StartCoroutine(delayFalingPlatform());
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeathTrig"))
        {
            Die();
            DethEffect.Play();
            currentHealth -= 100;
            healthBar.SetHealth(currentHealth);
        }

        if (collision.gameObject.CompareTag("Traps"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 12);
            enemy.SetActive(false);
        
            ps.Play();
        }
       

        if (collision.gameObject.CompareTag("FireTrap"))
        {
            currentHealth -= 20;
            healthBar.SetHealth(currentHealth);
            StartCoroutine(TakeDamge());
            StartCoroutine(FireDamage());
        }

        if (collision.gameObject.CompareTag("Arrow"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 6);
            currentHealth -= 20;
            healthBar.SetHealth(currentHealth);
            StartCoroutine(TakeDamge());
        }

        if (collision.gameObject.CompareTag("Health"))
        {
            currentHealth += 20;
            healthBar.SetHealth(currentHealth);
            HealthUp.Play();
            Destroy(collision.gameObject);
            StartCoroutine(HealthTopUp());
        }

        if (collision.gameObject.CompareTag("StoneHead"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 6);
            currentHealth -= 20;
            healthBar.SetHealth(currentHealth);
            StartCoroutine(TakeDamge());
        }

        if (currentHealth <= 0)
        {
            Die();
            DethEffect.Play();
        }
    }

    
    private void Die()
    {
        anim.SetTrigger("TriggerDeath");
        rb.bodyType = RigidbodyType2D.Static;
    }
  
    private void ResetLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator TakeDamge()
    {
        pl.SetActive(true);
        yield return new WaitForSeconds(2);
        pl.SetActive(false);
    }

    IEnumerator FireDamage()
    {
        FireDam.gameObject.SetActive(true);
        FireDam.Play();
        yield return new WaitForSeconds(3);
        FireDam.gameObject.SetActive(false);
    }

    IEnumerator HealthTopUp()
    {
        HealthParticle.gameObject.SetActive(true);
        HealthParticle.Play();
        yield return new WaitForSeconds(2);
        HealthParticle.gameObject.SetActive(false);
    }

    IEnumerator delayFalingPlatform()
    {
        yield return new WaitForSeconds(1);
        FP.fallingPlatformRb.bodyType = RigidbodyType2D.Dynamic;

        //FP.fallingPlatformRb.mass = 0.2f;
        //FP.fallingPlatformRb.gravityScale = 0.2f;
    }
}
