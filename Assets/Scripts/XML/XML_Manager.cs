
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public static class XML_Manager
{
    static public Lista_Dzwiekow_XML Wczytaj_Liste_Dzwiekow()
    {
        if(File.Exists(Application.dataPath + "/Dzwieki/Lista_Dzwiekow_XML.xml"))
        {
            Debug_me.ins.LogT(7, "Znaleziono Plik Liste Dzwiekow XML");
            Lista_Dzwiekow_XML lista_dzwiekow;

            XmlSerializer serializer = new XmlSerializer(typeof(Lista_Dzwiekow_XML));
            FileStream stream = new FileStream(Application.dataPath + "/Dzwieki/Lista_Dzwiekow_XML.xml", FileMode.OpenOrCreate);

            lista_dzwiekow = serializer.Deserialize(stream) as Lista_Dzwiekow_XML;
            stream.Close();

            return lista_dzwiekow;
        }
        else
        {
            Debug_me.ins.LogT(7, "Nie Znaleziono Plik Liste Dzwiekow XML");
            Lista_Dzwiekow_XML lista_dzwiekow;
            lista_dzwiekow = new Lista_Dzwiekow_XML();
            lista_dzwiekow.lista_dzwiekow_XML = new List<Dzwiek_XML>();

            XmlSerializer serializer = new XmlSerializer(typeof(Lista_Dzwiekow_XML));
            FileStream stream = new FileStream(Application.dataPath + "/Dzwieki/Lista_Dzwiekow_XML.xml", FileMode.Create);
            serializer.Serialize(stream, lista_dzwiekow);
            stream.Close();

            return lista_dzwiekow;
        }

    }
    public static void Zapisz_Liste_Dzwiekow(Lista_Dzwiekow_XML lista_dzwiekow)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Lista_Dzwiekow_XML));
        FileStream stream = new FileStream(Application.dataPath + "/Dzwieki/Lista_Dzwiekow_XML.xml", FileMode.Create);
        serializer.Serialize(stream, lista_dzwiekow);
        stream.Close();
    }

    public static Lista_Presetow_XML Wczytaj_Liste_Presetow()
    {
        if(File.Exists(Application.dataPath + "/Dzwieki/Lista_Presetow_XML.xml"))
        {
            Debug_me.ins.LogT(7, "Znaleziono Plik Liste Presetow XML");
            Lista_Presetow_XML lista_presetow;

            XmlSerializer serializer = new XmlSerializer(typeof(Lista_Presetow_XML));
            FileStream stream = new FileStream(Application.dataPath + "/Dzwieki/Lista_Presetow_XML.xml", FileMode.OpenOrCreate);

            lista_presetow = serializer.Deserialize(stream) as Lista_Presetow_XML;
            stream.Close();

            return lista_presetow;
        }
        else
        {
            Debug_me.ins.LogT(7, "Nie Znaleziono Plik Liste Presetow XML");
            Lista_Presetow_XML lista_presetow;
            lista_presetow = new Lista_Presetow_XML();
            lista_presetow.lista_presetow = new List<Preset_XML>();

            XmlSerializer serializer = new XmlSerializer(typeof(Lista_Presetow_XML));
            FileStream stream = new FileStream(Application.dataPath + "/Dzwieki/Lista_Presetow_XML.xml", FileMode.Create);
            serializer.Serialize(stream, lista_presetow);
            stream.Close();

            return lista_presetow;
        }
    }
    public static void Zapisz_Liste_Presetow(Lista_Presetow_XML lista_presetow)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Lista_Presetow_XML));
        FileStream stream = new FileStream(Application.dataPath + "/Dzwieki/Lista_Presetow_XML.xml", FileMode.Create);
        serializer.Serialize(stream, lista_presetow);
        stream.Close();
    }
}
