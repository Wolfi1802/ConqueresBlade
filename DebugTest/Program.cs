
using DebugTest;
using System.Diagnostics;
using System.Text.Json;

List<Unit> units = new();
HttpClient client = new();

try
{
    List<string> names = new() {
        "feathered_crossbowmen.html",
        "wuwei_mansion_guard.html",
        "xuanjia_heavy_cavalry.html",
        "cataphract_lancers.html",
"chevaliers.html",
"falconetti_gunners.html",
"fire_lance_cavalry.html",
"hashashins.html",
"houndsmen.html",
"iron_reapers.html",
"kheshigs.html",
"liaos_rangers.html",
"modao_battalion.html",
"monastic_knights.html",
"orochi_samurai.html",
"pavise_crossbowmen.html",
"queens_knights.html",
"rattan_rangers.html",
"retiarii.html",
"shenji_grenadiers.html",
"shield_maidens.html",
"silahdars.html",
"siphonarioi.html",
"tercio_arquebusiers.html",
"varangian_guards.html",
"winged_hussars.html",
"yanyuedao_cavalry.html",
"zweihanders.html",
"armiger_lancers.html",
"axe_raiders.html",
"azaps.html",
"banner_guards.html",
"berserkers.html",
"camel_lancers.html",
"claymores.html",
"crescent_monks.html",
"daggeraxe_lancers.html",
"fortebraccio_pikemen.html",
"greyhair_garrison.html",
"halberdier_sergeants.html",
"huskarls.html",
"imperial_archers.html",
"imperial_arquebusiers.html",
"imperial_javelineers.html",
"imperial_pike_guards.html",
"imperial_spear_guards.html",
"javelin_sergeants.html",
"khevtuul_cavalry.html",
"kriegsbruders.html",
"kriegsrat_fusiliers.html",
"matchlock_ashigaru.html",
"menatarms.html",
"myrmillones.html",
"onnamusha.html",
"palace_guards.html",
"percevals_royal_guard.html",
"prefecture_heavy_cavalry.html",
"sipahis.html",
"spear_sergeants.html",
"symmachean_paladins.html",
"symmachean_stalwarts.html",
"tseregs.html",
"vassal_longbowmen.html",
"yeomen.html",
"alchemists.html",
"bagpipers.html",
"caradocs_cavalry.html",
"condottieri_guards.html",
"cudgel_monks.html",
"demesne_arbalists.html",
"demesne_arquebusiers.html",
"dimachaeri.html",
"halberdiers.html",
"incendiary_archers.html",
"ironcap_spearmen.html",
"jangjus.html",
"janissaries.html",
"khorchins.html",
"landsknechts.html",
"mace_sergeants.html",
"namkhan_archers.html",
"outriders.html",
"prefecture_archers.html",
"prefecture_guards.html",
"prefecture_pikeman.html",
"rattan_marksmen.html",
"rattan_vipers.html",
"ronin.html",
"schutzdieners.html",
"selemchid_cavalry.html",
"sons_of_fenrir.html",
"squires.html",
"vanguard_archers.html",
"wuxing_pikemen.html",
"zykalian_militia.html",
"coutiliers.html",
"demesne_archers.html",
"demesne_crossbowmen.html",
"demesne_javelineers.html",
"demesne_spearmen.html",
"ironcap_archers.html",
"ironcap_arquebusiers.html",
"ironcap_bowriders.html",
"ironcap_scout_cavalry.html",
"ironcap_swordsmen.html",
"javelin_militia.html",
"pike_militia.html",
"rattan_pikemen.html",
"rattan_roundshields.html",
"archer_militia.html",
"demesne_pikeman.html",
"levy_bowmen.html",
"spear_militia.html",
"sword_militia.html",
"serfs.html",
"tenant_farmers.html",
"village_watchmen.html",
"woodcutters.html",
"feathered_crossbowmen.html",
"wuwei_mansion_guard.html",
"xuanjia_heavy_cavalry.html"
    };
    foreach (string name in names)
    {
        try
        {

            var result = await client.GetAsync($"https://www.conquerorsbladehub.com/units/{name}").Result.Content.ReadAsStringAsync();

            var indexx = result.IndexOf(@"<h2>Unit Details</h2>");
            var sub = result.Substring(indexx);

            var indexx2 = sub.IndexOf(@"<h3>Unit Kit Crafting</h3>");
            var datas = sub.Remove(indexx2);

            Unit unit = new();
            unit.Name = name.Replace(".html", "");
            var datasSplited = datas.Split(">");

            string lastNode = "";
            int index2 = 0;
            bool allowAdd = false;

            bool effect = false;
            bool path1 = false;
            bool path2 = false;
            bool path3 = false;
            bool path4 = false;

            foreach (string data in datasSplited)
            {
                int index = data.IndexOf("<");
                if (index >= 1)
                {
                    var splited = data.Remove(index);
                    if (!string.IsNullOrWhiteSpace(splited) && !string.IsNullOrEmpty(splited))
                    {
                        if (effect)
                            unit.TerrainEffects.Add(splited.Trim());
                        if (path1)
                        {
                            if (lastNode.Contains(":"))
                                unit.Path1.Add((lastNode, splited.Trim()));
                        }
                        if (path2)
                        {
                            if (lastNode.Contains(":"))
                                unit.Path2.Add((lastNode, splited.Trim()));
                        }
                        if (path3)
                        {
                            if (lastNode.Contains(":"))
                                unit.Path3.Add((lastNode, splited.Trim()));
                        }
                        if (path4)
                        {
                            if (lastNode.Contains(":"))
                                unit.Path4.Add((lastNode, splited.Trim()));
                        }

                        switch (lastNode)
                        {
                            case "Acquisition:": unit.Acquisition = splited.Trim(); break;
                            case "Type:": unit.Type = splited.Trim(); break;
                            case "Era:": unit.Era = splited.Trim(); break;
                            case "Health": unit.Health = splited.Trim(); break;
                            case "Strength (Units)": unit.Strength = splited.Trim(); break;
                            case "Leadership": unit.Leadership = splited.Trim(); break;
                            case "Speed": unit.Speed = splited.Trim(); break;
                            case "Range": unit.Range = splited.Trim(); break;
                            case "Ammo": unit.Ammo = splited.Trim(); break;
                            case "Labour": unit.Labour = splited.Trim(); break;
                            case "Max Level": unit.MaxLevel = splited.Trim(); break;
                            case "Piercing AP": unit.PiercingAP = splited.Trim(); break;
                            case "Piercing DMG": unit.PiercingDMG = splited.Trim(); break;
                            case "Piercing DEF": unit.PiercingDEF = splited.Trim(); break;
                            case "Slashing AP": unit.SlashingAP = splited.Trim(); break;
                            case "Slashing DMG": unit.SlashingDMG = splited.Trim(); break;
                            case "Slashing DEF": unit.SlashingDEF = splited.Trim(); break;
                            case "Blunt AP": unit.BluntAP = splited.Trim(); break;
                            case "Blunt DMG": unit.BluntDMG = splited.Trim(); break;
                            case "Blunt DEF": unit.BluntDEF = splited.Trim(); break;
                            case "TerrainEffects": effect = true; break;
                            case "Path 1": path1 = true; effect = false; break;
                            case "Path 2": path2 = true; path1 = false; break;
                            case "Path 3": path3 = true; path2 = false; break;
                            case "Path 4": path4 = true; path3 = false; break;
                        }

                        lastNode = splited.Trim();
                    }
                }

            }
            string json = JsonSerializer.Serialize(unit);
            File.WriteAllText($@"C:\CB\{unit.Name}.json", json);
            units.Add(unit);
            Console.WriteLine($"{unit.Name} - {units.Count}/{names.Count} DONE");
            Task.Delay(300).Wait();
            /*
Ausnahme ausgelöst: "System.ArgumentOutOfRangeException" in System.Private.CoreLib.dll
error bei [matchlock_ashigaru.html]
StartIndex cannot be less than zero. (Parameter 'startIndex')

Ausnahme ausgelöst: "System.ArgumentOutOfRangeException" in System.Private.CoreLib.dll
error bei [mace_sergeants.html]
StartIndex cannot be less than zero. (Parameter 'startIndex')

Ausnahme ausgelöst: "System.ArgumentOutOfRangeException" in System.Private.CoreLib.dll
error bei [archer_militia.html]
StartIndex cannot be less than zero. (Parameter 'startIndex')

Ausnahme ausgelöst: "System.ArgumentOutOfRangeException" in System.Private.CoreLib.dll
error bei [serfs.html]
StartIndex cannot be less than zero. (Parameter 'startIndex')

Ausnahme ausgelöst: "System.ArgumentOutOfRangeException" in System.Private.CoreLib.dll
error bei [tenant_farmers.html]
StartIndex cannot be less than zero. (Parameter 'startIndex')

Ausnahme ausgelöst: "System.ArgumentOutOfRangeException" in System.Private.CoreLib.dll
error bei [village_watchmen.html]
StartIndex cannot be less than zero. (Parameter 'startIndex')

Ausnahme ausgelöst: "System.ArgumentOutOfRangeException" in System.Private.CoreLib.dll
error bei [woodcutters.html]
StartIndex cannot be less than zero. (Parameter 'startIndex')
             */
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"error bei [{name}]\n\n{ex.Message}\n{ex.InnerException}");
        }
    }

    string json2= JsonSerializer.Serialize(units);
    File.WriteAllText($@"C:\CB\allUnits.json", json2);
}
catch (Exception ex)
{
}
