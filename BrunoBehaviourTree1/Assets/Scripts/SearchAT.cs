using NodeCanvas.Framework;
using NodeCanvas.Tasks.Conditions;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UI;


namespace NodeCanvas.Tasks.Actions {

	public class SearchAT : ActionTask {

		public Transform Platform;
        public Transform Platform1;
        public Transform Platform2;
        public BBParameter<Transform> PlatformExit;
        public BBParameter<Vector3> CurrentDestination;
        public BBParameter<float> SearchTimer;
        public BBParameter<int> SearchedLocations;
        public float CurrentTime;

		public Image image;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//reset variables
			CurrentTime = 0;
            //EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			timer();
			image.fillAmount = CurrentTime / 5;
            
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			//increment by one when the code stops, which means the character has finished looking for the milk to compare
			SearchedLocations.value++;
			image.fillAmount = 0;

        }

		private void timer()
		{
			//if the current timer has not reached the required value increases the timer, otherwise choose new location
			if(CurrentTime <= SearchTimer.value)
			{
				CurrentTime += Time.deltaTime;
				
			}
			else
			{
                //if the timer is complete choose a new location
                ChooseNextLocation();
            }

		}

		private void ChooseNextLocation()
		{
			//generate a random number so it feels more natural
			int NextLocationId = Random.Range(0, 3);
			switch(NextLocationId)
			{
				case 0:
					//if the character is already at the location skip it, otherwise set the as the new locaiton
					// I check if the player is at the platform by checking their current position is close enough to the platform im checking for
					//this is for all switch cases
					if(Vector3.Distance(Platform.position, agent.transform.position) >1f)
					{
						Debug.Log("platform 1 chosen");
						CurrentDestination.value = Platform.position;
						EndAction(true);
					}
					else
					{
                        Debug.Log("platform 1 skipped");
                        break;
						//skip this case
					}
					break; 
				
				case 1:
                    if (Vector3.Distance(Platform1.position, agent.transform.position) > 1f)
                    {
                        Debug.Log("platform 2 chosen");
                        CurrentDestination.value = Platform1.position;
                        EndAction(true);
                    }
                    else
                    {
                        Debug.Log("platform 2 skipped");
                        break;
                        //skip this case
                    }
                    break;
					case 2:
                    if (Vector3.Distance(Platform2.position, agent.transform.position) > 1f)
                    {
                        Debug.Log("platform 3 chosen");
                        CurrentDestination.value = Platform2.position;
                        EndAction(true);
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