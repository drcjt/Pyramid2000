using Pyramid2000.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid2000.Engine.Implementation
{
    public class Resources : IResources
    {
        public string AlreadyCarryingIt { get { return "You are already carrying it."; } }
        public string ArentCarryingIt { get { return "You aren't carrying it."; } }
        public string AttackingSerpentFails { get { return "Attacking the serpent both doesn't work and is very dangerous."; } }
        public string BarredBySerpent { get { return "A huge green fierce serpent bars the way!"; } }
        public string Batteries { get { return "Batteries"; } }
        public string BatteriesFreshLongDesc { get { return "There are fresh batteries here."; } }
        public string BatteriesWornLongDesc { get { return "Some worn-out batteries have been discarded nearby."; } }
        public string BeyondYourPower { get { return "It is beyond your power to do that."; } }
        public string BirdAlive { get { return "The bird statue comes to life and attacks the serpent and in an astounding flurry, drives the serpent away. The bird turns back into a statue."; } }
        public string BirdBoxed { get { return "Bird statue in box"; } }
        public string BirdBoxedLongDesc { get { return "There is a bird statue in the box."; } }
        public string BirdNotHungry { get { return "It's not hungry. Besides, you have no bird seed."; } }
        public string BirdStatueDead { get { return "The bird statue is now dead. Its body disappears."; } }
        public string Bottle { get { return "Small bottle"; } }
        public string BottleAlreadyFull { get { return "Your bottle is already full."; } }
        public string BottleLongDesc { get { return "There is a bottle here."; } }
        public string BrassLantern { get { return "Brass Lantern"; } }
        public string BridgeAppears { get { return "A stone bridge now spans the bottomless pit."; } }
        public string BridgeRetracted { get { return "The stone bridge has retracted!"; } }
        public string BrokenNeck { get { return "You are at the bottom of the pit with a broken neck."; } }
        public string CantBeSerious { get { return "You can't be serious!"; } }
        public string CantCarryAnymore { get { return "You can't carry anything more. You'll have to drop something first."; } }
        public string CantCarryStatue { get { return "You can lift the statue, but you cannot carry it."; } }
        public string CantCrossPit { get { return "There is no way across the bottomless pit."; } }
        public string CantFillThat { get { return "You can't fill that."; } }
        public string CantFitThroughTwoInchSlit { get { return "You don't fit through the two-inch slit!"; } }
        public string CantPourThat { get { return "You can't pour that."; } }
        public string CantReincarnate { get { return "I seem to be out of orange smoke. How can I reincarnate you without orange smoke?"; } }
        public string Chest { get { return "Treasure chest"; } }
        public string ChestLongDesc { get { return "The pharaoh's treasure chest is here!"; } }
        public string ClimbedPlant { get { return "You've climbed up the plant and out of the pit."; } }
        public string ClimbPlant { get { return "You clamber up the plant and scurry through the hole at the top."; } }
        public string ClumsyOaf { get { return "You clumsy oaf, you've done it again! I don't know how long I can keep this up. Do you want me to try reincarnating you again?"; } }
        public string Coins { get { return "Rare coins"; } }
        public string CoinsLongDesc { get { return "There are many coins here!"; } }
        public string CrackTooSmall { get { return "The crack is far too small for you to follow."; } }
        public string CrawledAround { get { return "You have crawled around in some little holes and found your way blocked by a fallen slab. You are now back in the main passage."; } }
        public string CrawledAroundBackToMainPassage { get { return "You have crawled around in some little holes and wound up back in the main passage."; } }
        public string CrawlToPassage { get { return "You have crawled through a very low wide passage parallel to and north of the hall of gods."; } }
        public string CrossDontJump { get { return "I respectfully suggest you go across the bridge instead of jumping."; } }
        public string DeadEnd { get { return "Dead end."; } }
        public string Delicious { get { return "Thank you, it was delicious!"; } }
        public string Desert { get { return "You are in the desert."; } }
        public string Diamonds { get { return "Several diamonds"; } }
        public string DiamondsLongDesc { get { return "There are diamonds here!"; } }
        public string DidntMakeIt { get { return "You didn't make it."; } }
        public string DiscardedStatueBox { get { return "There is a small statue box discarded nearby."; } }
        public string DomeUnclimbable { get { return "The dome is unclimbable."; } }
        public string DontBeRidiculous { get { return "Don't be ridiculous!"; } }
        public string DontBlameMe { get { return "All right. But don't blame me if something goes wr.............\n                     ----  Poof !!  ----\nYou are engulfed in a cloud of orange smoke. Coughing and gasping, you emerge from the smoke."; } }
        public string DontKnowHow { get { return "I don't know how."; } }
        public string DontKnowHowToApplyWord { get { return "I don't know how to apply that word here."; } }
        public string DontKnowHowToLockUnlock { get { return "I don't know how to lock or unlock such a thing."; } }
        public string DontKnowThatWord { get { return "I don't know that word."; } }
        public string DontKnowWhatYouMean { get { return "I don't know what you mean."; } }
        public string DontUnderstand { get { return "I don't understand."; } }
        public string DrinkFromStream { get { return "You have taken a drink from the stream. The water tastes strongly of minerals, but is not unpleasant. It is extremely cold."; } }
        public string DropSomething { get { return "Something you're carrying won't fit through the tunnel with you. You'd best take inventory and drop something."; } }
        public string Emerald { get { return "Egg-sized emerald"; } }
        public string EmeraldLongDesc { get { return "There is an emerald here the size of a plover's egg!"; } }
        public string EmptyBottle { get { return "The bottle is now empty."; } }
        public string EmptyBottleWetGround { get { return "Your bottle is empty and the ground is wet."; } }
        public string EmptySarcophagus { get { return "The sarcophagus creaks open, revealing nothing inside. It promptly snaps shut again."; } }
        public string FellIntoPit { get { return "You fell into a pit and broke every bone in your body."; } }
        public string FloorLitteredWithShards { get { return "The floor is littered with worthless shards of pottery."; } }
        public string Food { get { return "Tasty food"; } }
        public string FoodLongDesc { get { return "There is food here."; } }
        public string FreshBatteries { get { return "There are now some fresh batteries here."; } }
        public string GiganticBeanStalk { get { return "There is a gigantic bean stalk stretching all the way up to the hole."; } }
        public string GlisteningPearl { get { return "Glistening pearl"; } }
        public string GlisteningPearlLongDesc { get { return "Off to one side lies a glistening pearl!"; } }
        public string Gold { get { return "Large gold nugget"; } }
        public string GoldLongDesc { get { return "There is a large sparkling nugget of gold here!"; } }
        public string GottenKilled { get { return "Oh dear, you seem to have gotten yourself killed.  I might be able to help you out, but I've never really done this before. Do you want me to try to reincarnate you?"; } }
        public string Help { get { return "I'm as confused as you are!"; } }
        public string ImGame { get { return "I'm game. Would you care to explain how?"; } }
        public string ISeeNo { get { return "I see no {0} here."; } }
        public string ItsPitchDark { get { return "It is now pitch dark. If you proceed, you will likely fall into a pit."; } }
        public string Jewelry { get { return "Precious jewelry"; } }
        public string JewelryLongDesc { get { return "There is precious jewelry here!"; } }
        public string Key { get { return "Jeweled key"; } }
        public string KeyLongDesc { get { return "There is a jewel-encrusted key here!"; } }
        public string LampGettingDim { get { return "Your lamp is getting dim. You'd best start wrapping this up, unless you can find some fresh batteries. I seem to recall there is a vending machine in the maze. Bring some coins with you."; } }
        public string LampGettingDimChangingBatteries { get { return "Your lamp is getting dim. I'm taking the liberty of replacing the batteries."; } }
        public string LampIsNowOff { get { return "Your lamp is now off."; } }
        public string LampIsNowOn { get { return "Your lamp is now on."; } }
        public string LampOutOfPower { get { return "Your lamp has run out of power."; } }
        public string LampShining { get { return "There is a lamp shining nearby."; } }
        public string LostAppetite { get { return "I think I just lost my appetite."; } }
        public string Magazine { get { return "\"Egyptian weekly\""; } }
        public string MagazineLongDesc { get { return "There are a few recent issues of \"Egyptian weekly\" magazine here."; } }
        public string Maze { get { return "You are in a maze of twisty passages, all alike."; } }
        public string MummyStealsTreasures { get { return "Suddenly, a mummy creeps up behind you!! \"I'm the keeper of the tomb\", he wails, \"I take these treasures and put them in the chest deep in the maze!\" He grabs your treasure and vanishes into the gloom."; } }
        public string Nest { get { return "Golden eggs"; } }
        public string NestLongDesc { get { return "There is a large nest here, full of golden eggs!"; } }
        public string NoLongerRememberHowYouGotHere { get { return "Sorry, but I no longer seem to remember how it was you got here."; } }
        public string NoSourceOfLight { get { return "You have no source of light."; } }
        public string NotCarryingAnything { get { return "You're not carrying anything."; } }
        public string NothingHappens { get { return "Nothing happens."; } }
        public string NothingToClimb { get { return "There is nothing here to climb. Use up or out to leave the pit."; } }
        public string NothingToFillBottleWith { get { return "There is nothing here with which to fill the bottle."; } }
        public string NotStrongEnoughToOpenSarcophagus { get { return "You don't have anything strong enough to open the sarcophagus."; } }
        public string NoWayToGoThatDirection { get { return "There is no way for you to go that direction."; } }
        public string Ok { get { return "Ok"; } }
        public string OverwateredPlant { get { return "You've over-watered the plant! It's shrivelling up!"; } }
        public string PearlFallsOut { get { return "A glistening pearl falls out of the sarcophagus and rolls away. The sarcophagus snaps shut again."; } }
        public string Peculiar { get { return "Peculiar. Nothing unexpected happens."; } }
        public string Pillow { get { return "Velvet pillow"; } }
        public string PlantBellowing { get { return "There is a twelve foot bean stalk stretching up out of the pit, bellowing \"Water...Water...\""; } }
        public string PlantCantBePulledFree { get { return "The plant has exceptionally deep roots and cannot be pulled free."; } }
        public string PlantGrows { get { return "The plant grows explosively, almost filling the bottom of the pit."; } }
        public string PlantMurmuring { get { return "There is a tiny plant in the pit, murmuring \"Water, Water, ...\""; } }
        public string PlantSpurts { get { return "The plant spurts into furious growth for a few seconds."; } }
        public string Prompt { get { return ": "; } }
        public string PutSarcophagusDown { get { return "I'd advise you to put down the sarcophagus before opening it!!"; } }
        public string Room1 { get { return "You are standing before the entrance of a pyramid. Around you is a desert."; } }
        public string Room10 { get { return "You are in an awkward sloping east/west corridor."; } }
        public string Room11 { get { return "You are in a splendid chamber thirty feet high. The walls are frozen rivers of orange stone. An awkward corridor and a good passage exit from the east and west sides of the chamber."; } }
        public string Room12 { get { return "At your feet is a small pit breathing traces of white mist. An east passage ends here except for a small crack leading on. Rough stone steps lead down the pit."; } }
        public string Room13 { get { return "You are at one end of a vast hall stretching forward out of sight to the west. There are openings to either side. Nearby, a wide stone staircase leads downward. The hall is very musty and a cold wind blows up the staircase. There is a passage at the top of a dome behind you. Rough stone steps lead up the dome."; } }
        public string Room14 { get { return "This is a low room with a hieroglyph on the wall. It translates \"You won't get it up the steps\"."; } }
        public string Room15 { get { return "You are on the east bank of a bottomless pit stretching across the hall. The mist is quite thick here, and the pit is too wide to jump."; } }
        public string Room16 { get { return "You are in the pharaoh's chamber, with passages off in all directions."; } }
        public string Room17 { get { return "You are in the south side chamber."; } }
        public string Room18 { get { return "You are on the west side of the bottomless pit in the hall of gods."; } }
        public string Room19 { get { return "You are at the west end of the hall of gods. A low wide pass continues west and another goes north. To the south is a little passage six feet off the floor."; } }
        public string Room2 { get { return "You are in the entrance to the pyramid. A hole in the floor leads to a passage beneath the surface."; } }
        public string Room20 { get { return "You are at east end of a very long hall apparently without side chambers. To the east a low wide crawl slants up. To the north a round two foot hole slants down."; } }
        public string Room21 { get { return "You are at the west end of a very long featureless hall. The hall joins up with a narrow north/south passage."; } }
        public string Room22 { get { return "You are at a crossover of a high N/S passage and a low E/W one."; } }
        public string Room24 { get { return "You are in the west throne chamber. A passage continues west and up from here."; } }
        public string Room25 { get { return "You are in a low N/S passage at a hole in the floor. The hole goes down to an E/W passage."; } }
        public string Room26 { get { return "You are in a large room, with a passage to the south, and a wall of broken rock to the east. There is a panel on the north wall."; } }
        public string Room27 { get { return "You are in the chamber of Anubis."; } }
        public string Room52 { get { return "You are on the brink of a large pit. You could climb down, but you would not be able to climb back up. The maze continues on this level."; } }
        public string Room54 { get { return "You are in a dirty broken passage. To the east is a crawl. To the west is a large passage. Above you is a hole to another passage."; } }
        public string Room55 { get { return "You are on the brink of a small clean climbable pit. A crawl leads west."; } }
        public string Room56 { get { return "You are in the bottom of a small pit with a little stream, which enters and exits through tiny slits."; } }
        public string Room57 { get { return "You are in the room of Bes, whose picture is on the wall. There is a big hole in the floor. There is a passage leading east."; } }
        public string Room58 { get { return "You are at a complex junction. A low hands and knees passage from the north joins a higher crawl from the east to make a walking passage going west. There is also a large room above. The air is damp here."; } }
        public string Room59 { get { return "You are in the underworld anteroom of Seker. Passages go east, west, and up. Human bones are strewn about on the floor. Hieroglyphics on the wall roughly translate to \"Those who proceed east may never return.\"."; } }
        public string Room60 { get { return "You are at the land of dead. Passages lead off in >all< directions."; } }
        public string Room61 { get { return "You're in a large room with ancient drawings on all walls. The pictures depict Atum, a pharaoh wearing the double crown. A shallow passage proceeds downward, and a somewhat steeper one leads up. A low hands and knees passage enters from the south."; } }
        public string Room62 { get { return "You are in a chamber whose wall contains a picture of a man wearing the lunar disk on his head. He is the god Khons, the moon god."; } }
        public string Room63 { get { return "You are in a long sloping corridor with ragged walls."; } }
        public string Room64 { get { return "You are in a cul-de-sac about eight feet across."; } }
        public string Room65 { get { return "You are in the chamber of Horus, a long east/west passage with holes everywhere. To explore at random, select north, south, up, or down."; } }
        public string Room66 { get { return "You are in a large low circular chamber whose floor is an immense slab fallen from the ceiling. East and west there once where large passages, but they are now filled with sand. Low small passages go north and south."; } }
        public string Room68 { get { return "You are in the chamber of Nekhebet, a woman with the head of a vulture, wearing the crown of Egypt. A passage exits to the south."; } }
        public string Room7 { get { return "You are in a small chamber beneath a hole from the surface. A low crawl leads inward to the west. Hieroglyphics on the wall translate, \"Curse all who enter this sacred crypt.\""; } }
        public string Room70 { get { return "The passage here is blocked by a fallen block."; } }
        public string Room71 { get { return "You are in the chamber of Osiris. The ceiling is too high up for your lamp to show it. Passages lead east, north, and south."; } }
        public string Room72 { get { return "You are in the priest's bedroom. The walls are covered with curtains, the floor with a thick pile carpet. Moss covers the ceiling."; } }
        public string Room73 { get { return "This is the chamber of the high priest. Ancient drawings cover the walls. An extremely tight tunnel leads west. It looks like a tight squeeze. Another passage leads SE."; } }
        public string Room76 { get { return "You are in the high priest's treasure room lit by an eerie green light. A narrow tunnel exits to the east."; } }
        public string Room77 { get { return "You are in a long, narrow corridor stretching out of sight to the west. At the eastern end is a hole through which you can see a profusion of leaves."; } }
        public string Room78 { get { return "You are at the east end of the twopit room. The floor here is littered with thin rock slabs, which make it easy to descend the pits. There is a path here bypassing the pits to connect passages east and west. There are holes all over, but the only big one is on the wall directly over the west pit where you can't get to it."; } }
        public string Room79 { get { return "You are at the bottom of the eastern pit in the twopit room."; } }
        public string Room8 { get { return "You are crawling over pebbles in a low passage. There is a dim light at the east end of the passage."; } }
        public string Room80 { get { return "You are at the west end of the twopit room. There is a large hole in the wall above the pit at this end of the room."; } }
        public string Room81 { get { return "You are at the bottom of the west pit in the twopit room. There is a large hole in the wall about twenty five feet above you."; } }
        public string Room9 { get { return "You are in a room filled with broken shards of ancient egyptian crafts. An awkward corridor leads upward and west."; } }
        public string RubbingNothingHappens { get { return "Rubbing the electric lamp is not particularly rewarding. Anyway, nothing exciting happens."; } }
        public string Sarcophagus { get { return "Sarcophagus >groan<"; } }
        public string SarcophagusDoesntFit { get { return "You can't fit this big sarcophagus through that little passage!"; } }
        public string SarcophagusLongDesc { get { return "There is a sarcophagus here with it's cover tightly closed."; } }
        public string Scepter { get { return "Scepter"; } }
        public string SerpentBlocks { get { return "You can't get by the serpent."; } }
        public string SerpentEatenBird { get { return "The serpent has now devoured your bird statue."; } }
        public string SerpentHasNothingToEat { get { return "There is nothing here it wants to eat - except perhaps you."; } }
        public string ShinyBrassLamp { get { return "There is a shiny brass lamp nearby."; } }
        public string Silver { get { return "Silver bars"; } }
        public string SilverLongDesc { get { return "There are bars of silver here!"; } }
        public string SmallVelvetPillow { get { return "A small velvet pillow lies on the floor."; } }
        public string StatueBox { get { return "Statue box"; } }
        public string StatueComesToLife { get { return "As you approach the statue, it comes to life and flies across the chamber where it lands and returns to stone."; } }
        public string StatueInBox { get { return "Bird statue in box."; } }
        public string StatueOfBirdGod { get { return "A statue of the bird god is sitting here."; } }
        public string StoneVeryStrong { get { return "The stone is very strong and is impervious to attack."; } }
        public string ThreeFootScepter { get { return "A three foot scepter with an ankh on an end lies nearby."; } }
        public string TryToReincarnate { get { return "Do you want me to try to reincarnate you?"; } }
        public string UnsureHowYouAreFacing { get { return "I am unsure how you are facing. Use compass points."; } }
        public string UseCompassPoints { get { return "I don't know in from out here. Use compass points."; } }
        public string Vase { get { return "Vase"; } }
        public string VaseDropsWithCrash { get { return "The vase drops with a delicate crash."; } }
        public string VaseHurledToGround { get { return "You have taken the vase and hurled it delicately to the ground."; } }
        public string VasePillowLongDesc { get { return "The vase is now resting, delicately, on a velvet pillow."; } }
        public string VaseRestingOnPillow { get { return "The vase is now resting, delicately, on a velvet pillow."; } }
        public string VaseSoloLongDesc { get { return "There is a delicate, precious, vase here!"; } }
        public string VendingMachine { get { return "There is a massive vending machine here. The instructions on it read- \"Drop coins here to receive fresh batteries\"."; } }
        public string VerbWhat { get { return "{0} what?"; } }
        public string Water { get { return "Water in the bottle"; } }
        public string WaterLongDesc { get { return "There is water in the bottle."; } }
        public string Welcome { get { return "Welcome to pyramid!!"; } }
        public string What { get { return "What?"; } }
        public string WhatDoYouWantToDoWith { get { return "What do you want me to do with the {0} ?"; } }
        public string WhereDidIPutMyOrangeSmoke { get { return "Okay, Now where did I put my orange smoke?... >Poof!< Everything disappears in  a dense cloud of orange smoke."; } }
        public string YouAreHolding { get { return "You are currently holding the following:"; } }
        public string YouHaveScored { get { return "You have scored {0: 0000;-0000} out of a possible 0220, using {1:0000} turns."; } }
    }
}
