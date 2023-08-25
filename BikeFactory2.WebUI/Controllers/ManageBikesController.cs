using BikeFactory2.WebUI.Models;
using BikeFactory2.WebUI.WebApiClients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace BikeFactory2.WebUI.Controllers;
[Authorize]
public class ManageBikesController : Controller
{
    private readonly IConfiguration _configuration;
    private BikeFactory2WebAPIClient _webApiClient;

    public ManageBikesController(IConfiguration configuration)
    {
        _configuration = configuration;

        string serverAddress = configuration["BikeFactoryWebApiServer"];

        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(serverAddress);
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _webApiClient = new BikeFactory2WebAPIClient(httpClient);
    }

    public async Task<IActionResult> Index()
    {
        var listOfBikes = new List<Bikes>();
        try
        {
            listOfBikes = (List<Bikes>)await _webApiClient.BikeAllAsync(EBikeCriteria.All);
        }
        catch (Exception ex)
        {
            ViewBag.Message = new MessageViewModel(EMessageType.Danger, ex.Message);
        }
     
        return View(listOfBikes);
    }
    public async Task<IActionResult> AddOrUpdate(int? id)
    {
        if (id == null)
            return View();
        Bikes? bike = null;
        try
        {
            bike = await _webApiClient.BikeGETAsync(id.Value);
            if (bike == null)
                return View("NotFound");
        }
        catch (Exception ex)
        {
            ViewBag.Message = new MessageViewModel(EMessageType.Danger, ex.Message);
        }
        return View(bike);
    }

    [HttpPost]
    public async Task<IActionResult> AddOrUpdate(Bikes bike)
    {
        if (!ModelState.IsValid)
            return (bike.Id == 0) ? View() : View(bike);
        try
        {
            if (bike.Id == 0)
                await _webApiClient.BikePOSTAsync(bike);
            else await _webApiClient.BikePUTAsync(bike);
        }
        catch (Exception ex)
        {
            ViewBag.Message = new MessageViewModel(EMessageType.Danger, ex.Message);
            return (bike.Id == 0) ? View() : View(bike);
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Remove(int id)
    {
        try
        {
            var bike = await _webApiClient.BikeGETAsync(id);
            if (bike != null)
                await _webApiClient.BikeDELETEAsync(id);
        }
        catch (Exception ex)
        {
            ViewBag.Message = new MessageViewModel(EMessageType.Danger, ex.Message);
        }
        return RedirectToAction(nameof(Index));
    }
}
