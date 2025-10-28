using System.Net.Mime;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Assignment3.Models;
using Newtonsoft.Json;

namespace Assignment3.Controllers;

// Controller to consume API endpoints
public class StudentController : Controller
{
    private readonly HttpClient _client;

    public StudentController(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("api");
    }

    // GET: Students/Index
    public async Task<IActionResult> Index()
    {
        using var response = await _client.GetAsync("api/students"); // Call api to get all students

        response.EnsureSuccessStatusCode();

        // Storing the response details received from web api.
        var result = await response.Content.ReadAsStringAsync();

        // Deserialize response and store as List of Students
        var students = JsonConvert.DeserializeObject<List<Student>>(result);

        return View(students); // Pass list into View
    }


}
