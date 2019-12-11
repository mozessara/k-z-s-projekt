using UnityEngine;
using UnityEngine.SceneManagement;
public class MonsterController : MonoBehaviour
{
    public PlayerScript player;
    private void Start()
    {
        player = FindObjectOfType<PlayerScript>();
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 2f * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
