using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rejsetidspunkt.Services
{
	internal class GestureRecognitionService
	{
		SwipeGestureRecognizer leftSwipeGesture;
		
		public GestureRecognitionService()
		{
			leftSwipeGesture = new SwipeGestureRecognizer() { Direction = SwipeDirection.Left };
			leftSwipeGesture.Swiped += LeftSwipeGesture_Swiped;
		}

		private void LeftSwipeGesture_Swiped(object sender, SwipedEventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}
