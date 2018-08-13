using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private CharacterStats stats;
    private Animator animator;
    private AudioSource audioData;
    private AudioSource audioDatadead;
    private AudioSource audioDataPowerup;



    public Slider hitpointSlider;
    public Slider fuelSlider;

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audioData = GetComponents<AudioSource>()[0];
        audioDatadead = GetComponents<AudioSource>()[2];
        audioDataPowerup = GetComponents<AudioSource>()[3];
        stats = GetComponent<PlayerRogueLikeControll>().stats;
        animator = GetComponent<Animator>();
        hitpointSlider = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Slider>();
        fuelSlider = GameObject.FindGameObjectWithTag("FuelBar").GetComponent<Slider>();

        hitpointSlider.maxValue = stats.maxHitpoint;
        hitpointSlider.value = stats.hitpoint;

        fuelSlider.maxValue = stats.maxFuel;
        fuelSlider.value = stats.fuel;
    }

    void Start ()
	{
	    stats = GetComponent<PlayerRogueLikeControll>().stats;
	    audioData = GetComponents<AudioSource>()[0];
	    audioDatadead = GetComponents<AudioSource>()[2];
	    audioDataPowerup = GetComponents<AudioSource>()[3];

        animator = GetComponent<Animator>();
        hitpointSlider = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Slider>();
	    fuelSlider = GameObject.FindGameObjectWithTag("FuelBar").GetComponent<Slider>();

        hitpointSlider.maxValue = stats.maxHitpoint;
	    hitpointSlider.value = stats.hitpoint;

	    fuelSlider.maxValue = stats.maxFuel;
	    fuelSlider.value = stats.fuel;
    }
	
	// Update is called once per frame
	void Update () {
	    if (stats.isInvulnerable == true)
	    {
	        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.2f);
            if (Time.time > stats.recoveryTime)
	        {
	            stats.isInvulnerable = false;
	            //transform.GetComponent<Rigidbody2D>().isKinematic = true;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1.0f);
            }

        }
	}

    public void UpdateHealth()
    {
        if (stats.hitpoint > stats.maxHitpoint)
            stats.hitpoint = stats.maxHitpoint;
        if (stats.fuel > stats.maxFuel)
            stats.fuel = stats.maxFuel;
        hitpointSlider.value = stats.hitpoint;
    }

    public void UpdateFuel()
    {
        if (stats.hitpoint > stats.maxHitpoint)
            stats.hitpoint = stats.maxHitpoint;
        if (stats.fuel > stats.maxFuel)
            stats.fuel = stats.maxFuel;
        fuelSlider.value = stats.fuel;
    }

    public void Regenerate(EnergyStats eStats)
    {
        stats.hitpoint += eStats.healthRegen;
        if (stats.hitpoint > stats.maxHitpoint)
            stats.hitpoint = stats.maxHitpoint;
        if (stats.fuel > stats.maxFuel)
            stats.fuel = stats.maxFuel;
        stats.fuel += eStats.fuelRegen;
        UpdateHealth();
        UpdateFuel();
        audioDataPowerup.Play(0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Goop")
            TakeDamage(10);
        if (col.tag == "OrbitProjectile")
            TakeDamage(col.GetComponent<OrbitProjectileBehavior>().stats.damage);
        if (col.tag == "Projectile")
            TakeDamage(col.GetComponent<ProjectileBehavior>().projectileStats.damage);
    }

    public void TakeDamage(int damage)
    {
        if (stats.isDead == false)
        {
            if (stats.isInvulnerable == false)
            {
                /*transform.GetComponent<Rigidbody2D>().isKinematic = false;
                 transform.GetComponent<Rigidbody2D>().AddForce(moveDirection.normalized * 250f);
                Debug.Log(moveDirection);*/
                stats.hitpoint -= damage;
                stats.recoveryTime = Time.time + stats.universalRecoveryTime;
                stats.isInvulnerable = true;
                audioData.Play(0);
                UpdateHealth();
            }

            if (stats.hitpoint <= 0)
            {
                Die();
                audioDatadead.Play(0);
            }
        }
    }

    void Die()
    {
        stats.isDead = true;
        Destroy(GameObject.FindGameObjectWithTag("Player"), 3.6f);
        Destroy(GameObject.FindGameObjectWithTag("HealthBar"));
        Destroy(GameObject.FindGameObjectWithTag("FuelBar"));
        Destroy(GameObject.FindGameObjectWithTag("Persitant"));
        Destroy(GameObject.FindGameObjectWithTag("Music"));

        StartCoroutine(LoadAfterWait("MainMenu"));
        animator.SetBool("IsDead", true);
    }

    IEnumerator LoadAfterWait(string levelName)

    {

        yield return new WaitForSeconds(3.5f); // wait 2 seconds
        SceneManager.LoadScene(levelName);
    }
}
