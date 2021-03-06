﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000.Engine.Interfaces
{
    public interface IResources
    {
        string AlreadyCarryingIt { get; }
        string ArentCarryingIt { get; }
        string AttackingSerpentFails { get; }
        string BarredBySerpent { get; }
        string Batteries { get; }
        string BatteriesFreshLongDesc { get; }
        string BatteriesWornLongDesc { get; }
        string BeyondYourPower { get; }
        string BirdAlive { get; }
        string BirdBoxed { get; }
        string BirdBoxedLongDesc { get; }
        string BirdNotHungry { get; }
        string BirdStatueDead { get; }
        string Bottle { get; }
        string BottleAlreadyFull { get; }
        string BottleLongDesc { get; }
        string BrassLantern { get; }
        string BridgeAppears { get; }
        string BridgeRetracted { get; }
        string BrokenNeck { get; }
        string CantBeSerious { get; }
        string CantCarryAnymore { get; }
        string CantCarryStatue { get; }
        string CantCrossPit { get; }
        string CantFillThat { get; }
        string CantFitThroughTwoInchSlit { get; }
        string CantPourThat { get; }
        string CantReincarnate { get; }
        string Chest { get; }
        string ChestLongDesc { get; }
        string ClimbedPlant { get; }
        string ClimbPlant { get; }
        string ClumsyOaf { get; }
        string Coins { get; }
        string CoinsLongDesc { get; }
        string CrackTooSmall { get; }
        string CrawledAround { get; }
        string CrawledAroundBackToMainPassage { get; }
        string CrawlToPassage { get; }
        string CrossDontJump { get; }
        string DeadEnd { get; }
        string Delicious { get; }
        string Desert { get; }
        string Diamonds { get; }
        string DiamondsLongDesc { get; }
        string DidntMakeIt { get; }
        string DiscardedStatueBox { get; }
        string DomeUnclimbable { get; }
        string DontBeRidiculous { get; }
        string DontBlameMe { get; }
        string DontKnowHow { get; }
        string DontKnowHowToApplyWord { get; }
        string DontKnowHowToLockUnlock { get; }
        string DontKnowThatWord { get; }
        string DontKnowWhatYouMean { get; }
        string DontUnderstand { get; }
        string DrinkFromStream { get; }
        string DropSomething { get; }
        string Emerald { get; }
        string EmeraldLongDesc { get; }
        string EmptyBottle { get; }
        string EmptyBottleWetGround { get; }
        string EmptySarcophagus { get; }
        string FellIntoPit { get; }
        string FloorLitteredWithShards { get; }
        string Food { get; }
        string FoodLongDesc { get; }
        string FreshBatteries { get; }
        string GiganticBeanStalk { get; }
        string GlisteningPearl { get; }
        string GlisteningPearlLongDesc { get; }
        string Gold { get; }
        string GoldLongDesc { get; }
        string GottenKilled { get; }
        string Help { get; }
        string ImGame { get; }
        string ISeeNo { get; }
        string ItsPitchDark { get; }
        string Jewelry { get; }
        string JewelryLongDesc { get; }
        string Key { get; }
        string KeyLongDesc { get; }
        string LampGettingDim { get; }
        string LampGettingDimChangingBatteries { get; }
        string LampIsNowOff { get; }
        string LampIsNowOn { get; }
        string LampOutOfPower { get; }
        string LampShining { get; }
        string LostAppetite { get; }
        string Magazine { get; }
        string MagazineLongDesc { get; }
        string Maze { get; }
        string MummyStealsTreasures { get; }
        string Nest { get; }
        string NestLongDesc { get; }
        string NoLongerRememberHowYouGotHere { get; }
        string NoSourceOfLight { get; }
        string NotCarryingAnything { get; }
        string NothingHappens { get; }
        string NothingToClimb { get; }
        string NothingToFillBottleWith { get; }
        string NotStrongEnoughToOpenSarcophagus { get; }
        string NoWayToGoThatDirection { get; }
        string Ok { get; }
        string OverwateredPlant { get; }
        string PearlFallsOut { get; }
        string Peculiar { get; }
        string Pillow { get; }
        string PlantBellowing { get; }
        string PlantCantBePulledFree { get; }
        string PlantGrows { get; }
        string PlantMurmuring { get; }
        string PlantSpurts { get; }
        string Prompt { get; }
        string PutSarcophagusDown { get; }
        string Room1 { get; }
        string Room10 { get; }
        string Room11 { get; }
        string Room12 { get; }
        string Room13 { get; }
        string Room14 { get; }
        string Room15 { get; }
        string Room16 { get; }
        string Room17 { get; }
        string Room18 { get; }
        string Room19 { get; }
        string Room2 { get; }
        string Room20 { get; }
        string Room21 { get; }
        string Room22 { get; }
        string Room24 { get; }
        string Room25 { get; }
        string Room26 { get; }
        string Room27 { get; }
        string Room52 { get; }
        string Room54 { get; }
        string Room55 { get; }
        string Room56 { get; }
        string Room57 { get; }
        string Room58 { get; }
        string Room59 { get; }
        string Room60 { get; }
        string Room61 { get; }
        string Room62 { get; }
        string Room63 { get; }
        string Room64 { get; }
        string Room65 { get; }
        string Room66 { get; }
        string Room68 { get; }
        string Room7 { get; }
        string Room70 { get; }
        string Room71 { get; }
        string Room72 { get; }
        string Room73 { get; }
        string Room76 { get; }
        string Room77 { get; }
        string Room78 { get; }
        string Room79 { get; }
        string Room8 { get; }
        string Room80 { get; }
        string Room81 { get; }
        string Room9 { get; }
        string RubbingNothingHappens { get; }
        string Sarcophagus { get; }
        string SarcophagusDoesntFit { get; }
        string SarcophagusLongDesc { get; }
        string Scepter { get; }
        string SerpentBlocks { get; }
        string SerpentEatenBird { get; }
        string SerpentHasNothingToEat { get; }
        string ShinyBrassLamp { get; }
        string Silver { get; }
        string SilverLongDesc { get; }
        string SmallVelvetPillow { get; }
        string StatueBox { get; }
        string StatueComesToLife { get; }
        string StatueInBox { get; }
        string StatueOfBirdGod { get; }
        string StoneVeryStrong { get; }
        string ThreeFootScepter { get; }
        string TryToReincarnate { get; }
        string UnsureHowYouAreFacing { get; }
        string UseCompassPoints { get; }
        string Vase { get; }
        string VaseDropsWithCrash { get; }
        string VaseHurledToGround { get; }
        string VasePillowLongDesc { get; }
        string VaseRestingOnPillow { get; }
        string VaseSoloLongDesc { get; }
        string VendingMachine { get; }
        string VerbWhat { get; }
        string Water { get; }
        string WaterLongDesc { get; }
        string Welcome { get; }
        string What { get; }
        string WhatDoYouWantToDoWith { get; }
        string WhereDidIPutMyOrangeSmoke { get; }
        string YouAreHolding { get; }
        string YouHaveScored { get; }
    }
}
