using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class WalkToLocationAT : ActionTask {


        public BBParameter<Transform> CurrentDestination;
        public BBParameter<NavMeshAgent> NavAgent;
        public BBParameter<Transform> endLocation;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			walkToLocation();
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}

		private void walkToLocation()
		{
			NavAgent.value.SetDestination(CurrentDestination.value.position);
			if(Vector3.Distance(agent.transform.position,CurrentDestination.value.position) <  0.5f)
			{
				Debug.Log("arrived");
				EndAction(true);
			}
		}
		private void isItOver()
		{
            if (Vector3.Distance(agent.transform.position, CurrentDestination.value.position) < 0.5f && 
				CurrentDestination.value.position == endLocation.value.position)
            {
                Debug.Log("left the store");
                EndAction(false);
            }
        }
	}
}