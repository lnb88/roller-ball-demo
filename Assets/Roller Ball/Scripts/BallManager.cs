using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallManager : MonoBehaviour
{
    private Rigidbody2D rb;

    private float movementSensitivity_ForEditor = 5f;
    private float movementSensitivity_ForDevice = 10f;
    private float movementX = 0f;
    private float movementY = 0f;
    private Vector2 velocity;
    
    public delegate void LevelFailDelegate();
    public static event LevelFailDelegate OnLevelFailEvent;

    public delegate void LevelClearDelegate();
    public static event LevelClearDelegate OnLevelClearEvent;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Application.isEditor)       // on editor
        {
            movementX = Input.GetAxis("Horizontal") * movementSensitivity_ForEditor;
            movementY = Input.GetAxis("Vertical") * movementSensitivity_ForEditor;
        }
        else        // on device
        {
            movementX = Input.acceleration.x * movementSensitivity_ForDevice;
            movementY = Input.acceleration.y * movementSensitivity_ForDevice;
        }
    }

    private void FixedUpdate()
    {
        MoveBall();
    }

    private void MoveBall()
    {
        velocity = rb.velocity;
        velocity.x = movementX;
        velocity.y = movementY;
        rb.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagManager.Key))
        {
            // open locked door
            GamePlayManager.instance.OpenLockedDoor();

            Destroy(collision.gameObject);

            AudioManager.instance!.PlaySound(SoundName.doorOpen);
        }
        else if (collision.gameObject.CompareTag(TagManager.Star))
        {
            GamePlayManager.instance.SetStarsCollectedCount();

            Destroy(collision.gameObject);

            AudioManager.instance!.PlaySound(SoundName.starCollect);
        }
        else if (collision.gameObject.CompareTag(TagManager.DestinationHole))
        {
            StartCoroutine(BallDropEffect(collision.gameObject.transform));
            StartCoroutine(CallLevelClear(1f));
        }
        else if (collision.gameObject.CompareTag(TagManager.Laser))
        {
            rb.simulated = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

            StartCoroutine(CallLevelFail(0.5f));

            AudioManager.instance!.PlaySound(SoundName.laserHit);
        }
        else if (collision.gameObject.CompareTag(TagManager.PitHole))
        {
            StartCoroutine(BallDropEffect(collision.gameObject.transform));
            StartCoroutine(CallLevelFail(1f));

            AudioManager.instance!.PlaySound(SoundName.obstacleImpact);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagManager.Obstacle))
        {
            AudioManager.instance!.PlaySound(SoundName.obstacleImpact);
        }
    }

    private IEnumerator CallLevelClear(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (OnLevelClearEvent != null)
        {
            OnLevelClearEvent();
        }

        AudioManager.instance!.PlaySound(SoundName.levelClear);
    }

    private IEnumerator CallLevelFail(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (OnLevelFailEvent != null)
        {
            OnLevelFailEvent();
        }

        AudioManager.instance!.PlaySound(SoundName.levelFail);
    }

    private IEnumerator BallDropEffect(Transform target)
    {
        rb.simulated = false;
        transform.position = target.position;

        yield return null;

        Vector3 mLocalScale;

        while (transform.localScale.x > 0.1f)
        {
            mLocalScale = transform.localScale;
            mLocalScale.x -= Time.deltaTime * 2;
            mLocalScale.y -= Time.deltaTime * 2;
            transform.localScale = mLocalScale;

            yield return null;
        }
    }
}
