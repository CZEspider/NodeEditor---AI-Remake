using NodeEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using DialogEditor;
using System.Linq;
using UnityEngine.Events;
using static GUIStylizer;


//V Tomto kódu se bude dělat mnoho optimalizace!!! Spoustu věcí je navíc - např. dvojité nastavování boolů (decidedLocal ř. 563 a ve void OnButtonClicked0-4)

namespace DialogEditor
{
    [CreateAssetMenu(menuName = "DialogEditor/Nodes/Decision")]
    public class DialogDecisionNode : ExecutableNode
    {
        [SerializeField]
        public bool TimeIsRunning = false;

        public int decisionSelectedOption = 10;

        [SerializeField]
        public bool decidedLocal = false;

        private bool SoundPlayed;

        public float DecisionTime;

        [SerializeField]
        private bool Reseted = false;

        public bool DecidedOnce0 = false;
        public bool DecidedOnce1 = false;
        public bool DecidedOnce2 = false;
        public bool DecidedOnce3 = false;
        public bool DecidedOnce4 = false;

        public override void DrawCurve(BaseNode node)
        {
        }

        public override void DrawWindow(BaseNode b)
        {
            //GUISTYLE for Spacing
            GUIStyle p = new GUIStyle();
            p.fontSize = 20;
            p.richText = true;
            p.alignment = TextAnchor.UpperRight;
            p.padding.top = 0;
            p.normal.textColor = GUIStylizer.Colors.RED;

            //GUISTYLE for "Decision"
            GUIStyle s = new GUIStyle();
            s.fontSize = 16;
            s.richText = true;
            s.alignment = TextAnchor.UpperCenter;
            s.padding.top = 0;
            s.normal.textColor = GUIStylizer.Colors.LIGHTSKYBLUE;

            b.Resetable = EditorGUILayout.Toggle("Reseting?", b.Resetable);

            DialogEditor.GetEGLLable("Decision", s);

            DialogEditor.GetEGLLable("Decisions Amount: ", GUIStyle.none);
            b.dialogDecisionAmount = EditorGUILayout.IntSlider(b.dialogDecisionAmount, 1, 5);

            DialogEditor.GetEGLLable("Character: " + (b.dialogPartspeaker != null ? b.dialogPartspeaker.ToString() : ""), GUIStyle.none);
            b.dialogPartspeaker = EditorGUILayout.ObjectField(b.dialogPartspeaker, typeof(Character), false) as Character;

            DialogEditor.GetEGLLable("Question Audio: ", GUIStyle.none);
            b.dialogAudioClip = EditorGUILayout.ObjectField(b.dialogAudioClip, typeof(AudioClip), false) as AudioClip;
            
            DialogEditor.GetEGLLable("Question Subs: ", GUIStyle.none);
            b.dialogPartSubtitles = GUILayout.TextArea(b.dialogPartSubtitles, 150);

            GUIStyle n = new GUIStyle();
            n.fontSize = 18;
            n.richText = true;
            n.alignment = TextAnchor.MiddleCenter;
            n.padding.top = 0;
            n.normal.textColor = GUIStylizer.Colors.BLACK;

            if (b.dialogDecisionAmount >= 1)
            {
                DialogEditor.GetEGLLable("Decision 1", n);                                                                  //vykreslení textu "Decision1"
                b.decisionImage0 = EditorGUILayout.ObjectField(b.decisionImage0, typeof(Sprite), false) as Sprite;          //Objectfield pro Sprite soubory
                b.decisionString0 = GUILayout.TextField(b.decisionString0, 200);                                            //Textové pole pro text dialogového výběru
                b.DecisionOneTime0 = EditorGUILayout.Toggle("One Time?", b.DecisionOneTime0);                               //Pokud je True tuto možnost spustit lze jen jednou! tzn. nedochází k resetu tohoto Boolu v této nodě!
                b.Color0 = (BaseNode.TextColor)EditorGUILayout.EnumPopup("Color", b.Color0);                                //Handler barvy textu
                EditorGUILayout.LabelField("------------------------------------", p);

                if (b.Color0 == BaseNode.TextColor.Green)
                {
                    b.TextColor0 = Color.green;
                }    
                if (b.Color0 == BaseNode.TextColor.Yellow)
                {
                    b.TextColor0 = Color.yellow;
                }
                if (b.Color0 == BaseNode.TextColor.Red)
                {
                    b.TextColor0 = Color.red;
                }
                if (b.Color0 == BaseNode.TextColor.Blue)
                {
                    b.TextColor0 = Color.blue;
                }
                if (b.Color0 == BaseNode.TextColor.White)
                {
                    b.TextColor0 = Color.white;
                }
            }               //Obsahuje komentáře

            if (b.dialogDecisionAmount >= 2)
            {
                DialogEditor.GetEGLLable("Decision 2", n);
                b.decisionImage1 = EditorGUILayout.ObjectField(b.decisionImage1, typeof(Sprite), false) as Sprite;
                b.decisionString1 = GUILayout.TextField(b.decisionString1, 200);
                b.DecisionOneTime1 = EditorGUILayout.Toggle("One Time?", b.DecisionOneTime1);
                b.Color1 = (BaseNode.TextColor)EditorGUILayout.EnumPopup("Color", b.Color1);
                EditorGUILayout.LabelField("------------------------------------", p);

                if (b.Color1 == BaseNode.TextColor.Green)
                {
                    b.TextColor1 = Color.green;
                }
                if (b.Color1 == BaseNode.TextColor.Yellow)
                {
                    b.TextColor1 = Color.yellow;
                }
                if (b.Color1 == BaseNode.TextColor.Red)
                {
                    b.TextColor1 = Color.red;
                }
                if (b.Color1 == BaseNode.TextColor.Blue)
                {
                    b.TextColor1 = Color.blue;
                }
                if (b.Color1 == BaseNode.TextColor.White)
                {
                    b.TextColor1 = Color.white;
                }
            }

            if (b.dialogDecisionAmount >= 3)
            {

                DialogEditor.GetEGLLable("Decision 3", n);
                b.decisionImage2 = EditorGUILayout.ObjectField(b.decisionImage2, typeof(Sprite), false) as Sprite;
                b.decisionString2 = GUILayout.TextField(b.decisionString2, 200);
                b.DecisionOneTime2 = EditorGUILayout.Toggle("One Time?", b.DecisionOneTime2);
                b.Color2 = (BaseNode.TextColor)EditorGUILayout.EnumPopup("Color", b.Color2);
                EditorGUILayout.LabelField("------------------------------------", p);

                if (b.Color2 == BaseNode.TextColor.Green)
                {
                    b.TextColor2 = Color.green;
                }
                if (b.Color2 == BaseNode.TextColor.Yellow)
                {
                    b.TextColor2 = Color.yellow;
                }
                if (b.Color2 == BaseNode.TextColor.Red)
                {
                    b.TextColor2 = Color.red;
                }
                if (b.Color2 == BaseNode.TextColor.Blue)
                {
                    b.TextColor2 = Color.blue;
                }
                if (b.Color2 == BaseNode.TextColor.White)
                {
                    b.TextColor2 = Color.white;
                }
            }

            if (b.dialogDecisionAmount >= 4)
            {
                DialogEditor.GetEGLLable("Decision 4", n);
                b.decisionImage3 = EditorGUILayout.ObjectField(b.decisionImage3, typeof(Sprite), false) as Sprite;
                b.decisionString3 = GUILayout.TextField(b.decisionString3, 200);
                b.DecisionOneTime3 = EditorGUILayout.Toggle("One Time?", b.DecisionOneTime3);
                b.Color3 = (BaseNode.TextColor)EditorGUILayout.EnumPopup("Color", b.Color3);
                EditorGUILayout.LabelField("------------------------------------", p);

                if (b.Color3 == BaseNode.TextColor.Green)
                {
                    b.TextColor3 = Color.green;
                }
                if (b.Color3 == BaseNode.TextColor.Yellow)
                {
                    b.TextColor3 = Color.yellow;
                }
                if (b.Color3 == BaseNode.TextColor.Red)
                {
                    b.TextColor3 = Color.red;
                }
                if (b.Color3 == BaseNode.TextColor.Blue)
                {
                    b.TextColor3 = Color.blue;
                }
                if (b.Color3 == BaseNode.TextColor.White)
                {
                    b.TextColor3 = Color.white;
                }
            }
            
            if (b.dialogDecisionAmount >= 5)
            {
                DialogEditor.GetEGLLable("Decision 5", n);
                b.decisionImage4 = EditorGUILayout.ObjectField(b.decisionImage4, typeof(Sprite), false) as Sprite;
                b.decisionString4 = GUILayout.TextField(b.decisionString4, 200);
                b.DecisionOneTime4 = EditorGUILayout.Toggle("One Time?", b.DecisionOneTime4);
                b.Color4 = (BaseNode.TextColor)EditorGUILayout.EnumPopup("Color", b.Color4);
                EditorGUILayout.LabelField("------------------------------------", p);

                if (b.Color4 == BaseNode.TextColor.Green)
                {
                    b.TextColor4 = Color.green;
                }
                if (b.Color4 == BaseNode.TextColor.Yellow)
                {
                    b.TextColor4 = Color.yellow;
                }
                if (b.Color4 == BaseNode.TextColor.Red)
                {
                    b.TextColor4 = Color.red;
                }
                if (b.Color4 == BaseNode.TextColor.Blue)
                {
                    b.TextColor4 = Color.blue;
                }
                if (b.Color4 == BaseNode.TextColor.White)
                {
                    b.TextColor4 = Color.white;
                }
            }

            for (int i = 0; i < b.dialogDecisionAmount; i++)
            {
                b.WindowRect.height = b.drawNode.Height + (b.dialogDecisionAmount * 120f);
            }
            
            b.IsTimed = EditorGUILayout.Toggle("Timed?", b.IsTimed);

            if (b.IsTimed)
            {
                b.DecisionTime = EditorGUILayout.Slider(b.DecisionTime, 2f, 10f);
                DialogEditor.GetEGLLable("TimeOut Branch", GUIStyle.none);
            }
        }


        public override void Execute(BaseNode b)
        {
            if (b.transitions.Count == 0)
            {
                Debug.LogError("Node doesnt have further path in Dialog!");
                return;
            }

            if(b.Resetable && !Reseted)
            {
                b.DidOnce = false;
                SoundPlayed = false;
                Reseted = true;
            }

            if (!b.DidOnce)                     //Resetování hodnot Nody - nemazat!!
            {
                DialogManager.Instance.TimeBar.fillAmount = b.DecisionTime / 1 ;
                decidedLocal = false;
                decisionSelectedOption = 10;
                DecisionTime = b.DecisionTime;
                Debug.Log("Reset");
                b.DidOnce = true;
                PlaySound(b.dialogAudioClip);
                SoundPlayed = true;
            }

            if (decidedLocal)                    // Jistá forma resetu Nody
            {
                b.decided = decidedLocal;
                b.DidOnce = false;
            }

            if (!b.decided)
            {
                decisionSelectedOption = -1;    //Nastavuje int do -1 protože jinak se ihned potvrdí první volba! (neměnit)
            }

            if (b.DecisionOneTime0)         //Pokud se hráč může rozhodnout jednou
            {
                if(b.AlreadyDecided0)         //Zjistit jestli už se jednou rozhodl
                {
                    DecidedOnce0 = true;    //Pokud ano nemůže tuto možnost použít znovu
                }
                else
                {
                    DecidedOnce0 = false;   //Pokud ne může tuto možnost použít
                }
            }
            if (b.DecisionOneTime1)
            {
                if (b.AlreadyDecided1)         
                {
                    DecidedOnce1 = true;    
                }
                else
                {
                    DecidedOnce1 = false;   
                }
            }
            if (b.DecisionOneTime2)
            {
                if (b.AlreadyDecided2)         
                {
                    DecidedOnce2 = true;    
                }
                else
                {
                    DecidedOnce2 = false;   
                }
            }
            if (b.DecisionOneTime3)
            {
                if (b.AlreadyDecided3)         
                {
                    DecidedOnce3 = true;    
                }
                else
                {
                    DecidedOnce3 = false;   
                }
            }
            if (b.DecisionOneTime4)
            {
                if (b.AlreadyDecided4)         
                {
                    DecidedOnce4 = true;    
                }
                else
                {
                    DecidedOnce4 = false;   
                }
            }

            string[] data = new string[b.transitions.Count];

            //aktivuje decisionOptionsHolder
            DialogManager.Instance.DecisionHolder.SetActive(true);

            for (int i = 0; i < b.transitions.Count; i++)
            {
                BaseNode subs = b.transitions[i].endNode.transitions[0].endNode.transitions[0].endNode;

                data[i] = subs.dialogPartSubtitles;
            }

            //Pokud Decision je časovaný - Odečítá čas a zobrazí bar
            if (TimeIsRunning && b.IsTimed)         
            {
                DialogManager.Instance.TimeBar.enabled = true;
                DialogManager.Instance.TimeBar.fillAmount -= 1.0f / b.DecisionTime * Time.deltaTime;
            }

            //Pokud Decision není časovaný - Vypne zobrazení TimeBaru
            if (!b.IsTimed)             
            {
                DialogManager.Instance.TimeBar.enabled = false;
            }

            if (DialogManager.Instance.TimeBar.fillAmount <= 0.01 && b.IsTimed)     //Pokud vyprší čas zvolí 5. výstup
            {
                b.decisionSelectedOption = 5;
                b.decided = true;
                TimeIsRunning = false;
                DialogManager.Instance.TimeBar.fillAmount = 0;
            }
            if (!TimeIsRunning && b.IsTimed)                //Pokud čas neběží a Node je časovaná - spustí časovač
            {
                TimeIsRunning = true;
            }

            if (b.dialogDecisionAmount >= 1 && !b.decided)                          //Pokud je počet možností větší nebo rovno 1 a hráč se ještě NEROZHODL 
            {
                if (b.DecisionOneTime0)                                             //Pokud rozhodnutí může proběhnout jen jednou
                {
                    if (!DecidedOnce0)                                              //Pokud hráč ještě svoji volbu neučinil
                    {
                        DialogManager.Instance.GO_DecisionButton0.SetActive(true);
                        DialogManager.Instance.DecisionImage0.sprite = b.decisionImage0;
                        DialogManager.Instance.DecisionText0.text = b.decisionString0;
                        DialogManager.Instance.DecisionText0.color = b.TextColor0;
                    }
                    else
                    {
                        DialogManager.Instance.GO_DecisionButton0.SetActive(false); //Pokud hráč svou volbu učinil - NEZOBRAZÍ SE!!
                    }
                }
                else
                {
                    DialogManager.Instance.GO_DecisionButton0.SetActive(true);      //Pokud rozhodnutí může proběhnout vícekrát
                    DialogManager.Instance.DecisionImage0.sprite = b.decisionImage0;
                    DialogManager.Instance.DecisionText0.text = b.decisionString0;
                    DialogManager.Instance.DecisionText0.color = b.TextColor0;
                }

            }

            if (b.dialogDecisionAmount >= 2 && !b.decided)
            {
                if (b.DecisionOneTime1)
                {
                    if (!DecidedOnce1)                                              //Pokud hráč ještě svoji volbu neučinil
                    {
                        DialogManager.Instance.GO_DecisionButton1.SetActive(true);
                        DialogManager.Instance.DecisionImage1.sprite = b.decisionImage1;
                        DialogManager.Instance.DecisionText1.text = b.decisionString1;
                        DialogManager.Instance.DecisionText1.color = b.TextColor1;
                    }
                    else
                    {
                        DialogManager.Instance.GO_DecisionButton1.SetActive(false); //Pokud hráč svou volbu učinil - NEZOBRAZÍ SE!!
                    }

                }
                else
                {
                    DialogManager.Instance.GO_DecisionButton1.SetActive(true);      //Pokud rozhodnutí může proběhnout vícekrát
                    DialogManager.Instance.DecisionImage1.sprite = b.decisionImage1;
                    DialogManager.Instance.DecisionText1.text = b.decisionString1;
                    DialogManager.Instance.DecisionText1.color = b.TextColor1;
                }
            }

            if (b.dialogDecisionAmount >= 3 && !b.decided)
            {
                if (b.DecisionOneTime2)
                {
                    if (!DecidedOnce2)                                              //Pokud hráč ještě svoji volbu neučinil
                    {
                        DialogManager.Instance.GO_DecisionButton2.SetActive(true);
                        DialogManager.Instance.DecisionImage2.sprite = b.decisionImage2;
                        DialogManager.Instance.DecisionText2.text = b.decisionString2;
                        DialogManager.Instance.DecisionText2.color = b.TextColor2;
                    }
                    else
                    {
                        DialogManager.Instance.GO_DecisionButton2.SetActive(false); //Pokud hráč svou volbu učinil - NEZOBRAZÍ SE!!
                    }

                }
                else
                {
                    DialogManager.Instance.GO_DecisionButton2.SetActive(true);
                    DialogManager.Instance.DecisionImage2.sprite = b.decisionImage2;
                    DialogManager.Instance.DecisionText2.text = b.decisionString2;
                    DialogManager.Instance.DecisionText2.color = b.TextColor2;
                }
            }

            if (b.dialogDecisionAmount >= 4 && !b.decided)
            {
                if (b.DecisionOneTime3)
                {
                    if (!DecidedOnce3)                                              //Pokud hráč ještě svoji volbu neučinil
                    {
                        DialogManager.Instance.GO_DecisionButton3.SetActive(true);
                        DialogManager.Instance.DecisionImage3.sprite = b.decisionImage3;
                        DialogManager.Instance.DecisionText3.text = b.decisionString3;
                        DialogManager.Instance.DecisionText3.color = b.TextColor3;
                    }
                    else
                    {
                        DialogManager.Instance.GO_DecisionButton3.SetActive(false); //Pokud hráč svou volbu učinil - NEZOBRAZÍ SE!!
                    }

                }
                else
                {
                    DialogManager.Instance.GO_DecisionButton3.SetActive(true);
                    DialogManager.Instance.DecisionImage3.sprite = b.decisionImage3;
                    DialogManager.Instance.DecisionText3.text = b.decisionString3;
                    DialogManager.Instance.DecisionText3.color = b.TextColor3;
                }
            }

            if (b.dialogDecisionAmount >= 5 && !b.decided)
            {
                if (b.DecisionOneTime4)
                {
                    if (!DecidedOnce4)                                              //Pokud hráč ještě svoji volbu neučinil
                    {
                        DialogManager.Instance.GO_DecisionButton4.SetActive(true);
                        DialogManager.Instance.DecisionImage4.sprite = b.decisionImage4;
                        DialogManager.Instance.DecisionText4.text = b.decisionString4;
                        DialogManager.Instance.DecisionText4.color = b.TextColor4;
                    }
                    else
                    {
                        DialogManager.Instance.GO_DecisionButton4.SetActive(false); //Pokud hráč svou volbu učinil - NEZOBRAZÍ SE!!
                    }

                }
                else
                {
                    DialogManager.Instance.GO_DecisionButton4.SetActive(true);
                    DialogManager.Instance.DecisionImage4.sprite = b.decisionImage4;
                    DialogManager.Instance.DecisionText4.text = b.decisionString4;
                    DialogManager.Instance.DecisionText4.color = b.TextColor4;
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) && (b.transitions.Count >= 1))   //zmáčkni tlačítko
            {
                if (b.DecisionOneTime0)
                {
                    if (!b.AlreadyDecided0)
                    {
                        Button0Clicked();
                    }
                }
                else
                {
                    Button0Clicked();
                }

            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && (b.transitions.Count >= 2))
            {
                if (b.DecisionOneTime1)
                {
                    if (!b.AlreadyDecided1)
                    {
                        Button1Clicked();
                    }
                }
                else
                {
                    Button1Clicked();
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) && (b.transitions.Count >= 3))
            {
                if (b.DecisionOneTime2)
                {
                    if (!b.AlreadyDecided2)
                    {
                        Button2Clicked();
                    }
                }
                else
                {
                    Button2Clicked();
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha4) && (b.transitions.Count >= 4))
            {
                if (b.DecisionOneTime3)
                {
                    if (!b.AlreadyDecided3)
                    {
                        Button3Clicked();
                    }
                }
                else
                {
                    Button3Clicked();
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha5) && (b.transitions.Count >= 5))
            {
                if (b.DecisionOneTime4)
                {
                    if (!b.AlreadyDecided4)
                    {
                        Button4Clicked();
                    }
                }
                else
                {
                    Button4Clicked();
                }
            }

            DialogManager.Instance.DecisionButton0.onClick.AddListener(Button0Clicked);         //Pokud Kliknem spustí se funkce která potvrdí výber tlačítka
            DialogManager.Instance.DecisionButton1.onClick.AddListener(Button1Clicked);
            DialogManager.Instance.DecisionButton2.onClick.AddListener(Button2Clicked);
            DialogManager.Instance.DecisionButton3.onClick.AddListener(Button3Clicked);
            DialogManager.Instance.DecisionButton4.onClick.AddListener(Button4Clicked);

            if (decidedLocal)
            {
                DialogManager.Instance.GO_DecisionButton0.SetActive(false);
                DialogManager.Instance.GO_DecisionButton1.SetActive(false);
                DialogManager.Instance.GO_DecisionButton2.SetActive(false);
                DialogManager.Instance.GO_DecisionButton3.SetActive(false);
                DialogManager.Instance.GO_DecisionButton4.SetActive(false);
                DialogManager.Instance.DecisionHolder.SetActive(false);

                DialogManager.Instance.TimeBar.enabled = false;
            }

            if (decisionSelectedOption < 5 && decisionSelectedOption >= 0)                      //Výběr musí být mezi 1-5
            {
                b.decisionSelectedOption = decisionSelectedOption;
                switch (b.decisionSelectedOption)
                {
                    case 4:
                        b.AlreadyDecided4 = true;
                        Debug.Log("4 true");
                        break;
                    case 3:
                        b.AlreadyDecided3 = true;
                        Debug.Log("3 true");
                        break;
                    case 2:
                        b.AlreadyDecided2 = true;
                        Debug.Log("2 true");
                        break;
                    case 1:
                        b.AlreadyDecided1 = true;
                        Debug.Log("1 true");
                        break;
                    case 0:
                        b.AlreadyDecided0 = true;
                        Debug.Log("0 true");
                        break;
                }
                b.decided = true;
            }

            Debug.Log("Option:" + decisionSelectedOption);                                      //Debug pro zvolenou možnost

            DialogManager.Instance.SubtitleArea.text = b.dialogPartspeaker + ": " + b.dialogPartSubtitles; //Titulky
        }

        public void Button0Clicked()
        {
            decisionSelectedOption = 0;
            TimeIsRunning = false;
            decidedLocal = true;
            SoundPlayed = false;
        }

        public void Button1Clicked()
        {
            decisionSelectedOption = 1;
            TimeIsRunning = false;
            decidedLocal = true;
            SoundPlayed = false;
        }

        public void Button2Clicked()
        {
            decisionSelectedOption = 2;
            TimeIsRunning = false;
            decidedLocal = true;
            SoundPlayed = false;
        }

        public void Button3Clicked()
        {
            decisionSelectedOption = 3;
            TimeIsRunning = false;
            decidedLocal = true;
            SoundPlayed = false;
        }

        public void Button4Clicked()
        {
            decisionSelectedOption = 4;
            TimeIsRunning = false;
            decidedLocal = true;
            SoundPlayed = false;
        }

        public void PlaySound(AudioClip audio)
        {
            Debug.Log("PlayingSound");
            AudioSource AudioPlayer = DialogManager.Instance.GetComponentInParent<AudioSource>();
            AudioPlayer.clip = audio;
            AudioPlayer.PlayOneShot(audio);
        }
    }
}
