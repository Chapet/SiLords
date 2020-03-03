using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PopupSystem : MonoBehaviour
{
    public Text textBoxPopupMsg;
    public GameObject popPanel;
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
                textBoxPopupMsg.text = "    Vos éclaireurs reportent des apparitions de bandits dans votre fief, souhaitez-vous " +
                    "envoyer certains de vos hommes pour les empêchez de piller librement (1 unités occupée jusqu'à la prochaine " +
                    "saison?\n   Si vous ne les arrêtez pas, il prendront la moitié de votre or ou certaines de vos ressources.";
                break;
            case Popup.PopDiscontent:
                textBoxPopupMsg.text = "Votre population est mécontente de la manière dont vous dirigez votre fief, souhaitez-vous " +
                    "leur donner de la nourriture pour les apaiser (-1 grain)?\n  Si vous ne les apaisez pas, vous ne recevrez que la moitié " +
                    "de votre quantité normale d'or pendant le reste de la saison";
                break;
            case Popup.PopSendKid:
                textBoxPopupMsg.text = "Un de vos enfants a atteint l'âge de 7 ans, il peut être envoyé chez un autre Seigneur " +
                    "afin de forger des liens plus forts entre vos deux familles.\n   Souhaitez-vous l'envoyer chez un seigneur " +
                    "de votre choix? Si il accepte, votre disposition avec ce seigneur augmentera de 5. Mais si il refuse, " +
                    "elle baissera de 10";
                break;
            case Popup.PopMerchant:
                textBoxPopupMsg.text = "Un marchant itinérant est passé par votre fief et vous propose d'acheter la ressouce " +
                    "que vous possédez en plus petite quantité contre 75 pièces d'or.\n   Souhaitez-vous accepter?";
                break;
            case Popup.PopHunt:
                textBoxPopupMsg.text = "Vous êtes parti chasser dans une forêt de votre fief et vous avez abbatu un bel animal." +
                    "\n   Souhaitez-vous le manger et donc économiser en nourriture (+1 grain) ou l'exposer dans votre hall " +
                    "principal (+1 réputation)?";
                break;
            case Popup.PopBountyString:
                textBoxPopupMsg.text = "Le printemps est particulièrement bon pour les récoltes cette année, les stocks se portent " +
                    "bien (+1 grain).";
                break;
            case Popup.PopFlood:
                textBoxPopupMsg.text = "La pluie s'abbat sans cesse sur le pays: les rivières sortent de leur lit et les lacs " +
                    "débordent.\n   Souhaitez-vous faire construire un barage (-1 pierre) pour sauvez les champs qui peuvent encore l'être? " +
                    "Si un barrage n'est pas construit, vous devrez nourrir vos gens (-2 grain)";
                break;
            case Popup.PopBountySummer:
                textBoxPopupMsg.text = "L'été est particulièrement bon pour les récoltes cette année, les stocks se portent " +
                    "bien (+1 grain).";
                break;
            case Popup.PopForestFire:
                textBoxPopupMsg.text = "L'été est torride, la végétation flétrit et il suffirait d'un feu de camp non surveillé " +
                    "pour réduire en cendre une partie de vos fôrets.\n    Souhaitez-vous envoyez certains de vos hommes pour qu'il " +
                    "patrouilles les forêts de votre fief (1 unité occupé jusqu'à la fin de l'été)? Si vous n'envoyez pas d'hommes, " +
                    "certaines  de vos forêt brulera sûrement (-2 bois).";
                break;
            case Popup.PopBountyFall:
                textBoxPopupMsg.text = "L'automne est particulièrement bon pour les récoltes cette année, les stocks se portent " +
                    "bien (+1 grain).";
                break;
            case Popup.PopDisease:
                textBoxPopupMsg.text = "L'automne est particulièrement frais et humide, une grippe particulièrement forte circule dans " +
                    "le pays.\n    Souhaitez-vous distribuez du bois (-1 bois) à vos gens pour qu'il se chauffe mieux? Si vous refusez, " +
                    "vous perdrez de la popularité auprès de vos gens (-1 réputation)";
                break;
            case Popup.PopHarshWinter:
                textBoxPopupMsg.text = "L'hiver est particulièrement rude cette année: le vent souffle, la neige tombe à gros " +
                    "flocons, et le froid est mordant.\n    Souhaitez-vous distribuer du bois et de la nourriture à vos gens " +
                    "pour leur facilitez l'hiver (-1 grain, -1 bois) ? Si vous ne le faites pas, " +
                    "vous ne pourrez pas construire de bâtiments, recruter des troupes pendant le reste de l'hiver";
                break;
        }

        popPanel.SetActive(true);
    }
}
