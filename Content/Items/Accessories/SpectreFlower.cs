using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace gim.Content.Items.Accessories
{
    internal class SpectreFlower : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectral Bloom");
            Tooltip.SetDefault("16% reduced mana usage\nAutomatically use mana potions while needed\nIf visible, replaces Mana Sickness with Potion Sickness for 20 seconds\nWhile visible, if a mana potion is used while Potion Sickness is active, you gain increasingly more dangerous debuffs");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(3, 25));
        }

        public override void SetDefaults()
        {
            Item.width = 29;
            Item.height = 33;
            Item.value = Item.buyPrice(gold: 5, silver: 75);
            Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;
            Item.maxStack = 1;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaCost -= player.manaCost / 6;
            player.manaFlower = true;

            if (hideVisual == false) //Visible
            {
                if (player.manaSick == true && player.HasBuff(BuffID.CursedInferno) == true)
                {
                    player.AddBuff(BuffID.Silenced, 60);
                    player.AddBuff(BuffID.Weak, 240);
                    player.AddBuff(BuffID.CursedInferno, 240);
                    player.AddBuff(BuffID.Ichor, 240);
                    player.AddBuff(BuffID.PotionSickness, 1200);
                }
                if (player.manaSick == true && player.HasBuff(BuffID.Ichor) == true)
                {
                    player.AddBuff(BuffID.CursedInferno, 240);
                    player.AddBuff(BuffID.Weak, 240);
                    player.AddBuff(BuffID.Ichor, 240);
                    player.AddBuff(BuffID.PotionSickness, 1200);
                }
                if (player.manaSick == true && player.HasBuff(BuffID.Weak) == true)
                {
                    player.AddBuff(BuffID.Weak, 240);
                    player.AddBuff(BuffID.Ichor, 240);
                    player.AddBuff(BuffID.PotionSickness, 1200);
                }
                if (player.manaSick == true && player.HasBuff(BuffID.PotionSickness) == true)
                {
                    player.AddBuff(BuffID.Weak, 240);
                    player.AddBuff(BuffID.PotionSickness, 1200);
                }
                if (player.manaSick == true)
                {
                    player.ClearBuff(BuffID.ManaSickness);
                    player.AddBuff(BuffID.PotionSickness, 1200);
                }
            }
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Items.Accessories.DashingBelt>(), 1)
                .AddIngredient(ItemID.AncientCloth, 1)
                .AddIngredient(ItemID.Ectoplasm, 5)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}
