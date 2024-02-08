using System;
using Microsoft.AspNetCore.Mvc;
using MongoExample.Services;
using MongoExample.Models;

namespace MongoExample.Controllers;

[Controller]
[Route("api/[controller]/[action]")]
public class StudentListController: Controller
{
    private readonly MongoDBService _mongoDBService;
    public StudentListController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }

    [HttpGet]
    public async Task<List<StudentList>> Get() 
    {
        return await _mongoDBService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] StudentList studentList) 
    {
        await _mongoDBService.CreateAsync(studentList);
        return CreatedAtAction(nameof(Get), new { id =  studentList.Id }, studentList);
    }

    [HttpPut("(Id)")]
    public async Task<IActionResult> AddToStudentList(string Id, [FromBody] string studentId) 
    {
        await _mongoDBService.AddToStudentListAsync(Id, studentId);
        return NoContent();
    }

    [HttpDelete("(Id)")]
    public async Task<IActionResult> Delete(string Id) 
    {
        await _mongoDBService.DeleteAsync(Id);
        return NoContent();
    }

}