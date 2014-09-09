using System;
using System.Net;
using ModernHttpClient;
using System.Threading.Tasks;
using System.Net.Http;
using ServiceStack.Text;
using bscheiman.Common.Extensions;

namespace App.Json {
	public static class JsonHelper {
		static JsonHelper() {
			// TODO: Remove this for real-world usage
			ServicePointManager.ServerCertificateValidationCallback = delegate {
				return true;
			};
		}

		internal static async Task<TReturn> Send<TReturn>(HttpClient client, HttpMethod method, string url, object queryString = null, object post = null) {
			JsConfig.IncludePublicFields = true;
			JsConfig.IncludeNullValues = true;

			var uri = url + queryString.ToQueryString();

			// TODO: Add headers
			//client.DefaultRequestHeaders.Add("", "");

			string jsonResponse;
			HttpResponseMessage response = null;

			switch (method.Method.ToUpper()) {
				case "DELETE":
					response = await client.DeleteAsync(uri);

					break;

				case "GET":
					response = await client.GetAsync(uri);

					break;

				case "POST":
					response = await client.PostAsync(uri, new StringContent(post.ToJson() ?? ""));

					break;

				case "PUT":
					response = await client.PutAsync(uri, new StringContent(post.ToJson() ?? ""));

					break;

				default:
					throw new ArgumentException("Unsupported method");
			}

			jsonResponse = await response.Content.ReadAsStringAsync();

			return string.IsNullOrEmpty(jsonResponse) ? default(TReturn) : jsonResponse.FromJson<TReturn>();
		}

		public static Task<TReturn> Delete<TReturn>(string cmd, string queryString = null) {
			using (var client = new HttpClient(new NativeMessageHandler()))
				return Send<TReturn>(client, HttpMethod.Post, cmd, queryString);
		}

		public static Task<TReturn> Get<TReturn>(string cmd, string queryString = null) {
			using (var client = new HttpClient(new NativeMessageHandler()))
				return Send<TReturn>(client, HttpMethod.Post, cmd, queryString);
		}

		public static Task<TReturn> Post<TReturn>(string cmd, string queryString = null, object post = null) {
			using (var client = new HttpClient(new NativeMessageHandler()))
				return Send<TReturn>(client, HttpMethod.Post, cmd, queryString, post);
		}

		public static Task<TReturn> Put<TReturn>(string cmd, string queryString = null, object post = null) {
			using (var client = new HttpClient(new NativeMessageHandler()))
				return Send<TReturn>(client, HttpMethod.Post, cmd, queryString, post);
		}
	}	
}
