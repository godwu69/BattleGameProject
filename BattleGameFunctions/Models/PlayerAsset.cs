using System;

namespace BattleGameFunctions.Models
{
    public class PlayerAsset
    {
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
        public Guid AssetId { get; set; }
        public Asset Asset { get; set; }
    }
}