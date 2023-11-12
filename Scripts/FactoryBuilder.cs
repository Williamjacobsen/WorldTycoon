using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryBuilder
{
    private GameObject BuildMenu;
    //private GameObject PrefabPlaceholder;
    private GameObject PrefabObject;
    private string _name;
    private int cost;
    private float earn;
    private float ethics;

    public FactoryBuilder(string name, int cost, float earn, float ethics)
    {
        this._name = name;
        this.cost = cost;
        this.earn = earn;
        this.ethics = ethics;

        BuildMenu = GameObject.Find("BuildMenu");
        //PrefabPlaceholder = Resources.Load("/Prefabs/FactoryPlaceholder") as GameObject;
    }

    /// <summary>
    ///  FactoryBuilder.FactoryPlaceholder
    ///  <para>Creates factories shown in (GameObject)BuildMenu</para>
    ///  <para>_________________________________________________</para>
    ///  <para>Not implemented due to time limitations</para>
    ///  <para>but it would be a better solution...</para>
    /// </summary>
    public void FactoryPlaceholder()
    {

    }

    /// <summary>
    ///  FactoryBuilder.FactoryObject
    ///  <para>Creates the actual factories in the world</para>
    ///  <para>_________________________________________________</para>
    ///  <para>Not implemented due to time limitations</para>
    ///  <para>but it would be a better solution...</para>
    /// </summary>
    public void FactoryObject()
    {

    }
}