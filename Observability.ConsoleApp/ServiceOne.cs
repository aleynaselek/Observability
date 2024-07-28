using Observability.ConsoleApp;
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

            activity?.AddEvent(new("google'a istek başladı", tags: eventTags));
             
            var result =await httpClient.GetAsync("https://www.google.com");

            var responseContent = await result.Content.ReadAsStringAsync();

            eventTags.Add("google body length", responseContent.Length);
            activity?.AddEvent(new("google'a istek tamamlandı", tags: eventTags));
            return responseContent.Length;
        }
    }
}
