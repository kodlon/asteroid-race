using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private bl_Joystick joystick;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private SpriteRenderer gunDrone;
    [SerializeField] private Animator bonusPanel;
    [SerializeField] private ChangeSettings joystickActive;

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

            if (joystickActive.Active)
            {
                MoveJoystick();
                joystick.gameObject.SetActive(true);
            }
            else
            {
                MoveAcceleration();
                joystick.gameObject.SetActive(false);
            }

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


    private void MoveAcceleration()
    {
        float horizontalAxis = Input.acceleration.x;
        float verticalAxis = Input.acceleration.y;

        Vector3 translate = (new Vector3(horizontalAxis, verticalAxis, 0) * Time.deltaTime) * SPEED_ACCELERATION;
        transform.Translate(translate);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "asteroid")
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
                GameOver();
            }

            Destroy(other.transform.parent.gameObject);
        }
        else if (other.tag == "bonus")
        {
            StopAllCoroutines();


            if (!bonusActive)
            {
                int powerOfBonus = UnityEngine.Random.Range(0, 4);

                bonusSound.Play();
                bonusActive = true;
                switch (powerOfBonus)
                {
                    case 0:
                        health++;
                        playerSprite.color = new Color(1f, 0.1686275f, 0.1686275f, 1.0f);
                        bonusPanel.SetInteger("ChangeAnim", 1);
                        break;
                    case 1:
                        StartCoroutine(PlayerBonuses.GunBonusCoroutine(gunDrone, bonusPanel));
                        bonusPanel.SetInteger("ChangeAnim", 2);
                        break;
                    case 2:
                        StartCoroutine(PlayerBonuses.TimeBonusCoroutine(bonusPanel));
                        bonusPanel.SetInteger("ChangeAnim", 3);
                        break;
                    case 3:
                        bonusPanel.SetInteger("ChangeAnim", 4);
                        StartCoroutine(PlayerBonuses.SizeBonusCoroutine(bonusPanel, transform));
                        break;
                }

                Destroy(other.gameObject);

            }
        }
    }

    private void ScoreChanging()
    {
        score += (transform.position.y - (-3.0f)) - ((transform.position.y - (-3.0f)) / 1.5f);
        scoreText.text = Mathf.Round(score).ToString() + " km";
    }


    private void GameOver()
    {
        if (score > PlayerPrefs.GetFloat("Score"))
            PlayerPrefs.SetFloat("Score", score);
        score = 0.0f;
        gameActive = false;
        Time.timeScale = 1.0f;
        SpawnBullet.Active = false;
        transform.localScale = Vector3.one;
        bonusPanel.SetInteger("ChangeAnim", 0);

        Ads.ADS();
        SceneManager.LoadScene("Main");
    }

}
