using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BattleGameFunctions.Models;

public static class RegisterPlayer
{
    [FunctionName("registerplayer")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var player = JsonConvert.DeserializeObject<Player>(requestBody);

        using (var context = new BattleGameContext())
        {
            context.Players.Add(player);
            await context.SaveChangesAsync();
        }

        return new OkObjectResult("Player registered successfully.");
    }
}