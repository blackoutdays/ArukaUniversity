using arusha.Services;
using Microsoft.AspNetCore.Mvc;

public class StoredProcedureController : Controller
{
    private readonly StoredProcedureService _storedProcedureService;

    public StoredProcedureController(StoredProcedureService storedProcedureService)
    {
        _storedProcedureService = storedProcedureService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ExecuteStoredProcedure(int parameter)
    {
        var result = _storedProcedureService.ExecuteStoredProcedure(parameter);
        ViewData["Result"] = result;
        return View("Result"); // "Result.cshtml"
    }

}
