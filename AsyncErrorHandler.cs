using System;

namespace App {
	public static class AsyncErrorHandler {
		public static void HandleException(Exception exception) {
			Console.WriteLine(exception);
		}
	}
}

