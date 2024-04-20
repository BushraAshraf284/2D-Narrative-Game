using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cain : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Sprite OpenTab;
    void Start()
    {
        Events.Conversation.ConversationStateChange += ChangeSprite;
    }

    // Update is called once per frame
    private void ChangeSprite(bool ConversationStop)
    {
        if(ConversationStop)
            sprite.sprite = OpenTab;
    }
}
