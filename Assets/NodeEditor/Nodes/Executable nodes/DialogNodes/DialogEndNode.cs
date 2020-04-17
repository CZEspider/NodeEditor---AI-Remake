using NodeEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DialogEditor
{
    [CreateAssetMenu(menuName = "DialogEditor/Nodes/End")]
    public class DialogEndNode : ExecutableNode
    {       
        public override void DrawCurve(BaseNode node)
        {
        }

        //Obecná specifikace vzhledu textu
        public override void DrawWindow(BaseNode b)
        {
            GUIStyle s = new GUIStyle();
            s.fontSize = 18;                    //Veliskost písma
            s.richText = true;              //RichText?
            s.alignment = TextAnchor.UpperCenter;      //Zarovnání textu může být (UpperLeft, Right, atd.)
            s.padding.top = 0;              //Odsazení (místo top může být bottom, left, right)
            s.normal.textColor = GUIStylizer.Colors.BLACK;  //Barva textu

            b.DialogGraph.SetDirty();
        }

        public override void Execute(BaseNode b)        //Funkce co se stane při spuštění – resp. Co bude dělat se souborem
        {
            DialogManager.Instance.SubtitleArea.text = " ";
            DialogManager.Instance.DecisionHolder.SetActive(false);
            DialogManager.Instance.TimeBar.enabled = false;
        }    
    }
}
