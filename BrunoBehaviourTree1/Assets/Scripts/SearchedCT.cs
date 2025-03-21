using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class SearchedCT : ConditionTask {
		public BBParameter<int> NumberOfSearchedLocation;
		public BBParameter <int> requiredNumberOfLocation;
        public BBParameter<Vector3> CurrentDestination;
		public BBParameter<Transform> ExitLocation;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			//check if the character has compared all of the milk prices
			if(NumberOfSearchedLocation.value >= requiredNumberOfLocation.value)
			{
				CurrentDestination.value = ExitLocation.value.position;
			}
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			return true;
		}
	}
}