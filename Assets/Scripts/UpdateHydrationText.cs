using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using TMPro;


namespace NodeCanvas.Tasks.Actions {

	public class UpdateHydrationText : ActionTask {

		Blackboard blackboard;
		public TMPro.TextMeshProUGUI hydrationText;
        float hydrationLevel;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            // Get reference to blackboard
            blackboard = agent.GetComponent<Blackboard>();
            // Get initial hydration level
            hydrationLevel = blackboard.GetVariableValue<float>("Hydration");
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            // Get hydration level from blackboard
            hydrationLevel = blackboard.GetVariableValue<float>("Hydration");
            // Update hydration text
            hydrationText.text = (Mathf.RoundToInt(hydrationLevel)).ToString();
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}