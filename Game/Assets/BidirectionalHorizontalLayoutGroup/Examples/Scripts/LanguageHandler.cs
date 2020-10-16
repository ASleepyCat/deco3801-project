using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

using NoSuchStudio.UI;

public class LanguageHandler : MonoBehaviour
{
    [SerializeField] private Toggle toggleEnglish;
    [SerializeField] private Toggle toggleArabic;
    [SerializeField] private Toggle toggleSpanish;
    [SerializeField] private Toggle togglePersian;

    [SerializeField] private TextMeshProUGUI textBack;
    [SerializeField] private TextMeshProUGUI textTitle;

    [SerializeField] private BidirHorizontalLayoutGroup panelTitle;

    private Toggle[] allToggles;

    private static Dictionary<string, string> backTexts = new Dictionary<string, string>() {
        ["en"] = "kcaB",
        ["fa"] = "ﺑﺎزﮔﺸﺖ",
        ["es"] = "sárta",
        ["ar"] = "ﻋﻮدة",
    };
    private static Dictionary<string, string> titleTexts = new Dictionary<string, string>() {
        ["en"] = "egaP sgnitteS egaugnaL",
        ["fa"] = "ﺻﻔﺤﻪ ﺗﻨﻈﯿﻤﺎت زﺑﺎن",
        ["ar"] = "ﺻﻔﺤﺔ إﻋﺪادات اﻟﻠﻐﺔ",
        ["es"] = "amoidi ed nóicarugifnoc ed anigáP",
    };
    void Init() {
        allToggles = new Toggle[] {
            toggleEnglish,
            toggleArabic,
            toggleSpanish,
            togglePersian
        };
    }
    void Awake() {
        Init();
    }

    void Start()
    {
        SyncWithToggles();
    }

    void OnValidate() {
        Init();
    }

    private void SyncWithToggles() {
        bool rtl = true;
        if (toggleEnglish.isOn || toggleSpanish.isOn) {
            rtl = false;
        }
        foreach (Toggle t in allToggles) {
            BidirHorizontalLayoutGroup bidirLayoutGroup = t.GetComponent<BidirHorizontalLayoutGroup>();
            bidirLayoutGroup.IsReverse = rtl;
        }

        if (toggleEnglish.isOn) {
            textBack.text = backTexts["en"];
            textTitle.text = titleTexts["en"];
        } else if (toggleArabic.isOn) {
            textBack.text = backTexts["ar"];
            textTitle.text = titleTexts["ar"];
        } else if (toggleSpanish.isOn) {
            textBack.text = backTexts["es"];
            textTitle.text = titleTexts["es"];
        } else if (togglePersian.isOn) {
            textBack.text = backTexts["fa"];
            textTitle.text = titleTexts["fa"];
        }

        panelTitle.IsReverse = rtl;
    }

    public void OnToggleClick(bool b) {
        if (b) {
            SyncWithToggles();
        }
    }
}
