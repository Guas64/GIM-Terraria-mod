using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace gim.Content.Items.Consumables
{
    public class GimPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Grants the powers of the Earth.");
	    
	    CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
	    
	    ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
			new Color(103, 231, 138),
			new Color(57, 223, 183),
			new Color(1, 158, 144)
		};
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 30;
            Item.consumable = true;
            Item.rare = ItemRarityID.Purple;
            Item.value = Item.buyPrice(gold: 5);
        }
        public override bool? UseItem(Player player) //For some reason 'Item.consumable = true;' wasn't working, so this was the work around. Most likely a better way, but this works.
        {
            player.AddBuff(BuffID.Inferno, 18000);
            player.AddBuff(BuffID.Endurance, 18000);
            player.AddBuff(BuffID.Thorns, 18000);
            player.AddBuff(BuffID.Lifeforce, 18000);
            player.AddBuff(BuffID.Wrath, 18000);
            player.AddBuff(BuffID.Rage, 18000);
            player.AddBuff(BuffID.Ironskin, 18000);
            player.AddBuff(BuffID.Regeneration, 18000);
            player.AddBuff(BuffID.Swiftness, 18000);


            for (int i = 0; i < 0; i++) //Only activate once
            {
                Item.stack -= 1; //Reduce item stack by 1
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.InfernoPotion, 3)
                .AddIngredient(ItemID.EndurancePotion, 3)
                .AddIngredient(ItemID.ThornsPotion, 3)
                .AddIngredient(ItemID.LifeforcePotion, 3)
                .AddIngredient(ItemID.WrathPotion, 3)
                .AddIngredient(ItemID.RagePotion, 3)
                .AddIngredient(ItemID.IronskinPotion, 5)
                .AddIngredient(ItemID.RegenerationPotion, 5)
                .AddIngredient(ItemID.SwiftnessPotion, 5)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}
