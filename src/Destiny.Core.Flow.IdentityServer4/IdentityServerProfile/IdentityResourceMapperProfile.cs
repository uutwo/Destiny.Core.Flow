﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using AutoMapper;
using Destiny.Core.Flow.Model.DestinyIdentityServer4;
using System.Collections.Generic;
using System.Linq;

namespace Destiny.Core.Flow.IdentityServer.IdentityServerProfile
{
    /// <summary>
    /// AutoMapper configuration for identity resource
    /// Between model and entity
    /// </summary>
    public class IdentityResourceMapperProfile : Profile
    {
        /// <summary>
        /// <see cref="IdentityResourceMapperProfile"/>
        /// </summary>
        public IdentityResourceMapperProfile()
        {
            CreateMap<IdentityResourceProperty, KeyValuePair<string, string>>()
               .ReverseMap();

            CreateMap<IdentityResource, IdentityServer4.Models.IdentityResource>(MemberList.Destination)
                .ConstructUsing(src => new IdentityServer4.Models.IdentityResource())
                .ReverseMap();

            CreateMap<IdentityResourceClaim, string>()
               .ConstructUsing(x => x.Type)
               .ReverseMap()
               .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src));
        }
    }
}