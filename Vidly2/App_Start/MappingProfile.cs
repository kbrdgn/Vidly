﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly2.Dtos;
using Vidly2.Models;

namespace Vidly2.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Musteri, MusteriDto>();
            Mapper.CreateMap<MusteriDto, Musteri>();

            Mapper.CreateMap<Film, FilmDto>();
            Mapper.CreateMap<FilmDto, Film>();
        }
    }
}