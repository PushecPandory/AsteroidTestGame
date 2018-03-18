using UnityEngine;

namespace TestGame
{
	public class PlayerView : MonoBehaviour 
	{
		[SerializeField]
		private GameObject _body; 
		[SerializeField]
		private GameObject _dyingAnim; 

		public void SetDisabledView()
		{
			_body.SetActive(false);
			_dyingAnim.SetActive(false);
		}

		public void SetAliveView(bool enable)
		{
			_body.SetActive(enable);
		}

		public void SetDyingView(bool enable)
		{
			_dyingAnim.SetActive(enable);
		}
	}
}

