using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    private Vector2 newPosition;
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;
    [SerializeField] private float respawnTime = 2.0f;
    [SerializeField] private int score = 10;
    [SerializeField] private int plusScore = 0;
    [SerializeField] private int minusScore = 60;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float timer = 0f;

    private void Start()
    {
        score = 10;
        scoreText.text = score.ToString();
        timer = 10f;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            newPosition = new Vector2(Random.Range(-8.0f, 8.0f), Random.Range(-4.0f, 4.0f));

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null/* && hit.collider.tag != "Player"*/)
            {
                plusScore = hit.collider.CompareTag("Player") ? 10 : 100;

                score += plusScore;

                StartCoroutine(respawnWait(hit.collider.gameObject));
                hit.transform.position = newPosition;
                //Destroy(hit.collider.transform.gameObject);
                ChangeColor(hit.collider.gameObject);
                
                //Debug.Log(score);
            }
            else
            {
                score -= minusScore;
            }
        }

        timer -= 5f * Time.deltaTime;

        if (timer <= 0)
        {
            timer = 10f;
            score -= 1;
        }

        if (score < 0)
        {
            score = 0;
            lose();
        }
        if (score >= 999)
        {
            score = 999;
        }

        win();

        scoreText.text = score.ToString();
    }

    void win()
    {
        if (score >= 999)
        {
            SceneManager.LoadScene(3);
        }
    }
    void lose()
    {
        SceneManager.LoadScene(2);
    }

    void ChangeColor(GameObject obj)
    {        
        int length = obj.CompareTag("Player") ? obj.GetComponent<Player>().colors.Length : obj.GetComponent<Enemy>().colors.Length;
        int color = Random.Range(0, length);
        
        obj.GetComponentInChildren<SpriteRenderer>().color = obj.CompareTag("Player") ? obj.GetComponent<Player>().colors[color] : obj.GetComponent<Enemy>().colors[color];
    }

    IEnumerator respawnWait(GameObject obj)
    {
        obj.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnTime);
        obj.gameObject.SetActive(true);
    }
}
