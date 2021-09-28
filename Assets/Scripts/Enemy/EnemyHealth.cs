using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;


    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;


    void Awake()
    {
        //Menapatkan reference komponen
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        //Set current health
        currentHealth = startingHealth;
    }


    void Update()
    {
        //Check jika sinking
        if (isSinking)
        {
            //memindahkan object kebawah
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        //Check jika dead
        if (isDead)
            return;

        //play audio
        enemyAudio.Play();

        //kurangi health
        currentHealth -= amount;

        //Ganti posisi particle
        hitParticles.transform.position = hitPoint;

        //Play particle system
        hitParticles.Play();

        //Dead jika health <= 0
        if (currentHealth <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        //set isdead
        isDead = true;

        //SetCapcollider ke trigger
        capsuleCollider.isTrigger = true;

        //trigger play animation Dead
        anim.SetTrigger("Dead");

        //Play Sound Dead
        enemyAudio.clip = deathClip;
        enemyAudio.Play();
    }

    public void StartSinking()
    {
        //disable Navmesh Component
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        //Set rigisbody ke kimematic
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
        Destroy(gameObject, 2f);
    }
}