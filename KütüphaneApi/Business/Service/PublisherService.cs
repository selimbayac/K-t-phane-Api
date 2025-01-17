﻿using Business.IService;
using Data.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task AddPublisherAsync(Publisher publisher)
        {
            await _publisherRepository.AddPublisherAsync(publisher);
        }

        public async Task DeletePublisherAsync(int id)
        {
            await _publisherRepository.DeletePublisherAsync(id);
        }

        public async Task<IEnumerable<Publisher>> GetAllPublishersAsync()
        {
            return await _publisherRepository.GetAllPublishersAsync();
        }

        public async Task<Publisher> GetPublisherByIdAsync(int id)
        {
            return await _publisherRepository.GetPublisherByIdAsync(id);
        }

        public async Task UpdatePublisherAsync(Publisher publisher)
        {
            await _publisherRepository.UpdatePublisherAsync(publisher);
        }
    }
}
