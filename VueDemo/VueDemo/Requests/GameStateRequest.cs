using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace VueDemo.Requests
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GameStateRequest
    {
        public string[] Playground { get; set; }
    }
}
