using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using CWLB.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace CWLB
{
    internal class API
    {
        public static string sb_anon_key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImNyb2lxbGZqZ29maG9rZnJwYWdrIiwicm9sZSI6ImFub24iLCJpYXQiOjE2NjU3ODE3NDQsImV4cCI6MTk4MTM1Nzc0NH0.OBdI7jvIYdI1lwVqxJa41L4ASoQuCb6n3GKolwVYglA";

        public static void AddToLeaderboard(string modGuid, string modName, string playerName, int score)
        {
            var lbEntry = new LeaderboardEntry
            {
                mod_guid = modGuid,
                mod_name = modName,
                player_name = playerName,
                score = score
            };
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://croiqlfjgofhokfrpagk.supabase.co/rest/v1/Leaderboards");
            request.Headers.Add("apikey", API.sb_anon_key);
            request.Content = new StringContent(JsonUtility.ToJson(lbEntry));
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            var response = client.SendAsync(request).Result;
            var respText = response.Content.ReadAsStringAsync().Result;
        }

        public static IEnumerable<GetAllEntries> GetAllEntries()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://croiqlfjgofhokfrpagk.supabase.co/rest/v1/Leaderboards?select=*");
            request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            request.Headers.Add("apikey", API.sb_anon_key);
            var response = client.SendAsync(request).Result;
            var jsonStr = response.Content.ReadAsStringAsync().Result ?? "ERROR";
            return JsonUtility.FromJson<IEnumerable<GetAllEntries>>(jsonStr);
        }
    }
}
