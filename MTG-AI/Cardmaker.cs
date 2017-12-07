using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_AI
{
    class Cardmaker
    {
        public static LinkedList<Card> Knights = new LinkedList<Card>();
        public static LinkedList<Card> Dragons = new LinkedList<Card>();

        /*I need to implement the creature ability enumeration still
        Colors will be parsed out for mana cost and card color. use the format "3RR" for 3 colorless and 2 red
        Colors are "W", "G", or "R". multicolor fit together without commas "WG"
        Use the correct format or it will crash!!
             */

        public static void MakeDecks()
        {
//-------------------**KNIGHT DECK**-------------------------------------------------
            //ALL LAND
            //basic lands
            for (int i = 0; i < 12; ++i)
            {
                Knights.AddLast(new KnightCards.Plains());
            }

            for (int i = 0; i < 6; ++i)
            {
                Knights.AddLast(new KnightCards.Forest());
            }
            //non-basic lands
            Knights.AddLast(new KnightCards.Treetop_Village());  // pay "NG"this becomes 3/3 trample ape
            Knights.AddLast(new KnightCards.Selesnya_Sanctuary());
            Knights.AddLast(new KnightCards.Selesnya_Sanctuary());// bounces out one land.
            Knights.AddLast(new KnightCards.Sejiri_Steppe());  // when enters - one target creature gains protection from red.
            Knights.AddLast(new KnightCards.Grasslands()); //creates no mana, tap and sacrifice to search for forest or plains
            Knights.AddLast(new KnightCards.Grasslands());
            //Creatures
            Knights.AddLast(new KnightCards.Plover_Knights());
            Knights.AddLast(new KnightCards.Knights_of_Cliffhaven());
            Knights.AddLast(new KnightCards.Knights_of_Cliffhaven());
            Knights.AddLast(new KnightCards.Caravan_Escort());
            Knights.AddLast(new KnightCards.Kabira_Vindicator());
            Knights.AddLast(new KnightCards.Silver_Knight());
            Knights.AddLast(new KnightCards.Knight_of_Meadowgrain());
            Knights.AddLast(new KnightCards.Juniper_Order_Ranger());
            Knights.AddLast(new KnightCards.Skyhunter_Patrol());
            Knights.AddLast(new KnightCards.Wilt_Leaf_Caviliers());
            Knights.AddLast(new KnightCards.Paladin_of_Prahv());
            Knights.AddLast(new KnightCards.Knight_Exemplar());
            Knights.AddLast(new KnightCards.White_Knight());
            Knights.AddLast(new KnightCards.Benalish_Lancer());
            Knights.AddLast(new KnightCards.Knight_of_the_White_Orchid());
            Knights.AddLast(new KnightCards.Kinsbaile_Cavalier());
            Knights.AddLast(new KnightCards.Leonin_Skyhunter());
            Knights.AddLast(new KnightCards.Knight_of_the_Reliquary());
            Knights.AddLast(new KnightCards.Alaborn_Cavalier());
            Knights.AddLast(new KnightCards.Steward_of_Valeron());
            Knights.AddLast(new KnightCards.Lionheart_Maverick());
            Knights.AddLast(new KnightCards.Lionheart_Maverick());
            Knights.AddLast(new KnightCards.Knotvine_Paladin());
            Knights.AddLast(new KnightCards.Zhalfirin_Commander());
            //spells
            Knights.AddLast(new KnightCards.Reciprocate());
            Knights.AddLast(new KnightCards.Sigil_Blessing());
            Knights.AddLast(new KnightCards.Heroes_Reunion());
            Knights.AddLast(new KnightCards.Test_of_Faith());
            Knights.AddLast(new KnightCards.Mighty_Leap());
            Knights.AddLast(new KnightCards.Reprisal());
            Knights.AddLast(new KnightCards.Edge_of_Autumn());
            Knights.AddLast(new KnightCards.Harm_s_Way());
           //artifacts/enchantments
            Knights.AddLast(new KnightCards.LoxodonWarhammer());
            Knights.AddLast(new KnightCards.Oblivian_Ring());
            Knights.AddLast(new KnightCards.Spidersilk_Armor());
            Knights.AddLast(new KnightCards.Griffin_Guide());


//------------------------**DRAGON DECK**------------------------------------------------
            //basic lands
            for (int i = 0; i < 24; ++i) {
                Dragons.AddLast(new DragonCards.Mountain());
            }
            //card name,mana on card (6)colorless and(RR) 2 red, (8) total mana, (5) attack power, (5)toughness, "R"card color, ability array, text.
            Dragons.AddLast(new DragonCards.BogardanHellkite());
            Dragons.AddLast(new DragonCards.DragonspeakerShaman());
            Dragons.AddLast(new DragonCards.CinderWall());
            Dragons.AddLast(new DragonCards.MordantDragon());
            Dragons.AddLast(new DragonCards.DragonWhelp());
            Dragons.AddLast(new DragonCards.DragonWhelp());
            Dragons.AddLast(new DragonCards.BogardanRager());
            Dragons.AddLast(new DragonCards.ShivanHellkite());
            Dragons.AddLast(new DragonCards.MudbuttonTorchrunner());
            Dragons.AddLast(new DragonCards.MudbuttonTorchrunner());
            Dragons.AddLast(new DragonCards.SkirkProspector());
            Dragons.AddLast(new DragonCards.KilnmouthDragon());
            Dragons.AddLast(new DragonCards.ThunderDragon());
            Dragons.AddLast(new DragonCards.BloodmarkMentor());
            Dragons.AddLast(new DragonCards.VoraciousDragon());
            Dragons.AddLast(new DragonCards.FireBellyChangeling());
            Dragons.AddLast(new DragonCards.HengeGuardian());
            //Spells
            Dragons.AddLast(new DragonCards.PunishingFire());
            Dragons.AddLast(new DragonCards.Ghostfire());
            Dragons.AddLast(new DragonCards.FieryFall());
            Dragons.AddLast(new DragonCards.FieryFall());
            Dragons.AddLast(new DragonCards.SeismicStrike());
            Dragons.AddLast(new DragonCards.TemporaryInsanity());
            Dragons.AddLast(new DragonCards.SeethingSong());
            Dragons.AddLast(new DragonCards.JawsOfStone());
            Dragons.AddLast(new DragonCards.ConeOfFlame());
            Dragons.AddLast(new DragonCards.BreathOfDarigaaz());
            Dragons.AddLast(new DragonCards.SpittingEarth());
            Dragons.AddLast(new DragonCards.DragonFodder());
            Dragons.AddLast(new DragonCards.DragonFodder());
            //Enchant/Artifacts
            Dragons.AddLast(new DragonCards.ArmillarySphere());
            Dragons.AddLast(new DragonCards.ArmillarySphere());
            Dragons.AddLast(new DragonCards.DragonsClaw());
            Dragons.AddLast(new DragonCards.ShivsEmbrace());
            Dragons.AddLast(new DragonCards.ClawsOfValakut());
            Dragons.AddLast(new DragonCards.CaptiveFlame());






        }
    }
}

