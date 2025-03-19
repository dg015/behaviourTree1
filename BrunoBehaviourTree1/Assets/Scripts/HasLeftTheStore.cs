using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class HasLeftTheStore : ConditionTask {

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        public BBParameter<int> requiredNumberOfLocation;
        public BBParameter<int> NumberOfSearchedLocation;
		public bool isOver;
        protected override string OnInit(){
			return null;
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
            HasItEnded();
			//if it matches return false and end the loop otherwise continue it 
            if (isOver)
            {
				//stops loop
				return false;
            }
			else
			{
				//continue the loop
                return true;
            }
		}

		private void HasItEnded()
		{
			//check if it matches the number of searched locations
			if (requiredNumberOfLocation.value == NumberOfSearchedLocation.value)
			{
				isOver = true;
			}
			else
			{
				isOver = false;
			}
		}
	}
}