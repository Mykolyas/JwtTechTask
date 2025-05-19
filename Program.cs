
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using JwtTechTask.Models;
using JwtTechTask.Helpers;

namespace JwtTechTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string jwt = "eyJhbGciOiJub25lIn0.eyJkYXRhIjpbeyJ1c2VySWQiOiIxMjM0NSIsInRyYW5zYWN0aW9ucyI6W3siaWQiOiIxIiwiYW1vdW50Ijo1MCwiY3VycmVuY3kiOiJVQUgiLCJtZXRhIjp7InNvdXJjZSI6IkNBQiIsImNvbmZpcm1lZCI6dHJ1ZX0sInN0YXR1cyI6IkNvbXBsZXRlZCJ9LHsiaWQiOiIyIiwiYW1vdW50IjozMC41LCJjdXJyZW5jeSI6IlVBSCIsIm1ldGEiOnsic291cmNlIjoiQUNCIiwiY29uZmlybWVkIjpmYWxzZX0sInN0YXR1cyI6IkluUHJvZ3Jlc3MifSx7ImlkIjoiMyIsImFtb3VudCI6ODkuOTksImN1cnJlbmN5IjoiVUFIIiwibWV0YSI6eyJzb3VyY2UiOiJDQUIiLCJjb25maXJtZWQiOnRydWV9LCJzdGF0dXMiOiJDb21wbGV0ZWQifV19LHsidXNlcklkIjoidTEyMyIsInRyYW5zYWN0aW9ucyI6W3siaWQiOiIxIiwiYW1vdW50Ijo0NDM0LCJjdXJyZW5jeSI6IkVVUiIsIm1ldGEiOnsic291cmNlIjoiQ0FCIiwiY29uZmlybWVkIjp0cnVlfSwic3RhdHVzIjoiQ29tcGxldGVkIn0seyJpZCI6IjIiLCJhbW91bnQiOjU2LjUzLCJjdXJyZW5jeSI6IlVBSCIsIm1ldGEiOnsic291cmNlIjoiQUNCIiwiY29uZmlybWVkIjpmYWxzZX0sInN0YXR1cyI6Mn1dfV19.";
            string json = JwtDecoder.DecodePayload(jwt);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            RootPayload payload = JsonSerializer.Deserialize<RootPayload>(json, options);

            if (payload == null)
            {
                Console.WriteLine("❌ Error: Payload could not be deserialized.");
                return;
            }

            foreach (var user in payload.data)
            {
                Console.WriteLine($"\nUser ID: {user.userId}");

                int transactionCount = user.transactions?.Count ?? 0;
                Console.WriteLine($"  Transactions Count: {transactionCount}");

                var confirmedTransactions = user.transactions?
                    .Where(t => t.meta?.confirmed == true);

                if (confirmedTransactions == null || !confirmedTransactions.Any())
                {
                    Console.WriteLine("  No confirmed transactions.");
                    continue;
                }

                var totalsByCurrency = confirmedTransactions
                    .GroupBy(t => t.currency)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Sum(t => t.amount)
                    );

                Console.WriteLine("  Confirmed Totals:");
                foreach (var kvp in totalsByCurrency)
                {
                    Console.WriteLine($"    - {kvp.Key}: {kvp.Value:F2}");
                }
            }
        }
    }
}
