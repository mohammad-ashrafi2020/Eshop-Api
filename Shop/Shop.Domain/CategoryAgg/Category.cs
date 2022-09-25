using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using Shop.Domain.CategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.CategoryAgg
{
    public class Category : AggregateRoot
    {
        private Category()
        {
            Childs = new List<Category>();
        }
        public Category(string title, string slug, SeoData seoData, ICategoryDomainService service, string? imageName)
        {
            slug = slug.ToSlug();
            Guard(title, slug, service);
            Title = title;
            Slug = slug;
            SeoData = seoData;
            ImageName = imageName ?? "category.png";
            Childs = new List<Category>();
        }

        public string Title { get; private set; }
        public string Slug { get; private set; }
        public string ImageName { get; private set; }
        public SeoData SeoData { get; private set; }
        public long? ParentId { get; private set; }
        public List<Category> Childs { get; private set; }

        public void Edit(string title, string slug, SeoData seoData, ICategoryDomainService service)
        {
            slug = slug?.ToSlug();
            Guard(title, slug, service);
            Title = title;
            Slug = slug;
            SeoData = seoData;
        }

        public void AddChild(string title, string slug, SeoData seoData, ICategoryDomainService service)
        {
            Childs.Add(new Category(title, slug, seoData, service, null)
            {
                ParentId = Id
            });
        }

        public void Guard(string title, string slug, ICategoryDomainService service)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));

            if (slug != Slug)
                if (service.IsSlugExist(slug))
                    throw new SlugIsDuplicateException();
        }

        public void SetImageName(string imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                ImageName = imageName;
        }
    }
}