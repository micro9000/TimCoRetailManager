using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Configuration;
using TRMDesktopUI.Models;

namespace TRMDesktopUI.Helpers
{
	public class APIHelper : IAPIHelper
	{
		private HttpClient apiClient
		{
			get; set;
		}

		public APIHelper ()
		{
			InitializeClient();
		}

		private void InitializeClient ()
		{
			string api = ConfigurationManager.AppSettings["api"];

			apiClient = new HttpClient();
			apiClient.BaseAddress = new Uri(api);
			apiClient.DefaultRequestHeaders.Accept.Clear();
			apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public async Task<AuthenticatedUser> Authenticate (string username, string password)
		{
			// ranielgarcia101@gmail.com
			// SWORDfish@2020
			var data = new FormUrlEncodedContent(new []
			{
				new KeyValuePair<string, string>("grant_type", "password"),
				new KeyValuePair<string, string>("username", username),
				new KeyValuePair<string, string>("password", password)
			});

			using (HttpResponseMessage response = await apiClient.PostAsync("/Token", data))
			{
				if (response.IsSuccessStatusCode)
				{
					var results = await response.Content.ReadAsAsync<AuthenticatedUser>();
					return results;
				}
				else
				{
					throw new Exception(response.ReasonPhrase);
				}
			}

		}
	}
}
