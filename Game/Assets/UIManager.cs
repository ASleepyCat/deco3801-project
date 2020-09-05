using System.Collections;
using System.Collections.Generic;
using VIDE_Data; //Access VD class to retrieve node data
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject dialogueContainer;
    public GameObject containerNPC;
    public GameObject containerPlayer;
    public Text npcText;
    public Text npcLabel;
    public Text playerLabel;
    public Text[] textChoices;
    bool animatingText = false;

    IEnumerator NPC_TextAnimator;

    // Start is called before the first frame update
    void Start()
    {
        containerNPC.SetActive(false);
        containerPlayer.SetActive(false);
        dialogueContainer.SetActive(false);
    }

    //This begins the dialogue and progresses through it (Called by VIDEDemoPlayer.cs)
    public void Interact(VIDE_Assign dialogue)
    {
   

        if (!VD.isActive)
        {
            Begin(dialogue);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!VD.isActive)
            {
                Begin(GetComponent<VIDE_Assign>());
            }
            else {
                VD.Next();
            }
        }
    }

    // Begins the dialogue sequence
    void Begin(VIDE_Assign dialogue)
    {
        //Reset the NPC text variables
        npcText.text = "";
        npcLabel.text = "";
        playerLabel.text = "";

        // Subscribes the UpdateUI and End methods to the OnNodeChange and OnEnd events respectively 
        VD.OnNodeChange += UpdateUI;
        VD.OnEnd += End;
        VD.BeginDialogue(dialogue);
    }

    void UpdateUI(VD.NodeData data)
    {
        // Hides the dialogue containers on screen
        containerNPC.SetActive(false);
        containerPlayer.SetActive(false);
        dialogueContainer.SetActive(true);

        if (data.isPlayer)
        {
            containerPlayer.SetActive(true);
            for (int i = 0; i < textChoices.Length; i++)
            {
                // Only displays the number of buttons need for the comments and hides the rest
                if (i < data.comments.Length)
                {
                    // Displays the parent button and updates the text
                    textChoices[i].transform.parent.gameObject.SetActive(true);
                    textChoices[i].text = data.comments[i];
                } else
                {
                    textChoices[i].transform.parent.gameObject.SetActive(false);
                }
            }
            
        } else
        {
            containerNPC.SetActive(true);

            //This coroutine animates the NPC text instead of displaying it all at once
            NPC_TextAnimator = DrawText(data.comments[data.commentIndex], 0.02f);
            StartCoroutine(NPC_TextAnimator);
        }
    }

    void End(VD.NodeData data)
    {
        // Once the dialogue has ended hide the dialogue box and unsubscribe the functions
        containerPlayer.SetActive(false);
        containerNPC.SetActive(false);
        VD.OnNodeChange -= UpdateUI;
        VD.OnEnd -= End;
        VD.EndDialogue();
    }

    void OnDisable()
    {
        if (containerNPC !=  null)
        {
            End(null);
        }
    }

    public void SetPlayerChoice(int choice)
    {
        // This is added as onClick function to the dialogue buttons
        VD.nodeData.commentIndex = choice;
        if (Input.GetMouseButtonUp(0))
            VD.Next();
    }

    IEnumerator DrawText(string text, float time)
    {
        animatingText = true;

        string[] words = text.Split(' ');

        // This loop prints out the letters in a comment one by one rather than all at once
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            if (i != words.Length - 1) word += " ";

            string previousText = npcText.text;

            float lastHeight = npcText.preferredHeight;
            npcText.text += word;
            if (npcText.preferredHeight > lastHeight)
            {
                previousText += System.Environment.NewLine;
            }

            for (int j = 0; j < word.Length; j++)
            {
                npcText.text = previousText + word.Substring(0, j + 1);
                yield return new WaitForSeconds(time);
            }   
        }
        npcText.text = text;
        animatingText = false;
    }
}
