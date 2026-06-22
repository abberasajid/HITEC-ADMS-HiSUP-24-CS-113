using HiSUP.Data;
using HiSUP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HiSUP.Controllers;

public class CourseController : Controller
{
    private readonly ApplicationDbContext _context;

    public CourseController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Course
    public async Task<IActionResult> Index()
    {
        var courses = await _context.Courses
            .Where(c => c.IsActive)
            .OrderBy(c => c.CourseCode)
            .ToListAsync();
        return View(courses);
    }

    // GET: /Course/Create
    public async Task<IActionResult> Create()
    {
        ViewBag.Programs = await _context.Programs.ToListAsync();
        return View();
    }

    // POST: /Course/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Course course)
    {
        try
        {
            course.IsActive = true;
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Course added successfully!";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            TempData["Error"] = "Error: " + ex.Message;
            ViewBag.Programs = await _context.Programs.ToListAsync();
            return View(course);
        }
    }
}