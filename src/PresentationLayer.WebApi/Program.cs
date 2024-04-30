
using BusinessLayer;
using BusinessLayer.Services.Transaction;
using BusinessLayer.Validator.Transaction;
using BusinessLayer.Validator.User;
using DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PresentationLayer.WebApi;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.AddRazorComponents();

builder.Services.AddAutoMapper(options =>
{
    options.AddProfile<AccountDtoProfile>();
});
builder.Services.AddAutoMapper(options =>
{
    options.AddProfile<AccountDtoUpdateProfile>();
});
builder.Services.AddAutoMapper(options =>
{
    options.AddProfile<GoalDtoProfile>();
});
builder.Services.AddAutoMapper(options =>
{
    options.AddProfile<GoalDtoUpdateProfile>();
});
builder.Services.AddAutoMapper(options =>
{
    options.AddProfile<TransactionDtoProfile>();
});
builder.Services.AddAutoMapper(options =>
{
    options.AddProfile<TransactionDtoUpdateProfile>();
});
builder.Services.AddAutoMapper(options =>
{
    options.AddProfile<TransactionCategoryDtoProfile>();
});
builder.Services.AddAutoMapper(options =>
{
    options.AddProfile<UserDtoProfile>();
});
builder.Services.AddAutoMapper(options =>
{
    options.AddProfile<UserDtoUpdateProfile>();
});
builder.Services.AddAutoMapper(options =>
{
    options.AddProfile<UserSettingsDtoProfile>();
});

builder.Services.AddDbContext<FinancialDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection"))
);
builder.Services.AddStackExchangeRedisCache(options
    => options.Configuration = builder.Configuration.GetConnectionString("RedisConnection"));

builder.Services.AddScoped<AccountRepository>();
builder.Services.AddScoped<AccountRepositoryProxy>();
builder.Services.AddScoped<GoalRepository>();
builder.Services.AddScoped<GoalRepositoryProxy>();
builder.Services.AddScoped<TransactionRepository>();
builder.Services.AddScoped<TransactionRepositoryProxy>();
builder.Services.AddScoped<TransactionCategoryRepository>();
builder.Services.AddScoped<TransactionCategorRepositoryProxy>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserRepositoryProxy>();
builder.Services.AddScoped<UserSettingsRepository>();

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IGoalService, GoalService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ITransactionCategoryService, TransactionCategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserSettingsService, UserSettingsService>();

builder.Services.AddScoped<IValidator<AccountDto>, AccountDtoValidator>();
builder.Services.AddScoped<IValidator<AccountDtoUpdate>, AccountDtoUpdateValidator>();
builder.Services.AddScoped<IValidator<GoalDto>, GoalDtoValidator>();
builder.Services.AddScoped<IValidator<GoalDtoUpdate>, GoalDtoUpdateValidator>();
builder.Services.AddScoped<IValidator<TransactionDto>, TransactionDtoValidator>();
builder.Services.AddScoped<IValidator<TransactionDtoUpdate>, TransactionDtoUpdateValidator>();
builder.Services.AddScoped<IValidator<TransactionCategoryDto>, TransactionCategoryDtoValidator>();
builder.Services.AddScoped<IValidator<UserDto>, UserDtoValidator>();
builder.Services.AddScoped<IValidator<UserDtoUpdate>, UserDtoUpdateValidator>();
builder.Services.AddScoped<IValidator<UserSettingsDto>, UserSettingsDtoValidator>();


builder.Services.AddSwaggerGen();



WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.UseAntiforgery();

//app.MapRazorComponents<App>();

//app.MapGet("/", () => "Hello World!");

app.Run();
