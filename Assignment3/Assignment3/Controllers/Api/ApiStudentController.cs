using Microsoft.AspNetCore.Mvc;
using Assignment3.Models;
using Assignment3.Models.Repository;

namespace Assignment3.Api.Controllers;

// API for Students

[ApiController]
[Route("api/students")]
public class ApiStudentController : ControllerBase
{
    private readonly IStudentRepository _repo;

    public ApiStudentController(IStudentRepository repo)
    {
        _repo = repo;
    }

    // GET: api/students
    [HttpGet]
    public IEnumerable<Student> Get()
    {
        return _repo.GetAll();
    }

}