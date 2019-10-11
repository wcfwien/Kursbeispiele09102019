using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FussballManager
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FussballInfoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FussballInfoService.svc or FussballInfoService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Single)]
    public class FussballInfoService : IFussballInfoService
    {
        List<Player> players = new List<Player>();

        public void CreatePlayer(Player player)
        {
            if (player == null)
                throw new NullReferenceException(nameof(player));

            players.Add(player);
        }

        public string GetPlayerById(string playerId)
        {
            //return $"Spieler {PlayerId} - Marc Janko";
            return players.FirstOrDefault(p => p.Id == playerId)?.Name;
        }
    }
}
