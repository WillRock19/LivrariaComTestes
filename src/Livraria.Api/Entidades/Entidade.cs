using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Api.Entidades
{
    public class Entidade
    {
        [JsonProperty("_id")]
        public int Id { get; set; }
    }
}
