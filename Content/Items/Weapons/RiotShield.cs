using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace gim.Content.Items.Weapons
{
    internal class RiotShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Riot Shield");
            Tooltip.SetDefault("Knocks enemies back\nSlows you down");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 36;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 1;
            Item.knockBack = 5;
            Item.damage = 10;
            Item.crit = 5;
            Item.useTime = 4;
            Item.useAnimation = 4;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.useStyle = 5;
            Item.autoReuse = true;
        }
        public override bool? UseItem(Player player)
        {
            player.AddBuff(BuffID.Slow, 10);


            return true;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3, 0);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.IronBar, 12)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
