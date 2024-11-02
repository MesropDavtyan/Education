using System.Net;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MinimalApiTest;
using MinimalApiTest.Data;
using MinimalApiTest.Models;
using MinimalApiTest.Models.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/coupons", (ILogger<Program> logger) =>
{
    APIResponse response = new ();
    logger.Log(LogLevel.Information,"Getting all Coupons");
    response.Result = CouponStore.couponList;
    response.IsSuccess = true;
    response.StatusCode = HttpStatusCode.OK;
    
    return Results.Ok(response);
})
    .WithName("GetCoupons")
    .Produces<IEnumerable<Coupon>>(200);

app.MapGet("/api/coupon/{id:int}", (int id) =>
{
    APIResponse response = new ();
    response.Result = CouponStore.couponList.FirstOrDefault(c => c.Id == id);
    response.IsSuccess = true;
    response.StatusCode = HttpStatusCode.OK;
    
    return Results.Ok(response);
})
    .WithName("GetCoupon")
    .Produces<Coupon>(200);

app.MapPost("/api/coupon", async (IMapper mapper, IValidator<CouponCreateDTO> validator, [FromBody] CouponCreateDTO couponCreateDto) =>
{
    APIResponse response = new () {IsSuccess = false, StatusCode = HttpStatusCode.BadRequest};
    var validationResult = await validator.ValidateAsync(couponCreateDto);
    
    if (!validationResult.IsValid)
    {
        response.ErrorMessages.Add(validationResult.Errors.FirstOrDefault()!.ToString());
        return Results.BadRequest(response);
    }

    if (CouponStore.couponList.FirstOrDefault(c => c.Name.ToLower() == couponCreateDto.Name.ToLower()) != null)
    {
        response.ErrorMessages.Add("A coupon with the same name already exists");
        return Results.BadRequest(response);
    }
    
    var coupon = mapper.Map<Coupon>(couponCreateDto);
    coupon.Id = CouponStore.couponList.OrderByDescending(c => c.Id).FirstOrDefault()!.Id + 1;
    CouponStore.couponList.Add(coupon);
    var couponDto = mapper.Map<CouponDTO>(coupon);
    
    response.Result = couponDto;
    response.IsSuccess = true;
    response.StatusCode = HttpStatusCode.Created;
    
    return Results.Ok(response);
    //return Results.CreatedAtRoute("GetCoupon", new { id = coupon.Id }, couponDto);
    //return Results.Created($"/api/coupon/{coupon.Id}", coupon);
})
    .WithName("CreateCoupon")
    .Accepts<CouponCreateDTO>("application/json")
    .Produces<APIResponse>(201)
    .Produces(400);

app.MapPut("/api/coupon", async (IMapper mapper, IValidator<CouponUpdateDTO> validator, [FromBody] CouponUpdateDTO couponUpdateDto) =>
{
    APIResponse response = new () {IsSuccess = false, StatusCode = HttpStatusCode.BadRequest};
    var validationResult = await validator.ValidateAsync(couponUpdateDto);

    if (!validationResult.IsValid)
    {
        response.ErrorMessages.Add(validationResult.Errors.FirstOrDefault()!.ToString());
        return Results.BadRequest(response);
    }
    
    var couponFromStore = CouponStore.couponList.FirstOrDefault(c => c.Id == couponUpdateDto.Id);

    if (couponFromStore != null)
    {
        couponFromStore.IsActive = couponUpdateDto.IsActive;
        couponFromStore.Name = couponUpdateDto.Name;
        couponFromStore.Percent = couponUpdateDto.Percent;
        couponFromStore.LastUpdated = DateTime.Now;
    }

    var couponDto = mapper.Map<CouponDTO>(couponFromStore);

    response.Result = couponDto;
    response.IsSuccess = true;
    response.StatusCode = HttpStatusCode.OK;

    return Results.Ok(response);
})    
    .WithName("UpdateCoupon")
    .Accepts<CouponUpdateDTO>("application/json")
    .Produces<APIResponse>(200)
    .Produces(400);

app.MapDelete("/api/coupon/{id:int}", (int id) =>
{
    APIResponse response = new () {IsSuccess = false, StatusCode = HttpStatusCode.BadRequest};
    
    var couponFromStore = CouponStore.couponList.FirstOrDefault(c => c.Id == id);

    if (couponFromStore != null)
    {
        CouponStore.couponList.Remove(couponFromStore);
        response.IsSuccess = true;
        response.StatusCode = HttpStatusCode.NoContent;
        return Results.Ok(response);
    }
    else
    {
        response.ErrorMessages.Add("Coupon not found");
        return Results.BadRequest(response);
    }
});

app.Run();