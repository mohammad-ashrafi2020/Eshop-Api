using System.Collections.Generic;

namespace Common.Domain.ValueObjects
{
    public class SeoData : ValueObject
    {
        public SeoData()
        {
        }

        public static SeoData CreateEmpty()
        {
            return new SeoData();
        }

        public SeoData(string? metaKeyWords, string? metaDescription, string? metaTitle, bool indexPage, string? canonical)
        {
            MetaKeyWords = metaKeyWords;
            MetaDescription = metaDescription;
            MetaTitle = metaTitle;
            IndexPage = indexPage;
            Canonical = canonical;
        }

        public string? MetaTitle { get;  set; }
        public string? MetaDescription { get;  set; }
        public string? MetaKeyWords { get;  set; }
        public bool IndexPage { get;  set; } = true;
        public string? Canonical { get;  set; }
    }
}