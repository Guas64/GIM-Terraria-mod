using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace gim.Content.Items.Consumables
{
	public class GimPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Grants the powers of the Earth.");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;

			// little particles that appear when you drink it
			ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
				new Color(103, 231, 138),
				new Color(57, 223, 183),
				new Color(1, 158, 144)
			};
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.rare = ItemRarityID.Red;
			Item.value = Item.buyPrice(gold: 3);
			Item.buffType = 1; //this doesnt do anything to my knowlage, besides allowing you to use the buff hotkey
			Item.buffTime = 18000;
		}

		public override bool? UseItem(Player player) //because item.bufftype doesnt allow for multiple buffs
        {
			player.AddBuff(BuffID.Endurance, 18000);
			player.AddBuff(BuffID.Thorns, 18000);
			player.AddBuff(BuffID.Lifeforce, 18000); 
			player.AddBuff(BuffID.Wrath, 18000);
			player.AddBuff(BuffID.Rage, 18000);
			player.AddBuff(BuffID.Ironskin, 18000); 
			player.AddBuff(BuffID.Regeneration, 18000); 
			player.AddBuff(BuffID.Swiftness, 18000);
			player.AddBuff(BuffID.Inferno, 18000);

			return true;
		}
	}
}
