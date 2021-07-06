
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.GameObject)]
	[Tooltip("Translates a Game Object. Use a Vector3 variable and/or XYZ components. To leave any axis unchanged, set variable to 'None'.")]
	public class SetAsLastSiblingIndex : FsmStateAction
	{
		[RequiredField]
		[Tooltip("The game object to translate.")]
		public FsmOwnerDefault gameObject;
	   
        [Tooltip("原本的排序序号")]
        public FsmInt OriginalSiblingIndex ;
	
		public override void Reset()
		{
			gameObject = null;
			OriginalSiblingIndex = null;
			
		}

		public override void OnEnter()
		{
			
				DoTranslate();
				Finish();
			
		}


		void DoTranslate()
		{   var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null) return;
			OriginalSiblingIndex.Value = go.transform.GetSiblingIndex();
			var count =go.transform.childCount-1;
			go.transform.SetSiblingIndex(count);

	}
	
}}