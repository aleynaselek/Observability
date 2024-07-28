using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observability.ConsoleApp
{
    internal class ServiceOne
    {
        static HttpClient httpClient = new HttpClient();
        internal async Task<int> MakeRequestToGoogle()
        {
            using var activity = ActivitySourceProvider.Source.StartActivity();

            var eventTags = new ActivityTagsCollection();
            eventTags.Add("userId", 30);

            activity.AddEvent(new("google'a istek başladı", tags: eventTags));

            var result =await httpClient.GetAsync("https://www.google.com");
            var responseContent = await result.Content.ReadAsStringAsync();

            return responseContent.Length;
        }
    }
}
