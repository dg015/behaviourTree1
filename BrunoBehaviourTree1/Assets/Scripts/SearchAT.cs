using NodeCanvas.Framework;
using NodeCanvas.Tasks.Conditions;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SearchAT : ActionTask {

		public BBParameter<Transform> Platform;
        public BBParameter<Transform> Platform1;
        public BBParameter<Transform> Platform2;
        public BBParameter<Transform> PlatformExit;
        public BBParameter<Transform> CurrentDestination;
        public BBParameter<float> SearchTimer;
        public BBParameter<int> SearchedLocations;
        public float CurrentTime;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			CurrentTime = 0;

            //EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			timer();
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			SearchedLocations.value++;
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
		private void timer()
		{
			if(CurrentTime <= SearchTimer.value)
			{
				CurrentTime += Time.deltaTime;
			}

		}

		private void ChooseNextLocation()
		{
			int NextLocationId = Random.Range(0, 3);
			switch(NextLocationId)
			{
				case 0:
					if(Vector3.Distance(Platform.value.position, agent.transform.position) >1f)
					{
						Debug.Log("platform 1 chosen");
						CurrentDestination.value.position = Platform.value.position;
					}
					else
					{
                        Debug.Log("platform 1 skipped");
                        break;
						//skip this case
					}
					break; 
				
				case 1:
                    if (Vector3.Distance(Platform1.value.position, agent.transform.position) > 1f)
                    {
                        Debug.Log("platform 2 chosen");
                        CurrentDestination.value.position = Platform1.value.position;
                    }
                    else
                    {
                        Debug.Log("platform 2 skipped");
                        break;
                        //skip this case
                    }
                    break;
					case 2:
                    if (Vector3.Distance(Platform2.value.position, agent.transform.position) > 1f)
                    {
                        Debug.Log("platform 3 chosen");
                        CurrentDestination.value.position = Platform2.value.position;
                    }
                    else
                    {
                        Debug.Log("platform 3 skipped");
                        break;
                        //skip this case
                    }
					break;
            }

		}
	}
}