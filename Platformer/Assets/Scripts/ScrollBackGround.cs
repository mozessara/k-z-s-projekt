using UnityEngine;

public class ScrollBackGround : MonoBehaviour
{
    float scrollTime = 0;
    float scrollingSpeed = 0.05f;
    PlayerScript player;
    private void Start()
    {
        player = FindObjectOfType<PlayerScript>();
    }
    private void Update()
    {
        if (player.horizontalMove > 0) scrollTime += Time.deltaTime;
        else if (player.horizontalMove < 0) scrollTime -= Time.deltaTime;

        Vector2 offset = new Vector2(scrollTime * scrollingSpeed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
