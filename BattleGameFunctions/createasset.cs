using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BattleGameFunctions.Models;

public static class CreateAsset
{
    [FunctionName("createasset")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        // Đọc dữ liệu từ request body
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var asset = JsonConvert.DeserializeObject<Asset>(requestBody);

        // Kiểm tra dữ liệu đầu vào
        if (asset == null || string.IsNullOrEmpty(asset.AssetName)
        {
            return new BadRequestObjectResult("Asset data is invalid.");
        }

        // Lưu tài sản vào database
        using (var context = new BattleGameContext())
        {
            context.Assets.Add(asset);
            await context.SaveChangesAsync();
        }

        // Trả về kết quả thành công
        return new OkObjectResult("Asset created successfully.");
    }
}