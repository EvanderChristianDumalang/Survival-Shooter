using UnityEngine;

public class Healing : PowerUp
{
    GameObject player;
    PlayerHealth playerHealth;
    public AudioSource healingAudio;

    public override void Awake()
    {
        //Mencari tag "Player"
        player = GameObject.FindGameObjectWithTag("Player");

        //Komponen player health
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    //Check object masuk kedalam trigger
    public override void OnTriggerEnter(Collider other)
    {
        //Set player in range
        float dist = Vector3.Distance(other.transform.position, transform.position);
        if ((other.tag == "Player") && (dist < 1.5))
        {
            playerHealth.Healing();
            this.gameObject.SetActive(false);
        }
    }
}
