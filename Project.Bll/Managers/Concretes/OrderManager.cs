﻿using AutoMapper;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Concretes
{
    public class OrderManager : BaseManager<OrderDto, Order>, IOrderManager
    {
        readonly IOrderRepository _repository;
        public OrderManager(IOrderRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }
    }
}