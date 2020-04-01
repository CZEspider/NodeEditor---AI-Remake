using NodeEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static GUIStylizer;

namespace DialogEditor
{
    [CreateAssetMenu(menuName = "DialogEditor/Graph")]
    public class DialogGraph : NodeGraph, IPlayable
    {

        public BaseNode firstSubtitles;

        #region Dialog variables
        internal bool wasPlayed = false;
        internal bool repeatable = false;
        internal bool skipable = false;
        internal int repeatLimit = 1;
        internal bool unlimitedRepeating = false;
        internal bool IsEnable = true;
        public bool destroyOnEnd = false;
        internal DialogLifeCycle lifeCycle;
        internal int playCount = 0;
        private bool isStopped = true, isPaused = false;
        #endregion

        public override NodeGraphLifeCycle LifeCycle()
        {
            return lifeCycle;
        }

        public override BaseNode AddNode(DrawNode drawNode, float x, float y, string title)
        {
            BaseNode n = base.AddNode(drawNode, x, y, title);
            n.DialogGraph = this;
            if (firstSubtitles.transitions.Count == 0)
            {
                SetAsEnterState(firstSubtitles, n, Colors.ORANGE);
            }
            return n;
        }
        public bool IsFirstSubtitles(BaseNode b)
        {
            return b.depencies.Exists(d => d.startNode == firstSubtitles);
        }
        protected override void Awake()
        {
            base.Awake();
            if (!nodes.Exists(f => f.drawNode is EnterNode))
            {
                enterNode = new BaseNode(DialogEditor.DrawNodes.EnterNode, 10, 200, "", GenerateId());
                nodes.Add(enterNode);
                enterNode.DialogGraph = this;

            }
            else
            {
                enterNode = nodes.Find(f => f.drawNode is EnterNode);
            }


            if (!nodes.Exists(f => f.drawNode is DialogNode))
            {
                firstSubtitles = new BaseNode(DialogEditor.DrawNodes.DialogNode, 200, 200, "Dialog Audio", GenerateId());
                nodes.Add(firstSubtitles);
                firstSubtitles.DialogGraph = this;

            }
            else
            {
                firstSubtitles = nodes.Find(f => f.drawNode is DialogNode);
                
            }


            SetAsEnterState(enterNode, firstSubtitles, Colors.GREEN);
            Debug.Log("Init");
        }
        public void RemoveDecisionBranch(BaseNode b)
        {

            for (int i = 0; i < b.transitions.Count; i++)
            {
                if (b.transitions.Count == 0) return;
                BaseNode c = b.transitions[i].endNode;

                removeNodesIDs.Add(c.ID);

                RemoveDecisionBranch(c);
            }
        }

        #region CreateDecisionBranchGraphs

        public void AddDecisionBranch1(BaseNode decisionNode, float x, float y)
        {
            firstSubtitles.Decision0 = true;    //firstSubtitles = BaseNode
            string id0 = GenerateId() + 0 + "u", id1 = GenerateId() + 1 + "u", id2 = GenerateId() + 2 + "u"; 


            BaseNode audio = AddNode(DialogEditor.DrawNodes.DialogAudioNode, x, y, "Decision 1 Audio");
            BaseNode even = AddNode(DialogEditor.DrawNodes.DialogEventNode, x + 5, y + 150, "Decision 1 Event");
            BaseNode subtitles = AddNode(DialogEditor.DrawNodes.DialogPartNode, x + 10, y + 300, "Decision 1 Subtitles");

            Transition
             t0 = new Transition(decisionNode, audio, EWindowCurvePlacement.Decision1, EWindowCurvePlacement.LeftCenter, Colors.REDPING, false, "", false, id0),
             t1 = new Transition(audio, even, EWindowCurvePlacement.RightCenter, EWindowCurvePlacement.LeftCenter, Colors.REDPING, false, "", false, id1),
             t2 = new Transition(even, subtitles, EWindowCurvePlacement.RightCenter, EWindowCurvePlacement.LeftCenter, Colors.REDPING, false, "", false, id2);


            t0.removable = false;
            t1.removable = false;
            t2.removable = false;


            even.collapse = true;
            subtitles.collapse = true;
        }

        public void AddDecisionBranch2(BaseNode decisionNode, float x, float y)
        {
            firstSubtitles.Decision1 = true;    //firstSubtitles = BaseNode
            string id0 = GenerateId() + 0 + "u", id1 = GenerateId() + 1 + "u", id2 = GenerateId() + 2 + "u";


            BaseNode audio = AddNode(DialogEditor.DrawNodes.DialogAudioNode, x, y, "Decision 2 Audio");
            BaseNode even = AddNode(DialogEditor.DrawNodes.DialogEventNode, x + 5, y + 150, "Decision 2 Event");
            BaseNode subtitles = AddNode(DialogEditor.DrawNodes.DialogPartNode, x + 10, y + 300, "Decision 2 Subtitles");

            Transition
             t0 = new Transition(decisionNode, audio, EWindowCurvePlacement.Decision2, EWindowCurvePlacement.LeftCenter, Colors.GREEN, false, "", false, id0),
             t1 = new Transition(audio, even, EWindowCurvePlacement.RightCenter, EWindowCurvePlacement.LeftCenter, Colors.GREEN, false, "", false, id1),
             t2 = new Transition(even, subtitles, EWindowCurvePlacement.RightCenter, EWindowCurvePlacement.LeftCenter, Colors.GREEN, false, "", false, id2);


            t0.removable = false;
            t1.removable = false;
            t2.removable = false;


            even.collapse = true;
            subtitles.collapse = true;
        }

        public void AddDecisionBranch3(BaseNode decisionNode, float x, float y)
        {
            firstSubtitles.Decision2 = true;    //firstSubtitles = BaseNode
            string id0 = GenerateId() + 0 + "u", id1 = GenerateId() + 1 + "u", id2 = GenerateId() + 2 + "u";


            BaseNode audio = AddNode(DialogEditor.DrawNodes.DialogAudioNode, x, y, "Decision 3 Audio");
            BaseNode even = AddNode(DialogEditor.DrawNodes.DialogEventNode, x + 5, y + 150, "Decision 3 Event");
            BaseNode subtitles = AddNode(DialogEditor.DrawNodes.DialogPartNode, x + 10, y + 300, "Decision 3 Subtitles");

            Transition
             t0 = new Transition(decisionNode, audio, EWindowCurvePlacement.Decision3, EWindowCurvePlacement.LeftCenter, Colors.CYAN, false, "", false, id0),
             t1 = new Transition(audio, even, EWindowCurvePlacement.RightCenter, EWindowCurvePlacement.LeftCenter, Colors.CYAN, false, "", false, id1),
             t2 = new Transition(even, subtitles, EWindowCurvePlacement.RightCenter, EWindowCurvePlacement.LeftCenter, Colors.CYAN, false, "", false, id2);


            t0.removable = false;
            t1.removable = false;
            t2.removable = false;


            even.collapse = true;
            subtitles.collapse = true;
        }

        public void AddDecisionBranch4(BaseNode decisionNode, float x, float y)
        {
            firstSubtitles.Decision3 = true;    //firstSubtitles = BaseNode
            string id0 = GenerateId() + 0 + "u", id1 = GenerateId() + 1 + "u", id2 = GenerateId() + 2 + "u";


            BaseNode audio = AddNode(DialogEditor.DrawNodes.DialogAudioNode, x, y, "Decision 4 Audio");
            BaseNode even = AddNode(DialogEditor.DrawNodes.DialogEventNode, x + 5, y + 150, "Decision 4 Event");
            BaseNode subtitles = AddNode(DialogEditor.DrawNodes.DialogPartNode, x + 10, y + 300, "Decision 4 Subtitles");

            Transition
             t0 = new Transition(decisionNode, audio, EWindowCurvePlacement.Decision4, EWindowCurvePlacement.LeftCenter, Colors.BLUE, false, "", false, id0),
             t1 = new Transition(audio, even, EWindowCurvePlacement.RightCenter, EWindowCurvePlacement.LeftCenter, Colors.BLUE, false, "", false, id1),
             t2 = new Transition(even, subtitles, EWindowCurvePlacement.RightCenter, EWindowCurvePlacement.LeftCenter, Colors.BLUE, false, "", false, id2);


            t0.removable = false;
            t1.removable = false;
            t2.removable = false;


            even.collapse = true;
            subtitles.collapse = true;
        }

        public void AddDecisionBranch5(BaseNode decisionNode, float x, float y)
        {
            firstSubtitles.Decision4 = true;    //firstSubtitles = BaseNode
            string id0 = GenerateId() + 0 + "u", id1 = GenerateId() + 1 + "u", id2 = GenerateId() + 2 + "u";


            BaseNode audio = AddNode(DialogEditor.DrawNodes.DialogAudioNode, x, y, "Decision 5 Audio");
            BaseNode even = AddNode(DialogEditor.DrawNodes.DialogEventNode, x + 5, y + 150, "Decision 5 Event");
            BaseNode subtitles = AddNode(DialogEditor.DrawNodes.DialogPartNode, x + 10, y + 300, "Decision 5 Subtitles");

            Transition
             t0 = new Transition(decisionNode, audio, EWindowCurvePlacement.Decision5, EWindowCurvePlacement.LeftCenter, Colors.YELLOW, false, "", false, id0),
             t1 = new Transition(audio, even, EWindowCurvePlacement.RightCenter, EWindowCurvePlacement.LeftCenter, Colors.YELLOW, false, "", false, id1),
             t2 = new Transition(even, subtitles, EWindowCurvePlacement.RightCenter, EWindowCurvePlacement.LeftCenter, Colors.YELLOW, false, "", false, id2);


            t0.removable = false;
            t1.removable = false;
            t2.removable = false;


            even.collapse = true;
            subtitles.collapse = true;
        }

        public void AddDecisionTimeOut(BaseNode decisionNode, float x, float y)
        {
            string id0 = GenerateId() + 0 + "u", id1 = GenerateId() + 1 + "u", id2 = GenerateId() + 2 + "u";


            BaseNode audio = AddNode(DialogEditor.DrawNodes.DialogAudioNode, x, y, "TimedOut Audio");
            BaseNode even = AddNode(DialogEditor.DrawNodes.DialogEventNode, x + 5, y + 150, "TimedOut Event");
            BaseNode subtitles = AddNode(DialogEditor.DrawNodes.DialogPartNode, x + 10, y + 300, "TimedOut Subtitles");

            Transition
             t0 = new Transition(decisionNode, audio, EWindowCurvePlacement.CenterBottom, EWindowCurvePlacement.CenterTop, Colors.RED, false, "", false, id0),
             t1 = new Transition(audio, even, EWindowCurvePlacement.CenterTop, EWindowCurvePlacement.CenterBottom, Colors.RED, false, "", false, id1),
             t2 = new Transition(even, subtitles, EWindowCurvePlacement.CenterTop, EWindowCurvePlacement.CenterBottom, Colors.RED, false, "", false, id2);


            t0.removable = false;
            t1.removable = false;
            t2.removable = false;


            even.collapse = true;
            subtitles.collapse = true;
        }

        #endregion

        public void Skip()
        {
            if (skipable)
            {
                lifeCycle.Skip();
            }
        }
        public void Play()
        {
            if (!IsPlaying())
            {
                if (isStopped)
                {
                    if (!CanPlay()) return;

                    ResetDialog();
                }
                lifeCycle.Play();
                isStopped = false;
                isPaused = false;
            }
        }

        public void Pause()
        {
            if (IsPlaying())
            {
                lifeCycle.Pause();
                isPaused = true;

            }
        }
        public bool IsPlaying()
        {
            return !isPaused && !isStopped && lifeCycle.IsPlaying();
        }
        public void Stop()
        {
            if (IsPlaying())
            {
                lifeCycle.Stop();
                isStopped = true;

            }
        }

        private bool CanPlay()
        {
            return IsEnable ? (unlimitedRepeating ? true : (repeatable ? repeatLimit > playCount : !wasPlayed)) : false;
        }
        public void ResetDialog()
        {
            playCount++;
        }
        public void InitDialog()
        {
            lifeCycle = new DialogLifeCycle(this);
        }
    }


}
