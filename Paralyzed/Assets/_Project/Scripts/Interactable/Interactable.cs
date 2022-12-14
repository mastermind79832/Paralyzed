using UnityEngine;

namespace Paralysed.Interactable
{
    public abstract class Interactable : MonoBehaviour
    {
		private void OnTriggerEnter2D(Collider2D collision)
		{
			Interact(collision);
		}

		protected abstract void Interact(Collider2D collision);
	}
}
