using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollider : MonoBehaviour
{
    [SerializeField]
    Animator _mAnimator;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject BloodPrefab;

    [Space]
    [SerializeField]
    float bumpForce = 30f;

    private HealthBarHUDTester healthController;
    public int damage = 1;
    private AudioSource audioSource;
    public AudioSource playerSound;
    public AudioClip[] sounds;

    private void Start()
    {
        healthController = GameObject.Find("HealthBarHUDTester").GetComponent<HealthBarHUDTester>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            audioSource.Play();
            healthController.Hurt(damage);

            GameObject blood = Instantiate(BloodPrefab, player.transform.position, Quaternion.identity);
            Destroy(blood, .8f);

            _mAnimator.Play("Demo_Type3_Die");

            Debug.Log(PlayerStats.Instance.Health);
            if (PlayerStats.Instance.Health <= 0)
            {
                playerSound.clip = sounds[1];
                _mAnimator.Play("Demo_Type3_Die");
                StartCoroutine(Death());
            }
            else
            {
                playerSound.clip = sounds[0];
            }
            playerSound.Play();
        }
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(.8f);
        SceneManager.LoadScene("Environment");
    }
}
