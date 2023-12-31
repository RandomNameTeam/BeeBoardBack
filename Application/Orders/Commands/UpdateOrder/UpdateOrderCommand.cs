﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand: IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
    }
}
