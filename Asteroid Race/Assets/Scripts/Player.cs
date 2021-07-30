using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private bl_Joystick joystick;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private Image blackScreen;
    [SerializeField] private SpriteRenderer gunDrone;
    [SerializeField] private Animator bonusPanel;

    [SerializeField] private AudioSource engineSound;
    [SerializeField] private AudioSource damageSound;
    [SerializeField] private AudioSource bonusSound;

    private const float SPEED = 1.0f;
    private const float SPEED_ACCELERATION = 10.0f;
    private int health = 1;
    private static float score = 0.0f;

    public static float Score
    {
        get { return score; }
    }


    private static bool gameActive = false;
    private static bool bonusActive = false;

    public static bool BonusActive
    {
        get { return bonusActive; }
        set { bonusActive = value; }
    }


    public static bool GameActive
    {
        get { return gameActive; }
        set { gameActive = value; }
    }
    private void Update()
    {
        if (gameActive)
        {
            float verticalAxis = joystick.Vertical;

            engineSound.volume = 1;
            engineSound.pitch = (verticalAxis / 10) + 1;

            MoveJoystick();

            //Position limit
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.2f, 2.2f),
                                            Mathf.Clamp(transform.position.y, -2.4f, 3.7f), 0);
            if (!Pause.IsPaused)
                ScoreChanging();
        }
    }


    private void MoveJoystick()
    {
        float horizontalAxis = joystick.Horizontal;
        float verticalAxis = joystick.Vertical;

        Vector3 translate = (new Vector3(horizontalAxis, verticalAxis, 0) * Time.deltaTime) * SPEED;
        transform.Translate(translate);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("asteroid"))
        {
            health--;
            damageSound.Play();

            if (bonusActive)
            {
                playerSprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                bonusActive = false;
                bonusPanel.SetInteger("ChangeAnim", 0);
            }


            if (health == 0)
            {
                StartCoroutine(GameOver());

            }

            Destroy(other);
        }
        else if (other.CompareTag("bonus"))
        {
            StopAllCoroutines();

            if (!bonusActive)
            {
                bonusSound.Play();
                bonusActive = true;

                IBonuses bonus = other.GetComponent<IBonuses>();

                if (bonus != null)
                    StartCoroutine(bonus.BonusCorutine(gunDrone, bonusPanel, transform));

                Destroy(other.gameObject);
            }
        }
    }

    private void ScoreChanging()
    {
        score += (transform.position.y - (-3.0f)) - ((transform.position.y - (-3.0f)) / 1.5f);
        scoreText.text = Mathf.Round(score).ToString() + " km";
    }

    private IEnumerator GameOver()
    {
        if (score > PlayerPrefs.GetFloat("Score"))
            PlayerPrefs.SetFloat("Score", score);
        score = 0.0f;
        Time.timeScale = 1.0f;
        gameActive = false;
        SpawnBullet.Active = false;
        transform.localScale = Vector3.one;
        bonusPanel.SetInteger("ChangeAnim", 0);

        //yield return StartCoroutine(BlackScreen());

        Ads.ADS();
        SceneManager.LoadScene("Main");


        yield return null;
    }

    private IEnumerator BlackScreen()
    {
        for (float i = 0.0f; i < 1.0f; i += 0.01f)
        {
            blackScreen.color = new Color(0f, 0f, 0f, i);

            yield return new WaitForSeconds(0.0f);
        }
    }

}
