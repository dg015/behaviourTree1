using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class WalkToLocationAT : ActionTask {


        public BBParameter<Vector3> CurrentDestination;
        public BBParameter<NavMeshAgent> NavAgent;
        public BBParameter<Transform> endLocation;

		public Transform firstPlatform;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            CurrentDestination.value = firstPlatform.position;
            return null;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			walkToLocation();
			isItOver();

        }

		private void walkToLocation()
		{
			//walk to the direction of the current destination
			NavAgent.value.SetDestination(CurrentDestination.value);
			//check distanc , if its close enough them end action
			if(Vector3.Distance(agent.transform.position,CurrentDestination.value) <  0.5f)
			{
				Debug.Log("arrived");
				EndAction(true);
			}
		}
		private void isItOver()
		{
			//here it checks first if its close to the exit of the store but it also checks if the current location is the same as the end platform to
			//extra make sure  its the correct location
            if (Vector3.Distance(agent.transform.position, CurrentDestination.value) < 0.5f && 
				CurrentDestination.value == endLocation.value.position)
            {
                Debug.Log("left the store");
                EndAction(false);
            }
        }
	}
}