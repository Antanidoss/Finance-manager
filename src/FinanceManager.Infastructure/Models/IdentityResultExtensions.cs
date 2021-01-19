﻿using FinanceManager.Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace FinanceManager.Infastructure.Models
{
    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => e.Description));
        }       

        public static Result EmailIsBusy()
        {
            return Result.Failure(new[] { "Эта эл.почта уже используется на сайте" });
        }
    }
}
