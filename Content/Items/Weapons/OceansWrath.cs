using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace gim.Content.Items.Weapons
{
    internal class OceansWrath : ModItem
    {
        int count = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ocean's Wrath");
            Tooltip.SetDefault("Cast three fast moving razorwheels and a burst of bubbles");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.rare = ItemRarityID.Red;
            Item.maxStack = 1;
            Item.knockBack = 5;
            Item.damage = 95;
            Item.crit = 18;
            Item.useTime = 19; //Dollar Fortnite card!
            Item.useAnimation = 19; //Who wants it?
            Item.DamageType = DamageClass.Magic;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.shootSpeed = 8f;
            Item.mana = 18;
            Item.UseSound = SoundID.Item84;
            Item.shoot = ProjectileID.Bunny; //Isn't used because of Shoot returning false
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles1 = 3;
            float rotation1 = MathHelper.ToRadians(25);
            float numberProjectiles2 = 8;
            float rotation2 = MathHelper.ToRadians(45);
            Vector2 position1 = position;
            Vector2 position2 = position;
            position1 += Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 25f;
            position2 += Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 1f;

            for (int i2 = 0; i2 < numberProjectiles1; i2++)
            {
                Vector2 perturbedSpeed1 = new Vector2(velocity.X, velocity.Y).RotatedBy(MathHelper.Lerp(-rotation1, rotation1, i2 / (numberProjectiles1 - 1))) * 0.6f;
                Projectile.NewProjectile(player.GetSource_Accessory(Item), position1.X, position1.Y, perturbedSpeed1.X, perturbedSpeed1.Y, ProjectileID.Typhoon, damage, knockback, player.whoAmI);
            }
            for (int i1 = 0; i1 < 5; i1++)
            {
                for (int i3 = 0; i3 < numberProjectiles2; i3++)
                {
                    {
                        Vector2 perturbedSpeed2 = new Vector2(velocity.X, velocity.Y).RotatedBy(MathHelper.Lerp(-rotation2, rotation2, i3 / (numberProjectiles1 - 1))) * 1.5f;
                        Projectile.NewProjectile(player.GetSource_Accessory(Item), position2.X, position2.Y, perturbedSpeed2.X, perturbedSpeed2.Y, ProjectileID.Bubble, damage / 3, knockback / 3, player.whoAmI);
                    }
                }
            }
            return false;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.RazorbladeTyphoon)
                .AddIngredient(ItemID.FragmentNebula, 16)
                .AddIngredient(ItemID.LunarBar, 3)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
