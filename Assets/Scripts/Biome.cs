using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class Biome : ActionTask {

        Blackboard blackboard;
        public TMPro.TextMeshProUGUI biome;
        float biomeLevel;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            blackboard = agent.GetComponent<Blackboard>();
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			biomeLevel = Random.Range(0.0001f, 0.0011f);
            blackboard.SetVariableValue("DecreaseAmount", biomeLevel);

			if (biomeLevel < 0.0005f)
            {
                biome.text = "Desert Biome";
            }
            else
            {
                biome.text = "Forest Biome";
            }

            EndAction();
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}