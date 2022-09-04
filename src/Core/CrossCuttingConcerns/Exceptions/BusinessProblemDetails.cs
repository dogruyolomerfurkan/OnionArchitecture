using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CrossCuttingConcerns.Exceptions;

/// <summary>
/// this keyword means created method itself
/// </summary>
public class BusinessProblemDetails : ProblemDetails
{
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
