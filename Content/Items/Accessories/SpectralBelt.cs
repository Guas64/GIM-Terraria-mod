using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace GIMTestModMedPan.Items.Accessories
{
    internal class SpectralBelt : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectral Cloak");
            Tooltip.SetDefault("Grants an attack doding dash\nWhile dashing, you shoot out spirits");
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
            Item.CountsAsClass(DamageClass.Magic);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.timeSinceLastDashStarted > 50 && player.HasBuff(BuffID.Wisp) == true)
            {
                player.dashType = 1;
            }
            else if (player.timeSinceLastDashStarted > 100)
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
                player.statMana = player.statMana + 1;
            }
            else
            {
                player.shadowDodge = false;
            }

            if (player.timeSinceLastDashStarted < 6)
            {
                Projectile.NewProjectile(player.GetSource_Accessory(Item), player.position.X, player.position.Y, 0f, 0f, ProjectileID.LostSoulFriendly, 65, 10, player.whoAmI, 1, 0f);
            }
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Items.Accessories.DashingBelt>(), 1)
                .AddIngredient(ItemID.TatteredCloth, 1)
                .AddIngredient(ItemID.Ectoplasm, 5)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}
