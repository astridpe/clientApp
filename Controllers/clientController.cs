using System;
using Model;
using Microsoft.AspNetCore.Mvc;

namespace kundeApp_v1.Controllers
{
    [Route("[controller]/[action]")]
    public class ClientController : ControllerBase
    {
        public List<Client> getAllClients()
        {
            var clients = new List<Client>();

            var client1 = new Client();
            client1.name = "Per Hansen";
            client1.address = "Osloveien 82";

            var client2 = new Client
            {
                name = "Lise Hansen",
                address = "Akersgaten 83"
            };

            clients.Add(client1);
            clients.Add(client2);

            return clients;
         }
        
    }
}

