﻿
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace bookstore.bookstore_models.ViewModels;

public class BookVM
{
    public Book Book {get; set;}
    [ValidateNever]
    public IEnumerable<SelectListItem>  CategoryList {get; set;}

}
