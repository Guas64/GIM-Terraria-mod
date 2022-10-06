using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace GIMTestModMedPan.Items.Accessories
{
    internal class DashingBelt : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dashing Cloak");
            Tooltip.SetDefault("Grants an attack doding dash");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.value = Item.buyPrice(gold: 1, silver: 75);
            Item.accessory = true;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 1;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.timeSinceLastDashStarted > 100)
            {
                player.dashType = 1;
            }
            else
            {
                player.dashType = 0;
            }

            if (player.timeSinceLastDashStarted < 20)
            {
                player.shadowDodge = true;
            }
            else
            {
                player.shadowDodge = false;
            }
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 15)
                .AddIngredient(ItemID.Bone, 5)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}
