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

namespace DialogEditor
{
    [CreateAssetMenu(menuName = "DialogEditor/Nodes/Decision")]
    public class DialogDecisionNode : ExecutableNode
    {
        public bool TimeIsRunning = false;
        public int decisionSelectedOption = 10;
        public bool decidedLocal = false;
        public float DecisionTime;

        public override void DrawCurve(BaseNode node)
        {
        }

        public override void DrawWindow(BaseNode b)
        {
            //GUISTYLE for "Decision"
            GUIStyle s = new GUIStyle();
            s.fontSize = 16;
            s.richText = true;
            s.alignment = TextAnchor.UpperCenter;
            s.padding.top = 0;
            s.normal.textColor = GUIStylizer.Colors.LIGHTSKYBLUE;

            DialogEditor.GetEGLLable("Decision", s);

            DialogEditor.GetEGLLable("Decisions Amount: ", GUIStyle.none);
            b.dialogDecisionAmount = EditorGUILayout.IntSlider(b.dialogDecisionAmount, 1, 5);

            GUIStyle n = new GUIStyle();
            n.fontSize = 12;
            n.richText = true;
            n.alignment = TextAnchor.UpperRight;
            n.padding.top = 0;
            n.normal.textColor = GUIStylizer.Colors.BLACK;

            if (b.dialogDecisionAmount >= 1)
            {
                DialogEditor.GetEGLLable("Decision 1", n);                                                                  //vykreslení textu "Decision1"
                b.decisionImage0 = EditorGUILayout.ObjectField(b.decisionImage0, typeof(Sprite), false) as Sprite;          //Objectfield pro Sprite soubory
                b.decisionString0 = GUILayout.TextField(b.decisionString0, 200);                                            //Textové pole pro text dialogového výběru
                b.Color0 = (BaseNode.TextColor)EditorGUILayout.EnumPopup("Color", b.Color0);                                    //Handler barvy textu

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
                b.Color1 = (BaseNode.TextColor)EditorGUILayout.EnumPopup("Color", b.Color1);
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
                b.Color2 = (BaseNode.TextColor)EditorGUILayout.EnumPopup("Color", b.Color2);
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
                b.Color3 = (BaseNode.TextColor)EditorGUILayout.EnumPopup("Color", b.Color3);
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
                b.Color4 = (BaseNode.TextColor)EditorGUILayout.EnumPopup("Color", b.Color4);
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
            

            b.IsTimed = EditorGUILayout.Toggle("Timed?", b.IsTimed);

            if (b.IsTimed)
            {
                b.DecisionTime = EditorGUILayout.Slider(b.DecisionTime, 2f, 10f);
                DialogEditor.GetEGLLable("TimeOut Branch", GUIStyle.none);
            }
        }


        public override void Execute(BaseNode b)
        {
            if (b.transitions.Count == 0) return;

            if (!b.DidOnce)                     //Resetování hodnot Nody - nemazat!!
            {
                DialogManager.Instance.TimeBar.fillAmount = b.DecisionTime / 1 ;
                decidedLocal = false;
                decisionSelectedOption = 10;
                DecisionTime = b.DecisionTime;
                b.DidOnce = true;
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

            if (b.dialogDecisionAmount >= 1 && !b.decided)
            {
                DialogManager.Instance.GO_DecisionButton0.SetActive(true);
                DialogManager.Instance.DecisionImage0.sprite = b.decisionImage0;
                DialogManager.Instance.DecisionText0.text = b.decisionString0;
                DialogManager.Instance.DecisionText0.color = b.TextColor0;
            }
            else { DialogManager.Instance.GO_DecisionButton0.SetActive(false); }

            if (b.dialogDecisionAmount >= 2 && !b.decided)
            {
                DialogManager.Instance.GO_DecisionButton1.SetActive(true);
                DialogManager.Instance.DecisionImage1.sprite = b.decisionImage1;
                DialogManager.Instance.DecisionText1.text = b.decisionString1;
                DialogManager.Instance.DecisionText1.color = b.TextColor1;
            }
            else { DialogManager.Instance.GO_DecisionButton1.SetActive(false); }

            if (b.dialogDecisionAmount >= 3 && !b.decided)
            {
                DialogManager.Instance.GO_DecisionButton2.SetActive(true);
                DialogManager.Instance.DecisionImage2.sprite = b.decisionImage2;
                DialogManager.Instance.DecisionText2.text = b.decisionString2;
                DialogManager.Instance.DecisionText2.color = b.TextColor2;
            }
            else { DialogManager.Instance.GO_DecisionButton2.SetActive(false); }

            if (b.dialogDecisionAmount >= 4 && !b.decided)
            {
                DialogManager.Instance.GO_DecisionButton3.SetActive(true);
                DialogManager.Instance.DecisionImage3.sprite = b.decisionImage3;
                DialogManager.Instance.DecisionText3.text = b.decisionString3;
                DialogManager.Instance.DecisionText3.color = b.TextColor3;
            }
            else { DialogManager.Instance.GO_DecisionButton3.SetActive(false); }

            if (b.dialogDecisionAmount >= 5 && !b.decided)
            {
                DialogManager.Instance.GO_DecisionButton4.SetActive(true);
                DialogManager.Instance.DecisionImage4.sprite = b.decisionImage4;
                DialogManager.Instance.DecisionText4.text = b.decisionString4;
                DialogManager.Instance.DecisionText4.color = b.TextColor4;
            }
            else { DialogManager.Instance.GO_DecisionButton4.SetActive(false); }

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


            if (Input.GetKeyDown(KeyCode.Alpha1) && (b.transitions.Count >= 1))
            {
                b.decisionSelectedOption = 0;
                b.decided = true;
                TimeIsRunning = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && (b.transitions.Count >= 2))
            {
                b.decisionSelectedOption = 1;
                b.decided = true;
                TimeIsRunning = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && (b.transitions.Count >= 3))
            {
                b.decisionSelectedOption = 2;
                b.decided = true;
                TimeIsRunning = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) && (b.transitions.Count >= 4))
            {
                b.decisionSelectedOption = 3;
                b.decided = true;
                TimeIsRunning = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha5) && (b.transitions.Count >= 5))
            {
                b.decisionSelectedOption = 4;
                b.decided = true;
                TimeIsRunning = false;
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

            DialogManager.Instance.DecisionButton0.onClick.AddListener(Button0Clicked);         //Pokud Kliknem spustí se funkce která potvrdí výber tlačítka
            DialogManager.Instance.DecisionButton1.onClick.AddListener(Button1Clicked);
            DialogManager.Instance.DecisionButton2.onClick.AddListener(Button2Clicked);
            DialogManager.Instance.DecisionButton3.onClick.AddListener(Button3Clicked);
            DialogManager.Instance.DecisionButton4.onClick.AddListener(Button4Clicked);

            if (decisionSelectedOption < 5 && decisionSelectedOption >= 0)                      //Výběr musí být mezi 1-5
            {
                b.decided = true;
                b.decisionSelectedOption = decisionSelectedOption;
            }

            Debug.Log("Option:" + decisionSelectedOption);                                      //Debug pro zvolenou možnost

        }

        public void Button0Clicked()
        {
            decisionSelectedOption = 0;
            TimeIsRunning = false;
            decidedLocal = true;
        }

        public void Button1Clicked()
        {
            decisionSelectedOption = 1;
            TimeIsRunning = false;
            decidedLocal = true;
        }

        public void Button2Clicked()
        {
            decisionSelectedOption = 2;
            TimeIsRunning = false;
            decidedLocal = true;
        }

        public void Button3Clicked()
        {
            decisionSelectedOption = 3;
            TimeIsRunning = false;
            decidedLocal = true;
        }

        public void Button4Clicked()
        {
            decisionSelectedOption = 4;
            TimeIsRunning = false;
            decidedLocal = true;
        }
    }
}
