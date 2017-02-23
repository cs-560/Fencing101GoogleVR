using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace UnityEngine.UI{
	public class ScreenCenterGraphicRaycaster : GraphicRaycaster {
		public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList){
			eventData.position = new Vector2 (Screen.width/2.0f, Screen.height/2.0f);
			base.Raycast (eventData, resultAppendList);
		}
	}
}
