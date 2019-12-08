using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialManager : MonoBehaviour
{
    // Variables
    public static bool is_in_tutorial = false;
    public GameObject tutorial_box;
    public GameObject jump_button;
    public Animator tutorial_animator;

    //private Text tutorial_name;
    private Image tutorial_image1;
    private Image tutorial_image2;
    private Text tutorial_content;
    private Queue<string> AllSentences;
    // Start is called before the first frame update
    private void Start()
    {
        tutorial_image1 = tutorial_box.transform.GetChild(0).GetComponent<Image>();
        tutorial_image2 = tutorial_box.transform.GetChild(1).GetComponent<Image>();
        tutorial_content = tutorial_box.transform.GetChild(2).GetComponent<Text>();
        AllSentences = new Queue<string>();
    }
    public void StartDialogue(Tutorial CurrentDialogue)
    {
        is_in_tutorial = true;
        jump_button.SetActive(false);
        tutorial_animator.SetBool("IsOpen", true);
        tutorial_image1.sprite = CurrentDialogue.action_image;
        tutorial_image2.sprite = CurrentDialogue.result_image;
        AllSentences.Clear();
        foreach(string sentence in CurrentDialogue.sentences)
        {
            AllSentences.Enqueue(sentence);
        }
        Time.timeScale = 0;
        NextDialogueSentence();
    }
    public void NextDialogueSentence()
    {
        if(AllSentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        else
        {
            string CurrentSentence = AllSentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(CurrentSentence));
        }
    }
    void EndDialogue()
    {
        Time.timeScale = 1;
        is_in_tutorial = false;
        tutorial_animator.SetBool("IsOpen", false);
        jump_button.SetActive(true);
    }
    IEnumerator TypeSentence(string Sentence)
    {
        tutorial_content.text = "";
        foreach(char letter in Sentence)
        {
            tutorial_content.text += letter;
            yield return null;
        }
    }
}