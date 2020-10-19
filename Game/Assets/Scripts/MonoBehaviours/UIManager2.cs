using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;
using UnityEngine.UI;
using MonoBehaviours;
using ScriptableObjects;

public class UIManager2 : MonoBehaviour {

    public GameObject NPCContainer;
    public GameObject PlayerContainer;
    public Text NPCText;
    public Text[] TextChoices;
    public Image NPCSprite;
    public Image PlayerSprite;
    private GameManager _gameManager;


    private void Awake()
    {
        //VD.LoadDialogues(); //Load all dialogues to memory so that we dont spend time doing so later
    }

    // Start is called before the first frame update
    void Start()
    {
        NPCContainer.SetActive(false);
        PlayerContainer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (VD.isActive)
            {
                VD.Next();
            } else
            {
                
            }
        }
    }

    //Call this to begin the dialogue and advance through it
    public void Interact(VIDE_Assign dialogue)
    {
        //Sometimes, we might want to check the ExtraVariables and VAs before moving forward
        //We might want to modify the dialogue or perhaps go to another node, or dont start the dialogue at all
        //In such cases, the function will return true

        if (!VD.isActive)
        {
            Begin(dialogue);
        }
        else
        {
            VD.Next();
        }
    }

    void Begin(VIDE_Assign dialogue)
    {
        VD.OnNodeChange += UpdateUI;
        VD.OnEnd += End;    
        VD.BeginDialogue(dialogue);
        Debug.Log(GameManager.Instance.PlayerState.State);
        if (GameManager.Instance.PlayerState.SetPlayerState(PlayerState.States.InDialogue))
        {
            Debug.Log("Set state");
        }
    }

    void UpdateUI(VD.NodeData data)
    {
        NPCContainer.SetActive(false);
        PlayerContainer.SetActive(false);
        PlayerSprite.sprite = null;
        NPCSprite.sprite = null;

        if (data.isPlayer)
        {
            if (data.sprite != null)
                PlayerSprite.sprite = data.sprite;
            else if (VD.assigned.defaultPlayerSprite != null)
                PlayerSprite.sprite = VD.assigned.defaultPlayerSprite;
            PlayerContainer.SetActive(true);

            for (int i = 0; i < TextChoices.Length; i++)
            {
                if (i < data.comments.Length)
                {
                    TextChoices[i].transform.parent.gameObject.SetActive(true);
                    TextChoices[i].text = data.comments[i];
                } else
                {
                    TextChoices[i].transform.parent.gameObject.SetActive(false);
                }
            }
            TextChoices[0].transform.parent.GetComponent<Button>().Select();
        } else
        {
            //Set node sprite if there's any, otherwise try to use default sprite
            if (data.sprite != null)
            {
                //For NPC sprite, we'll first check if there's any "sprite" key
                //Such key is being used to apply the sprite only when at a certain comment index
                //Check CrazyCap dialogue for reference
                if (data.extraVars.ContainsKey("sprite"))
                {
                    if (data.commentIndex == (int)data.extraVars["sprite"])
                        NPCSprite.sprite = data.sprite;
                    else
                        NPCSprite.sprite = VD.assigned.defaultNPCSprite; //If not there yet, set default dialogue sprite
                }
                else //Otherwise use the node sprites
                {
                    NPCSprite.sprite = data.sprite;
                }
            } //or use the default sprite if there isnt a node sprite at all
            else if (VD.assigned.defaultNPCSprite != null)
                NPCSprite.sprite = VD.assigned.defaultNPCSprite;

            NPCContainer.SetActive(true);
            NPCText.text = data.comments[data.commentIndex];
        }
    }

    void End(VD.NodeData data)
    {
        NPCContainer.SetActive(false);
        PlayerContainer.SetActive(false);
        VD.OnNodeChange -= UpdateUI;
        VD.OnEnd -= End;
        VD.EndDialogue();
        GameManager.Instance.PlayerState.SetPlayerState(PlayerState.States.Free);
    }

    private void OnDisable()
    {
        if (NPCContainer != null)
            End(null);
    }

    public void SetPlayerChoice(int choice)
    {
        VD.nodeData.commentIndex = choice;
        if (Input.GetMouseButtonUp(0))
            VD.Next();
    }
}
