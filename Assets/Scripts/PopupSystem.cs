using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PopupSystem : MonoBehaviour
{
    public Text textBoxPopupMsg;
    public Button acceptButton;
    public Button refuseButton;
    public Button okButton;
    public GameObject popPanel;
    public Player player;
    public enum Popup
    {
        PopBandit, PopDiscontent, PopSendKid, PopMerchant, PopHunt, PopBountyString, PopFlood, PopBountySummer,
        PopForestFire, PopBountyFall, PopDisease, PopHarshWinter
    };


    public void PopMessage(Popup popup) //rend un panel visible au dessus du reste avec message + options
    {
        switch (popup)
        {
            case Popup.PopBandit:
                player.currentEvent = 0;
                textBoxPopupMsg.text = "    Vos éclaireurs reportent des apparitions de bandits dans votre fief, souhaitez-vous " +
                    "envoyer certains de vos hommes pour les empêchez de piller librement (1 unités occupée jusqu'à la prochaine " +
                    "saison?\n   Si vous ne les arrêtez pas, il prendront la moitié de votre or ou certaines de vos ressources.";
                acceptButton.gameObject.SetActive(true);
                refuseButton.gameObject.SetActive(true);
                break;
            case Popup.PopDiscontent:
                player.currentEvent = 1;
                textBoxPopupMsg.text = "Votre population est mécontente de la manière dont vous dirigez votre fief, souhaitez-vous " +
                    "leur donner de la nourriture pour les apaiser (-1 grain)?\n  Si vous ne les apaisez pas, vous ne recevrez que la moitié " +
                    "de votre quantité normale d'or pendant le reste de la saison";
                acceptButton.gameObject.SetActive(true);
                refuseButton.gameObject.SetActive(true);
                break;
            case Popup.PopSendKid:
                player.currentEvent = 2;
                textBoxPopupMsg.text = "Un de vos enfants a atteint l'âge de 7 ans, il peut être envoyé chez un autre Seigneur " +
                    "afin de forger des liens plus forts entre vos deux familles.\n   Souhaitez-vous l'envoyer chez un seigneur " +
                    "de votre choix? Si il accepte, votre disposition avec ce seigneur augmentera de 5. Mais si il refuse, " +
                    "elle baissera de 10";
                acceptButton.gameObject.SetActive(true);
                refuseButton.gameObject.SetActive(true);
                break;
            case Popup.PopMerchant:
                player.currentEvent = 3;
                textBoxPopupMsg.text = "Un marchant itinérant est passé par votre fief et vous propose d'acheter la ressouce " +
                    "que vous possédez en plus petite quantité contre 75 pièces d'or.\n   Souhaitez-vous accepter?";
                acceptButton.gameObject.SetActive(true);
                refuseButton.gameObject.SetActive(true);
                break;
            case Popup.PopHunt:
                player.currentEvent = 4;
                textBoxPopupMsg.text = "Vous êtes parti chasser dans une forêt de votre fief et vous avez abbatu un bel animal." +
                    "\n   Souhaitez-vous l'exposer dans votre hall principal (+1 réputation)? Sinon vous le mangerez (+1 grain)";
                acceptButton.gameObject.SetActive(true);
                refuseButton.gameObject.SetActive(true);
                break;
            case Popup.PopBountyString:
                player.currentEvent = 5;
                textBoxPopupMsg.text = "Le printemps est particulièrement bon pour les récoltes cette année, les stocks se portent " +
                    "bien (+1 grain).";
                okButton.gameObject.SetActive(true);
                break;
            case Popup.PopFlood:
                player.currentEvent = 6;
                textBoxPopupMsg.text = "La pluie s'abbat sans cesse sur le pays: les rivières sortent de leur lit et les lacs " +
                    "débordent.\n   Souhaitez-vous faire construire un barage (-1 pierre) pour sauvez les champs qui peuvent encore l'être? " +
                    "Si un barrage n'est pas construit, vous devrez nourrir vos gens (-2 grain)";
                acceptButton.gameObject.SetActive(true);
                refuseButton.gameObject.SetActive(true);
                break;
            case Popup.PopBountySummer:
                player.currentEvent = 7;
                textBoxPopupMsg.text = "L'été est particulièrement bon pour les récoltes cette année, les stocks se portent " +
                    "bien (+1 grain).";
                okButton.gameObject.SetActive(true);
                break;
            case Popup.PopForestFire:
                player.currentEvent = 8;
                textBoxPopupMsg.text = "L'été est torride, la végétation flétrit et il suffirait d'un feu de camp non surveillé " +
                    "pour réduire en cendre une partie de vos fôrets.\n    Souhaitez-vous envoyez certains de vos hommes pour qu'il " +
                    "patrouilles les forêts de votre fief (1 unité occupé jusqu'à la fin de l'été)? Si vous n'envoyez pas d'hommes, " +
                    "certaines  de vos forêt bruleront sûrement (-2 bois).";
                acceptButton.gameObject.SetActive(true);
                refuseButton.gameObject.SetActive(true);
                break;
            case Popup.PopBountyFall:
                player.currentEvent = 9;
                textBoxPopupMsg.text = "L'automne est particulièrement bon pour les récoltes cette année, les stocks se portent " +
                    "bien (+1 grain).";
                okButton.gameObject.SetActive(true);
                break;
            case Popup.PopDisease:
                player.currentEvent = 10;
                textBoxPopupMsg.text = "L'automne est particulièrement frais et humide, une grippe particulièrement forte circule dans " +
                    "le pays.\n    Souhaitez-vous distribuez du bois (-1 bois) à vos gens pour qu'il se chauffe mieux? Si vous refusez, " +
                    "vous perdrez de la popularité auprès de vos gens (-1 réputation)";
                acceptButton.gameObject.SetActive(true);
                refuseButton.gameObject.SetActive(true);
                break;
            case Popup.PopHarshWinter:
                player.currentEvent = 11;
                textBoxPopupMsg.text = "L'hiver est particulièrement rude cette année: le vent souffle, la neige tombe à gros " +
                    "flocons, et le froid est mordant.\n    Souhaitez-vous distribuer du bois et de la nourriture à vos gens " +
                    "pour leur facilitez l'hiver (-1 grain, -1 bois) ? Si vous ne le faites pas, " +
                    "vous ne pourrez pas construire de bâtiments, recruter des troupes pendant le reste de l'hiver";
                acceptButton.gameObject.SetActive(true);
                refuseButton.gameObject.SetActive(true);
                break;
        }

        popPanel.SetActive(true);
    }

    public void DoOnAccept()
    {
        switch (player.currentEvent)
        {
            case 0: //Bandits
                if (true) //TODO: change to boolean "!hasAvailableUnits"
                {
                    PopMessage(Popup.PopBandit);
                }
                break;
            case 1: //Discontent
                if (player.grain < 1) //0 grain
                {
                    PopMessage(Popup.PopDiscontent);
                }
                player.ChangeGrain(-1);
                break;
            case 2: //SendKid
                Debug.Log("TODO: Sending Kid");
                break;
            case 3: //Merchant
                if (player.wood == 0 && player.stone == 0 && player.grain == 0 && player.iron == 0) // no ressources left
                {
                    player.ChangeGold(25);
                    Debug.Log("TODO: Popup: Le marchand a pitié et donne 25 gold");
                }
                else
                {
                    player.ChangeGold(75);
                    Debug.Log("TODO: le marchand prend d'une ressource");
                }
                break;
            case 4: //Hunt
                player.ChangeReputation(1);
                break;
            case 6: //Flood
                if (player.stone < 1) //0 stone
                {
                    PopMessage(Popup.PopFlood);
                }
                player.ChangeStone(-1);
                break;
            case 8: //ForestFire
                if (true) //TODO: change to boolean "!hasAvailableUnits"
                {
                    PopMessage(Popup.PopForestFire);
                }
                else 
                {
                    Debug.Log("TODO: 1 unit taken");
                }
                break;
            case 10: //Disease
                if (player.wood < 1) //0 wood
                {
                    PopMessage(Popup.PopDisease);
                }
                player.ChangeWood(-1);
                break;
            case 11: //HarshWinter
                if (player.wood < 1 || player.grain < 1) //0 wood or 0 grain
                {
                    PopMessage(Popup.PopHarshWinter);
                }
                else
                {
                    player.ChangeWood(-1);
                    player.ChangeGrain(-1);
                } 
                break;
        }
    }

    public void DoOnRefuse()
    {
        switch (player.currentEvent)
        {
            case 0: //Bandits
                player.ChangeGold(-player.tier*25);
                player.ChangeIron(-1);
                break;
            case 1: //Discontent
                Debug.Log("Rates set to 1/2 for the rest of the season");
                break;
            case 2: //SendKid
                break;
            case 3: //Merchant
                break;
            case 4: //Hunt
                player.ChangeGrain(1);
                break;
            case 6: //Flood
                player.ChangeGrain(-2);
                break;
            case 8: //ForestFire
                player.ChangeWood(-2);
                break;
            case 10: //Disease
                player.ChangeReputation(-1);
                break;
            case 11: //HarshWinter
                Debug.Log("TODO: Cannot buy buildings/troops or attack until the end of winter");
                break;
        }
    }
}
