﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Slimsy.cs" company="Our.Umbraco">
//   2014
// </copyright>
// <summary>
//   Defines the Slimsy type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Umbraco.Core;

namespace Slimsy
{
    using Umbraco.Core.Models;
    using Umbraco.Web;
    using Umbraco.Web.Models;

    public static class Slimsy
    {
        public static string GetResponsiveImageUrl(this IPublishedContent publishedContent, int width, int height)
        {
            return publishedContent.GetResponsiveImageUrl(width, height, Constants.Conventions.Media.File);
        }

        public static string GetResponsiveImageUrl(this IPublishedContent publishedContent, int width, int height, string propertyAlias)
        {
            if (height == 0)
            {
                return publishedContent.GetCropUrl(
                       width, 
                       null, 
                       propertyAlias, 
                       quality: 90,
                       furtherOptions: "&slimmage=true").ToLowerInvariant();
  
            }
            return publishedContent.GetCropUrl(
                   width,
                   height,
                   propertyAlias,
                   quality: 90,
                   ratioMode: ImageCropRatioMode.Height,
                   furtherOptions: "&slimmage=true").ToLowerInvariant();
        }

        // this could be a overload of GetResponsiveImageUrl but then dynamics can't use it, hence a new name
        public static string GetResponsiveCropUrl(this IPublishedContent publishedContent, string cropAlias)
        {
            return publishedContent.GetCropUrl(
                cropAlias: cropAlias,
                useCropDimensions: true,
                quality: 90,
                ratioMode: ImageCropRatioMode.Height,
                furtherOptions: "&slimmage=true").ToLowerInvariant();
        }

        public static string GetResponsiveCropUrl(this IPublishedContent publishedContent, string cropAlias, string propertyAlias)
        {
            return publishedContent.GetCropUrl(
                propertyAlias: propertyAlias,
                cropAlias: cropAlias,
                useCropDimensions: true,
                quality: 90,
                ratioMode: ImageCropRatioMode.Height,
                furtherOptions: "&slimmage=true").ToLowerInvariant();
        }


    }
}
