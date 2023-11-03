using Common.Application.SecurityUtil;
using Common.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.BrandAgg;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Services;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Services;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Enums;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;
using Shop.Infrastructure.Persistent.Ef;

namespace Shop.Api.Infrastructure;

public class DataSeeder
{
    private readonly ShopContext _context;
    private readonly IUserDomainService _domainService;
    private readonly ICategoryDomainService _categoryDomainService;
    private readonly IProductDomainService _productDomainService;
    public DataSeeder(ShopContext context, IUserDomainService domainService, ICategoryDomainService categoryDomainService, IProductDomainService productDomainService)
    {
        _context = context;
        _domainService = domainService;
        _categoryDomainService = categoryDomainService;
        _productDomainService = productDomainService;
    }

    public async Task SeedData()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch
        {
            return;
        }
        var user = await _context.Users.AnyAsync(f => f.PhoneNumber == "09170000000");
        if (user)
            return;

        var newUser = new User("admin", "admin", "09170000000", "admin@admin.com",
            Sha256Hasher.Hash("123456"),
            Gender.Male, _domainService);
        var role = new Role("admin", new List<RolePermission>()
        {
            new(Permission.CRUD_Banner),
            new(Permission.Add_Inventory),
            new(Permission.CRUD_Product),
            new(Permission.CRUD_Slider),
            new(Permission.CURD_User),
            new(Permission.Category_Management),
            new(Permission.ChangePassword),
            new(Permission.Comment_Management),
            new(Permission.EditProfile),
            new(Permission.Order_Management),
            new(Permission.PanelAdmin),
            new(Permission.Role_Management),
            new(Permission.User_Management)
        });
        _context.Add(role);
        _context.Add(newUser);

        var brand = new Brand("brand.png", "سامسونگ");
        await _context.AddAsync(brand);
        await _context.SaveChangesAsync();

        newUser.SetRoles(new List<UserRole>() { new(role.Id) });

        var category = new Category("کالای دیجیتال", "electronic-devices",
            new SeoData("کالای دیجیتال", "کالای دیجیتال", "کالای دیجیتال", true, null),
            _categoryDomainService, null);
        _context.Add(category);
        await _context.SaveChangesAsync();

        category.AddChild("گوشی موبایل", "mobile-phone", null,
            new SeoData("کالای دیجیتال", "کالای دیجیتال", "کالای دیجیتال", true, null),
            _categoryDomainService);
        _context.Update(category);
        await _context.SaveChangesAsync();

        var product = new Product("گوشی موبایل سامسونگ مدل Galaxy A13 SM-A137F/DS", "mobile.png", "test"
            , category.Id, category.Childs.First().Id, null, _productDomainService, "Galaxy-A13"
            , new SeoData("گوشی موبایل سامسونگ", "گوشی موبایل سامسونگ",
                "گوشی موبایل سامسونگ مدل Galaxy A13 SM-A137F/DS", true, null)
            , brand.Id);
        _context.Add(product);
        await _context.SaveChangesAsync();
    }
}