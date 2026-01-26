using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class DecreaseHydration : ActionTask {

        Blackboard blackboard;
        float hydrationLevel;
		float decreaseAmount;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            // Get reference to blackboard
            blackboard = agent.GetComponent<Blackboard>();
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            // Get DecreaseAmount from blackboard
            decreaseAmount = blackboard.GetVariableValue<float>("DecreaseAmount");
            // Get hydration level
            hydrationLevel = blackboard.GetVariableValue<float>("Hydration");

            // Decrease hydration level by decreaseAmount
            hydrationLevel -= decreaseAmount;

            if (hydrationLevel > 100)
            {
                hydrationLevel = 100;
            }

            // Update hydration level in blackboard
            blackboard.SetVariableValue("Hydration", hydrationLevel);

            // Check if hydration level is less than or equal to 0
            if (hydrationLevel <= 0)
            {
                hydrationLevel = 0;
                blackboard.SetVariableValue("Hydration", hydrationLevel);
                // Mark the action as finished
                EndAction();
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}