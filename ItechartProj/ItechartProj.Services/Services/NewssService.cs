﻿using ItechartProj.DAL.Models;
using ItechartProj.DAL.Repository.Interfaces;
using ItechartProj.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItechartProj.Services.Services
{
    public class NewssService : INewssSevice
    {
        private readonly INewssRepository newssRepository;

        public NewssService(INewssRepository newssRepository)
        {
            this.newssRepository = newssRepository;

        }
        public async Task<IEnumerable<News>> GetNews()
        {
            return await newssRepository.GetNewss();
        }
        public Task AddNews(News news)
        {

            return newssRepository.AddNewss(new News
            {
                Id = news.Id,
                Image = news.Image,
                Name = news.Name,
                Text = news.Text

            });
        }
    }
}

