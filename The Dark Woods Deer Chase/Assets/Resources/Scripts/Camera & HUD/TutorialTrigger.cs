using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class TutorialTrigger : MonoBehaviour
    {
        public Tutorial current_tutorial;

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                InitiateDialogue();
            }
        }

        public void InitiateDialogue()
        {
            FindObjectOfType<TutorialManager>().StartDialogue(current_tutorial);
        }
    }
}