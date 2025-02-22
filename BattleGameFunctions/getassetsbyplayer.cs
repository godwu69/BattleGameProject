using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using BattleGameFunctions.Models;

public static class GetAssetsByPlayer
{
    [FunctionName("getassetsbyplayer")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        // Lấy PlayerId từ query string
        string playerId = req.Query["playerId"];

        // Kiểm tra PlayerId có hợp lệ không
        if (string.IsNullOrEmpty(playerId)
        {
            return new BadRequestObjectResult("PlayerId is required.");
        }

        // Truy vấn database để lấy danh sách tài sản của người chơi
        using (var context = new BattleGameContext())
        {
            var assets = context.PlayerAssets
                .Where(pa => pa.PlayerId == Guid.Parse(playerId))
                .Select(pa => new
                {
                    PlayerName = pa.Player.PlayerName,
                    Level = pa.Player.Level,
                    Age = pa.Player.Age,
                    AssetName = pa.Asset.AssetName
                }).ToList();

            // Trả về kết quả
            return new OkObjectResult(assets);
        }
    }
}