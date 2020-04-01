using NodeEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using DialogEditor;
using System.Linq;
using static GUIStylizer;

namespace DialogEditor
{
    [CreateAssetMenu(menuName = "DialogEditor/Nodes/Decision")]
    public class DialogDecisionNode : ExecutableNode
    {
        public float DecisionTime = 0f;
        public bool TimeIsRunning = false;
        public BaseNode.TextColor Color0;
        public BaseNode.TextColor Color1;
        public BaseNode.TextColor Color2;
        public BaseNode.TextColor Color3;
        public BaseNode.TextColor Color4;
        public Color TextColor0;
        public Color TextColor1;
        public Color TextColor2;
        public Color TextColor3;
        public Color TextColor4;

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
                Color0 = (BaseNode.TextColor)EditorGUILayout.EnumPopup("Color", Color0);                                    //Handler barvy textu

                if (Color0 == BaseNode.TextColor.Green)
                {
                    TextColor0 = Color.green;
                }    
                if (Color0 == BaseNode.TextColor.Yellow)
                {
                    TextColor0 = Color.yellow;
                }
                if (Color0 == BaseNode.TextColor.Red)
                {
                    TextColor0 = Color.red;
                }
                if (Color0 == BaseNode.TextColor.Blue)
                {
                    TextColor0 = Color.blue;
                }
                if (Color0 == BaseNode.TextColor.White)
                {
                    TextColor0 = Color.white;
                }
            }               //Obsahuje komentáře

            if (b.dialogDecisionAmount >= 2)
            {
                DialogEditor.GetEGLLable("Decision 2", n);
                b.decisionImage1 = EditorGUILayout.ObjectField(b.decisionImage1, typeof(Sprite), false) as Sprite;
                b.decisionString1 = GUILayout.TextField(b.decisionString1, 200);
                Color1 = (BaseNode.TextColor)EditorGUILayout.EnumPopup("Color", Color1);
                if (Color1 == BaseNode.TextColor.Green)
                {
                    TextColor1 = Color.green;
                }
                if (Color1 == BaseNode.TextColor.Yellow)
                {
                    TextColor1 = Color.yellow;
                }
                if (Color1 == BaseNode.TextColor.Red)
                {
                    TextColor1 = Color.red;
                }
                if (Color1 == BaseNode.TextColor.Blue)
                {
                    TextColor1 = Color.blue;
                }
                if (Color1 == BaseNode.TextColor.White)
                {
                    TextColor1 = Color.white;
                }
            }

            if (b.dialogDecisionAmount >= 3)
            {

                DialogEditor.GetEGLLable("Decision 3", n);
                b.decisionImage2 = EditorGUILayout.ObjectField(b.decisionImage2, typeof(Sprite), false) as Sprite;
                b.decisionString2 = GUILayout.TextField(b.decisionString2, 200);
                Color2 = (BaseNode.TextColor)EditorGUILayout.EnumPopup("Color", Color2);
                if (Color2 == BaseNode.TextColor.Green)
                {
                    TextColor2 = Color.green;
                }
                if (Color2 == BaseNode.TextColor.Yellow)
                {
                    TextColor2 = Color.yellow;
                }
                if (Color2 == BaseNode.TextColor.Red)
                {
                    TextColor2 = Color.red;
                }
                if (Color2 == BaseNode.TextColor.Blue)
                {
                    TextColor2 = Color.blue;
                }
                if (Color2 == BaseNode.TextColor.White)
                {
                    TextColor2 = Color.white;
                }
            }

            if (b.dialogDecisionAmount >= 4)
            {
                DialogEditor.GetEGLLable("Decision 4", n);
                b.decisionImage3 = EditorGUILayout.ObjectField(b.decisionImage3, typeof(Sprite), false) as Sprite;
                b.decisionString3 = GUILayout.TextField(b.decisionString3, 200);
                Color3 = (BaseNode.TextColor)EditorGUILayout.EnumPopup("Color", Color3);
                if (Color3 == BaseNode.TextColor.Green)
                {
                    TextColor3 = Color.green;
                }
                if (Color3 == BaseNode.TextColor.Yellow)
                {
                    TextColor3 = Color.yellow;
                }
                if (Color3 == BaseNode.TextColor.Red)
                {
                    TextColor3 = Color.red;
                }
                if (Color3 == BaseNode.TextColor.Blue)
                {
                    TextColor3 = Color.blue;
                }
                if (Color3 == BaseNode.TextColor.White)
                {
                    TextColor3 = Color.white;
                }
            }

            if (b.dialogDecisionAmount >= 5)
            {
                DialogEditor.GetEGLLable("Decision 5", n);
                b.decisionImage4 = EditorGUILayout.ObjectField(b.decisionImage4, typeof(Sprite), false) as Sprite;
                b.decisionString4 = GUILayout.TextField(b.decisionString4, 200);
                Color4 = (BaseNode.TextColor)EditorGUILayout.EnumPopup("Color", Color4);
                if (Color4 == BaseNode.TextColor.Green)
                {
                    TextColor4 = Color.green;
                }
                if (Color4 == BaseNode.TextColor.Yellow)
                {
                    TextColor4 = Color.yellow;
                }
                if (Color4 == BaseNode.TextColor.Red)
                {
                    TextColor4 = Color.red;
                }
                if (Color4 == BaseNode.TextColor.Blue)
                {
                    TextColor4 = Color.blue;
                }
                if (Color4 == BaseNode.TextColor.White)
                {
                    TextColor4 = Color.white;
                }
            }
            

            b.IsTimed = EditorGUILayout.Toggle("Timed?", b.IsTimed);

            if (b.IsTimed)
            {
                DecisionTime = EditorGUILayout.Slider(DecisionTime, 2f, 10f);
                DialogEditor.GetEGLLable("TimeOut Branch", GUIStyle.none);
            }
        }

        public override void Execute(BaseNode b)
        {
            if (b.transitions.Count == 0) return;

            string[] data = new string[b.transitions.Count];
            //aktivuje decisionOptionsHolder
            DialogManager.Instance.DecisionHolder.SetActive(true);

            for (int i = 0; i < b.transitions.Count; i++)
            {
                BaseNode subs = b.transitions[i].endNode.transitions[0].endNode.transitions[0].endNode;

                data[i] = subs.dialogPartSubtitles;
            }

            if (TimeIsRunning && b.IsTimed)
            {
                DialogManager.Instance.TimeBar.fillAmount -= 1.0f / DecisionTime * Time.deltaTime;
            }

            if (DialogManager.Instance.TimeBar.fillAmount <= 0.01 && b.IsTimed)
            {
                b.decisionSelectedOption = 5;
                b.decided = true;
                TimeIsRunning = false;
                DialogManager.Instance.TimeBar.fillAmount = 0;
                DialogManager.Instance.DecisionHolder.SetActive(false);

            }
            if (!TimeIsRunning && b.IsTimed)
            {
                TimeIsRunning = true;
            }

            Debug.Log(DialogManager.Instance.TimeBar.fillAmount);

            if (b.dialogDecisionAmount >= 1)
            {
                DialogManager.Instance.DecisionImage0.sprite = b.decisionImage0;
                DialogManager.Instance.DecisionText0.text = b.decisionString0;
                DialogManager.Instance.DecisionText0.color = TextColor0;
            }
            if (b.dialogDecisionAmount >= 2)
            {
                DialogManager.Instance.DecisionImage1.sprite = b.decisionImage1;
                DialogManager.Instance.DecisionText1.text = b.decisionString1;
                DialogManager.Instance.DecisionText1.color = TextColor1;
            }
            if (b.dialogDecisionAmount >= 3)
            {
                DialogManager.Instance.DecisionImage2.sprite = b.decisionImage2;
                DialogManager.Instance.DecisionText2.text = b.decisionString2;
                DialogManager.Instance.DecisionText2.color = TextColor2;
            }
            if (b.dialogDecisionAmount >= 4)
            {
                DialogManager.Instance.DecisionImage3.sprite = b.decisionImage3;
                DialogManager.Instance.DecisionText3.text = b.decisionString3;
                DialogManager.Instance.DecisionText3.color = TextColor3;
            }
            if (b.dialogDecisionAmount >= 5)
            {
                DialogManager.Instance.DecisionImage4.sprite = b.decisionImage4;
                DialogManager.Instance.DecisionText4.text = b.decisionString4;
                DialogManager.Instance.DecisionText4.color = TextColor4;
            }

            else if (Input.GetKeyDown(KeyCode.M) && (b.transitions.Count >= 1))
            {
                b.decisionSelectedOption = 0;
                b.decided = true;
                TimeIsRunning = false;
                DialogManager.Instance.DecisionHolder.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.N) && (b.transitions.Count >= 2))
            {
                b.decisionSelectedOption = 1;
                b.decided = true;
                TimeIsRunning = false;
                DialogManager.Instance.DecisionHolder.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.B) && (b.transitions.Count >= 3))
            {
                b.decisionSelectedOption = 2;
                b.decided = true;
                TimeIsRunning = false;
                DialogManager.Instance.DecisionHolder.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.V) && (b.transitions.Count >= 4))
            {
                b.decisionSelectedOption = 3;
                b.decided = true;
                TimeIsRunning = false;
                DialogManager.Instance.DecisionHolder.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.C) && (b.transitions.Count >= 5))
            {
                b.decisionSelectedOption = 4;
                b.decided = true;
                TimeIsRunning = false;
                DialogManager.Instance.DecisionHolder.SetActive(false);

            }

            DialogManager.Instance.DecisionButton0.onClick.AddListener(Button0Clicked);
            
        }

        public void Button0Clicked()
        {
            TimeIsRunning = false;
            DialogManager.Instance.DecisionHolder.SetActive(false);
        }
    }
}
